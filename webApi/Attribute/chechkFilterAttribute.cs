using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net.Http;
using System.Web.Http.Filters;
using System.Web.Http.Controllers;
using webCore.common;
using System.Threading;

namespace webApi.Attribute
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
    public class chechkFilterAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            if (!actionContext.ModelState.IsValid)
            {
                actionContext.Response = actionContext.Request.CreateResponse(new ApiResult()
                {
                    Data = actionContext.ModelState.Values.SelectMany(r => r.Errors).Select(r => r.ErrorMessage),
                    StatusCode = System.Net.HttpStatusCode.Forbidden,
                    Message = "参数校验失败"
                });
            }
            else
            {   var tocket = HttpContext.Current.Request.Headers["tocket"];
                tocket = string.IsNullOrWhiteSpace(tocket) ? HttpContext.Current.Request["tocket"] : tocket;
                var time = HttpContext.Current.Request.Headers["time"];
                time = string.IsNullOrWhiteSpace(time) ? HttpContext.Current.Request["time"] : time;
                if (Math.Abs(Convert.ToInt64(time) - common.GetTimeSpan(DateTime.Now)) > 1000 * 60)
                {
                    actionContext.Response = actionContext.Request.CreateResponse(new ApiResult()
                    {
                        Data = actionContext.ModelState.Values.SelectMany(r => r.Errors).Select(r => r.ErrorMessage),
                        StatusCode = System.Net.HttpStatusCode.PaymentRequired,
                        Message = "服务器拒绝了您的请求"
                    });
                }
            }
        }
    }
}