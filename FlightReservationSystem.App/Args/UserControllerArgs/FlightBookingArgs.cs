namespace FlightReservationSystem.App.Args.UserControllerArgs
{
    public class FlightBookingArgs
    {
        public Guid FlightId { get; set; }
        public Guid UserId { get; set; }
        public string SeatNumber { get; set; }
    }
}
