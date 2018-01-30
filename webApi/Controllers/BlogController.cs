using PetaPoco;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using webApi.Models;
using webCore;
using webCore.common;
using webCore.services;

namespace webApi.Controllers
{
    public class BlogController : ApiController
    {
        private IBlogServices blogServices;
        public BlogController(IBlogServices blogServices)
        {

             this.blogServices = blogServices;
        }
        /// <summary>
        /// 分页获取Blog
        /// </summary>
        /// <param name="pagi">分页参数</param>
        /// <returns>api数据</returns>

        [HttpGet, Route("api/blog")]
        public ApiResult GetBlog([FromUri]paging pagi)
        {
            var pageobj = blogServices.blog<blog>(pagi);
            return new ApiResult()
            {
                Data = new
                {
                    list = pageobj.Items.Select(r => new ReturnBlog()
                    {
                        blog_id = r.blog_id,
                        classify_id = r.classify_id,
                        content = r.content,
                        time = r.time,
                        title = r.title,
                        type_id = r.type_id,
                        user_id = r.user_id
                    }),
                    page = pageobj.CurrentPage,
                    pageSize = pageobj.ItemsPerPage,
                    totalPage = pageobj.TotalPages
                },
                Message = "success",
                StatusCode = HttpStatusCode.OK
            };
        }


        [HttpPost, Route("api/AddBlog")]
        public ApiResult AddBlog(blog blog)
        {
            blog.time = DateTime.Now;
            var insertblg = blogServices.AddBlog(blog);
            return new ApiResult()
            {
                StatusCode = HttpStatusCode.OK,
                Message = insertblg.blog_id != 0 ? "success" : "添加失败",
                Data = new
                {
                    blogid = insertblg.blog_id
                }
            };
        }
        [HttpGet, Route("api/DeleteBlog")]
        public ApiResult DeleteBlog([FromUri] int blog_id) => new ApiResult()
        {

            StatusCode = HttpStatusCode.OK,
            Message = blogServices.DeleteBlog(blog_id) ? "success" : "删除失败"
        };

        [HttpPost, Route("api/UpdateBlog")]
        public ApiResult UpdateBlog(blog blog) => new ApiResult()
        {
            StatusCode = HttpStatusCode.OK,
            Message = blogServices.UpdateBlog(blog) ? "success" : "修改失败"
        };


    }
}
