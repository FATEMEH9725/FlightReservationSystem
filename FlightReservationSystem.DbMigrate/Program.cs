using Microsoft.EntityFrameworkCore;

namespace FlightReservationSystem.DbMigrate
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Migrate();
        }

        private static void Migrate()
        {
            using var db = new MigrateDbContext();
            db.Database.SetCommandTimeout(500);
            db.Database.Migrate();
        }
    }
}
