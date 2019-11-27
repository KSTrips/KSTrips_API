﻿using System;

namespace KSTrips.Domain.Entities
{
    public class User
    {
        public int UserId { get; set; }
        public string Provider { get; set; }
        public string AuthZeroId { get; set; }
        public string GivenName { get; set; }
        public string FamilyName { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime? DateInitial { get; set; } 
        public DateTime? DateUse { get; set; }
        public DateTime? DateModified { get; set; }
        public string CreatedBy { get; set; }
        public bool IsActive { get; set; }
        public int NotificationDays { get; set; }

        public DateTime? DateInitSubscription { get; set; }
        public DateTime? DateEndSubscription { get; set; }
        public virtual Trip Trip { get; set; }

    }
}
