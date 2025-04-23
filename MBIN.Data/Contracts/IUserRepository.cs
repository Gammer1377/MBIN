using MBIN.Entity.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MBIN.Entity.DTOs;

namespace MBIN.Data.Contracts
{
    public interface IUserRepository : IGenericRepository<User, int>
    {
        Task<bool> EmailExist(string email);
        User Login (string email,string password);
    }
}
