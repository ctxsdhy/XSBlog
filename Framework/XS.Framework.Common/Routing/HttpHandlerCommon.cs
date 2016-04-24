using System.Collections.Generic;
using System.Text;
using System.Web;
using System.Web.SessionState;

namespace XS.Framework.Common.Routing
{
    /// <summary>
    /// 公共HttpHandler类
    /// </summary>
    public class HttpHandlerCommon : IHttpHandler, IRequiresSessionState
    {
        /// <summary>
        /// 地址
        /// </summary>
        public string Url { get; set; }

        /// <summary>
        /// 参数
        /// </summary>
        public Dictionary<string, string> ParamList { get; set; } 

        public void ProcessRequest(HttpContext context)
        {
            if (ParamList?.Count > 0)
            {
                var paramStrb = new StringBuilder();
                var paramStr = string.Empty;

                foreach (var paramInfo in ParamList)
                {
                    paramStrb.Append("&" + paramInfo.Key + "=" + paramInfo.Value);
                }

                if (Url.IndexOf('?') < 0)
                {
                    Url += '?';
                    paramStr = paramStrb.ToString().Substring(1);
                }
                else
                {
                    paramStr = paramStrb.ToString();
                }

                context.Server.Transfer(Url + paramStr);
            }
            context.Server.Transfer(Url);
        }

        public bool IsReusable { get; private set; }
    }
}
