using FlightReservationSystem.Model.Dto;

namespace FlightReservationSystem.Service.Contracts
{
    public interface IJwtService
    {
        Task<JWTTokenDto> Generate(UserDto user);
    }
}