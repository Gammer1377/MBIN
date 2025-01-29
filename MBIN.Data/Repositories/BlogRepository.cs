using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MBIN.Data.Context;
using MBIN.Data.Contracts;
using MBIN.Entity.Blog;

namespace MBIN.Data.Repositories
{
    public class BlogRepository : GenericRepository<Blog, int>, IBlogRepository
    {
        private readonly ApplicationDbContext _context;

        public BlogRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
