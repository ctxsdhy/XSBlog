using System;

namespace XS.Blog.WebUI
{
    public partial class Index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //首页跳转
            Response.Redirect("xsblog/ctxsdhy");
        }
    }
}