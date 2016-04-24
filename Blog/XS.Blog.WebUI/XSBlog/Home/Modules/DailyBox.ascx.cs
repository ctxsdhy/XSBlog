using System;
using System.Web.UI.WebControls;
using XS.Blog.Components;
using XS.Blog.Entity;

namespace XS.Blog.WebUI.XSBlog.Home.Modules
{
    /// <summary>
    /// 文章列表模块
    /// </summary>
    public partial class DailyBox : UserControlBase, IHomeModule
    {
        protected string ReadMoreVisible;

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// 初始化控件
        /// </summary>
        public void InitControl()
        {
            var dailyManager = new DailyManager();

            //获取前5条文章列表
            var dailyList = dailyManager.GetTopList(5, " Blog_Guid='" + BlogGuid + "' and Is_Home = 1 ", " Is_Stick desc, Create_Time desc ");

            if (dailyList.Count < 5)
            {
                ReadMoreVisible = "display:none";
            }

            rptDaily.DataSource = dailyList;
            rptDaily.DataBind();
        }

        /// <summary>
        /// 列表绑定事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void rptDaily_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                var row = e.Item.DataItem as DailyInfo;
                if (row != null)
                {
                    var firstImageUrl = "";

                    //获得文章摘要
                    var summary = DailyHelper.GetContentSummary(row.Content, 80, false, false, ref firstImageUrl);

                    //去除摘要以后产生的换行符
                    if (!string.IsNullOrEmpty(summary))
                    {
                        summary = summary.Replace("<br/>", "");
                    }

                    ((Literal) e.Item.FindControl("litContent")).Text = summary;

                    //展示第一张图片
                    if (!string.IsNullOrEmpty(firstImageUrl))
                    {
                        if (firstImageUrl.IndexOf("?imageView") > -1)
                        {
                            firstImageUrl = firstImageUrl.Substring(0, firstImageUrl.IndexOf("?imageView")) +
                                            "?imageView2/1/w/220/h/150/interlace/1";
                        }
                        else
                        {
                            firstImageUrl += "?imageView2/1/w/220/h/150/interlace/1";
                        }

                        ((Image)e.Item.FindControl("imgDailyImage")).ImageUrl = firstImageUrl;
                    }
                    else
                    {
                        (e.Item.FindControl("plImage")).Visible = false;
                    }
                }
            }
        }
    }
}