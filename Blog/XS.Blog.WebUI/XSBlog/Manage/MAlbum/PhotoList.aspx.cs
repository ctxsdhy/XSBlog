using System;
using XS.Blog.Components;
using XS.Blog.Components.Helper;
using XS.Framework.Utility;

namespace XS.Blog.WebUI.XSBlog.Manage.MAlbum
{
    /// <summary>
    /// 照片列表
    /// </summary>
    public partial class PhotoList : PagePermission
    {
        protected PhotoManager PhotoBll = new PhotoManager();

        protected string AlbumGuid
        {
            get
            {
                if (Request.QueryString["albumguid"] != null)
                {
                    return Request.QueryString["albumguid"].ToUpper();
                }
                return "";
            }
        }

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
            int recordCount;
            var strWhere = "";
            strWhere += "Album_Guid='" + AlbumGuid + "'";

            var list = PhotoBll.GetList(PageIndex, PageSize, out recordCount, strWhere, "Create_time asc");
            base.BindRepeater(recordCount, list);
        }

        /// <summary>
        /// 保存事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnAdd_Click(object sender, EventArgs e)
        {
            Response.Redirect("PhotoEdit.aspx?albumguid=" + AlbumGuid);
        }

        /// <summary>
        /// 修改事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            var guid = FormHelper.GetRepeaterSelectedRowId(rptList).TrimStart('\'').TrimEnd('\'');
            var url = string.Format("PhotoEdit.aspx?guid={0}&albumguid={1}", guid, AlbumGuid);
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

            //批量删除
            PhotoBll.DeleteByGuIds(guids);

            //七牛批量删除
            QiniuHelper.DeleteDatas(imageKeys);

            BindData();
        }
    }
}