using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KSTrips.Domain.Entities
{
    public class User : BaseEntityTrackable
    {

        public DateTime? DateEndSubscription { get; set; }
        public DateTime? DateforPay { get; set; }
        public DateTime? DateInitial { get; set; }
        public DateTime? DateInitSubscription { get; set; }
        public DateTime? DateUse { get; set; }
        public string Email { get; set; }
        public int? NotificationDays { get; set; }
        public int? ParentId { get; set; }
        public string Password { get; set; }
        public virtual SubscriptionType SubscriptionType { get; set; }
        [ForeignKey("SubscriptionType")]
        public int? SubscriptionTypeId { get; set; }

        public virtual Trip Trip { get; set; }
        public string UserName { get; set; }
    }
}
