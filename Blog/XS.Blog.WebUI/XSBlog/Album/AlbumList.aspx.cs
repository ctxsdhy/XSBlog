using System;
using System.Web.UI.WebControls;
using XS.Blog.Components;
using XS.Blog.Entity;

namespace XS.Blog.WebUI.XSBlog.Album
{
    /// <summary>
    /// 相册列表
    /// </summary>
    public partial class AlbumList : PageBase
    {
        protected AlbumManager AlbumManager = new AlbumManager();
        protected PhotoManager PhotoManager = new PhotoManager();
        
        protected int AlbumCount;
        protected int PhotoCount; 

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
            var list = AlbumManager.GetList("", " Order_Id Asc ");

            rptList.DataSource = list;
            rptList.DataBind();

            AlbumCount = list.Count;
            PhotoCount = PhotoManager.GetCount("");
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
                var row = e.Item.DataItem as AlbumInfo;
                if (row != null)
                {
                    ((Label)e.Item.FindControl("lblName")).Text = row.Name;

                    //相册信息
                    var lblInfo = (Label) e.Item.FindControl("lblInfo");
                    if (lblInfo != null)
                    {
                        lblInfo.Text += PhotoManager.GetCount(" Album_Guid ='" + row.Guid + "' ") + " 张相片 ";
                        lblInfo.Text += row.CreateTime.ToString("yyyy-MM-dd");
                    }

                    //相册封面
                    var photoList = PhotoManager.GetTopList(1, " Album_Guid ='" + row.Guid + "' ", " Is_Cover desc, Create_Time asc ");
                    if (photoList.Count > 0)
                    {
                        ((Image)e.Item.FindControl("imgPhoto")).ImageUrl = photoList[0].ImageUrl + "?imageView2/1/w/160/h/160/interlace/1";
                    }
                }
            }
        }
    }
}