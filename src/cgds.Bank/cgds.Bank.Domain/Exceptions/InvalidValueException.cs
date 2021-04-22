using System;
using System.Collections.Generic;
using System.Text;

namespace cgds.Bank.Domain.Exceptions
{
    public class InvalidValueException : BankException
    {
        public InvalidValueException(string valueName) : base($"Invalid value for the field '{valueName}'")
        {
        }
    }
}
