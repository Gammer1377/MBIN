using MBIN.Data.Context;
using MBIN.Data.Contracts;
using MBIN.Entity.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MBIN.Data.Repositories
{
    public class UserRepository : GenericRepository<User, int>, IUserRepository
    {
        private readonly ApplicationDbContext _context;

        public UserRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
