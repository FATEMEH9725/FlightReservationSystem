using FlightReservationSystem.App.Args.FlightContrllerArgs;
using FlightReservationSystem.App.Args.UserControllerArgs;
using FlightReservationSystem.Model.Dto;
using FlightReservationSystem.Service.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Fly.App.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IFlightReservationSystemDbService _flightReservationSystemDbService;

        public UserController(IFlightReservationSystemDbService flightReservationSystemDbService)
        {
            _flightReservationSystemDbService = flightReservationSystemDbService;
        }

        [HttpPost("SaveFlightBooking")]
        public async Task SaveFlightBooking(FlightBookingArgs args)
        {
            await _flightReservationSystemDbService.SaveFlightBooking(args.FlightId, args.UserId, args.SeatNumber);
        }


        [HttpPost("GetUserFlights")]
        public async Task<List<FlightDto>> GetUserFlights(UserFlightsArgs args)
        {
            return await _flightReservationSystemDbService.GetUserFlights(args.UserId);
        }
    }

}
