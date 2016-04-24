<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="BlogTop.ascx.cs" Inherits="XS.Blog.WebUI.XSBlog.Home.UserControls.BlogTop" %>
<script type="text/javascript">
    $(function() {
        //设置nav-li选中
        var url = window.location.pathname;
        var nav = url.substring(8);
        if(nav.indexOf('/', nav.indexOf('/') + 1) > 0) {
            nav = nav.substring(nav.indexOf('/') + 1, nav.indexOf('/', nav.indexOf('/') + 1));
        }
        else {
            nav = nav.substring(nav.indexOf('/') + 1, nav.length);
        }
        if ($(".top-nav-ul li[value=" + nav + "]").length > 0) {
            $(".top-nav-ul li[value=" + nav + "]").addClass("active");
        } else {
            $(".top-nav-ul li:eq(0)").addClass("active");
        }
    });
</script>
<div class="top">
    <div class="top-banner">
        <div class="top-intro">
            <div class="top-name">xs's life</div>
            <div class="top-tag">常通宵, 睡懒觉, 爱生活</div>
        </div>
    </div>
    <div class="top-nav">
        <ul class="top-nav-ul">
            <li>
                <a href="/xsblog/<%=BlogName %>"><i class="icon-home"></i>&nbsp;首页</a>
            </li>
            <li value="daily">
                <a href="/xsblog/<%=BlogName %>/daily/c"><i class="icon-book"></i>&nbsp;日志</a>
            </li>
            <li value="category">
                <a href="/xsblog/<%=BlogName %>/category"><i class="icon-star-empty"></i>&nbsp;分类</a>
            </li>
            <li value="album">
                <a href="/xsblog/<%=BlogName %>/album"><i class="icon-picture"></i>&nbsp;相册</a>
            </li>
            <li value="mood">
                <a href="/xsblog/<%=BlogName %>/mood"><i class="icon-comment-alt"></i>&nbsp;说说</a>
            </li>
            <li value="archive">
                <a href="/xsblog/<%=BlogName %>/archive"><i class="icon-inbox"></i>&nbsp;归档</a>
            </li>
            <li value="about">
                <a href="/xsblog/<%=BlogName %>/about"><i class="icon-paper-clip"></i>&nbsp;关于</a>
            </li>
        </ul>
        <div class="clear"></div>
    </div>
    <div class="top-space"></div>
</div>
