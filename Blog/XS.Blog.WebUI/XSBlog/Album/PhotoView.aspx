<%@ Page Title="" Language="C#" MasterPageFile="~/XSBlog/PageTemplates/BlogPageTemplate.master" AutoEventWireup="true" CodeBehind="PhotoView.aspx.cs" Inherits="XS.Blog.WebUI.XSBlog.Album.PhotoView" %>

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
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="BlogContentPlaceHolder" runat="server">
    <div class="album-mini">
        <div class="album-content">
            <div class="a-p-v-c-title">
                <a href='/xsblog/<%=BlogName %>/album'>所有相册</a>&nbsp;
                <i class="icon-double-angle-right"></i>&nbsp;
                <a href='/xsblog/<%=BlogName %>/album/<%=AlbumId %>'><%=AlbumInfo.Name %></a>
                <%--<a href='javascript:history.go(-1);'><%=AlbumInfo.Name %></a>--%>
            </div>
            <div class="a-p-v-c-main">
                <img class="a-p-v-c-m-image" src='<%=PhotoInfo.ImageUrl + "?imageView2/2/w/960/interlace/1" %>' />
            </div>
            <div class="daily-content-comment">
                <div class="d-c-c-content">
                    <div class="ds-thread" data-thread-key="<%=PhotoInfo.Guid %>" data-title="<%=PhotoInfo.Name %>" data-url="<%=Request.Url.ToString() %>" style="width: 100%"></div>
                </div>
                <div class="d-c-c-bottom"></div>
            </div>
        </div>
    </div>
</asp:Content>
