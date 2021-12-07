namespace Uania.Tools.Infrastructure.RegValidator
{
    public interface IRegValidatorServices
    {
        public bool IsPhoneNumber(string? phoneNumber);

        public bool IsEmail(string? email);
    }
}