<%@ Page Title="" Language="C#" MasterPageFile="~/XSBlog/PageTemplates/BlogPageTemplate.master" AutoEventWireup="true" CodeBehind="AlbumList.aspx.cs" Inherits="XS.Blog.WebUI.XSBlog.Album.AlbumList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="BlogTitlePlaceHolder" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="BlogContentPlaceHolder" runat="server">
    <div class="album album-mini">
        <div class="album-content">
            <div class="album-content-title" style="display: none;">
                共有<%=AlbumCount %>个相册 <%=PhotoCount %>张照片
            </div>
            <div class="album-content-main">
                <asp:Repeater runat="server" ID="rptList" OnItemDataBound="rptList_ItemDataBound">
                    <ItemTemplate>
                        <div class="album-content-main-item">
                            <div class="a-c-m-i-outbox">
                                <div class="a-c-m-i-box">
                                    <a href='/xsblog/<%=BlogName %>/album/<%# Eval("Id") %>'>
                                        <asp:Image ID="imgPhoto" CssClass="a-c-m-i-a-image" runat="server" />
                                    </a>
                                </div>
                            </div>
                            <div class="a-c-m-i-title">
                                <a class="a-c-m-i-t-a" href="/xsblog/<%=BlogName %>/album/<%# Eval("Id") %>">
                                    <asp:Label runat="server" ID="lblName" />
                                </a>
                            </div>
                            <div class="a-c-m-i-info">
                                <asp:Label runat="server" ID="lblInfo"></asp:Label>
                            </div>
                        </div>
                    </ItemTemplate>
                </asp:Repeater>
                <div class="clear"></div>
                <div style="height: 38px;"></div>
            </div>
        </div>
    </div>
</asp:Content>
