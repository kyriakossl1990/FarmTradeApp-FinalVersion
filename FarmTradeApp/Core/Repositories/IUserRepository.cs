using FarmTradeApp.Core.Models;

namespace FarmTradeApp.Core.Repositories
{
    public interface IUserRepository
    {
        ApplicationUser GetUser(string userId);
        ApplicationUser GetUserWithVerificationForm(string userId);
    }
}