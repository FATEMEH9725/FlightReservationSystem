using FlightReservationSystem.Model.Entity;
using FlightReservationSystem.Model.Enum;
using Microsoft.EntityFrameworkCore;

namespace FlightReservationSystem.Data
{
    public static class DataConstants
    {
        public static class Prices
        {
            public static readonly decimal MinPrice = 1800000M;
            public static readonly decimal MaxPrice = 3200000M;
        }
    }

    public static class DataGeneratorHelpers
    {
        private static Random _random = new Random();

        public static DateTimeOffset RandomDate(int minDays, int maxDays) =>
            DateTimeOffset.UtcNow.AddDays(_random.Next(minDays, maxDays));

        public static decimal RandomPrice() =>
            DataConstants.Prices.MinPrice +
            (_random.Next(0, 15) * 100000M);

        public static string RandomMobile() =>
            $"0912{_random.Next(1000000, 9999999)}";

        public static string RandomNationalCode() =>
            $"1{_random.Next(100000000, 999999999)}";

    }

    public static class MasterDataPredefined
    {
        public static List<City> GetCities()
        {
            var cities = new List<City>()
            {
                new City{ Title = "تهران", IsActive = true },
                new City{ Title = "تبریز", IsActive = true },
                new City{ Title = "اصفهان", IsActive = true },
                new City{ Title = "شیراز", IsActive = true },
                new City{ Title = "کیش", IsActive = true },
            };
            return cities;  
        }

        public static List<AirlineAgency> GetAirLineAgency()
        {
            var cities = new List<AirlineAgency>()
            {
                new AirlineAgency{ Title = "MahanAir", AirLineCode = "MA", IsActive = true },
                new AirlineAgency{ Title = "Iran Air",  AirLineCode = "IA", IsActive = true },
                new AirlineAgency{ Title = "Aseman Air",  AirLineCode = "AA", IsActive = true },
                new AirlineAgency{ Title = "Ava Air",  AirLineCode = "AV", IsActive = true },
                new AirlineAgency{ Title = "SaHa",  AirLineCode = "SH", IsActive = true },
            };
            return cities;
        }
    }
    public static class UserPredefinedData
    {
        private static readonly (string firstName, string lastName)[] _names = {
            ("فاطمه", "حسینی"),
            ("سارا", "عبدلی"),
            ("امین", "خانی"),
            ("علی", "سیفی"),
            ("مجید", "سلامی")
        };

        public static List<User> GetUsers() =>
            _names.Select((name, index) => new User(true)
            {
                FirstName = name.firstName,
                LastName = name.lastName,
                UserName = $"{name.firstName}-{name.lastName}",
                MobileNumber = DataGeneratorHelpers.RandomMobile(),
                Password = $"8d969eef6ecad3c29a3a629280e686cf0c3f5d5a86aff3ca12020c923adc6c92",
                NationalCode = DataGeneratorHelpers.RandomNationalCode(),
                EmailAddress = $"{name.firstName}{name.lastName}@gmail.com".ToLower(),
                BirthDate = DataGeneratorHelpers.RandomDate(-12000, -8000),
                IsActive = true,
                CreateDateTime = DateTimeOffset.UtcNow
            }).ToList();
    }

    public static class FlightPredefinedData
    {
        public static List<Flight> GetFlights(List<AirlineAgency> airLineAgency, List<City> cities)
        {
            var flights = new List<Flight>();
            Random random = new Random();
            int randomDays = random.Next(1, 31);

            for (int i = 0; i < 5; i++)
            {
                var departureTime = DateTimeOffset.Now.AddDays(randomDays);

                flights.Add(new Flight(true)
                {
                    FlightNumber = "MA-002",
                    AirlineAgency_Id = airLineAgency[i].Id,
                    OriginCity_Id = cities[i].Id,
                    DestinationCity_Id = cities[i].Id,
                    DepartureTime = departureTime,
                    ArrivalTime = departureTime.AddHours(3),
                    SeatsCount = 100,
                    Price = DataGeneratorHelpers.RandomPrice(),
                    CabinClassType = CabinClassType.Economy,
                    FlightType = FlightType.Systemic,
                    CreateDateTime = DateTimeOffset.Now,
                    AircraftModel = "",
                    CargoAllowance = 30,
                    TerminalType = TerminalType.MehrAbad,
                    IsActive = true,
                });
            }

            return flights;
        }
    }

    public static class FlightBookPredefinedData
    {
        public static List<TicketsBooked> GetUserFlights(List<User> users, List<Flight> flights)
        {
            Random random = new Random();
            int randomSeat = random.Next(1, 100);

            return Enumerable.Range(0, 5).Select(i => new TicketsBooked(true)
            {
                Flight_Id = flights[i].Id,
                User_Id = users[i].Id,
                SeatNumber = randomSeat.ToString(),
                IsActive = true,
                CreateDateTime = DateTimeOffset.UtcNow.AddDays(-10 + i),
            }).ToList();
        }
    }

    public static class PredefineData
    {
        public static async Task SeedDatabaseAsync(FlightReservationSystemDbContext context)
        {
            try
            {
                if (!await context.User.AnyAsync())
                {
                    var cities = MasterDataPredefined.GetCities();
                    await context.City.AddRangeAsync(cities);
                    await context.SaveChangesAsync();

                    var airlineAgencies = MasterDataPredefined.GetAirLineAgency();
                    await context.AirlineAgencie.AddRangeAsync(airlineAgencies);
                    await context.SaveChangesAsync();

                    var users = UserPredefinedData.GetUsers();
                    await context.User.AddRangeAsync(users);
                    await context.SaveChangesAsync();

                    var flights = FlightPredefinedData.GetFlights(airlineAgencies, cities);
                    await context.Flight.AddRangeAsync(flights);
                    await context.SaveChangesAsync();

                    var bookings = FlightBookPredefinedData.GetUserFlights(users, flights);
                    await context.TicketsBooked.AddRangeAsync(bookings);
                    await context.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

    }
}