using System;
using System.Web.UI;
using XS.Blog.Components;

namespace XS.Blog.WebUI.XSBlog.Home
{
    /// <summary>
    /// 首页
    /// </summary>
    public partial class Home : PageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            InitControls();   
        }

        /// <summary>
        /// 初始化控件
        /// </summary>
        private void InitControls()
        {
            //文章列表模块
            var dailyBox = Page.LoadControl("~/XSBlog/Home/Modules/DailyBox.ascx") as IHomeModule;
            if ((Control)dailyBox != null)
            {
                dailyBox.InitControl();
                PlaceHolderLeft.Controls.Add(dailyBox as Control);
            }

            //个人说明模块
            var profileBox = Page.LoadControl("~/XSBlog/Home/Modules/ProfileBox.ascx") as IHomeModule;
            if ((Control)profileBox != null)
            {
                profileBox.InitControl();
                PlaceHolderCenter.Controls.Add(profileBox as Control);
            }

            //虾米音乐模块
            var musicBox = Page.LoadControl("~/XSBlog/Home/Modules/MusicBox.ascx") as IHomeModule;
            if ((Control)musicBox != null)
            {
                musicBox.InitControl();
                PlaceHolderCenter.Controls.Add(musicBox as Control);
            }

            //新浪微博模块
            var sinaBox = Page.LoadControl("~/XSBlog/Home/Modules/SinaBox.ascx") as IHomeModule;
            if ((Control)sinaBox != null)
            {
                sinaBox.InitControl();
                PlaceHolderCenter.Controls.Add(sinaBox as Control);
            }
        }
    }
}