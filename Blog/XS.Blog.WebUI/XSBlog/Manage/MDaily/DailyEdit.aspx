<%@ Page Title="" Language="C#" MasterPageFile="~/XSBlog/PageTemplates/ManageTemplate.master" validateRequest="false" AutoEventWireup="true" CodeBehind="DailyEdit.aspx.cs" Inherits="XS.Blog.WebUI.XSBlog.Manage.MDaily.DailyEdit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ManageTitlePlaceHolder" runat="server">
    <script src="/XSBlog/Components/UEditor/ueditor.config.js" type="text/javascript"></script>
    <script src="/XSBlog/Components/UEditor/ueditor.all.js" type="text/javascript"></script>
    <script src="/XSBlog/Js/banBackSpace.js" type="text/javascript"></script>
    <style type="text/css">
        #editor {
            padding-bottom: 5px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ManageContentPlaceHolder" runat="server">
    标题：<asp:TextBox runat="server" ID="tbName" CssClass="inblock" Width="500" datatype="Limit" min="1" msg="请输入标题" />
    <script type="text/plain" id="editor" name="editContent" style="width: 100%;height: 500px;">
        <%=EditContent %> 
    </script>
    <script type="text/javascript">
        var ue = UE.getEditor('editor');
    </script>
    分类：<asp:DropDownList runat="server" ID="ddlCategory" datatype="Select" msg="请增加分类" /><br />
    首页：<asp:CheckBox runat="server" ID="chkIsHome"/><br />
    置顶：<asp:CheckBox runat="server" ID="chkIsStick"/><br />
    权限：<asp:DropDownList runat="server" ID="ddlSpecial" /><br />
    <asp:Button runat="server" ID="btnSave" Text="保存" OnClick="BtnSave_OnClick" OnClientClick="javascript:return ButtonSubmit();" CssClass="btn btn-default"/>
    <asp:Button runat="server" ID="btnDraft" Text="草稿" OnClick="BtnDraft_OnClick" OnClientClick="javascript:return ButtonSubmit();" CssClass="btn btn-default"/>
    <asp:Button runat="server" ID="btnReturn" Text="返回" OnClick="BtnReturn_OnClick" CssClass="btn btn-default"/>
</asp:Content>
