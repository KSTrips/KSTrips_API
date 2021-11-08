﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace KSTrips.Domain.Entities
{
    public class SubscriptionType : BaseEntityTrackable
    {
        public string Description { get; set; }
        public  int QtyAllowedUsers { get; set; }
    }
}
