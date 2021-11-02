namespace KSTrips.Domain.Transversal.Response
{
    public class VehiclesMaintenance
    {
        public int TripId { get; }
        public string LicensePlate { get; }
        public string Driver { get; }
        public int KilometersTraveled { get; }
        public int NotificationKilometers { get; }
        public bool IsNotification { get; }
    }
}
