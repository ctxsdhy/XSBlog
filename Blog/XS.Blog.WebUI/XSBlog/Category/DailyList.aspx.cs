using System;
using System.Web;
using System.Web.UI.WebControls;
using XS.Blog.Components;
using XS.Blog.Entity;
using XS.Framework.Utility;

namespace XS.Blog.WebUI.XSBlog.Category
{
    /// <summary>
    /// 分类文章列表
    /// </summary>
    public partial class DailyList : PageBase
    {
        protected DailyManager DailyManager = new DailyManager();
        protected CategoryManager CategoryManager = new CategoryManager();

        protected string Category
        {
            get
            {
                if (Request.QueryString["Category"] != null)
                    return Request.QueryString["Category"];
                return "0";
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            InitializePageControls(pager, rptDaily);
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
            //日志列表
            int recordCount;
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

            //获得分类下的文章列表
            var categoryInfo = CategoryManager.GetModelById(ConvertHelper.GetInt(Category));
            if (categoryInfo != null)
            {
                strWhere += " and (Category_Guid='" + categoryInfo.Guid + "' or Category_Guid in (select Guid from dbo.F_XSBlog_GetCategorys('" + categoryInfo.Guid + "'))) ";
            }
            var dailyList = DailyManager.GetList(PageIndex, PageSize, out recordCount, strWhere, "Create_Time desc");
            base.BindRepeater(recordCount, dailyList);
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
                    var summary = DailyHelper.GetContentSummary(row.Content, 118, false, false, ref firstImageUrl);

                    //去除摘要以后产生的换行符
                    if (!string.IsNullOrEmpty(summary))
                    {
                        summary = summary.Replace("<br/>", "");
                    }

                    ((Literal)e.Item.FindControl("litContent")).Text = summary;

                    //展示第一张图片
                    if (!string.IsNullOrEmpty(firstImageUrl))
                    {
                        if (firstImageUrl.IndexOf("?imageView") > -1)
                        {
                            firstImageUrl = firstImageUrl.Substring(0, firstImageUrl.IndexOf("?imageView")) +
                                            "?imageView2/1/w/780/h/400/interlace/1";
                        }
                        else
                        {
                            firstImageUrl += "?imageView2/1/w/780/h/400/interlace/1";
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