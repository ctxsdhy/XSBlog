//扩展页面功能按钮方法
$(function () {
    //列表全选和反选事件句柄
    $('#chkall').click(function () {
        chkAll($('#chkall').is(":checked"));
    });
});

//全选或反选
function chkAll(isChecked) {
    $(":checkbox[name$='Id']").each(function () {
        if (!$(this).is(":disabled")) {
            $(this).prop("checked", isChecked);
        }
    });
}

//删除按钮判断是否已经已选中项目
function Delete() {
    if ($("input[type='checkbox'][name$='Id']:checked").length == 0) {
        alert("请选择您要操作的记录！");
        return false;
    }
    var msg = "您确定删除选中的记录吗？";
    if (arguments[0] && arguments[0] != "") {
        msg = arguments[0]; //用户自定义提示内容
    }
    return confirm(msg);
}

//判断更新编辑按钮，只能选择一个复选框
function Update() {
    var i = $("input[type='checkbox'][name$='Id']:checked").length;
    if (i == 0) { alert("请选择您要修改的记录！"); return false; }
    if (i != 1) { alert("只能选择一条记录！"); return false; }
    return true;
}

//打开窗口
function OpenWindow(url, heigh, width) {
    var windowName = "信息浏览_" + (new Date).getMilliseconds();
    var newWindow = window.open(url, windowName, 'left=200,top=100,height=' + heigh + ',width=' + width + ',menubar=no,status=no,location=no,directories=no,resizable=yes,scrollbars=yes');
    newWindow.focus();

}

//打开模态窗口
function OpenModalWindow(url, height, width) {
    var param = ("dialogWidth=" + width + "px;dialogHeight=" + height + "px;center=yes;scroll=no;");
    return window.showModalDialog(url, 'newWin', param);
}

//打开全屏窗口
function OpenFullWindow(url) {
    var newwin = window.open("", "", "");
    if (document.all) {
        newwin.moveTo(0, 0);
        newwin.resizeTo(screen.width, screen.height);
    }
    newwin.location = url;
}
