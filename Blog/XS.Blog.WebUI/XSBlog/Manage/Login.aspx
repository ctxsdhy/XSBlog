<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="XS.Blog.WebUI.XSBlog.Manage.Login" MasterPageFile="../PageTemplates/ManageTemplateBase.Master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitlePlaceHolder" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
    <div class="login-content">
        <div class="login-main">
            <div class="login-logo">
            </div>
            <div class="login-form">
                <asp:TextBox runat="server" ID="txtLoginName" />
                <asp:TextBox runat="server" ID="txtLoginPwd" TextMode="Password" />
                <div class="login-form-button">
                    <asp:Button runat="server" ID="btnLogin" Text="登&nbsp;&nbsp;&nbsp;&nbsp;录" OnClick="BtnLoginOnClick" CssClass="btn btn-default" />
                    <span class="space"></span><asp:Button runat="server" ID="btnRegister" Text="注&nbsp;&nbsp;&nbsp;&nbsp;册" CssClass="btn btn-default" />
                </div>
            </div>
        </div>
    </div>
</asp:Content>
