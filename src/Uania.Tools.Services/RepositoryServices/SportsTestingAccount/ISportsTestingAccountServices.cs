using Uania.Tools.Models.SportsTesting;

namespace Uania.Tools.Services.RepositoryServices.SportsTestingAccount
{
    public interface ISportsTestingAccountServices
    {
        /// <summary>
        /// 获取用户信息
        /// </summary>
        /// <param name="phone"></param>
        /// <returns></returns>
        public Task<SportsTestingUsers?> GetUserInfo(string phone);

        /// <summary>
        /// 验证密码
        /// </summary>
        /// <param name="plainPassword"></param>
        /// <param name="cipherPassword"></param>
        /// <returns></returns>
        public bool ValidPassword(string plainPassword, string cipherPassword);
    }
}