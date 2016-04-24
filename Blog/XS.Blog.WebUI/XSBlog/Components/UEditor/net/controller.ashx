<%@ WebHandler Language="C#" Class="UEditorHandler" %>

using System.Web;
using System.Web.SessionState;
using XS.Blog.Entity;

public class UEditorHandler : IHttpHandler, IRequiresSessionState
{
    public void ProcessRequest(HttpContext context)
    {
        Handler action = null;
        switch (context.Request["action"])
        {
            case "config": //��ȡ���� 
                action = new ConfigHandler(context);
                break;
            case "uploadimage": //�ϴ�ͼƬ
                action = new QiniuUploadHandler(context, new UploadConfig()
                {
                    AllowExtensions = Config.GetStringList("imageAllowFiles"),
                    PathFormat = Config.GetString("imagePathFormat"),
                    SizeLimit = Config.GetInt("imageMaxSize"),
                    UploadFieldName = Config.GetString("imageFieldName")
                });
                break;
            case "getAlbumList" : //��ȡ���
                action = new GetAlbumHandler(context);
                break;
            case "setPhotoList" : //��ȡ��Ƭ�б�
                var userGuid = "";
                var user = HttpContext.Current.Session["UserInfo"] as UserInfo;
                if (user != null)
                {
                    userGuid = user.Guid;
                }
                action = new SetPhotoHandler(context, userGuid);
                break;
            case "uploadscrawl": //�ϴ�Ϳѻ
                action = new UploadHandler(context, new UploadConfig()
                {
                    AllowExtensions = new string[] { ".png" },
                    PathFormat = Config.GetString("scrawlPathFormat"),
                    SizeLimit = Config.GetInt("scrawlMaxSize"),
                    UploadFieldName = Config.GetString("scrawlFieldName"),
                    Base64 = true,
                    Base64Filename = "scrawl.png"
                });
                break;
            case "uploadvideo": //�ϴ���Ƶ
                action = new UploadHandler(context, new UploadConfig()
                {
                    AllowExtensions = Config.GetStringList("videoAllowFiles"),
                    PathFormat = Config.GetString("videoPathFormat"),
                    SizeLimit = Config.GetInt("videoMaxSize"),
                    UploadFieldName = Config.GetString("videoFieldName")
                });
                break;
            case "uploadfile": //�ϴ��ļ�
                action = new UploadHandler(context, new UploadConfig()
                {
                    AllowExtensions = Config.GetStringList("fileAllowFiles"),
                    PathFormat = Config.GetString("filePathFormat"),
                    SizeLimit = Config.GetInt("fileMaxSize"),
                    UploadFieldName = Config.GetString("fileFieldName")
                });
                break;
            case "listimage": //��ȡͼƬ�б�
                action = new ListFileManager(context, Config.GetString("imageManagerListPath"), Config.GetStringList("imageManagerAllowFiles"));
                break;
            case "listfile": //��ȡ�ļ��б�
                action = new ListFileManager(context, Config.GetString("fileManagerListPath"), Config.GetStringList("fileManagerAllowFiles"));
                break;
            //case "catchimage": //��קͼƬ�ϴ�
            //    action = new QiniuCrawlerHandler(context);
            //    break;
            default:
                action = new NotSupportedHandler(context);
                break;
        }
        action.Process();
    }

    public bool IsReusable
    {
        get
        {
            return false;
        }
    }
}