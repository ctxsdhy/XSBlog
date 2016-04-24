using System.Web.Routing;
using XS.Framework.Common.Routing;

namespace XS.Blog.Framework
{
    /// <summary>
    /// REST的路由
    /// </summary>
    public class RoutingController
    {
        public static void SetRouteCollection(RouteCollection routes)
        {
            //首页
            routes.Add(RoutingHelper.GetRoute("xsblog/{BlogName}", "~/XSBlog/Home/Home.aspx", "BlogName"));
            
            //文章
            routes.Add(RoutingHelper.GetRoute("xsblog/{BlogName}/daily/c/{Category}/{Page}", "~/XSBlog/Daily/DailyList.aspx", "BlogName,Category,Page", new { Category = "0", Page = "1" }));
            routes.Add(RoutingHelper.GetRoute("xsblog/{BlogName}/daily/{Id}", "~/XSBlog/Daily/DailyView.aspx", "BlogName,Id"));

            //分类
            routes.Add(RoutingHelper.GetRoute("xsblog/{BlogName}/category", "~/XSBlog/Category/CategoryList.aspx", "BlogName"));
            routes.Add(RoutingHelper.GetRoute("xsblog/{BlogName}/category/{Category}/{Page}", "~/XSBlog/Category/DailyList.aspx", "BlogName,Category,Page", new { Category = "0", Page = "1" }));

            //心情
            routes.Add(RoutingHelper.GetRoute("xsblog/{BlogName}/mood/{Page}", "~/XSBlog/Mood/MoodList.aspx", "BlogName,Page", new { Page = "1" }));

            //相册
            routes.Add(RoutingHelper.GetRoute("xsblog/{BlogName}/album/{AlbumId}/{Page}", "~/XSBlog/Album/PhotoList.aspx", "BlogName,AlbumId,Page", new { Page = "1" }));
            routes.Add(RoutingHelper.GetRoute("xsblog/{BlogName}/album", "~/XSBlog/Album/AlbumList.aspx", "BlogName"));
            routes.Add(RoutingHelper.GetRoute("xsblog/{BlogName}/album/{AlbumId}/p/{PhotoId}", "~/XSBlog/Album/PhotoView.aspx", "BlogName,AlbumId,PhotoId"));

            //归档
            routes.Add(RoutingHelper.GetRoute("xsblog/{BlogName}/archive", "~/XSBlog/Archive/Archive.aspx", "BlogName"));

            //关于
            routes.Add(RoutingHelper.GetRoute("xsblog/{BlogName}/about", "~/XSBlog/About/About.aspx", "BlogName"));
        }
    }
}
