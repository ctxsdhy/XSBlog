<%@ Page Title="" Language="C#" MasterPageFile="~/XSBlog/PageTemplates/BlogPageTemplate.master" AutoEventWireup="true" CodeBehind="MoodList.aspx.cs" Inherits="XS.Blog.WebUI.XSBlog.Mood.MoodList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="BlogTitlePlaceHolder" runat="server">
    <style type="text/css">
        .PageCustomInfo {
            width: 0;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="BlogContentPlaceHolder" runat="server">
    <div class="mood mood-mini">
        <div class="mood-content">
            <asp:Repeater ID="rptMood" runat="server">
                <ItemTemplate>
                    <div class="mood-content-item">
                        <div class="m-c-i-head"></div>
                        <div class="m-c-i-body">
                            <div class="m-c-i-b-content">
                                <%#Eval("Content") %>
                            </div>
                        </div>
                        <div class="m-c-i-foot">
                            <div class="m-c-i-b-otherinfo">
                                <span title="<%# string.Format("{0:HH:mm:ss}",Convert.ToDateTime(Eval("CreateTime")))%>"><%# string.Format("{0:yyyy-MM-dd}",Convert.ToDateTime(Eval("CreateTime")))%></span>
                            </div>
                        </div>
                    </div>
                </ItemTemplate>
            </asp:Repeater>
            <webdiyer:AspNetPager ID="pager" runat="server" HorizontalAlign="Center" EnableUrlRewriting="True" UrlRewritePattern="/xsblog/%BlogName%/mood/{0}" />
        </div>
    </div>
</asp:Content>
