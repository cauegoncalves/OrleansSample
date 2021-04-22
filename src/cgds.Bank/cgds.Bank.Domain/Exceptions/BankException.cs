using System;
using System.Collections.Generic;
using System.Text;

namespace cgds.Bank.Domain.Exceptions
{
    public class BankException : Exception
    {
        public BankException()
        {
        }

        public BankException(string message) : base(message)
        {
        }
    }
}
