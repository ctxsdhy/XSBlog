<%@ Page Title="" Language="C#" MasterPageFile="~/XSBlog/PageTemplates/ManageTemplateBase.Master" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="XS.Blog.WebUI.XSBlog.Manage.Index" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitlePlaceHolder" runat="server">
    <link rel="stylesheet" type="text/css" href="/XSBlog/Skin/Manage/Frame.css" />
    <script type="text/javascript">
        $(document).ready(function () {
            var p = $("#mainTable").position();
            var height = document.body.offsetHeight - p.top;
            $("#mainTable").css("height", height);
            $("#tdLeftFrame").css("height", height);
        });

        function openFrameUrl(url, mainUrl, selectIndex, topMenuCount) {
            $("#tdLeftFrame,#tdSplitFrame").show();

            for (var i = 1; i <= topMenuCount; i++) {
                $("#li" + i).removeClass();
            }
            $("#li" + selectIndex).addClass("checked");

            if (url == null || url.length == 0)
                return;

            var l = window.frames["contentLeftFrame"];
            if (l != null) {
                l.location = url;
            }

            var w = window.frames["contentFrame"];
            if (w != null) {
                w.location = "../" + mainUrl;
            }
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
    <div style="overflow: hidden; width: 100%; margin: 0 auto;">
        <div id="frame_top" class="frame-top">
            <div class="frame-top-logo"></div>
        </div>
        <div id="frame_main">
            <table id="mainTable" class="mainTable">
                <tbody>
                    <tr>
                        <!-- 左边栏 -->
                        <td id="tdLeftFrame" class="frame-left">
                            <iframe frameborder="0" style="width: 100%; height: 100%;" name="contentLeftFrame"
                                id="contentLeftFrame" src="Left.aspx"></iframe>
                        </td>
                        <!-- 右边内容 -->
                        <td id="mainFrame">
                            <iframe frameborder="0" style="width: 100%; height: 100%;" name="contentFrame" id="contentFrame"
                                scrolling="auto" src="MHome/Home.aspx"></iframe>
                        </td>
                    </tr>
                </tbody>
            </table>
        </div>
    </div>
</asp:Content>
