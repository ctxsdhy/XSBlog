using System;
using System.Web;
using XS.Blog.Components;
using XS.Blog.Entity;
using XS.Framework.Utility;

namespace XS.Blog.WebUI.XSBlog.Manage.MAlbum
{
    /// <summary>
    /// 相册编辑
    /// </summary>
    public partial class AlbumEdit : PagePermission
    {
        protected AlbumManager AlbumBll = new AlbumManager();
        protected string EditContent = string.Empty;

        protected string StrGuid
        {
            get
            {
                if (Request.QueryString["guid"] != null)
                {
                    return Request.QueryString["guid"];
                }
                return "";
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (!string.IsNullOrEmpty(StrGuid))
                {
                    var info = AlbumBll.GetModel(StrGuid);
                    if (info != null)
                    {
                        tbName.Text = info.Name;
                        tbOrderId.Text = info.OrderId.ToString();
                    }
                }
            }
        }

        /// <summary>
        /// 保存事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void BtnSave_OnClick(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(StrGuid))
            {
                var info = new AlbumInfo();

                info.Name = tbName.Text;
                info.OrderId = ConvertHelper.GetInt(tbOrderId.Text);
                var user = HttpContext.Current.Session["UserInfo"] as UserInfo;
                if (user != null)
                {
                    info.UserGuid = user.Guid;
                }
                var blog = HttpContext.Current.Session["BlogInfo"] as BlogInfo;
                if (blog != null)
                {
                    info.BlogGuid = blog.Guid;
                }
                info.CreateTime = DateTime.Now;

                AlbumBll.Add(info);
            }
            else
            {
                var info = AlbumBll.GetModel(StrGuid);
                info.Name = tbName.Text;
                info.OrderId = ConvertHelper.GetInt(tbOrderId.Text);

                AlbumBll.Update(info);
            }

            Response.Redirect("AlbumList.aspx");
        }

        /// <summary>
        /// 返回事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void BtnReturn_OnClick(object sender, EventArgs e)
        {
            Response.Redirect("AlbumList.aspx");
        }
    }
}