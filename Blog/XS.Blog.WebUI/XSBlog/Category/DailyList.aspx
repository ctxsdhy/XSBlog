<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DailyList.aspx.cs" Inherits="XS.Blog.WebUI.XSBlog.Category.DailyList" MasterPageFile="../PageTemplates/BlogPageTemplate.master" %>

<asp:Content runat="server" ID="Content1" ContentPlaceHolderID="BlogTitlePlaceHolder">
</asp:Content>
<asp:Content runat="server" ID="Content2" ContentPlaceHolderID="BlogContentPlaceHolder">
    <div class="daily">
        <div class="daily-list">
            <asp:Repeater ID="rptDaily" runat="server" OnItemDataBound="rptDaily_ItemDataBound">
                <ItemTemplate>
                    <div class="daily-list-Item">
                        <div class="d-l-i-name">
                            <a href='/xsblog/<%=BlogName %>/daily/<%# Eval("Id") %>' target="_blank"><%# Eval("Name") %></a>
                        </div>
                        <div class="d-l-i-content">
                            <asp:Literal ID="litContent" runat="server" />
                        </div>
                        <asp:Panel runat="server" ID="plImage">
                            <div class="d-l-i-image">
                                <a class="d-l-i-i-a" href='/xsblog/<%=BlogName %>/daily/<%# Eval("Id") %>' target="_blank">
                                    <asp:Image ID="imgDailyImage" CssClass="b-c-d-i-a-image" runat="server" />
                                </a>
                            </div>
                        </asp:Panel>
                    </div>
                </ItemTemplate>
            </asp:Repeater>
            <div class="daily-list-page">
                <webdiyer:AspNetPager ID="pager" runat="server" HorizontalAlign="Center" EnableUrlRewriting="True" UrlRewritePattern="/xsblog/%BlogName%/category/%Category%/{0}" />
            </div>
        </div>
        <div class="clear"></div>
    </div>
</asp:Content>
