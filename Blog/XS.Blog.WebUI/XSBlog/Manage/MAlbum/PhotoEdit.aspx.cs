using System;
using System.Web;
using XS.Blog.Components;
using XS.Blog.Components.Helper;
using XS.Blog.Entity;
using XS.Framework.Utility;

namespace XS.Blog.WebUI.XSBlog.Manage.MAlbum
{
    /// <summary>
    /// 照片编辑
    /// </summary>
    public partial class PhotoEdit : PagePermission
    {
        protected PhotoManager PhotoBll = new PhotoManager();
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
            if (!IsPostBack)
            {
                if (!string.IsNullOrEmpty(StrGuid))
                {
                    var info = PhotoBll.GetModel(StrGuid);
                    if (info != null)
                    {
                        tbName.Text = info.Name;
                        tbTag.Text = info.Tag;
                        chkCover.Checked = info.IsCover;
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
            var imageFile = GetImage();
            if (imageFile != null)
            {
                if (string.IsNullOrEmpty(StrGuid))
                {
                    var info = new PhotoInfo();

                    var ret = QiniuHelper.GetResult(imageFile);
                    if (ret.OK)
                    {
                        info.ImageUrl = QiniuHelper.GetUrl(ret.key);
                        info.ImageKey = ret.key;

                        info.Name = tbName.Text;
                        info.Tag = tbTag.Text;
                        info.IsCover = chkCover.Checked;

                        var user = HttpContext.Current.Session["UserInfo"] as UserInfo;
                        if (user != null)
                        {
                            info.UserGuid = user.Guid;
                        }

                        info.Createtime = DateTime.Now;
                        info.AlbumGuid = AlbumGuid;

                        PhotoBll.Add(info);

                        ScriptHelper.AlertAndRedirect("添加成功", "PhotoList.aspx?albumguid=" + AlbumGuid);
                    }
                    else
                    {
                        Util.ScriptHelper.Alert2("上传失败");
                    }
                }
                else
                {
                    var info = PhotoBll.GetModel(StrGuid);

                    var ret = QiniuHelper.GetResult(imageFile);
                    if (ret.OK)
                    {
                        QiniuHelper.DeleteData(info.ImageKey);

                        info.ImageUrl = QiniuHelper.GetUrl(ret.key);
                        info.ImageKey = ret.key;

                        info.Name = tbName.Text;
                        info.Tag = tbTag.Text;
                        info.IsCover = chkCover.Checked;

                        var user = HttpContext.Current.Session["UserInfo"] as UserInfo;
                        if (user != null)
                        {
                            info.UserGuid = user.Guid;
                        }

                        info.Createtime = DateTime.Now;
                        info.AlbumGuid = AlbumGuid;

                        PhotoBll.Update(info);

                        ScriptHelper.AlertAndRedirect("修改成功", "PhotoList.aspx?albumguid=" + AlbumGuid);
                    }
                    else
                    {
                        Util.ScriptHelper.Alert2("上传失败");
                    }
                }
            }
            else
            {
                if (string.IsNullOrEmpty(StrGuid))
                {
                    Util.ScriptHelper.Alert2("没有文件");
                }
                else
                {
                    var info = PhotoBll.GetModel(StrGuid);

                    info.Name = tbName.Text;
                    info.Tag = tbTag.Text;
                    info.IsCover = chkCover.Checked;

                    PhotoBll.Update(info);

                    ScriptHelper.AlertAndRedirect("修改信息成功", "PhotoList.aspx?albumguid=" + AlbumGuid);
                }
            }
        }

        /// <summary>
        /// 返回事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void BtnReturn_OnClick(object sender, EventArgs e)
        {
            Response.Redirect("PhotoList.aspx?albumguid=" + AlbumGuid);
        }

        /// <summary>
        /// 获得图片
        /// </summary>
        /// <returns></returns>
        private byte[] GetImage()
        {
            if (!string.IsNullOrEmpty(FileImage.Value))
            {
                Byte[] data = null;
                var imageFile = FileImage.PostedFile;//HttpPostedFile对象，用于读取图象文件属性
                var fileLength = imageFile.ContentLength;//记录文件长度 
                if (fileLength != 0)
                {
                    var fileByteArray = new Byte[fileLength]; //图象文件临时储存Byte数组 
                    var streamObject = imageFile.InputStream; //建立数据流对像 
                    //读取图象文件数据，FileByteArray为数据储存体，0为数据指针位置、FileLnegth为数据长度 
                    streamObject.Read(fileByteArray, 0, fileLength);
                    //图片数据
                    data = fileByteArray;
                }
                return data;
            }
            return null;
        }
    }
}