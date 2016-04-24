using System.Text;
using System.Web;
using System.Web.SessionState;

namespace XS.Framework.Common.WebBase
{
    /// <summary>
    /// 基本的HttpHandler
    /// </summary>
    public abstract class HttpHandlerBase : IHttpHandler, IRequiresSessionState
    {
        #region  私有成员

        /// <summary>
        /// 错误提示
        /// </summary>
        ErrorTipAccumulative _errorTips;

        #endregion

        /// <summary>
        /// 页面操作返回结果
        /// </summary>
        private JsonResult _result;
        /// <summary>
        /// 页面操作返回结果 Json 字符串
        /// </summary>
        protected virtual JsonResult Result
        {
            get
            {
                if (_result == null)
                    _result = new JsonResult();
                return _result;
            }
            set
            {
                _result = value;
            }
        }
        public HttpResponse Response { get; private set; }
        public HttpRequest Request { get; private set; }
        public HttpServerUtility Server { get; private set; }
        public HttpSessionState Session { get; private set; }
        public HttpContext Context { get; private set; }

        /// <summary>
        /// 错误提示信息
        /// </summary>
        public ErrorTipAccumulative ErrorTips
        {
            get
            {
                if (_errorTips == null)
                {
                    _errorTips = new ErrorTipAccumulative();
                }
                return _errorTips;
            }
        }

        /// <summary>
        /// 清除所有的错误信息
        /// </summary>
        public void ClearError()
        {
            if (_errorTips != null)
                this.ErrorTips.Clear();
        }

        /// <summary>
        /// 清除错误信息
        /// </summary>
        /// <param name="key"></param>
        public void ClearError(string key)
        {
            if (_errorTips != null)
                this.ErrorTips.Remove(key);
        }

        /// <summary>
        /// 附加错误提示信息
        /// </summary>
        /// <param name="key">如果已经存在key 则覆盖原来的</param>
        /// <param name="message"></param>
        public void AppendError(string key, string message)
        {
            this.ErrorTips.Append(key, message);
        }

        /// <summary>
        /// 这个页面是否包含错误
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public bool HasError()
        {
            if (_errorTips != null)
            {
                return _errorTips.Count > 0;
            }
            return false;
        }

        /// <summary>
        /// 这个页面是否包含关于某个的错误
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public bool HasError(string key)
        {
            if (_errorTips != null && _errorTips.Count > 0)
            {
                return _errorTips.ContainsKey(key);
            }
            return false;
        }

        public virtual bool IsReusable
        {
            get { return false; }
        }


        /// <summary>
        /// 输出异步调用结果
        /// </summary>
        /// <param name="succeed">操作是否成功</param>
        /// <param name="message">附加消息</param>
        protected virtual void OutputResult(bool succeed, string message)
        {
            OutputResult(succeed, message, false);

        }

        /// <summary>
        /// 输出异步调用结果
        /// </summary>
        /// <param name="succeed">操作是否成功</param>
        /// <param name="message">附加消息</param>
        /// <param name="endResponse">结束响应</param>
        protected virtual void OutputResult(bool succeed, string message, bool endResponse)
        {
            Response.Write(string.Format("{{\"succeed\":{0},\"message\":{1}}}", succeed.ToString().ToLowerInvariant(), WebUtil.ToJavascriptString(message,true)));
            if (endResponse)
                Response.End();
        }

        /// <summary>
        /// 自动返回异步调用结果 
        /// </summary>
        /// <returns>true ： 页面无错误提示/ false ： 页面有错误提示</returns>
        protected virtual bool OutputResult()
        {
            if (_errorTips == null || _errorTips.Count < 1)
            {
                Response.Write("{\"succeed\":true,\"message\":null}");
                return true;
            }

            StringBuilder json = new StringBuilder("[");
            var _errors = this.ErrorTips;
            foreach (var k in _errors)
            {
                json.AppendFormat("{{\"key\":\"{0}\",\"message\":\"{1}\"}},", k.Key, WebUtil.ToJavascriptString(k.Value));
            }
            json.Remove(json.Length - 1, 1);
            json.Append("]");
            Response.Write(string.Format("{\"succeed\":true,\"message\":{0}}", json.ToString()));
            return false;
        }

        public void ProcessRequest(HttpContext context)
        {
            this.Context = context;
            this.Request = context.Request;
            this.Response = context.Response;
            this.Server = context.Server;
            this.Session = context.Session;
            this.ProcessMain();
        }

        public abstract void ProcessMain();
    }
}
