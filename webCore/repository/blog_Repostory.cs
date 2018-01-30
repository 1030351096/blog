using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PetaPoco;
using webCore.common;
using System.Linq.Expressions;
namespace webCore.repository
{
    public class blog_Repostory : IBlog_Repostory
    {
        private DbcontextDB db = new DbcontextDB();

        public blog AddBlog(blog blog)
        {
            blog.blog_id = (int)db.Insert(blog);
            return blog;
        }

        public Page<T> blog<T>(paging pagi) where T : class
        {
            Sql sql = new Sql().Select("*").From("dbo.blog").Where("Isdal =@0", 1);
            if (pagi != null)
            {
                if (!string.IsNullOrWhiteSpace(pagi.keyword))
                {
                    sql.Where("[title] like @0", $"%{pagi.keyword}%");
                }
                if (pagi.type_id.HasValue)
                {
                    sql.Where("type_id =@0", $"{pagi.type_id.Value}");
                }
                if (pagi.lookno.HasValue)
                {
                    sql.Where("lookno =@0", $"{pagi.lookno.Value}");
                }
            }
            return db.Page<T>(pagi.pageindex, pagi.pagesizi, sql);
        }

        public bool DeleteBlog(int blog_id)
        {
            Sql sql = new Sql().Append("set Isdal=1 where blog_id =@0", blog_id);
            return db.Update<blog>(sql) > 0;
        }
        public bool UpdateBlog(blog blog) => db.Update(blog) > 0;




    }
}
