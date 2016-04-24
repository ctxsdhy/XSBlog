using System;
using System.Web.UI.WebControls;
using XS.Blog.Components;
using XS.Blog.Components.Helper;
using XS.Blog.Entity;
using XS.Framework.Utility;

namespace XS.Blog.WebUI.XSBlog.Manage.MCategory
{
    /// <summary>
    /// 分类列表
    /// </summary>
    public partial class CategoryList : PagePermission
    {
        protected CategoryManager CategoryBll = new CategoryManager();

        protected void Page_Load(object sender, EventArgs e)
        {
            InitializePageControls(pager, rptList);
            SetButtonValidScript(btnUpdate, btnDelete, null);
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
            var dailyBll = new CategoryManager();
            int recordCount;
            var list = dailyBll.GetList(PageIndex, PageSize, out recordCount, "", "Order_Id asc");
            base.BindRepeater(recordCount, list);
        }

        /// <summary>
        /// 保存事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnAdd_Click(object sender, EventArgs e)
        {
            Response.Redirect("CategoryEdit.aspx");
        }

        /// <summary>
        /// 修改事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            var guid = FormHelper.GetRepeaterSelectedRowId(rptList).TrimStart('\'').TrimEnd('\'');
            var url = string.Format("CategoryEdit.aspx?guid={0}", guid);
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
            var imageKeys = FormHelper.GetRepeaterSelectedRowId(rptList, "GuId", "hfImageKey");
            CategoryBll.DeleteByGuIds(guids);
            //七牛批量删除
            QiniuHelper.DeleteDatas(imageKeys);

            BindData();
        }

        /// <summary>
        /// 绑定列表
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void rptList_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                var category = e.Item.DataItem as CategoryInfo;
                if (category != null)
                {
                    //如果没有图片就不显示
                    if (string.IsNullOrEmpty(category.ImageUrl))
                    {
                        var image = e.Item.FindControl("img");
                        if (image != null)
                        {
                            image.Visible = false;
                        }
                    }
                }
            }
        }

        /// <summary>
        /// 获得类别名称
        /// </summary>
        /// <param name="guid"></param>
        /// <returns></returns>
        protected string GetCategoryName(string guid)
        {
            if (guid == "00000000-0000-0000-0000-000000000000")
            {
                return "无";
            }
            var info = CategoryBll.GetModel(guid);
            if (info != null)
            {
                return info.Name;
            }
            return "";
        }
    }
}