<%@ Page Title="" Language="C#" MasterPageFile="~/XSBlog/PageTemplates/ManageTemplate.master" AutoEventWireup="true" CodeBehind="CategoryEdit.aspx.cs" Inherits="XS.Blog.WebUI.XSBlog.Manage.MCategory.CategoryEdit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ManageTitlePlaceHolder" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ManageContentPlaceHolder" runat="server">
    分类：<asp:TextBox runat="server" ID="tbName" datatype="Limit" min="1" msg="请输入分类"/>
    <br />
    父类：<asp:DropDownList runat="server" ID="ddlParentCategory" />
    <br />
    序号：<asp:TextBox runat="server" ID="tbOrderId"></asp:TextBox>
    <br />
    图片：<input runat="server" id="FileImage" type="file" />
    <br />
    <asp:Button runat="server" ID="btnSave" Text="保存" OnClick="BtnSave_OnClick" OnClientClick="javascript:return ButtonSubmit();" CssClass="btn btn-default"/>
    <asp:Button runat="server" ID="btnReturn" Text="返回" OnClick="BtnReturn_OnClick" CssClass="btn btn-default"/>
</asp:Content>
