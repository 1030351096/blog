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
    public class UserController : ApiController
    {
        private IUserServices userServices;
        public UserController(IUserServices IUserServices)
        {
            this.userServices = IUserServices;
        }
        [HttpPost, Route("api/login")]
        public ApiResult Login(admin admin)
        {
            var module = userServices.Login(admin);
            if (module != null)
            {
                common.SetCookie("userid", common.MD5(module.id.ToString()), DateTime.Now.AddDays(1));
            }
            return new ApiResult()
            {
                StatusCode = HttpStatusCode.OK,
                Data = (module != null) ? module.id.ToString() : "",
                Message = (module != null) ? "success" : "用户名或密码错误"
            };
        }
        [HttpGet, Route("api/Registered")]
        public ApiResult Registered(admin admin)
        {
            var module = userServices.Registered(admin);
            return new ApiResult()
            {
                StatusCode = HttpStatusCode.OK,
                Message = (module != null) ? "success" : "邮箱已被使用",
                Data = new
                {
                    admin = new ReturnAdmin()
                    {
                        id = module?.id ?? 0,
                        name = module?.name,
                        email = module?.email
                    }
                }
            };
        }


    }
}
