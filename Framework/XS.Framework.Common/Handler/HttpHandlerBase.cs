using System.Reflection;
using System.Web;

namespace XS.Framework.Common.Handler
{
    /// <summary>
    /// HttpHandler基类
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class HttpHandlerBase <T> : IHttpHandler
    {
        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            string action = context.Request["Action"];
            if (!string.IsNullOrEmpty(action))
            {
                MethodInfo method = typeof(T).GetMethod(action);
                if (method != null)
                {
                    string result = (string)method.Invoke(this, new object[] { context });
                    context.Response.Write(result);
                }
                else
                {
                    context.Response.Write(action + "方法未实现");
                }
            }
            else
            {
                context.Response.Write("未传入方法名");
            }
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
