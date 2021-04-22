using System;
using System.Collections.Generic;
using System.Text;

namespace cgds.Bank.API.Models
{
    public class AccountOperationRequest
    {

        public decimal OperationAmount { get; set; }

        public string[] Tags { get; set; }

    }
}
