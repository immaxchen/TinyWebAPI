using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;

namespace demoServer
{
    /// <summary>
    /// RequestHandler 的摘要描述
    /// </summary>
    public class RequestHandler : IHttpHandler
    {
        public void ProcessRequest(HttpContext context)
        {
            string name = null;
            string sex = null;
            string age = null;

            if (context.Request.HttpMethod == "GET")
            {
                name = context.Request.QueryString["name"];
                sex = context.Request.QueryString["sex"];
                age = context.Request.QueryString["age"];
            }
            else if (context.Request.HttpMethod == "POST")
            {
                name = context.Request.Form["name"];
                sex = context.Request.Form["sex"];
                age = context.Request.Form["age"];
            }

            var data = new { name = name, sex = sex, age = age };
            var json = new JavaScriptSerializer().Serialize(data);
            context.Response.ContentType = "application/json";
            context.Response.Write(json);

            // Access Routed URL Parameters : context.Request.RequestContext.RouteData.Values[]
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}