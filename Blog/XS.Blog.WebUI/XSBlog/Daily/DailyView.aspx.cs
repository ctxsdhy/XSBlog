using System;
using System.Web;
using XS.Blog.Components;
using XS.Blog.Entity;
using XS.Framework.Utility;

namespace XS.Blog.WebUI.XSBlog.Daily
{
    /// <summary>
    /// 文章浏览
    /// </summary>
    public partial class DailyView : PageBase
    {
        protected DailyManager DailyManager = new DailyManager();
        protected CategoryManager CategoryManager = new CategoryManager();

        protected DailyInfo DailyInfo = new DailyInfo();
        protected CategoryInfo CategoryInfo = new CategoryInfo();

        protected string Id => UrlHelper.GetString(Request["id"]);

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                InitControls();
            }
        }

        /// <summary>
        /// 初始化控件
        /// </summary>
        private void InitControls()
        {
            if (!string.IsNullOrEmpty(Id))
            {
                DailyInfo = DailyManager.GetModelById(ConvertHelper.GetInt(Id));
                if (DailyInfo != null)
                {
                    lblName.Text = DailyInfo.Name;
                    litContent.Text = DailyInfo.Content;
                    lblCreateTime.Text = string.Format("{0:yyyy-MM-dd HH:mm:ss}", DailyInfo.CreateTime);

                    var user = HttpContext.Current.Session["UserInfo"] as UserInfo;

                    //记录除自己以外的浏览量
                    if (user != null)
                    {
                        if (DailyInfo.UserGuid != user.Guid)
                        {
                            DailyManager.UpdatePageView(DailyInfo.Guid, DailyInfo.PageView + 1);
                        }
                    }
                    else
                    {
                        DailyManager.UpdatePageView(DailyInfo.Guid, DailyInfo.PageView + 1);
                    }

                    //分类信息
                    CategoryInfo = CategoryManager.GetModel(DailyInfo.CategoryGuid);

                    //上一篇文章和下一篇文章
                    //var lastDailyList = DailyManager.GetTopList(1, " Create_Time < '" + DailyInfo.CreateTime + "'", "Create_Time desc");
                    //if (lastDailyList.Count > 0)
                    //{
                    //    litLast1.Text = "<a href=\"/xsblog/" + BlogName + "/daily/" + lastDailyList[0].Id + "\">" + lastDailyList[0].Name + "</a>";
                    //    litLast2.Text = litLast1.Text;
                    //}
                    //var nextDailyList = DailyManager.GetTopList(2, " Create_Time > '" + DailyInfo.CreateTime + "'", "Create_Time asc");
                    //if (nextDailyList.Count > 1)
                    //{
                    //    litNext1.Text = "<a href=\"/xsblog/" + BlogName + "/daily/" + nextDailyList[1].Id + "\">" + nextDailyList[1].Name + "</a>";
                    //    litNext2.Text = litNext1.Text;
                    //}
                }
            }

            if (CategoryInfo == null)
            {
                CategoryInfo = new CategoryInfo() {Id = 0, Name = ""};
            }
        }
    }
}