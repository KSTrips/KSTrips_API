using System;
using System.Collections.Generic;
using System.Text;

namespace KSTrips.Domain.Entities
{
    public class ErrorLog : BaseEntityTrackable
    {
        public string Exception { get; set; }
        public string Message { get; set; }
        public string Module { get; set; }

    }
}
