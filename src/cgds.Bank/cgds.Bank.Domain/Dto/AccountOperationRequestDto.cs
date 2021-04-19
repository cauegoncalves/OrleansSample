using System;
using System.Collections.Generic;
using System.Text;

namespace cgds.Bank.Domain.Dto
{
    public class AccountOperationRequestDto
    {

        public decimal OperationAmount { get; set; }

        public string[] Tags { get; set; }

    }
}
