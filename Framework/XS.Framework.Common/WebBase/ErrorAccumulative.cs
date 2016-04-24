using System;
using System.Collections.Generic;
using System.Text;

namespace XS.Framework.Common.WebBase
{
    /// <summary>
    /// 错误提示累计器
    /// </summary>
    public class ErrorTipAccumulative : Dictionary<string, string>
    {
        public ErrorTipAccumulative()
            : base(StringComparer.OrdinalIgnoreCase)
        {
        }
        /// <summary>
        ///  附加一条错误提示信息
        /// </summary>
        /// <param name="key"></param>
        /// <param name="message"></param>
        public void Append(string key, string message)
        {
            this[key] = message;
        }
        /// <summary>
        /// 将消息序列化json数据
        /// </summary>
        /// <returns></returns>
        public string ToJSON()
        {
            if (this.Values.Count < 1)
                return "{error:false,messages:[]}";

            StringBuilder json = new StringBuilder("{error:true,messages:[");
            foreach (string k in this.Keys)
            {
                json.AppendFormat("{{key:'{0}',message:'{1}'}},", k, WebUtil.ToJavascriptString(this[k]));
            }
            json.Remove(json.Length - 1, 1);
            json.Append("]}");

            return json.ToString();
        }

        /// <summary>
        /// 将消息序列化为html
        /// </summary>
        /// <returns></returns>
        public string ToHTML()
        {
            if (this.Values.Count < 1) return "";
            StringBuilder json = new StringBuilder("<ul class=\"tips\">");
            json.AppendLine();
            foreach (string k in this.Keys)
            {
                json.AppendFormat("<li class=\"tip-type-error\" id=\"tip-{0}\">{1}</li>", k, this[k]);
                json.AppendLine();
            }
            json.Append("</ul>");
            return json.ToString();
        }
        public string ToText()
        {
            StringBuilder sb = new StringBuilder();
            foreach (string s in this.Values)
            {
                sb.AppendLine(s);
            }
            return sb.ToString();
        }
    }
}