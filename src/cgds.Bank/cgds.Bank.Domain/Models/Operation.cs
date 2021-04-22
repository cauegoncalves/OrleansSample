using System;
using System.Collections.Generic;
using System.Text;

namespace cgds.Bank.Domain.Models
{
    public class Operation
    {
        public decimal Amount { get; set; }
        public string[] Tags { get; set; }
    }
}
