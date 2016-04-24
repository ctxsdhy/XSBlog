using System;
using System.Text;
using System.Web;
using XS.Blog.Components;
using XS.Blog.Entity;

namespace XS.Blog.WebUI.XSBlog.Archive
{
    /// <summary>
    /// 归档列表
    /// </summary>
    public partial class Archive : PageBase
    {
        protected DailyManager DailyManager = new DailyManager();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                InitControl();
            }
        }

        /// <summary>
        /// 初始化控件
        /// </summary>
        public void InitControl()
        {
            var str = new StringBuilder();
            var strWhere = "";
            var user = HttpContext.Current.Session["UserInfo"] as UserInfo;
            
            //显示登录用户可见和自己可见的文章
            if (user != null)
            {
                strWhere += " (Is_Special=0 or Is_Special=1 or (Is_Special=2 and User_Guid='" + user.Guid + "')) ";
            }
            else
            {
                strWhere += " Is_Special=0 ";
            }
            var dailyList = DailyManager.GetList(strWhere, " Create_Time desc ");

            if (dailyList.Count > 0)
            {
                var dateTime = dailyList[0].CreateTime;

                str.Append("<div class=\"a-m-item\">");
                str.Append("<div class=\"a-m-i-date\">" +
                           dateTime.ToString("MMM", new System.Globalization.CultureInfo("zh-cn")) + "&nbsp;" +
                           dateTime.Year +
                           "</div>");
                str.Append("<div class=\"a-m-i-content\">");

                //遍历月份拼接前台html（这里用前端写比较好）
                foreach (var dailyInfo in dailyList)
                {
                    if (dailyInfo.CreateTime.Year != dateTime.Year || dailyInfo.CreateTime.Month != dateTime.Month)
                    {
                        str.Append("</div><div class=\"clear\"></div></div>");
                        dateTime = dailyInfo.CreateTime;
                        str.Append("<div class=\"a-m-item\">");
                        str.Append("<div class=\"a-m-i-date\">" +
                           dateTime.ToString("MMM", new System.Globalization.CultureInfo("zh-cn")) + "&nbsp;" +
                           dateTime.Year +
                           "</div>");
                        str.Append("<div class=\"a-m-i-content\">");
                    }

                    str.Append("<span class=\"a-m-i-c-span\">" + dailyInfo.CreateTime.ToString("dd日") + "&nbsp;&nbsp;&nbsp;&nbsp;" + "<a href=\"/xsblog/" + BlogName + "/daily/" + dailyInfo.Id + "\" target=\"_blank\">" + dailyInfo.Name + "</a></span>");
                }

                str.Append("</div><div class=\"clear\"></div></div>");

                litArchiveList.Text = str.ToString();
            }
        }
    }
}