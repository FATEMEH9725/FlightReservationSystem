using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FlightReservationSystem.Model.Entity
{
    [Table("City", Schema = "Flight")]
    public class City : EntityBase
    {
        public City()
        {
        }

        public City(bool initialize) : base(initialize)
        {
        }

        [MaxLength(100)]
        public virtual string Title { get; set; }

        public virtual bool IsActive { get; set; }

        public virtual ICollection<Flight> OriginFlight { get; set; }
        public virtual ICollection<Flight> DestinationFlight { get; set; }
    }
}
