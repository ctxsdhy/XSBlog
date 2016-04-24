using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using XS.Blog;
using XS.Blog.Entity;

/// <summary>
/// Album 的摘要说明
/// </summary>
public class GetAlbumHandler : Handler
{
    private AlbumInfo[] albumStr;
    public GetAlbumHandler(HttpContext context) : base(context) { }

    public override void Process()
    {
        var albumList = new AlbumManager().GetList(""," Order_Id asc ");

        albumStr = albumList.ToArray();

        WriteJson(new { 
            state = "SUCCESS",
            list = albumStr.Select(x => new
            {
                id = x.Guid,
                name = x.Name
            })
        });
    }
}