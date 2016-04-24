using System;
using XS.Blog.Components;
using XS.Blog.Entity;
using XS.Framework.Utility;

namespace XS.Blog.WebUI.XSBlog.Album
{
    /// <summary>
    /// 照片浏览
    /// </summary>
    public partial class PhotoView : PageBase
    {
        protected AlbumManager AlbumManager = new AlbumManager();
        protected PhotoManager PhotoManager = new PhotoManager();

        protected AlbumInfo AlbumInfo = new AlbumInfo();
        protected PhotoInfo PhotoInfo = new PhotoInfo();

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

        protected string PhototId
        {
            get
            {
                if (Request.QueryString["photoid"] != null)
                {
                    return Request.QueryString["photoid"].ToUpper();
                }
                return "";
            }
        }

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
            //相册信息
            var albumInfo = AlbumManager.GetModelById(ConvertHelper.GetInt(AlbumId));
            if (albumInfo != null)
            {
                AlbumInfo = albumInfo;
            }

            //照片信息
            var photoInfo = PhotoManager.GetModelById(ConvertHelper.GetInt(PhototId));
            if (photoInfo != null)
            {
                PhotoInfo = photoInfo;
            }
        }
    }
}