using PetaPoco;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using webCore.common;

namespace webCore.repository
{
    public interface IBlog_Repostory
    {

        Page<T> blog<T>(paging pagi) where T : class;

        blog AddBlog(blog blog);

        bool DeleteBlog(int blog_id);
        bool UpdateBlog(blog blog);



    }
}
