using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace FlightReservationSystem.Model.Entity
{
    [Table("UserAuthentication", Schema = "Flight")]
    public class UserAuthentication: EntityBase
    {
        public UserAuthentication()
        {

        }
        public UserAuthentication(bool initialize) : base(initialize)
        {

        }
        
        public virtual Guid? User_Id { get; set; }

        [ForeignKey("User_Id")]
        public virtual User User { get; set; }

        public virtual int? VerifyCode { get; set; }

        public virtual DateTimeOffset? ExpireDate { get; set; }
    }
}
