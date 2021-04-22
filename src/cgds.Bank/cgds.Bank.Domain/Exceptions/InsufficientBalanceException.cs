using System;
using System.Collections.Generic;
using System.Text;

namespace cgds.Bank.Domain.Exceptions
{
    public class InsufficientBalanceException : BankException
    {
        public InsufficientBalanceException() : base("Insufficient balance to perform this operation.")
        {
        }
    }
}
