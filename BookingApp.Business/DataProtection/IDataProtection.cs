using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingApp.Business.DataProtection
{
    public interface IDataProtection
    {
        String Protect(String text);
        String UnProtect(String protectedText);

    }
}
