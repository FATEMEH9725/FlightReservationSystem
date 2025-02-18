using FlightReservationSystem.App.Args.AccountControllerArgs;
using FlightReservationSystem.Model.Dto;
using FlightReservationSystem.Service.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace FlightReservationSystem.App.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AccountController : ControllerBase
    {
        private readonly IJwtService _jwtService;
        private readonly IComputeHash _computeHash;
        private readonly IFlightReservationSystemDbService _flightReservationSystemDbService;

        public AccountController(IJwtService jwtService, IComputeHash computeHash, IFlightReservationSystemDbService flightReservationSystemDbService)
        {
            _jwtService = jwtService;
            _computeHash = computeHash;
            _flightReservationSystemDbService = flightReservationSystemDbService;
        }

        [HttpPost("login")]
        public async Task<JWTTokenDto> Login(LoginArgs args)
        {
            var password = _computeHash.ComputeSha256Hash(args.Password);
            var user = await _flightReservationSystemDbService.Login(args.MobileNo, password);
            return await _jwtService.Generate(user);
        }
    }

}
