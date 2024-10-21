using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingApp.Data.Entities
{
    public class RoomEntity : BaseEntity
    {
        public String RoomNumber { get; set; }

        // Relational Property
        public ICollection<ReservationEntity> Reservations { get; set; }
        public HotelEntity Hotel { get; set; }
    }
}
