using System;
using System.Collections.Generic;
using System.Text;

namespace cgds.Bank.Domain.Models
{
    public class OperationHistoryEntry : Operation
    {

        public DateTime Date { get; set; }
        public string Description { get; set; }

    }
}
