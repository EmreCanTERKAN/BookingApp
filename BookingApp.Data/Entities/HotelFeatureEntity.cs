using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingApp.Data.Entities
{
    // Hangi otelde hangi özellik var
    public class HotelFeatureEntity : BaseEntity
    {
        public int HotelId { get; set; }
        public int FeatureId { get; set; }

        //Relational Property

        public HotelEntity Hotel { get; set; }
        public FeatureEntity Feature { get; set; }


    }
}
