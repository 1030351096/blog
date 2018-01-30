using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PetaPoco;
using webCore.common;
using webCore.repository;

namespace webCore.services
{
    public class blogServices : IBlogServices
    {
        private IBlog_Repostory IBlog_Repostory;

        public blogServices(IBlog_Repostory IBlog_Repostory)
        {
            this.IBlog_Repostory = IBlog_Repostory;
        }
        public bool DeleteBlog(int blog_id) => IBlog_Repostory.DeleteBlog(blog_id);

        public blog AddBlog(blog blog) => IBlog_Repostory.AddBlog(blog);

        public Page<T> blog<T>(paging pagi) where T : class => IBlog_Repostory.blog<T>(pagi);

        public bool UpdateBlog(blog blog) => IBlog_Repostory.UpdateBlog(blog);


    }
}
