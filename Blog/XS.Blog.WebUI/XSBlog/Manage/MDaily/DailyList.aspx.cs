﻿using System;
using System.Web;
using XS.Blog.Components;
using XS.Blog.Entity;
using XS.Framework.Utility;

namespace XS.Blog.WebUI.XSBlog.Manage.MDaily
{
    /// <summary>
    /// 文章列表
    /// </summary>
    public partial class DailyList : PagePermission
    {
        protected DailyManager DailyBll = new DailyManager();
        protected CategoryManager CategoryBll = new CategoryManager();
        protected UserManager UserBll = new UserManager();

        protected void Page_Load(object sender, EventArgs e)
        {
            InitializePageControls(pager, rptList);
            SetButtonValidScript(btnUpdate, btnDelete, null);
            if (!IsPostBack)
            {
                BindData();
            }
        }

        private void BindData()
        {
            var dailyBll = new DailyManager();
            int recordCount;
            var strWhere = "";
            var blog = HttpContext.Current.Session["BlogInfo"] as BlogInfo;
            if (blog != null)
            {
                strWhere += " Blog_Guid='" + blog.Guid + "'";
            }

            var list = dailyBll.GetList(PageIndex, PageSize, out recordCount, strWhere, "Create_Time desc");
            base.BindRepeater(recordCount, list);
        }

        /// <summary>
        /// 保存事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnAdd_Click(object sender, EventArgs e)
        {
            Response.Redirect("DailyEdit.aspx");
        }

        /// <summary>
        /// 修改事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            var guid = FormHelper.GetRepeaterSelectedRowId(rptList).TrimStart('\'').TrimEnd('\'');
            var url = string.Format("DailyEdit.aspx?guid={0}", guid);
            Response.Redirect(url);
        }

        /// <summary>
        /// 删除事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnDelete_Click(object sender, EventArgs e)
        {
            var guids = FormHelper.GetRepeaterSelectedRowId(rptList);
            DailyBll.DeleteByGuIds(guids);
            BindData();
        }
    }
}