using FlightReservationSystem.Model.Entity;
using FlightReservationSystem.Util;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace FlightReservationSystem.Data
{
    public class FlightReservationSystemDbContext : DbContext
    {
        public FlightReservationSystemDbContext(DbContextOptions<FlightReservationSystemDbContext> options)
            : base(options)
        {
        }
        public FlightReservationSystemDbContext() : base(new DbContextOptionsBuilder<FlightReservationSystemDbContext>()
                                        .UseSqlServer(FlightReservationSystemConfigurationProvider.GetConfiguration().GetConnectionString("AppConnectionString"), sqlServerOptions => sqlServerOptions.CommandTimeout(20 * 60)).Options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //base.OnModelCreating(modelBuilder);

            //var userDefinedTypes =
            //    from type in typeof(EntityBase).Assembly.GetExportedTypes()
            //    where type.IsAssignableTo(typeof(EntityBase)) && type.IsClass
            //    select type;

            //foreach (var userDefinedType in userDefinedTypes)
            //{
            //    modelBuilder.Entity(userDefinedType);
            //}

            modelBuilder.Entity<Flight>()
            .HasOne(f => f.OriginCity)
            .WithMany(c => c.OriginFlight)
            .HasForeignKey(f => f.OriginCity_Id)
            .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Flight>()
                .HasOne(f => f.DestinationCity)
                .WithMany(c => c.DestinationFlight)
                .HasForeignKey(f => f.DestinationCity_Id)
                .OnDelete(DeleteBehavior.Restrict);
        }

        public DbSet<User> User { get; set; }
        public DbSet<UserAuthentication> UserAuthentication { get; set; }
        public DbSet<Flight> Flight { get; set; }
        public DbSet<City> City { get; set; }
        public DbSet<AirlineAgency> AirlineAgencie { get; set; }
        public DbSet<TicketsBooked> TicketsBooked { get; set; }
    }
}
