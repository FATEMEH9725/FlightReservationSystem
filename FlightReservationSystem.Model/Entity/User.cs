using FlightReservationSystem.Model.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FlightReservationSystem.Model.Entity
{
    [Table("User", Schema = "Flight")]
    public class User : EntityBase
    {
        public User()
        {
        }

        public User(bool initialize) : base(initialize)
        {
        }

        [MaxLength(50)]
        public virtual string FirstName { get; set; }

        [MaxLength(100)]
        public virtual string LastName { get; set; }

        [Column(TypeName = "char(10)")]
        public virtual string NationalCode { get; set; }


        [Column(TypeName = "char(11)")]
        public virtual string MobileNumber { get; set; }

        public virtual string UserName { get; set; }

        [MaxLength(255)]
        public virtual string Password { get; set; }

        [Column(TypeName = "varchar(200)")]
        public virtual string EmailAddress { get; set; }

        public virtual DateTimeOffset? BirthDate { get; set; }

        public virtual RoleType RoleType { get; set; }

        public virtual bool? IsActive { get; set; }

        public virtual DateTimeOffset? CreateDateTime { get; set; }

        public virtual ICollection<UserAuthentication> UserAuthentication { get; set; }
        public virtual ICollection<TicketsBooked> TicketsBooked { get; set; }
    }
}