<%@ Page Title="" Language="C#" MasterPageFile="~/XSBlog/PageTemplates/ManageTemplate.master" AutoEventWireup="true" CodeBehind="PhotoList.aspx.cs" Inherits="XS.Blog.WebUI.XSBlog.Manage.MAlbum.PhotoList" %>
<%@ Import Namespace="XS.Framework.Utility" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ManageTitlePlaceHolder" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ManageContentPlaceHolder" runat="server">
    <div class="title">
        <div title="title-left">
            <div class="title-main">
                <i class="icon-double-angle-right"></i>
                照片列表
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
                        <th>名称</th>
                        <th>路径</th>
                        <th>时间</th>
                        <th>内容</th>
                    </tr>
                </thead>
                <tbody>
        </HeaderTemplate>
        <ItemTemplate>
            <tr>
                <td>
                    <asp:CheckBox ID="GuId" runat="server" /><asp:HiddenField runat="server" ID="hfGuId" Value='<%#Eval("Guid") %>' /><asp:HiddenField runat="server" ID="hfImageKey" Value='<%#Eval("ImageKey") %>' />
                </td>
                <td>
                    <%# Eval("Name") %>
                </td>
                <td>
                    <a href="<%# Eval("ImageUrl") %>" target="_blank"><%# Eval("ImageUrl") %></a>
                </td>
                <td>
                    <%# ConvertHelper.GetTime(Eval("CreateTime")).ToString("yyyy-MM-dd HH:mm:ss") %>
                </td>
                <td>
                    <img src='<%#Eval("ImageUrl") + "?imageView2/2/w/100/h/100/interlace/1" %>' style="max-width: 100px;max-height: 100px;" />
                </td>
            </tr>
        </ItemTemplate>
        <FooterTemplate>
                </tbody>
            </table>
        </FooterTemplate>
    </asp:Repeater>
    <webdiyer:AspNetPager ID="pager" runat="server" />
</asp:Content>
