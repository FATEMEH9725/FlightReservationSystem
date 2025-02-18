

namespace FlightReservationSystem.Service.Contracts
{
    public interface IComputeHash
    {
        public string ComputeSha256Hash(string password);
    }
}
