<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="XS.Blog.WebUI.XSBlog.Home.Home" MasterPageFile="~/XSBlog/PageTemplates/BlogPageTemplate.master"%>
<asp:Content runat="server" ID="Content1" ContentPlaceHolderID="BlogTitlePlaceHolder"/>
<asp:Content runat="server" ID="Content2" ContentPlaceHolderID="BlogContentPlaceHolder">
    <div class="home">
        <div class="home-left">
            <asp:PlaceHolder ID="PlaceHolderLeft" runat="server"/>
        </div>
        <div class="home-center">
            <asp:PlaceHolder ID="PlaceHolderCenter" runat="server"/>
        </div>
        <div class="home-right">
            <asp:PlaceHolder ID="PlaceHolderRight" runat="server"/>
        </div>
        <div class="clear"></div>
    </div>
</asp:Content>
