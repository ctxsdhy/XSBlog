
namespace XS.Blog.Components
{
    /// <summary>
    /// 用户控件基类
    /// </summary>
    public class UserControlBase : System.Web.UI.UserControl
    {
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
