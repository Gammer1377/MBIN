using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MBIN.Data.Context;
using MBIN.Data.Contracts;
using MBIN.Entity.Blog;
using MBIN.Entity.User;

namespace MBIN.Data.Repositories
{
    public class BlogCategoryRepository : GenericRepository<BlogCategory, int>, IBlogCategoryRepository
    {
        private readonly ApplicationDbContext _context;

        public BlogCategoryRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
