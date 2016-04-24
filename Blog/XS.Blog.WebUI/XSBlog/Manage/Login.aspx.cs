using System;
using System.Web;
using XS.Blog.Entity;
using XS.Framework.Utility;

namespace XS.Blog.WebUI.XSBlog.Manage
{
    /// <summary>
    /// 登录页
    /// </summary>
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// 保存事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void BtnLoginOnClick(object sender, EventArgs e)
        {
            var userManager = new UserManager();
            
            var userId = userManager.GetValidate(txtLoginName.Text, txtLoginPwd.Text);
            if (!string.IsNullOrEmpty(userId))
            {
                var userInfo = userManager.GetModel(userId);
                HttpContext.Current.Session["UserInfo"] = userInfo;

                var blogInfo = new BlogInfo()
                {
                    Guid = "39caec73-6fd0-4ea2-ba8f-e7f30b84f507",
                    Name = "XS的Blog"
                };
                HttpContext.Current.Session["BlogInfo"] = blogInfo;

                Response.Redirect("Index.aspx");
            }
            else
            {
                Util.ScriptHelper.Alert2("登录失败，请输入正确的用户名和密码！");
            }
        }
    }
}