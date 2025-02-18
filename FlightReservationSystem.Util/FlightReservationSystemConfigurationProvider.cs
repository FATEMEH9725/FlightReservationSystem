using Microsoft.Extensions.Configuration;

namespace FlightReservationSystem.Util
{
    public class FlightReservationSystemConfigurationProvider
    {
        public static IConfiguration GetConfiguration()
        {
            return new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false)
                .AddJsonFile("appsettings.Development.json", optional: true)
                .Build();
        }
    }
}
