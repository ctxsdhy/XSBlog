<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="DailyBox.ascx.cs" Inherits="XS.Blog.WebUI.XSBlog.Home.Modules.DailyBox" %>
<%@ Import Namespace="XS.Blog" %>
<style type="text/css">
    .PagingClass .CurrentPagingClass {
        background-color: #aaa;
        border: 1px solid #aaa;
    }

    .PagingClass a {
        color: #666;
    }
</style>
<div class="box">
    <div class="box-content-dailybox">
        <asp:Repeater ID="rptDaily" runat="server" OnItemDataBound="rptDaily_ItemDataBound">
            <ItemTemplate>
                <div class="box-content-daily-item">
                    <asp:Panel runat="server" ID="plImage">
                        <div class="b-c-d-image">
                            <a class="b-c-d-i-a" href='/xsblog/<%=BlogName %>/daily/<%# Eval("Id") %>' target="_blank">
                                <asp:Image ID="imgDailyImage" CssClass="b-c-d-i-a-image" runat="server" />
                            </a>
                        </div>
                    </asp:Panel>
                    <div class="b-c-d-text">
                        <div class="b-c-d-t-title">
                            <div class="b-c-d-t-t-name">
                                <a href='/xsblog/<%=BlogName %>/daily/<%# Eval("Id") %>' target="_blank"><%# DailyHelper.GetContentSummary(Eval("Name").ToString(),20,false) %></a>
                            </div>
                            <div class="b-c-d-t-t-tag">
                                <span><%# string.Format("{0:yyyy-MM-dd HH:mm}",Convert.ToDateTime(Eval("CreateTime")))%></span><%--<span>阅读1</span><span>评论0</span>--%>
                            </div>
                        </div>
                        <div class="b-c-d-t-content">
                            <div class="b-c-d-t-c-text">
                                <asp:Literal ID="litContent" runat="server" />
                            </div>
                        </div>
                    </div>
                    <div class="clear"></div>
                </div>
            </ItemTemplate>
        </asp:Repeater>
        <div class="box-content-more" style='<%=ReadMoreVisible%>'>
            <a href="/xsblog/<%=BlogName %>/daily/c" target="_blank">more&nbsp;<i class="icon-double-angle-right"></i></a>&nbsp;
        </div>
    </div>
</div>
