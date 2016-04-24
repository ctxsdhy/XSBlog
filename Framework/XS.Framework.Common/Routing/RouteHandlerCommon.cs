using System.Collections.Generic;
using System.Web;
using System.Web.Routing;

namespace XS.Framework.Common.Routing
{
    /// <summary>
    /// 公共RouteHandler类
    /// </summary>
    public class RouteHandlerCommon : IRouteHandler
    {
        /// <summary>
        /// 地址
        /// </summary>
        public string Url { get; set; }

        /// <summary>
        /// 参数
        /// </summary>
        public List<string> ParamNameList { get; set; }

        public IHttpHandler GetHttpHandler(RequestContext requestContext)
        {
            if (ParamNameList?.Count > 0)
            {
                var paramList = new Dictionary<string, string>();

                foreach (var paramName in ParamNameList)
                {
                    //存在参数
                    if (requestContext.RouteData.Values.ContainsKey(paramName))
                    {
                        var value = requestContext.RouteData.GetRequiredString(paramName);
                        
                        //不为空
                        if (!string.IsNullOrWhiteSpace(value))
                        {
                            paramList.Add(paramName, value);
                        }
                    }
                }

                return new HttpHandlerCommon() {Url = Url, ParamList = paramList};
            }
            return new HttpHandlerCommon() {Url = Url};
        }
    }
}
