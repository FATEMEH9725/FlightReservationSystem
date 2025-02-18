using FlightReservationSystem.Data;
using FlightReservationSystem.Util;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace FlightReservationSystem.DbMigrate
{
    public class MigrateDbContext : FlightReservationSystemDbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            var connectionString = FlightReservationSystemConfigurationProvider.GetConfiguration().GetConnectionString("AppConnectionString");

            optionsBuilder.UseSqlServer(
                connectionString);
        }
    }
}
