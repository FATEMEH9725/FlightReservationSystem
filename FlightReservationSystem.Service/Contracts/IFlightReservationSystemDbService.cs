using FlightReservationSystem.Model.Dto;
namespace FlightReservationSystem.Service.Contracts
{
    public interface IFlightReservationSystemDbService
    {
        Task<UserDto> Login(string mobileNo, string password);

        Task<List<FlightDto>> GetFlights();
        Task<List<FlightDto>> GetUserFlights(Guid userId);
        Task SaveFlightBooking(Guid flightId, Guid userId, string seatNumber);
        Task<List<ReservedSeatDto>> GetReservedSeat(Guid id);
        Task<MaxNotBookedSeatDto> GetMaxNotBookedSeat(Guid id);
    }
}
