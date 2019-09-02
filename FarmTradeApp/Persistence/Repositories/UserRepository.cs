using FarmTradeApp.Core.Models;
using FarmTradeApp.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace FarmTradeApp.Persistence.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _context;

        public UserRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public ApplicationUser GetUser(string userId)
        {
            return _context.Users.Single(u => u.Id == userId);
        }

        public ApplicationUser GetUserWithVerificationForm(string userId)
        {
            return _context.Users
                .Include(u => u.VerificationForm)
                .Single(u => u.Id == userId);
        }
    }
}