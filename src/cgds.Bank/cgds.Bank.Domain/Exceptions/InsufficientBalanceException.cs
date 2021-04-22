using System;
using System.Collections.Generic;
using System.Text;

namespace cgds.Bank.Domain.Exceptions
{
    public class InsufficientBalanceException : Exception
    {
        public InsufficientBalanceException() : base("Insufficient balance to perform this operation.")
        {
        }
    }
}
