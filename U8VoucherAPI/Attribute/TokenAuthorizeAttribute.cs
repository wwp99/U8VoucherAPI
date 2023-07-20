using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Http.Controllers;

namespace U8VoucherAPI.AuthAttribute
{
    public class TokenAuthorizeAttribute : AuthorizeAttribute
    {
        /// <summary>
        /// 指示指定的控件是否已获得授权
        /// </summary>
        /// <param name="actionContext"></param>
        /// <returns></returns>
        protected override bool IsAuthorized(HttpActionContext actionContext)
        {
            var authHeader = from t in actionContext.Request.Headers where t.Key == "auth" select t.Value.FirstOrDefault();
            if (authHeader == null)
                return false;
            string token1 = authHeader.FirstOrDefault();//获取token
            string token = ConfigurationManager.AppSettings["token"];
            if (token == token1)
                return true;
            return false;
        }

        /// <summary>
        /// 处理授权失败的请求
        /// </summary>
        /// <param name="actionContext"></param>
        protected override void HandleUnauthorizedRequest(HttpActionContext actionContext)
        {
            var erModel = new Models.FeedbackResult
            {
                errmsg = "身份验证失败，拒绝访问！"
            };
            actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.OK, erModel, "application/json");
        }
    }

}