<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CategoryList.aspx.cs" Inherits="XS.Blog.WebUI.XSBlog.Category.CategoryList" MasterPageFile="../PageTemplates/BlogPageTemplate.master" %>

<asp:Content runat="server" ID="Content1" ContentPlaceHolderID="BlogTitlePlaceHolder">
</asp:Content>
<asp:Content runat="server" ID="Content2" ContentPlaceHolderID="BlogContentPlaceHolder">
    <div class="category">
        <asp:Repeater ID="rptCategory" runat="server">
            <ItemTemplate>
                <div class="category-item">
                    <a class="c-i-a" href='/xsblog/<%=BlogName %>/category/<%# Eval("Id") %>' style="background-image: url(<%#Eval("imageUrl") %>?imageView2/1/w/240/h/120/interlace/1)">
                        <div class="c-i-a-div">
                            <span class="c-i-a-span"><%#Eval("Name") %></span>
                        </div>
                    </a>
                </div>
            </ItemTemplate>
        </asp:Repeater>
        <div class="clear"></div>
    </div>
</asp:Content>
