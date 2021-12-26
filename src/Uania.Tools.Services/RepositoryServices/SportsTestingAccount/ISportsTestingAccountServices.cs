using Uania.Tools.Models.SportsTesting;

namespace Uania.Tools.Services.RepositoryServices.SportsTestingAccount
{
    public interface ISportsTestingAccountServices
    {
        public Task<SportsTestingUsers> GetUserInfo(string phone);
    }
}