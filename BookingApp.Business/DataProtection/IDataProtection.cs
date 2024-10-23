

namespace BookingApp.Business.DataProtection
{
    public interface IDataProtection
    {
        String Protect(String text);
        String UnProtect(String protectedText);

    }
}
