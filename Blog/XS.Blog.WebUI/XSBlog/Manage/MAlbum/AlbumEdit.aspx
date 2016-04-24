<%@ Page Title="" Language="C#" MasterPageFile="~/XSBlog/PageTemplates/ManageTemplate.master" AutoEventWireup="true" CodeBehind="AlbumEdit.aspx.cs" Inherits="XS.Blog.WebUI.XSBlog.Manage.MAlbum.AlbumEdit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ManageTitlePlaceHolder" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ManageContentPlaceHolder" runat="server">
    相册：<asp:TextBox runat="server" ID="tbName" />
    <br />
    序号：<asp:TextBox runat="server" ID="tbOrderId"></asp:TextBox>
    <br />
    <asp:Button runat="server" ID="btnSave" Text="保存" OnClick="BtnSave_OnClick" CssClass="btn btn-default"/>
    <asp:Button runat="server" ID="btnReturn" Text="返回" OnClick="BtnReturn_OnClick" CssClass="btn btn-default"/>
</asp:Content>
