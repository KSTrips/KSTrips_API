using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace KSTrips.Domain.Entities
{
   public class Role : BaseEntityTrackable
    {
        public string Name { get; set; }
    }
}
