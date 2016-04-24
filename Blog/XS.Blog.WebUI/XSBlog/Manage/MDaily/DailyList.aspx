<%@ Page Title="" Language="C#" MasterPageFile="~/XSBlog/PageTemplates/ManageTemplate.master" AutoEventWireup="true" CodeBehind="DailyList.aspx.cs" Inherits="XS.Blog.WebUI.XSBlog.Manage.MDaily.DailyList" %>

<%@ Import Namespace="XS.Framework.Utility" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ManageTitlePlaceHolder" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ManageContentPlaceHolder" runat="server">
    <div class="title">
        <div title="title-left">
            <div class="title-main">
                <i class="icon-double-angle-right"></i>
                文章列表
            </div>
        </div>
        <div class="title-right">
            <asp:Button runat="server" ID="btnAdd" Text="新增" OnClick="btnAdd_Click" CssClass="btn btn-default" />
            <asp:Button runat="server" ID="btnUpdate" Text="修改" OnClick="btnUpdate_Click" CssClass="btn btn-default" />
            <asp:Button runat="server" ID="btnDelete" Text="删除" OnClick="btnDelete_Click" CssClass="btn btn-default" />
        </div>
    </div>
    <asp:Repeater ID="rptList" runat="server">
        <HeaderTemplate>
            <table class="table">
                <thead>
                    <tr>
                        <th class="table-checkall">
                            <input type="checkbox" id="chkall" /></th>
                        <th>分类</th>
                        <th>标题</th>
                        <th>作者</th>
                        <th>日期</th>
                    </tr>
                    <tbody>
        </HeaderTemplate>
        <ItemTemplate>
            <tr>
                <td>
                    <asp:CheckBox ID="GuId" runat="server" /><asp:HiddenField runat="server" ID="hfGuId" Value='<%#Eval("Guid") %>' />
                </td>
                <td><%# CategoryBll.GetName(Eval("CategoryGuid").ToString()) %></td>
                <td><%# Eval("Name") %></td>
                <td><%# UserBll.GetName(Eval("UserGuid").ToString()) %></td>
                <td><%# ConvertHelper.GetTime(Eval("CreateTime")).ToString("yyyy-MM-dd HH:mm:ss") %></td>
            </tr>
        </ItemTemplate>
        <FooterTemplate>
            </tbody>
            </table>
        </FooterTemplate>
    </asp:Repeater>
    <webdiyer:AspNetPager ID="pager" runat="server" />
</asp:Content>
