using System.Text.RegularExpressions;

namespace Uania.Tools.Infrastructure.RegValidator.Impl
{
    public class RegValidatorServicesImpl : IRegValidatorServices
    {
        public bool IsEmail(string? phoneNumber)
        {
            if (string.IsNullOrWhiteSpace(phoneNumber))
                return false;
            return Regex.IsMatch(phoneNumber, @"^\d{11}$");
        }

        public bool IsPhoneNumber(string? email)
        {
            if (string.IsNullOrWhiteSpace(email))
                return false;
            return Regex.IsMatch(email, @"^\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$");
        }
    }
}