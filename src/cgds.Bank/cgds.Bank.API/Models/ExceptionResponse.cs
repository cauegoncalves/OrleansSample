using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace cgds.Bank.API.Models
{
    public class ExceptionResponse
    {
        public int StatusCode { get; set; }
        public string Message { get; set; }
    }
}
