<%@ Page Title="" Language="C#" MasterPageFile="~/XSBlog/PageTemplates/ManageTemplate.master" AutoEventWireup="true" CodeBehind="PhotoEdit.aspx.cs" Inherits="XS.Blog.WebUI.XSBlog.Manage.MAlbum.PhotoEdit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ManageTitlePlaceHolder" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ManageContentPlaceHolder" runat="server">
    名称：<asp:TextBox runat="server" ID="tbName" />
    <br />
    照片：<input runat="server" id="FileImage" type="file" />
    <br />
    简介：<asp:TextBox runat="server" ID="tbTag" />
    <br />
    封面：<asp:CheckBox runat="server" ID="chkCover"/>
    <br />
    <asp:Button runat="server" ID="btnSave" Text="保存" OnClick="BtnSave_OnClick" CssClass="btn btn-default"/>
    <asp:Button runat="server" ID="btnReturn" Text="返回" OnClick="BtnReturn_OnClick" CssClass="btn btn-default"/>
</asp:Content>
