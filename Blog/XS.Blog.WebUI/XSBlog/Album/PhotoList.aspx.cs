using System;
using System.Web.UI.WebControls;
using XS.Blog.Components;
using XS.Blog.Entity;
using XS.Framework.Utility;

namespace XS.Blog.WebUI.XSBlog.Album
{
    /// <summary>
    /// 照片列表
    /// </summary>
    public partial class PhotoList : PageBase
    {
        protected AlbumManager AlbumManager = new AlbumManager();
        protected PhotoManager PhotoManager = new PhotoManager();

        protected AlbumInfo AlbumInfo = new AlbumInfo();
        protected int PhotoCount; 

        protected string AlbumId
        {
            get
            {
                if (Request.QueryString["albumid"] != null)
                {
                    return Request.QueryString["albumid"].ToUpper();
                }
                return "";
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            InitializePageControls(pager, rptList);
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
            var albumInfo = AlbumManager.GetModelById(ConvertHelper.GetInt(AlbumId));
            if (albumInfo != null)
            {
                lblName.Text = albumInfo.Name;
                PageSize = 24;
                int recordCount;
                var list = PhotoManager.GetList(PageIndex, PageSize, out recordCount, " Album_Guid ='" + albumInfo.Guid + "' ", " Is_Cover desc, Create_Time asc ");
                base.BindRepeater(recordCount, list);

                PhotoCount = list.Count;
                AlbumInfo = albumInfo;
            }
        }

        /// <summary>
        /// 列表绑定事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void rptList_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                var row = e.Item.DataItem as PhotoInfo;
                if (row != null)
                {
                    //第一张照片增加样式
                    if (e.Item.ItemIndex == 0 && PageIndex == 1)
                    {
                        ((Literal)e.Item.FindControl("litFirstImage")).Text = "<span class=\"a-p-l-c-m-i-b-firstImage\">&nbsp;</span>";
                    }
                }
            }
        }
    }
}