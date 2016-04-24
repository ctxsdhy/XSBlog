using System.Collections.Generic;
using System.Web.UI.WebControls;
using Wuqi.Webdiyer;
using XS.Framework.Utility;

namespace XS.Blog.Components
{
    /// <summary>
    /// 页面基类
    /// </summary>
    public class PageBase : System.Web.UI.Page
    {
        /// <summary>
        /// 页长
        /// </summary>
        protected int _pageSize = 10;

        /// <summary>
        /// 分页控件
        /// </summary>
        private AspNetPager _pager;

        /// <summary>
        /// 设置“Repeater”控件的引用
        /// </summary>
        private Repeater _repeater;

        /// <summary>
        /// 初始化页面控件(不要放在IsPostBack中)
        /// </summary>
        /// <param name="pager"></param>
        /// <param name="repeater1"></param>
        protected void InitializePageControls(AspNetPager pager, Repeater repeater1)
        {
            this._repeater = repeater1;
            this._pager = pager;
        }

        /// <summary>
        /// 使用实体数据集合绑定Repeater控件
        /// </summary>
        /// <param name="recordCount"></param>
        /// <param name="list"></param>
        protected virtual void BindRepeater<T>(int recordCount, IList<T> list)
        {
            this._repeater.DataSource = list;
            this._repeater.DataBind();

            PaginationInfo(recordCount);
        }

        #region 分页控件

        /// <summary>
        /// 设置分页信息
        /// </summary>
        private void PaginationInfo(int recordCount)
        {
            PaginationInfo(recordCount, this._pager, this.PageSize, this.PageIndex);
        }

        /// <summary>
        /// 绑定分页控件
        /// </summary>
        /// <param name="recordCount"></param>
        /// <param name="pager"></param>
        /// <param name="pageSize"></param>
        /// <param name="pageIndex"></param>
        public static void PaginationInfo(int recordCount, AspNetPager pager, int pageSize, int pageIndex)
        {
            pager.RecordCount = recordCount;
            pager.AlwaysShow = true;
            pager.PageSize = pageSize;
            pager.PageIndexBoxType = PageIndexBoxType.DropDownList;
            pager.PageIndexBoxClass = "PageDropDown";
            pager.PageIndexBoxStyle = "width:42px;margin:0";
            pager.ShowBoxThreshold = 1;
            pager.CurrentPageIndex = pageIndex;
            //pager.HorizontalAlign = HorizontalAlign.Right;
            pager.UrlPaging = true;
            pager.ShowCustomInfoSection = ShowCustomInfoSection.Never;
            //pager.CustomInfoHTML = "当前第<b>%CurrentPageIndex%</b>/<b>%PageCount%</b>页 共<b>%RecordCount%</b>条记录 每页<b>%PageSize%</b>条&nbsp;";
            pager.CustomInfoHTML = "&nbsp;";
            pager.CustomInfoClass = "PageCustomInfo";

            pager.FirstLastButtonsStyle = "display:none";
            pager.FirstPageText = "<i class=\"icon-step-backward\"></i>";
            pager.LastPageText = "<i class=\"icon-step-forward\"></i>";
            pager.NextPageText = "<i class=\"icon-double-angle-right\"></i>";
            pager.PrevPageText = "<i class=\"icon-double-angle-left\"></i>";
            pager.CssClass = "PagingClass";
            pager.CurrentPageButtonClass = "CurrentPagingClass";
        }

        /// <summary>
        /// 页码
        /// </summary>
        protected virtual int PageIndex
        {
            get
            {
                if (this._pager == null && string.IsNullOrEmpty(Request.QueryString["page"]))
                    return 1;

                if (Request.QueryString["page"] == null || Request.QueryString["page"].Trim() == "")
                    return this._pager.CurrentPageIndex;

                return ConvertHelper.GetInt(Request.QueryString["page"], 1);
            }
            set { this._pager.CurrentPageIndex = value; }
        }

        /// <summary>
        /// 页长
        /// </summary>
        protected virtual int PageSize
        {
            get
            {
                return _pageSize;
            }
            set
            {
                _pageSize = value;
            }
        }

        #endregion

        /// <summary>
        /// 添加按钮验证属性方法
        /// </summary>
        /// <param name="btnUpdate">更新</param>
        /// <param name="btnDelete">删除</param>
        /// <param name="btnSubmit">提交</param>
        protected virtual void SetButtonValidScript(WebControl btnUpdate, WebControl btnDelete, WebControl btnSubmit)
        {
            if (btnUpdate != null) btnUpdate.Attributes.Add("onClick", "return Update();");
            if (btnDelete != null) btnDelete.Attributes.Add("onClick", "return Delete();");
            if (btnSubmit != null) btnSubmit.Attributes.Add("onClick", "return ButtonSubmit();");
        }

        public string BlogName
        {
            get
            {
                if (Request["BlogName"] != null)
                    return Request["BlogName"];
                return "";
            }
        }

        public string BlogGuid
        {
            get
            {
                if (!string.IsNullOrEmpty(BlogName))
                {
                    return new BlogManager().GetGuidByUrlName(BlogName);
                }
                return "";
            }
        }
    }
}
