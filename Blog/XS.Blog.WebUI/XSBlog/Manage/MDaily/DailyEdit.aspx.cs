using System;
using System.Web;
using System.Web.UI.WebControls;
using XS.Blog.Components;
using XS.Blog.Entity;
using XS.Framework.Utility;

namespace XS.Blog.WebUI.XSBlog.Manage.MDaily
{
    /// <summary>
    /// 文章编辑
    /// </summary>
    public partial class DailyEdit : PagePermission
    {
        protected DailyManager DailyBll = new DailyManager();
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
                ddlCategory.DataSource = new CategoryManager().GetTreeList();
                ddlCategory.DataTextField = "Name";
                ddlCategory.DataValueField = "Guid";
                ddlCategory.DataBind();

                ddlSpecial.Items.Add(new ListItem() { Value = "0", Text = "公开"});
                ddlSpecial.Items.Add(new ListItem() { Value = "1", Text = "登录用户可见" });
                ddlSpecial.Items.Add(new ListItem() { Value = "2", Text = "自己可见" });

                if (!string.IsNullOrEmpty(StrGuid))
                {
                    var info = DailyBll.GetModel(StrGuid);
                    if (info != null)
                    {
                        tbName.Text = info.Name;
                        EditContent = info.Content;
                        if (ddlCategory.Items.FindByValue(info.CategoryGuid) != null)
                        {
                            ddlCategory.SelectedValue = info.CategoryGuid;
                        }
                        if (ddlSpecial.Items.FindByValue(info.IsSpecial.ToString()) != null)
                        {
                            ddlSpecial.SelectedValue = info.IsSpecial.ToString();
                        }
                        chkIsStick.Checked = info.IsStick;
                        chkIsHome.Checked = info.IsHome;
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
                var info = new DailyInfo();
                SetModel(info);
                info.CreateTime = DateTime.Now;
                info.IsDraft = false;
                info.IsSpecial = ConvertHelper.GetInt(ddlSpecial.SelectedValue);
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

                DailyBll.Add(info);
            }
            else
            {
                var info = DailyBll.GetModel(StrGuid);
                SetModel(info);
                info.IsDraft = false;

                DailyBll.Update(info);
            }

            Response.Redirect("DailyList.aspx");
        }

        /// <summary>
        /// 保存草稿事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void BtnDraft_OnClick(object sender, EventArgs e)
        {
            var guid = "";

            if (string.IsNullOrEmpty(StrGuid))
            {
                var info = new DailyInfo();
                SetModel(info);
                info.CreateTime = DateTime.Now;
                info.IsDraft = true;
                info.IsSpecial = ConvertHelper.GetInt(ddlSpecial.SelectedValue);
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

                guid = DailyBll.Add(info);
            }
            else
            {
                var info = DailyBll.GetModel(StrGuid);
                SetModel(info);
                info.IsDraft = true;

                DailyBll.Update(info);

                guid = StrGuid;
            }

            Response.Redirect(string.Format("DailyEdit.aspx?guid={0}", guid));
        }

        /// <summary>
        /// 返回事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void BtnReturn_OnClick(object sender, EventArgs e)
        {
            Response.Redirect("DailyList.aspx");
        }

        /// <summary>
        /// 设置model
        /// </summary>
        /// <param name="dailyInfo"></param>
        private void SetModel(DailyInfo dailyInfo)
        {
            dailyInfo.Name = tbName.Text;
            dailyInfo.Content = Content;
            dailyInfo.CategoryGuid = ddlCategory.SelectedValue;
            dailyInfo.IsStick = chkIsStick.Checked;
            dailyInfo.IsHome = chkIsHome.Checked;
            dailyInfo.IsSpecial = ConvertHelper.GetInt(ddlSpecial.SelectedValue);
        }
    }
}