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

        public AccountGrain(IPersistentState<AccountState> account, ITime time)
        {
            _account = account;
            _time = time;
        }

        public Task Deposit(decimal amount)
        {
            _account.State.Balance += amount;
            var operation = new OperationHistoryEntry
            {
                Date = _time.Now,
                Amount = amount,
                Description = "Deposit"
            };
            _account.State.History.Add(operation);
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

        public Task Withdraw(decimal amount)
        {
            _account.State.Balance -= amount;
            var operation = new OperationHistoryEntry
            {
                Date = _time.Now,
                Amount = -amount,
                Description = "Withdraw"
            };
            _account.State.History.Add(operation);
            return _account.WriteStateAsync();
        }
    }
}
