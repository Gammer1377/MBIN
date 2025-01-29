using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MBIN.Entity.Common;

namespace MBIN.Entity.Blog
{
    public class Blog : BaseEntity
    {
        public string Title { get; set; }
        public string ShortDescription { get; set; }
        public string Text { get; set; }
        public string Slug { get; set; }
        public string ImageName { get; set; }
        public string ImageAlt { get; set; }
        public int VisitCount { get; set; }
        public bool Active { get; set; }
        public int UserID { get; set; }
        public string Writer { get; set; }

        #region Relations

        public int CategoryID { get; set; }
        public int SubCategoryID { get; set; }

        #endregion
    }
}
