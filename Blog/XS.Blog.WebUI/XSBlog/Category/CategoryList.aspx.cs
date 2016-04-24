using System;
using XS.Blog.Components;

namespace XS.Blog.WebUI.XSBlog.Category
{
    /// <summary>
    /// 分类列表
    /// </summary>
    public partial class CategoryList : PageBase
    {
        protected CategoryManager CategoryManager = new CategoryManager();

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
            //获得顶级的分类
            var categoryList = CategoryManager.GetListAndCount(" Parent_Guid='00000000-0000-0000-0000-000000000000' ", "Order_Id asc");

            rptCategory.DataSource = categoryList;
            rptCategory.DataBind();
        }
    }
}