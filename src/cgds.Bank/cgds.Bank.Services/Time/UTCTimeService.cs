using System;
using System.Collections.Generic;
using System.Text;

namespace cgds.Bank.Services.Time
{
    public class UTCTimeService : ITime
    {
        public DateTime Now => DateTime.UtcNow;
    }

}
