using System;
using System.Web;
using XS.Blog.Components;
using XS.Blog.Entity;

namespace XS.Blog.WebUI.XSBlog.Manage.MMood
{
    /// <summary>
    /// 心情编辑
    /// </summary>
    public partial class MoodEdit : PagePermission
    {
        protected MoodManager MoodBll = new MoodManager();
        protected string EditContent = string.Empty;

        protected string StrGuid
        {
            get
            {
                if (Request.QueryString["guid"] != null)
                {
                    return Request.QueryString["guid"];
                }
                return "";
            }
        }

        public string Content
        {
            get { return Context.Request.Form["editContent"]; }
            set { EditContent = value; }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (!string.IsNullOrEmpty(StrGuid))
                {
                    var info = MoodBll.GetModel(StrGuid);
                    if (info != null)
                    {
                        tbName.Text = info.Name;
                        EditContent = info.Content;
                    }
                }
            }
        }

        /// <summary>
        /// 保存事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void BtnSave_OnClick(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(StrGuid))
            {
                var info = new MoodInfo();

                info.Name = tbName.Text;
                info.Content = Content;
                info.CreateTime = DateTime.Now;
                var user = HttpContext.Current.Session["UserInfo"] as UserInfo;
                if (user != null)
                {
                    info.UserGuid = user.Guid;
                }
                var blog = HttpContext.Current.Session["BlogInfo"] as BlogInfo;
                if (blog != null)
                {
                    info.BlogGuid = blog.Guid;
                }

                MoodBll.Add(info);
            }
            else
            {
                var info = MoodBll.GetModel(StrGuid);
                info.Name = tbName.Text;
                info.Content = Content;

                MoodBll.Update(info);
            }

            Response.Redirect("MoodList.aspx");
        }

        /// <summary>
        /// 返回事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void BtnReturn_OnClick(object sender, EventArgs e)
        {
            Response.Redirect("MoodList.aspx");
        }
    }
}