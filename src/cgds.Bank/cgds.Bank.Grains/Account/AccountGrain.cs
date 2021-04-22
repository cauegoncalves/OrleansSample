using cgds.Bank.Domain.Exceptions;
using cgds.Bank.Domain.Models;
using cgds.Bank.GrainInterfaces.Account;
using cgds.Bank.Services.Time;
using Orleans;
using Orleans.Runtime;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cgds.Bank.Grains.Account
{
    public class AccountGrain : Grain, IAccountGrain
    {

        private readonly IPersistentState<AccountState> _account;
        private readonly ITime _time;

        public AccountGrain([PersistentState("Account", "AccountStorage")]IPersistentState<AccountState> account, ITime time)
        {
            _account = account;
            _time = time;
        }

        public Task Deposit(Operation operation)
        {
            if (operation.Amount <= 0)
                throw new InvalidValueException(nameof(operation.Amount));

            _account.State.Balance += operation.Amount;
            var operationHistory = new OperationHistoryEntry
            {
                Date = _time.Now,
                Amount = operation.Amount,
                Description = "Deposit",
                Tags = operation.Tags
            };
            _account.State.History.Add(operationHistory);
            return _account.WriteStateAsync();
        }

        public Task<decimal> GetBalance()
        {
            return Task.FromResult(_account.State.Balance);
        }

        public Task<List<OperationHistoryEntry>> GetHistory(DateTime startDate, DateTime endDate)
        {
            var filteredHistory = _account.State
                .History
                .Where(h => h.Date >= startDate && h.Date <= endDate)
                .ToList();
            return Task.FromResult(filteredHistory);
        }

        public Task Withdraw(Operation operation)
        {
            if (operation.Amount <= 0)
                throw new InvalidValueException(nameof(operation.Amount));

            if (_account.State.Balance < operation.Amount)
                throw new InsufficientBalanceException();

            _account.State.Balance -= operation.Amount;
            var operationHistory = new OperationHistoryEntry
            {
                Date = _time.Now,
                Amount = -(operation.Amount),
                Description = "Withdraw",
                Tags = operation.Tags
            };
            _account.State.History.Add(operationHistory);
            return _account.WriteStateAsync();
        }
    }
}
