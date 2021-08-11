using cgds.Bank.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace cgds.Bank.GrainInterfaces.Account
{

    public class AccountState
    {

        public decimal Balance { get; set; }
        public IList<OperationHistoryEntry> History { get; set; } = new List<OperationHistoryEntry>();

    }

}