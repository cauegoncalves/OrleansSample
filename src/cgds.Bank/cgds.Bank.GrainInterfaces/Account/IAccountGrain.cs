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

        Task Withdraw(decimal value);
        Task Deposit(decimal value);
        Task<decimal> GetBalance();
        Task<List<AccountOperation>> GetHistory(DateTime startDate, DateTime endDate);

    }
}
