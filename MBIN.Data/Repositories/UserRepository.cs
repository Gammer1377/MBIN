using MBIN.Data.Context;
using MBIN.Data.Contracts;
using MBIN.Entity.DTOs;
using MBIN.Entity.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace MBIN.Data.Repositories
{
    public class UserRepository : GenericRepository<User, int>, IUserRepository
    {
        private readonly ApplicationDbContext _context;

        public UserRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<bool> EmailExist(string email)
        {
            var Query = _context.Users.AnyAsync(u => u.Email.Trim() == email.Trim());

            return Query.Result;
        }

        public User Login(LoginUserDTO loginUserDto)
        {
            throw new NotImplementedException();
        }

    }
}
