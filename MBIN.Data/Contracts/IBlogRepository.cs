using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MBIN.Entity.Blog;

namespace MBIN.Data.Contracts
{
    public interface IBlogRepository:IGenericRepository<Blog,int>
    {

    }
}
