<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DailyView.aspx.cs" Inherits="XS.Blog.WebUI.XSBlog.Daily.DailyView" MasterPageFile="../PageTemplates/BlogPageTemplate.master" %>

<asp:Content runat="server" ID="Content1" ContentPlaceHolderID="BlogTitlePlaceHolder">
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
        //$(function() {
        //    $(".d-c-m-content img").css("float", "left").css("max-width", "480px");
        //});
    </script>
</asp:Content>
<asp:Content runat="server" ID="Content2" ContentPlaceHolderID="BlogContentPlaceHolder">
    <div class="daily">
        <div class="daily-content">
            <div class="daily-content-top" style="display: none;">
                <div class="d-c-t-left">
                    <span>&nbsp;</span><asp:Literal runat="server" ID="litLast1" />
                </div>
                <div class="d-c-t-right">
                    <asp:Literal runat="server" ID="litNext1" /><span>&nbsp;</span>
                </div>
                <div class="clear"></div>
            </div>
            <div class="daily-content-main">
                <div class="d-c-m-name">
                    <asp:Label runat="server" ID="lblName" />
                </div>
                <div class="d-c-m-tag">
                    <asp:Label runat="server" ID="lblCreateTime" />&nbsp;|&nbsp;&nbsp;分类：&nbsp;<a href="/xsblog/<%=BlogName %>/category/<%=CategoryInfo.Id %>"><%=CategoryInfo.Name %></a>
                </div>
                <div class="d-c-m-content">
                    <asp:Literal ID="litContent" runat="server" />
                </div>
                <div class="d-c-m-operate">
                    <%--阅读(1)&nbsp;&nbsp;|&nbsp;&nbsp;&nbsp;评论(0)--%>
                </div>
            </div>
        </div>
        <div class="daily-content-bottom" style="display: none;">
            <div class="d-c-t-left d-c-b-left">
                <span>&nbsp;</span><asp:Literal runat="server" ID="litLast2" />
            </div>
            <div class="d-c-t-right">
                <asp:Literal runat="server" ID="litNext2" /><span>&nbsp;</span>
            </div>
            <div class="clear"></div>
        </div>
        <div class="daily-content-comment">
            <div class="d-c-c-content">
                <div class="ds-thread" data-thread-key="<%=DailyInfo.Guid %>" data-title="<%=DailyInfo.Name %>" data-url="<%=Request.Url.ToString() %>" style="width: 100%"></div>
            </div>
            <div class="d-c-c-bottom"></div>
        </div>
    </div>
</asp:Content>
