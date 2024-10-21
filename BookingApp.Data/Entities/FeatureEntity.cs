using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingApp.Data.Entities
{
    public class FeatureEntity : BaseEntity
    {
        public String Title { get; set; }

        // Relational Property

        public ICollection<HotelFeatureEntity> HotelFeatures { get; set; }
    }
}
