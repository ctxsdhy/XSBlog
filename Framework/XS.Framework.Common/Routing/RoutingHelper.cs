using System.Linq;
using System.Web.Routing;

namespace XS.Framework.Common.Routing
{
    /// <summary>
    /// 路由助手
    /// </summary>
    public class RoutingHelper
    {
        public static Route GetRoute(string url, string toUrl, string paramName, object defaultParam)
        {
            if (!string.IsNullOrWhiteSpace(paramName))
            {
                var paramNameStr = paramName.Split(',');
                if (paramNameStr.Length > 0)
                {
                    var paramNameList = paramNameStr.ToList();
                    if (defaultParam != null)
                    {
                        return new Route(url, new RouteValueDictionary(defaultParam), new RouteHandlerCommon() { Url = toUrl, ParamNameList = paramNameList });
                    }
                    return new Route(url, new RouteHandlerCommon() { Url = toUrl, ParamNameList = paramNameList });
                }
            }
            if (defaultParam != null)
            {
                return new Route(url, new RouteValueDictionary(defaultParam), new RouteHandlerCommon() { Url = toUrl });
            }
            return new Route(url, new RouteHandlerCommon() { Url = toUrl });
        }

        public static Route GetRoute(string url, string toUrl, string paramName)
        {
            return GetRoute(url, toUrl, paramName, null);
        }

        public static Route GetRoute(string url, string toUrl, object defaultParam)
        {
            return GetRoute(url, toUrl, null, defaultParam);
        }

        public static Route GetRoute(string url, string toUrl)
        {
            return GetRoute(url, toUrl, null, null);
        }
    }
}
