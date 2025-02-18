using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FlightReservationSystem.Model.Entity
{

    [Table("TicketsBooked", Schema = "Flight")]
    public class TicketsBooked : EntityBase
    {
        public TicketsBooked()
        {
        }

        public TicketsBooked(bool initialize) : base(initialize)
        {
        }

        [Required]
        public virtual Guid Flight_Id { get; set; }

        [ForeignKey("Flight_Id")]
        public virtual Flight Flight { get; set; }

        [Required]
        public virtual Guid User_Id { get; set; }

        [ForeignKey("User_Id")]
        public virtual User User { get; set; }

        public virtual string SeatNumber { get; set; }

        public virtual bool? IsActive { get; set; }

        public virtual DateTimeOffset CreateDateTime { get; set; }

    }
}