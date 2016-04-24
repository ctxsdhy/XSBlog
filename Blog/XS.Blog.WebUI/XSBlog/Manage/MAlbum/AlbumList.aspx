<%@ Page Title="" Language="C#" MasterPageFile="~/XSBlog/PageTemplates/ManageTemplate.master" AutoEventWireup="true" CodeBehind="AlbumList.aspx.cs" Inherits="XS.Blog.WebUI.XSBlog.Manage.MAlbum.AlbumList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ManageTitlePlaceHolder" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ManageContentPlaceHolder" runat="server">
    <div class="title">
        <div title="title-left">
            <div class="title-main">
                <i class="icon-double-angle-right"></i>
                相册列表
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
                        <th>序号</th>
                    </tr>
                </thead>
                <tbody>
        </HeaderTemplate>
        <ItemTemplate>
            <tr>
                <td>
                    <asp:CheckBox ID="GuId" runat="server" /><asp:HiddenField runat="server" ID="hfGuId" Value='<%#Eval("Guid") %>' />
                </td>
                <td>
                    <a href='PhotoList.aspx?albumguid=<%#Eval("Guid") %>'><%# Eval("Name") %></a>
                </td>
                <td>
                    <%# Eval("OrderId") %>
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
