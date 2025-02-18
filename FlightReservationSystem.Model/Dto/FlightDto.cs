using FlightReservationSystem.Model.Enum;
using System;

namespace FlightReservationSystem.Model.Dto
{
    public class FlightDto
    {
        public Guid Id { get; set; }
        public string FlightNumber { get; set; }
        public string AirlineName { get; set; }
        public string Origin { get; set; }
        public string Destination { get; set; }
        public DateTimeOffset DepartureTime { get; set; }
        public DateTimeOffset ArrivalTime { get; set; }
        public int SeatsCount { get; set; }
        public decimal Price { get; set; }
        public CabinClassType CabinClassType { get; set; }
        public string AircraftModel { get; set; }
        public int CargoAllowance { get; set; }
        public TerminalType TerminalType { get; set; }
        public FlightType FlightType { get; set; }

    }
}
