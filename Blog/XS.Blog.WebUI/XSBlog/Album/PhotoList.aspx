<%@ Page Title="" Language="C#" MasterPageFile="~/XSBlog/PageTemplates/BlogPageTemplate.master" AutoEventWireup="true" CodeBehind="PhotoList.aspx.cs" Inherits="XS.Blog.WebUI.XSBlog.Album.PhotoList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="BlogTitlePlaceHolder" runat="server">
    <script type="text/javascript">
        //多说控件
        var duoshuoQuery = { short_name: "ctxsdhy" };
        (function () {
            var ds = document.createElement('script');
            ds.type = 'text/javascript'; ds.async = true;
            ds.src = (document.location.protocol == 'https:' ? 'https:' : 'http:') + '//static.duoshuo.com/embed.js';
            ds.charset = 'UTF-8';
            (document.getElementsByTagName('head')[0]
                || document.getElementsByTagName('body')[0]).appendChild(ds);
        })();

        $(function () {
            var firstImage = $(".a-p-l-c-m-i-b-firstImage");
            var left = firstImage.position().left + (firstImage.parent().width() - firstImage.parent().children().width() - 6) / 2;
            if (left >= firstImage.position().left && left < 58)
                firstImage.css("left", left);
        });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="BlogContentPlaceHolder" runat="server">
    <div class="album album-mini">
        <div class="album-content">
            <div class="a-p-l-c-title">
                <div>
                    <span class="a-p-l-c-t-name">
                        <asp:Label runat="server" ID="lblName" />
                    </span>
                    <a class="a-p-l-c-t-return" href="/xsblog/<%=BlogName %>/album">返回所有相册<i class="icon-double-angle-right"></i>
                    </a>
                </div>
                <span class="a-p-l-c-t-info">
                    <%=PhotoCount%>张相片&nbsp;&nbsp;<%--浏览8&nbsp;&nbsp;评论0&nbsp;&nbsp;--%>创建于<%=AlbumInfo.CreateTime.ToString("yyyy-MM-dd HH:mm") %>
                </span>
            </div>
            <div class="a-p-l-c-main">
                <asp:Repeater runat="server" ID="rptList" OnItemDataBound="rptList_ItemDataBound">
                    <ItemTemplate>
                        <div class="a-p-l-c-m-item">
                            <div class="a-p-l-c-m-i-box">
                                <a href='/xsblog/<%=BlogName %>/album/<%=AlbumId %>/p/<%#Eval("Id") %>' target="_blank">
                                    <div class="a-p-l-c-m-i-b-box">
                                        <img class="a-p-l-c-m-i-b-image" src="<%#Eval("imageUrl")+"?imageView2/2/w/130/h/150/interlace/1" %>" />
                                        <asp:Literal runat="server" ID="litFirstImage" />
                                    </div>
                                </a>
                            </div>
                        </div>
                    </ItemTemplate>
                </asp:Repeater>
                <div class="clear"></div>
            </div>
            <webdiyer:AspNetPager ID="pager" runat="server" HorizontalAlign="Center" EnableUrlRewriting="True" UrlRewritePattern="/xsblog/%BlogName%/album/%AlbumId%/{0}" />
            <div class="daily-content-comment">
                <div class="d-c-c-content">
                    <div class="ds-thread" data-thread-key="<%=AlbumInfo.Guid %>" data-title="<%=AlbumInfo.Name %>" data-url="<%=Request.Url.ToString() %>" style="width: 100%"></div>
                </div>
                <div class="d-c-c-bottom"></div>
            </div>
        </div>
    </div>
</asp:Content>
