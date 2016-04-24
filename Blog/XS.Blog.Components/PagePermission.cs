using System;
using System.Web;
using XS.Blog.Entity;
using XS.Framework.Utility;

namespace XS.Blog.Components
{
    /// <summary>
    /// 权限页面
    /// </summary>
    public class PagePermission : PageBase
    {
        private UserInfo _user;

        /// <summary>
        /// 验证用户是否为登录用户且有访问页面的权限
        /// </summary>
        /// <param name="e"></param>
        protected override void OnLoad(EventArgs e)
        {
            if (ValidateLoginStatus())
            {
                base.OnLoad(e);
            }
        }

        /// <summary>
        /// 验证用的登录状态
        /// </summary>
        private bool ValidateLoginStatus()
        {
            _user = HttpContext.Current.Session["UserInfo"] as UserInfo;

            if (_user == null)
            {
                ScriptHelper.AlertAndRedirectParent("请重新登录", WebsiteUrl + "XSBlog/Manage/Login.aspx");
                //ScriptHelper.ReplaceOpenerParentWindow(WebsiteUrl + "XSBlog/Manage/Login.aspx");
                Response.End();
            }
            else
                return true;
 
            return false;
        }

        /// <summary>
        /// 请求路径
        /// </summary>
        private static string WebsiteUrl
        {
            get
            {
                var request = HttpContext.Current.Request;
                return request.Url.Scheme + "://" + request.Url.Host + ":" + request.Url.Port + request.ApplicationPath;
            }
        }
    }
}
