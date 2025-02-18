using FlightReservationSystem.Model.Enum;
using System;

namespace FlightReservationSystem.Model.Dto
{
    public class UserDto
    {
        public Guid Id { get; set; }
        public RoleType RoleType { get; set; }
    }
}
