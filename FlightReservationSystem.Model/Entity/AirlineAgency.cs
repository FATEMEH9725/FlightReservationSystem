using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FlightReservationSystem.Model.Entity
{
    [Table("AirlineAgency", Schema = "Flight")]
    public class AirlineAgency : EntityBase
    {
        public AirlineAgency()
        {
        }

        public AirlineAgency(bool initialize) : base(initialize)
        {
        }

        [MaxLength(100)]
        public virtual string Title { get; set; }

        [MaxLength(20)]
        public virtual string AirLineCode { get; set; }

        public virtual bool IsActive { get; set; }

        public virtual ICollection<Flight> Flight { get; set; }
    }
}
