using FlightReservationSystem.Model.Dto;
using FlightReservationSystem.Service.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Fly.App.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FlightController : ControllerBase
    {
        private readonly IFlightReservationSystemDbService _flightReservationSystemDbService;

        public FlightController(IFlightReservationSystemDbService flightReservationSystemDbService)
        {
            _flightReservationSystemDbService = flightReservationSystemDbService;
        }


        [HttpGet("GetFlights")]
        public async Task<List<FlightDto>> GetFlights()
        {
            return await _flightReservationSystemDbService.GetFlights();
        }
    }

}
