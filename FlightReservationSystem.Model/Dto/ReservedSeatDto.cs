using FlightReservationSystem.Model.Enum;

namespace FlightReservationSystem.Model.Dto
{
    public class ReservedSeatDto
    {
        public string SeatNumber { get; set; }
        public ReservedStatus ReservedStatus { get; set; }
    }
}
