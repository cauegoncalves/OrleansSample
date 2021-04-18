using System;
using System.Collections.Generic;
using System.Text;

namespace cgds.Bank.Domain.Dto
{
    public class AccountOperationDto
    {

        public int AgencyNumber { get; set; }
        public string AccountNumber { get; set; }
        public decimal OperationAmount { get; set; }

    }
}
