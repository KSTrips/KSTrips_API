using System;
using System.Collections.Generic;
using System.Text;

namespace KSTrips.Domain.Entities
{
    public class ErrorLog : BaseEntity
    {
        public string Message { get; set; }
        public string Exception { get; set; }
        public string Module { get; set; }

    }
}
