using Microsoft.EntityFrameworkCore.Metadata.Builders;
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

    public class HotelFeatureConfiguration : BaseConfiguration<HotelFeatureEntity>
    {
        public override void Configure(EntityTypeBuilder<HotelFeatureEntity> builder)
        {
            builder.Ignore(x => x.Id);
            // Base entityden gelen Id propertysini görmezden geldik çünkü id ismini gördüğü için o kolonu primary key yapacaktır. Yeni composite key
            builder.HasKey("HotelId", "FeatureId");
            
            base.Configure(builder);
        }
    }
}
