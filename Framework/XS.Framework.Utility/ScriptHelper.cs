using System;
using System.Text;
using System.Web;
using System.Web.UI;

namespace XS.Framework.Utility
{
    /// <summary>
    /// js帮助类
    /// </summary>
    public class ScriptHelper
    {
        #region 弹出

        #region alert提示框

        /// <summary>
        /// alert提示框
        /// </summary>
        /// <param name="msg"></param>
        /// <returns></returns>
        public ScriptHelper Alert2(string msg)
        {
            msg = "alert('" + msg + "');";
            OutputJsB(msg);
            return this;
        }

        /// <summary>
        /// alert提示框 TODO
        /// </summary>
        /// <param name="msg"></param>
        /// <returns></returns>
        public static void Alert(string msg)
        {
            msg = "alert('" + msg + "');";
            var page = HttpContext.Current.Handler as Page;
            if (page != null)
            {
                if (!page.ClientScript.IsClientScriptBlockRegistered(typeof(Page), "keys"))
                {
                    page.ClientScript.RegisterStartupScript(typeof(Page), "keys", msg, true);

                }
            }
        }

        /// <summary>
        /// layer提示框
        /// </summary>
        /// <param name="msg"></param>
        /// <returns></returns>
        public ScriptHelper AlertLayer(string msg)
        {
            msg = "layer.msg('" + msg + "');";
            OutputJsB(msg);
            return this;
        }

        #endregion

        #endregion

        #region 私有方法

        /// <summary>
        /// 在页面前输出js
        /// </summary>
        /// <param name="js"></param>
        private void OutputJsA(string js)
        {
            var page = HttpContext.Current.Handler as Page;
            if (page != null)
            {
                if (!page.ClientScript.IsClientScriptBlockRegistered(typeof(Page), "keys"))
                {
                    page.ClientScript.RegisterClientScriptBlock(typeof(Page), "keys", js, true);

                }
            }
        }

        /// <summary>
        /// 在页面后输出js
        /// </summary>
        /// <param name="js"></param>
        private void OutputJsB(string js)
        {
            var page = HttpContext.Current.Handler as Page;
            if (page != null)
            {
                if (!page.ClientScript.IsClientScriptBlockRegistered(typeof(Page), "keys"))
                {
                    page.ClientScript.RegisterStartupScript(typeof(Page), "keys", js, true);

                }
            }
        }

        #endregion

        /// <summary>
        /// 弹出提示框，用于UpdatePanel
        /// </summary>
        /// <param name="strmess"></param>
        public static void AlertMessage(string strmess)
        {
            var page = HttpContext.Current.Handler as Page;
            var strBuilder = new StringBuilder();
            strBuilder.Append("<script>");
            strBuilder.AppendFormat("alert('{0}');", strmess);
            strBuilder.Append("</script>");
            if (page != null)
                ScriptManager.RegisterClientScriptBlock(page, typeof(Page), "", strBuilder.ToString(), false);
        }

        /// <summary>
        /// 弹出一个消息随后关闭当前窗口
        /// </summary>
        /// <param name="message">窗口信息</param>
        public static void AlertAndCloseWindow(string message)
        {
            message = StringHelper.DeleteUnVisibleChar(message);
            string js = @"<Script type='text/javascript'>
                    alert('" + message + "'); window.close(); </Script>";


            //注释原因，使用page注册脚本时，该脚本不是在页面中最先执行的脚本
            //Page page = System.Web.HttpContext.Current.Handler as Page;
            //if (page != null)
            //{
            //    string key = "CloseWindow" + page.ClientID;
            //    if (!page.ClientScript.IsClientScriptBlockRegistered(key))
            //        page.ClientScript.RegisterClientScriptBlock(typeof(Page), key, js);
            //}
            //else
                HttpContext.Current.Response.Write(js);
        }

        /// <summary>
        /// 禁用整个表单
        /// </summary>
        /// <param name="message"></param>
        public static void DisbaledForm(string message)
        {
            message = StringHelper.DeleteUnVisibleChar(message);

             string css =@"<style type='text/css'>
                            html, body {
	                            height:100%;
	                            width:100%;
                            }
                            * {
	                            margin:0;
	                            padding:0;
	                            font-size:12px;
                            }
                           </style>";
            string js = string.Format(@"<Script language='JavaScript'>
                            var body = document.getElementsByTagName('body')[0];
                            body.onload = function ()
                            {{
	                             var mybg = document.createElement('div');
	                             mybg.setAttribute('id','mybg');
	                             mybg.style.background = '#000';
	                             mybg.style.width = '100%';
	                             mybg.style.height = '100%';
	                             mybg.style.position = 'absolute';
	                             mybg.style.top = '0';
	                             mybg.style.left = '0';
	                             mybg.style.zIndex = '500';
	                             mybg.style.opacity = '0.3';
	                             mybg.style.filter = 'Alpha(opacity=30)';
	                             document.body.appendChild(mybg);
	                             document.body.style.overflow = 'hidden';
                                 alert('{0}');
                             }}
                            </Script>", message);

            Page page = System.Web.HttpContext.Current.Handler as Page;
            if (!page.ClientScript.IsClientScriptBlockRegistered("DisbaledHtml"))
                page.ClientScript.RegisterClientScriptBlock(typeof(Page), "DisbaledHtml", css + js);
        }

        /// <summary>
        /// 转向Url制定的页面
        /// </summary>
        /// <param name="url"></param>
        public static void Redirect(string url)
        {
            string js = @"<Script language='JavaScript'>
                    window.location.replace('{0}');
                  </Script>";
            js = string.Format(js, url);
            HttpContext.Current.Response.Write(js);
        }

        /// <summary>
        /// 弹出JavaScript小窗口,并转到指定的页面
        /// </summary>
        /// <param name="message"></param>
        /// <param name="toURL"></param>
        public static void AlertAndRedirect(string message, string toURL)
        {
            string js = "<script language='javascript'>alert('{0}');window.location.replace('{1}');</script>";
            HttpContext.Current.Response.Write(string.Format(js, message, toURL));
        }

        /// <summary>
        /// 弹出JavaScript小窗口,并转到指定的页面
        /// </summary>
        /// <param name="message"></param>
        /// <param name="toURL"></param>
        public static void AlertAndRedirectParent(string message, string toURL)
        {
            string js = "<script language='javascript'>alert('{0}');top.location.href='{1}';</script>";
            HttpContext.Current.Response.Write(string.Format(js, message, toURL));
        }

        /// <summary>
        /// 回到历史页面
        /// </summary>
        /// <param name="value">-1/1</param>
        public static void GoHistory(int value)
        {
            string js = @"<Script language='JavaScript'>
                    history.go({0});  
                  </Script>";
            js = string.Format(js, value);

            Page page = System.Web.HttpContext.Current.Handler as Page;
            if (page != null)
            {
                string key = "GoHistory" + page.ClientID;
                if (!page.ClientScript.IsClientScriptBlockRegistered(key))
                    page.ClientScript.RegisterClientScriptBlock(typeof(Page), key, js);
            }
            else
                HttpContext.Current.Response.Write(js);
        }

        /// <summary>
        /// 显示消息并回到历史页面
        /// </summary>
        /// <param name="msg"></param>
        /// <param name="value"></param>
        public static void GoHistory(string msg,int value)
        {
            string js = @"<Script language='JavaScript'>
                    alert('{0}');
                    history.go({1});  
                  </Script>";
            js = string.Format(js,msg, value);

            Page page = System.Web.HttpContext.Current.Handler as Page;
            if (page != null)
            {
                string key = "GoHistory" + page.ClientID;
                if (!page.ClientScript.IsClientScriptBlockRegistered(key))
                    page.ClientScript.RegisterClientScriptBlock(typeof(Page), key, js);
            }
            else
                HttpContext.Current.Response.Write(js);
        }

        /// <summary>
        /// 关闭当前窗口
        /// </summary>
        public static void CloseWindow()
        {
            string js = @"<Script language='JavaScript'>
                    window.close();  
                  </Script>";

            Page page = System.Web.HttpContext.Current.Handler as Page;
            if (page != null)
            {
                string key = "CloseWindow" + page.ClientID;
                if (!page.ClientScript.IsClientScriptBlockRegistered(key))
                    page.ClientScript.RegisterClientScriptBlock(typeof(Page), key, js);
            }
            else
                HttpContext.Current.Response.Write(js);
        }

        /// <summary>
        /// 刷新父窗口
        /// </summary>
        public static void RefreshParent()
        {
            string js = @"<Script language='JavaScript'>
                    parent.location.reload();
                  </Script>";
            HttpContext.Current.Response.Write(js);
        }

        /// <summary>
        /// 刷新打开窗口
        /// </summary>
        public static void RefreshOpener()
        {
            string js = @"<Script language='JavaScript'>
                    opener.location.reload();
                  </Script>";
            HttpContext.Current.Response.Write(js);
        }

        /// <summary>
        /// 格式化为JS可解释的字符串
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static string JSStringFormat(string s)
        {
            return s.Replace("\r", "\\r").Replace("\n", "\\n").Replace("'", "\\'").Replace("\"", "\\\"");
        }
        /// <summary>
        /// 为HTML元素赋值
        /// </summary>
        /// <param name="formName"></param>
        /// <param name="elementName"></param>
        /// <param name="elementValue"></param>
        public static void SetHtmlElementValue(string formName, string elementName, string elementValue)
        {
            string js = @"<Script language='JavaScript'>if(document." + formName + "." + elementName + "!=null){document." + formName + "." + elementName + ".value =" + elementValue + ";}</Script>";
            HttpContext.Current.Response.Write(js);
        }

        #region 打开模式窗口
        /// <summary>
        /// 函数名:ShowModalDialogWindow	
        /// 功能描述:打开模式窗口	
        /// 处理流程:
        /// 算法描述:
        /// 作 者: 
        /// 日 期: 2003-04-30 15:00
        /// 修 改:
        /// 日 期:
        /// 版 本:
        /// </summary>
        /// <param name="webFormUrl"></param>
        /// <returns></returns>
        public static void ShowModalDialogWindow(string webFormUrl)
        {
            string js = GetShowModalDialogJavascript(webFormUrl);
            HttpContext.Current.Response.Write(js);
        }
        /// <summary>
        /// 打开模式窗口
        /// </summary>
        /// <param name="webFormUrl"></param>
        /// <param name="features"></param>
        public static void ShowModalDialogWindow(string webFormUrl, string features)
        {
            string js = GetShowModalDialogJavascript(webFormUrl, features);
            HttpContext.Current.Response.Write(js);
        }
        /// <summary>
        /// 打开模式窗口
        /// </summary>
        /// <param name="webFormUrl"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <param name="top"></param>
        /// <param name="left"></param>
        public static void ShowModalDialogWindow(string webFormUrl, int width, int height, int top, int left)
        {
            string features = "dialogWidth:" + width + "px"
                + ";dialogHeight:" + height + "px"
                + ";dialogLeft:" + left + "px"
                + ";dialogTop:" + top + "px"
                + ";center:yes;help=no;resizable:no;status:no;scroll=no";
            ShowModalDialogWindow(webFormUrl, features);
        }


        /// <summary>
        /// 函数名:ShowModalDialogJavascript	
        /// 功能描述:返回打开模式窗口的脚本	
        /// 处理流程:
        /// 算法描述:
        /// 作 者: 
        /// 日 期: 2003-04-30 15:00
        /// 修 改:
        /// 日 期:
        /// 版 本:
        /// </summary>
        /// <param name="webFormUrl"></param>
        /// <returns></returns>
        public static string GetShowModalDialogJavascript(string webFormUrl)
        {
            string js = @"<script language=javascript>
							var iWidth = 0 ;
							var iHeight = 0 ;
							iWidth=window.screen.availWidth-10;
							iHeight=window.screen.availHeight-50;
							var szFeatures = 'dialogWidth:'+iWidth+';dialogHeight:'+iHeight+';dialogLeft:0px;dialogTop:0px;center:yes;help=no;resizable:on;status:on;scroll=yes';
							showModalDialog('" + webFormUrl + "','',szFeatures);</script>";
            return js;
        }
        /// <summary>
        /// 返回打开模式窗口的脚本
        /// </summary>
        /// <param name="webFormUrl"></param>
        /// <param name="features"></param>
        /// <returns></returns>
        public static string GetShowModalDialogJavascript(string webFormUrl, string features)
        {
            string js = @"<script language=javascript>							
							showModalDialog('" + webFormUrl + "','','" + features + "');</script>";
            return js;
        }
        #endregion

        /// <summary>
        /// 打开窗口
        /// </summary>
        /// <param name="url"></param>
        public static void OpenWebForm(string url)
        {

            /*…………………………………………………………………………………………*/
            /*修改人员:		sxs						*/
            /*修改时间:	2003-4-9	*/
            /*修改目的:	新开页面去掉ie的菜单。。。						*/
            /*注释内容:								*/
            /*开始*/
            string js = @"<Script language='JavaScript'>
			//window.open('" + url + @"');
			window.open('" + url + @"','','height=0,width=0,top=0,left=0,location=no,menubar=no,resizable=yes,scrollbars=yes,status=yes,titlebar=no,toolbar=no,directories=no');
			</Script>";
            /*结束*/
            /*…………………………………………………………………………………………*/


            HttpContext.Current.Response.Write(js);
        }
        /// <summary>
        /// 打开一个窗口
        /// </summary>
        /// <param name="url"></param>
        /// <param name="name"></param>
        /// <param name="future"></param>
        public static void OpenWebForm(string url, string name, string future)
        {
            string js = @"<Script language='JavaScript'>
                     window.open('" + url + @"','" + name + @"','" + future + @"')
                  </Script>";
            HttpContext.Current.Response.Write(js);
        }
        /// <summary>
        /// 打开一个窗口
        /// </summary>
        /// <param name="url"></param>
        /// <param name="formName"></param>
        public static void OpenWebForm(string url, string formName)
        {
            /*…………………………………………………………………………………………*/
            /*修改人员:								*/
            /*修改时间:	2003-4-9	*/
            /*修改目的:	新开页面去掉ie的菜单。。。						*/
            /*注释内容:								*/
            /*开始*/
            string js = @"<Script language='JavaScript'>
			//window.open('" + url + @"','" + formName + @"');
			window.open('" + url + @"','" + formName + @"','height=0,width=0,top=0,left=0,location=no,menubar=no,resizable=yes,scrollbars=yes,status=yes,titlebar=no,toolbar=no,directories=no');
			</Script>";
            /*结束*/
            /*…………………………………………………………………………………………*/

            HttpContext.Current.Response.Write(js);
        }

        /// <summary>		
        /// 函数名:OpenWebForm	
        /// 功能描述:打开WEB窗口	
        /// 处理流程:
        /// 算法描述:
        /// 作 者: 
        /// 日 期: 2003-04-29 17:00
        /// 修 改:
        /// 日 期:
        /// 版 本:
        /// </summary>
        /// <param name="url">WEB窗口</param>
        /// <param name="isFullScreen">是否全屏幕</param>
        public static void OpenWebForm(string url, bool isFullScreen)
        {
            string js = @"<Script language='JavaScript'>";
            if (isFullScreen)
            {
                js += "var iWidth = 0;";
                js += "var iHeight = 0;";
                js += "iWidth=window.screen.availWidth-10;";
                js += "iHeight=window.screen.availHeight-50;";
                js += "var szFeatures ='width=' + iWidth + ',height=' + iHeight + ',top=0,left=0,location=no,menubar=yes,resizable=yes,scrollbars=yes,status=yes,titlebar=no,toolbar=no,directories=no';";
                js += "window.open('" + url + @"','',szFeatures);";
            }
            else
            {
                js += "window.open('" + url + @"','','height=0,width=0,top=0,left=0,location=no,menubar=yes,resizable=yes,scrollbars=yes,status=yes,titlebar=no,toolbar=no,directories=no');";
            }
            js += "</Script>";
            HttpContext.Current.Response.Write(js);
        }

        /// <summary>
        /// 居中打开
        /// </summary>
        /// <param name="url">链接地址</param>
        /// <param name="height">高</param>
        /// <param name="width">宽</param>
        public static void OpenWebForm(string url,int height,int width)
        {
            string js = @"<Script language='JavaScript'>";

                js += "var iTop = 0;";
                js += "var iLeft = 0;";
                js += "iLeft=(window.screen.availWidth-" + width.ToString() +")/2;";
                js += "iTop=(window.screen.availHeight-" + height.ToString() +")/2;";
                js += "var szFeatures ='width=" + width + ",height=" + height + ",top='+ iTop+ ',left='+ iLeft +',location=no,menubar=yes,resizable=yes,scrollbars=yes,status=yes,titlebar=no,toolbar=no,directories=no';";
                js += "window.open('" + url + @"','',szFeatures);";

            js += "</Script>";
            HttpContext.Current.Response.Write(js);
        }


        /// <summary>
        /// 指定的框架页面转换
        /// </summary>
        /// <param name="FrameName"></param>
        /// <param name="url"></param>
        public static void JavaScriptFrameHref(string FrameName, string url)
        {
            string js = @"<Script language='JavaScript'>
					
                    @obj.location.replace(""{0}"");
                  </Script>";
            js = js.Replace("@obj", FrameName);
            js = string.Format(js, url);
            HttpContext.Current.Response.Write(js);
        }

        /// <summary>
        ///重置页面
        /// </summary>
        public static void JavaScriptResetPage(string strRows)
        {
            string js = @"<Script language='JavaScript'>
                    window.parent.CenterFrame.rows='" + strRows + "';</Script>";
            HttpContext.Current.Response.Write(js);
        }
        /// <summary>
        /// 函数名:JavaScriptSetCookie
        /// 功能描述:客户端方法设置Cookie
        /// 作者:
        /// 日期：2003-4-9
        /// 版本：1.0
        /// </summary>
        /// <param name="strName">Cookie名</param>
        /// <param name="strValue">Cookie值</param>
        public static void JavaScriptSetCookie(string strName, string strValue)
        {
            string js = @"<script language=Javascript>
			var the_cookie = '" + strName + "=" + strValue + @"'
			var dateexpire = 'Tuesday, 01-Dec-2020 12:00:00 GMT';
			//document.cookie = the_cookie;//写入Cookie<BR>} <BR>
			document.cookie = the_cookie + '; expires='+dateexpire;			
			</script>";
            HttpContext.Current.Response.Write(js);
        }

        /// <summary>		
        /// 函数名:GotoParentWindow	
        /// 功能描述:返回父窗口	
        /// 处理流程:
        /// 算法描述:
        /// 作 者: 
        /// 日 期: 2003-04-30 10:00
        /// 修 改:
        /// 日 期:
        /// 版 本:
        /// </summary>
        /// <param name="parentWindowUrl">父窗口</param>		
        public static void GotoParentWindow(string parentWindowUrl)
        {
            string js = string.Format(@"<Script language='JavaScript'>
                    if(this.parent.parent != null)
                        this.parent.parent.location.replace('{0}');
                    else
                        this.parent.location.replace('{0}');
                     </Script>",parentWindowUrl);
            HttpContext.Current.Response.Write(js);
        }

        /// <summary>		
        /// 函数名:ReplaceParentWindow	
        /// 功能描述:替换父窗口	
        /// 处理流程:
        /// 算法描述:
        /// 作 者: 
        /// 日 期: 2003-04-30 10:00
        /// 修 改:
        /// 日 期:
        /// 版 本:
        /// </summary>
        /// <param name="parentWindowUrl">父窗口</param>
        /// <param name="caption">窗口提示</param>
        /// <param name="future">窗口特征参数</param>
        public static void ReplaceParentWindow(string parentWindowUrl, string caption, string future)
        {
            string js = "";
            if (future != null && future.Trim() != "")
            {
                js = @"<script language=javascript>this.parent.location.replace('" + parentWindowUrl + "','" + caption + "','" + future + "');</script>";
            }
            else
            {
                js = @"<script language=javascript>var iWidth = 0 ;var iHeight = 0 ;iWidth=window.screen.availWidth-10;iHeight=window.screen.availHeight-50;
							var szFeatures = 'dialogWidth:'+iWidth+';dialogHeight:'+iHeight+';dialogLeft:0px;dialogTop:0px;center:yes;help=no;resizable:on;status:on;scroll=yes';this.parent.location.replace('" + parentWindowUrl + "','" + caption + "',szFeatures);</script>";
            }

            HttpContext.Current.Response.Write(js);
        }


        /// <summary>		
        /// 函数名:ReplaceOpenerWindow	
        /// 功能描述:替换当前窗体的打开窗口	
        /// 处理流程:
        /// 算法描述:
        /// 作 者: 
        /// 日 期: 2003-04-30 16:00
        /// 修 改:
        /// 日 期:
        /// 版 本:
        /// </summary>
        /// <param name="openerWindowUrl">当前窗体的打开窗口</param>		
        public static void ReplaceOpenerWindow(string openerWindowUrl)
        {
            string js = @"<Script language='JavaScript'>
                    window.opener.location.replace('" + openerWindowUrl + "');</Script>";
            HttpContext.Current.Response.Write(js);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="frameName"></param>
        /// <param name="frameWindowUrl"></param>	
        public static void ReplaceOpenerParentFrame(string frameName, string frameWindowUrl)
        {
            string js = @"<Script language='JavaScript'>
                    window.opener.parent." + frameName + ".location.replace('" + frameWindowUrl + "');</Script>";
            HttpContext.Current.Response.Write(js);
        }

        /// <summary>		
        /// 函数名:ReplaceOpenerParentWindow	
        /// 功能描述:替换当前窗体的打开窗口的父窗口	
        /// 处理流程:
        /// 算法描述:
        /// 作 者: 
        /// 日 期: 2003-07-03 19:00
        /// 修 改:
        /// 日 期:
        /// 版 本:
        /// </summary>
        /// <param name="openerParentWindowUrl">当前窗体的打开窗口的父窗口</param>		
        public static void ReplaceOpenerParentWindow(string openerParentWindowUrl)
        {
            string js = @"<Script language='JavaScript'>
                    window.opener.parent.location.replace('" + openerParentWindowUrl + "');</Script>";
            HttpContext.Current.Response.Write(js);
        }
    }
}
