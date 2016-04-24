using System;
using System.Collections.Generic;
using System.Web;
using XS.Blog;
using XS.Blog.Entity;
using XS.Framework.Utility.Serialization;

/// <summary>
/// Album 的摘要说明
/// </summary>
public class SetPhotoHandler : Handler
{
    private PhotoManager _photoBll = new PhotoManager();
    private AlbumInfo[] albumStr;
    private string UserGuid { get; set; }

    public SetPhotoHandler(HttpContext context, string userGuid) : base(context)
    {
        UserGuid = userGuid;
    }

    public override void Process()
    {
        var photoList = Request["photoList"];
        var albumId = Request["albumId"];

        if (!string.IsNullOrEmpty(albumId))
        {
            var list = JsonSerializer.DeserializeObject<List<PhotoInfo>>(photoList);

            foreach (var info in list)
            {
                info.Createtime = DateTime.Now;
                info.UserGuid = UserGuid;
                info.AlbumGuid = albumId;

                _photoBll.Add(info);
            }
        }

        WriteJson(new { 
            state = "SUCCESS"
        });
    }
}