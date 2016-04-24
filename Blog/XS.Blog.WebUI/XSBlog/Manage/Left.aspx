<%@ Page Language="C#" MasterPageFile="~/XSBlog/PageTemplates/ManageTemplateBase.Master" AutoEventWireup="true" CodeBehind="Left.aspx.cs" Inherits="XS.Blog.WebUI.XSBlog.Manage.Left" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitlePlaceHolder" runat="server">
    <link rel="stylesheet" type="text/css" href="/XSBlog/Skin/Manage/Frame.css" />
    <script type="text/javascript" src="../Js/jquery.nav-list.js"></script>
    <script type="text/javascript">
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
    <ul class="nav-list">
        <li class="active"><a href="MHome/Home.aspx" target="contentFrame"><i class="icon-dashboard"></i><span class="menu-text">控制台</span></a></li>
        <li><a href="MDaily/DailyList.aspx" target="contentFrame"><i class="icon-list-alt"></i><span class="menu-text">文章</span></a></li>
        <li><a href="MCategory/CategoryList.aspx" target="contentFrame"><i class="icon-th-list"></i><span class="menu-text">分类</span></a></li>
        <li style="display: none;"><a href="#" target="contentFrame"><i class="icon-tag"></i><span class="menu-text">标签</span></a></li>
        <li style="display: none;"><a href="#" target="contentFrame"><i class="icon-edit"></i><span class="menu-text">评论</span></a></li>
        <li><a href="MMood/MoodList.aspx" target="contentFrame"><i class="icon-heart"></i><span class="menu-text">心情</span></a></li>
        <li><a href="MAlbum/AlbumList.aspx" target="contentFrame"><i class="icon-picture"></i><span class="menu-text">相册</span></a></li>
        <li style="display: none;"><a style="cursor:pointer;"><i class="icon-book"></i><span class="menu-text">博客设置</span><b class="arrow icon-angle-down"></b></a>
            <ul class="submenu">
                <li><a href="#" target="contentFrame"><i class="icon-double-angle-right"></i>常规</a></li>
                <li><a href="#" target="contentFrame"><i class="icon-double-angle-right"></i>模块</a></li>
                <li><a href="#" target="contentFrame"><i class="icon-double-angle-right"></i>博客</a></li>
                <li><a href="#" target="contentFrame"><i class="icon-double-angle-right"></i>个人</a></li>
            </ul>
        </li>
        <li style="display: none;"><a style="cursor:pointer;"><i class="icon-cog"></i><span class="menu-text">系统管理</span><b class="arrow icon-angle-down"></b></a>
            <ul class="submenu">
                <li><a href="#" target="contentFrame"><i class="icon-double-angle-right"></i>用户</a></li>
                <li><a href="#" target="contentFrame"><i class="icon-double-angle-right"></i>博客</a></li>
            </ul>
        </li>
    </ul>
</asp:Content>
