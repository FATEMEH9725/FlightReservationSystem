using FlightReservationSystem.Data;
using FlightReservationSystem.Model.Dto;
using FlightReservationSystem.Model.Entity;
using FlightReservationSystem.Service.Contracts;
using Microsoft.EntityFrameworkCore;

namespace FlightReservationSystem.Service.Implementations
{
    public class FlightReservationSystemDbService : IFlightReservationSystemDbService
    {
        private readonly FlightReservationSystemDbContext Db;

        public FlightReservationSystemDbService(FlightReservationSystemDbContext context)
        {
            Db = context;
        }


        public async Task<UserDto> Login(string mobileNo, string password)
        {
            var user = await Db.Set<User>()
                               .Where(u => u.MobileNumber == mobileNo
                                && u.Password == password
                                && u.IsActive == true)
                               .Select(i => new UserDto
                               {
                                   Id = i.Id,
                                   RoleType = i.RoleType
                               }).FirstOrDefaultAsync();

            if (user == null)
            {
                throw new Exception("کاربری با این مشخصات وجود ندارد");
            }

            return user;
        }


        public async Task<List<FlightDto>> GetFlights()
        {
            var flights = await Db.Set<Flight>()
                                   .Where(i => i.IsActive == true)
                                   .Select(u => new FlightDto
                                   {
                                       Id = u.Id,
                                       FlightNumber = u.FlightNumber,
                                       AirlineName = u.AirlineAgency.Title,
                                       AircraftModel = u.AircraftModel,
                                       ArrivalTime = u.ArrivalTime,
                                       CabinClassType = u.CabinClassType,
                                       CargoAllowance = u.CargoAllowance,
                                       DepartureTime = u.DepartureTime,
                                       Destination = u.DestinationCity.Title,
                                       SeatsCount = u.SeatsCount,
                                       FlightType = u.FlightType,
                                       Origin = u.OriginCity.Title,
                                       Price = u.Price,
                                       TerminalType = u.TerminalType
                                   })
                                   .ToListAsync();


            return flights;
        }

        public async Task SaveFlightBooking(Guid flightId, Guid userId, string seatNumber)
        {
            var flightBooking = new TicketsBooked
            {
                Flight_Id = flightId,
                User_Id = userId,
                SeatNumber = seatNumber,
                CreateDateTime = DateTimeOffset.Now,
                IsActive = true
            };

            await Db.Set<TicketsBooked>().AddAsync(flightBooking);
            await Db.SaveChangesAsync();
        }

        public async Task<List<FlightDto>> GetUserFlights(Guid userId)
        {
            var ticketsBooked = await Db.Set<TicketsBooked>()
                                   .Where(i => i.User_Id == userId
                                   && i.IsActive == true)
                                   .Select(u => new FlightDto
                                   {
                                       Id = u.Id,
                                       FlightNumber = u.Flight.FlightNumber,
                                       AirlineName = u.Flight.AirlineAgency.Title,
                                       AircraftModel = u.Flight.AircraftModel,
                                       ArrivalTime = u.Flight.ArrivalTime,
                                       CabinClassType = u.Flight.CabinClassType,
                                       CargoAllowance = u.Flight.CargoAllowance,
                                       DepartureTime = u.Flight.DepartureTime,
                                       Destination = u.Flight.DestinationCity.Title,
                                       SeatsCount = u.Flight.SeatsCount,
                                       FlightType = u.Flight.FlightType,
                                       Origin = u.Flight.OriginCity.Title,
                                       Price = u.Flight.Price,
                                       TerminalType = u.Flight.TerminalType
                                   })
                                   .ToListAsync();

            return ticketsBooked;
        }

        public async Task<List<ReservedSeatDto>> GetReservedSeat(Guid id)
        {
            var reservedSeats = Db.Set<TicketsBooked>()
                .Where(t => t.Flight_Id == id && t.IsActive == true)
                .Select(s => s.SeatNumber)
                .ToList();

            var flightSeats = Db.Set<Flight>()
                .Where(f => f.Id == id)
                .Select(s => s.SeatsCount)
                .FirstOrDefault();

            var seatsStatus = new List<ReservedSeatDto>();

            int notBooked = 0;
            int maxNotBooked = 0;

            int start = 0;
            int startNotBooked = 0;
            int EndNotBooked = 0;

            for (var i = 1; i <= flightSeats; i++)
            {
                if (reservedSeats.Contains(i.ToString()))
                {
                    notBooked = 0;

                    seatsStatus.Add(new ReservedSeatDto
                    {
                        SeatNumber = i.ToString(),
                        ReservedStatus = Model.Enum.ReservedStatus.Reserved
                    });
                }
                else
                {
                    if (notBooked == 0)
                    {
                        start = i;
                    }

                    notBooked++;
                    
                    if (notBooked > maxNotBooked)
                    {
                        maxNotBooked = notBooked;
                        startNotBooked = start;
                        EndNotBooked = i;
                    }

                    seatsStatus.Add(new ReservedSeatDto
                    {
                        SeatNumber= i.ToString(),
                        ReservedStatus= Model.Enum.ReservedStatus.NotReserved
                    });
                }
            }

            return seatsStatus;
        }

        public async Task<MaxNotBookedSeatDto> GetMaxNotBookedSeat(Guid id)
        {
            var reservedSeats = Db.Set<TicketsBooked>()
                .Where(t => t.Flight_Id == id && t.IsActive == true)
                .Select(s => s.SeatNumber)
                .ToList();

            var flightSeats = Db.Set<Flight>()
                .Where(f => f.Id == id)
                .Select(s => s.SeatsCount)
                .FirstOrDefault();

            int notBooked = 0;
            int maxNotBooked = 0;

            int start = 0;
            int startNotBooked = 0;
            int EndNotBooked = 0;

            for (var i = 1; i <= flightSeats; i++)
            {
                if (reservedSeats.Contains(i.ToString()))
                {
                    notBooked = 0;
                }
                else
                {
                    if (notBooked == 0)
                    {
                        start = i;
                    }

                    notBooked++;

                    if (notBooked > maxNotBooked)
                    {
                        maxNotBooked = notBooked;
                        startNotBooked = start;
                        EndNotBooked = i;
                    }
                }
            }

            return new MaxNotBookedSeatDto
            {
                MaxNotBooked = maxNotBooked,
                StartNotBooked = startNotBooked,
                EndNotBooked = EndNotBooked
            };
        }
    }
}
