<%@ Page Title="" Language="C#" MasterPageFile="~/XSBlog/PageTemplates/ManageTemplate.master" validateRequest="false" AutoEventWireup="true" CodeBehind="MoodEdit.aspx.cs" Inherits="XS.Blog.WebUI.XSBlog.Manage.MMood.MoodEdit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ManageTitlePlaceHolder" runat="server">
    <script src="/XSBlog/Components/UEditor/ueditor.config.js" type="text/javascript"></script>
    <script src="/XSBlog/Components/UEditor/ueditor.all.js" type="text/javascript"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ManageContentPlaceHolder" runat="server">
    标题：<asp:TextBox runat="server" ID="tbName" Width="100%" />
    <script type="text/plain" id="editor" name="editContent" style="width: 100%;height: 500px;">
        <%=EditContent %> 
    </script>
    <script type="text/javascript">
        var ue = UE.getEditor('editor');
    </script>
    <asp:Button runat="server" ID="btnSave" Text="保存" OnClick="BtnSave_OnClick" CssClass="btn btn-default"/>
    <asp:Button runat="server" ID="btnReturn" Text="返回" OnClick="BtnReturn_OnClick" CssClass="btn btn-default"/>
</asp:Content>
