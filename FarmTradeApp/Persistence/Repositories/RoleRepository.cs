using FarmTradeApp.Core.Repositories;
using FarmTradeApp.Persistence;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FarmTradeApp.Repositories
{
    public class RoleRepository : IRoleRepository
    {
        private readonly ApplicationDbContext _context;

        public RoleRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public IdentityRole GetRole(string roleName)
        {
            return _context.Roles.SingleOrDefault(r => r.Name == roleName);
        }
    }
}