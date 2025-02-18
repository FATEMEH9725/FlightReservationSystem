namespace FlightReservationSystem.App.Args.FlightContrllerArgs
{
    public class FlightArgs
    {
        public Guid OriginCityId { get; set; }
        public Guid DestinationCityId { get; set; }
        public DateTimeOffset DateGone { get; set; }
        public DateTimeOffset PassengerCount { get; set; }
    }
}
