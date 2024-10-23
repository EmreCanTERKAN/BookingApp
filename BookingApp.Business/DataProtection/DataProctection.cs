
using Microsoft.AspNetCore.DataProtection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingApp.Business.DataProtection
{
    public class DataProctection : IDataProtection
    {
        private readonly IDataProtector _protector;

        public DataProctection(IDataProtectionProvider provider)
        {
            _protector = provider.CreateProtector("security");
        }
        public String Protect(String text)
        {
           return _protector.Protect(text);
        }

        public String UnProtect(String protectedText)
        {
          return _protector.Unprotect(protectedText);
        }
    }
}
