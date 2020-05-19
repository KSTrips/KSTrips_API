using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KSTrips.Domain.Entities
{
    public class User : BaseEntity
    {

        public string Provider { get; set; }
        public string AuthZeroId { get; set; }
        public string GivenName { get; set; }
        public string FamilyName { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public DateTime? DateInitial { get; set; } 
        public DateTime? DateUse { get; set; }
        public int NotificationDays { get; set; }
        public DateTime? DateInitSubscription { get; set; }
        public DateTime? DateEndSubscription { get; set; }
        public virtual Trip Trip { get; set; }

        [ForeignKey("SubscriptionType")]
        public int? SubscriptionTypeId { get; set; }
        public virtual SubscriptionType SubscriptionType { get; set; }

    }
}
