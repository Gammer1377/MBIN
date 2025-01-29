using MBIN.Entity.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MBIN.Data.Contracts
{
    public interface IUserRepository : IGenericRepository<User,int>
    {

    }
}
