using System;
using System.Web;
using XS.Blog.Components;
using XS.Blog.Components.Helper;
using XS.Blog.Entity;
using XS.Framework.Utility;

namespace XS.Blog.WebUI.XSBlog.Manage.MCategory
{
    /// <summary>
    /// 分类编辑
    /// </summary>
    public partial class CategoryEdit : PagePermission
    {
        protected CategoryManager CategoryBll = new CategoryManager();
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
                //绑定分类列表
                var categoryList = CategoryBll.GetTreeList();
                categoryList.Insert(0, new CategoryInfo() { Name = "顶级类别", Guid = "00000000-0000-0000-0000-000000000000" });
                ddlParentCategory.DataSource = categoryList;
                ddlParentCategory.DataTextField = "Name";
                ddlParentCategory.DataValueField = "Guid";
                ddlParentCategory.DataBind();

                if (!string.IsNullOrEmpty(StrGuid))
                {
                    var info = CategoryBll.GetModel(StrGuid);
                    if (info != null)
                    {
                        tbName.Text = info.Name;
                        tbOrderId.Text = info.OrderId.ToString();
                        ddlParentCategory.SelectedValue = info.ParentGuid;
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

            if (string.IsNullOrEmpty(StrGuid))
            {
                var info = new CategoryInfo();

                info.Name = tbName.Text;
                info.OrderId = ConvertHelper.GetInt(tbOrderId.Text);
                info.ParentGuid = ddlParentCategory.SelectedValue;
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
                if (imageFile != null)
                {
                    var ret = QiniuHelper.GetResult(imageFile);
                    if (ret.OK)
                    {
                        info.ImageUrl = QiniuHelper.GetUrl(ret.key);
                        info.ImageKey = ret.key;
                    }
                    else
                    {
                        ScriptHelper.Alert("图片上传失败");
                    }
                }

                CategoryBll.Add(info);
            }
            else
            {
                var info = CategoryBll.GetModel(StrGuid);

                info.Name = tbName.Text;
                info.OrderId = ConvertHelper.GetInt(tbOrderId.Text);
                info.ParentGuid = ddlParentCategory.SelectedValue;
                if (imageFile != null)
                {
                    var ret = QiniuHelper.GetResult(imageFile);
                    if (ret.OK)
                    {
                        info.ImageUrl = QiniuHelper.GetUrl(ret.key);
                        info.ImageKey = ret.key;
                    }
                    else
                    {
                        ScriptHelper.Alert("图片上传失败");
                    }
                }

                CategoryBll.Update(info);
            }


            Response.Redirect("CategoryList.aspx");
        }

        /// <summary>
        /// 返回事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void BtnReturn_OnClick(object sender, EventArgs e)
        {
            Response.Redirect("CategoryList.aspx");
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