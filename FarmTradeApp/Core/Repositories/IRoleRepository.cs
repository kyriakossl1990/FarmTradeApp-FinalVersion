using Microsoft.AspNet.Identity.EntityFramework;

namespace FarmTradeApp.Core.Repositories
{
    public interface IRoleRepository
    {
        IdentityRole GetRole(string roleName);
    }
}