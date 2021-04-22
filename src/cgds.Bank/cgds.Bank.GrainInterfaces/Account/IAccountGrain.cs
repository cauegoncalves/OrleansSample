using cgds.Bank.Domain.Models;
using Orleans;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace cgds.Bank.GrainInterfaces.Account
{
    public interface IAccountGrain : IGrainWithIntegerKey
    {

        Task Withdraw(Operation operation);
        Task Deposit(Operation operation);
        Task<decimal> GetBalance();
        Task<List<OperationHistoryEntry>> GetHistory(DateTime startDate, DateTime endDate);

    }
}
