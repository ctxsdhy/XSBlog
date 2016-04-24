<%@ Page Title="" Language="C#" MasterPageFile="~/XSBlog/PageTemplates/BlogPageTemplate.master" AutoEventWireup="true" CodeBehind="Archive.aspx.cs" Inherits="XS.Blog.WebUI.XSBlog.Archive.Archive" %>

<asp:Content ID="Content1" ContentPlaceHolderID="BlogTitlePlaceHolder" runat="server">
    <style type="text/css">
        .update-main {
            margin: 30px 50px 47px 50px;
            color: #4C4C4C;
        }

            .update-main div {
                margin-bottom: 20px;
            }

            .update-main h1 {
                font-size: 16px;
                font-weight: bold;
                margin-bottom: 20px;
            }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="BlogContentPlaceHolder" runat="server">
    <div class="archive">
        <div class="archive-main">
            <asp:Literal ID="litArchiveList" runat="server" />
        </div>
    </div>
    <div class="clear"></div>
</asp:Content>
