using System;
using XS.Blog.Components;

namespace XS.Blog.WebUI.XSBlog.Mood
{
    /// <summary>
    /// 心情列表
    /// </summary>
    public partial class MoodList : PageBase
    {
        protected MoodManager MoodManager = new MoodManager();

        protected void Page_Load(object sender, EventArgs e)
        {
            InitializePageControls(pager, rptMood);
            if (!IsPostBack)
            {
                BindData();
            }
        }

        /// <summary>
        /// 绑定数据
        /// </summary>
        private void BindData()
        {
            int recordCount;
            var list = MoodManager.GetList(PageIndex, PageSize, out recordCount, "", "Create_Time desc");
            base.BindRepeater(recordCount, list);
        }
    }
}