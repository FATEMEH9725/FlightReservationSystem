using FlightReservationSystem.Model.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace FlightReservationSystem.Model.Entity
{
    [Table("Flight", Schema = "Flight")]
    public class Flight : EntityBase
    {
        public Flight()
        {

        }

        public Flight(bool initialize) : base(initialize)
        {

        }

        public virtual string FlightNumber { get; set; }

        public virtual Guid AirlineAgency_Id { get; set; }

        [ForeignKey("AirlineAgency_Id")]
        public virtual AirlineAgency AirlineAgency { get; set; }

        public virtual Guid OriginCity_Id { get; set; }
        public virtual City OriginCity { get; set; }

        public virtual Guid DestinationCity_Id { get; set; }
        public virtual City DestinationCity { get; set; }

        public virtual DateTimeOffset DepartureTime { get; set; }

        public virtual DateTimeOffset ArrivalTime { get; set; }

        public virtual int SeatsCount { get; set; }

        public virtual decimal Price { get; set; }

        public virtual CabinClassType CabinClassType { get; set; }

        public virtual string AircraftModel { get; set; }

        public virtual int CargoAllowance { get; set; }

        public virtual TerminalType TerminalType { get; set; }

        public virtual FlightType FlightType { get; set; }

        public virtual DateTimeOffset CreateDateTime { get; set; }

        public virtual bool IsActive { get; set; }

        public virtual ICollection<TicketsBooked> Bookings { get; set; }

        public void SetFlightNumber(string airlineCode)
        {
            FlightNumber = GenerateFlightNumber(airlineCode);
        }

        private string GenerateFlightNumber(string airlineCode)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            Random random = new Random();
            var randomString = new string(Enumerable.Repeat(chars, 5)
                .Select(s => s[random.Next(s.Length)]).ToArray());
            return $"{airlineCode}-{randomString}";
        }
    }
}
