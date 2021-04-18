using cgds.Bank.Domain.Models;
using Orleans;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace cgds.Bank.GrainInterfaces.Account
{
    public interface IAccountGrain : IGrainWithIntegerCompoundKey
    {

        Task Withdraw(decimal amount);
        Task Deposit(decimal amount);
        Task<decimal> GetBalance();
        Task<List<OperationHistoryEntry>> GetHistory(DateTime startDate, DateTime endDate);

    }
}
