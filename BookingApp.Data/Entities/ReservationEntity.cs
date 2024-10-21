using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingApp.Data.Entities
{
    public class ReservationEntity : BaseEntity
    {
        public int RoomId { get; set; }
        public int UserId { get; set; }

        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int GuestCount { get; set; }

        // Relational Property

        public UserEntity User { get; set; }
        public RoomEntity Room { get; set; }

    }
}
