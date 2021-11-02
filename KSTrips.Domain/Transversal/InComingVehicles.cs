namespace KSTrips.Domain.Transversal
{
    public class InComingVehicles
    {
        public string Description { get; set; }
        public string Driver { get; set; }
        public string LicensePlate { get; set; }
        public int NotificationKilometers { get; set; }
        public int CarCategoryId { get; set; }
        public string Email { get; set; }
        public bool IsActive { get; set; }
    }
}
