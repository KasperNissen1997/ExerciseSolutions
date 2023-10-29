using W43BankingAPI.Models;

namespace W43BankingAPI.Services
{
    public interface IAuthorizationService
    {
        string GenerateTokenString(LoginUser user);
        Task<bool> Login(LoginUser user);
        Task<bool> RegisterUser(LoginUser user);
    }
}