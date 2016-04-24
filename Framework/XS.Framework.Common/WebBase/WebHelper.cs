using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using XS.Framework.Common.Extension;

namespace XS.Framework.Common.WebBase
{
    /// <summary>
    /// 提供WEB开发常用功能
    /// </summary>
    public static class WebUtil
    {
        /// <summary>
        /// 判断当前是否是POST请求方式
        /// </summary>
        /// <returns>是否接收到了Post请求</returns>
        public static bool IsPost()
        {
            return HttpContext.Current.Request.HttpMethod.Equals("POST");
        }
        /// <summary>
        /// 判断当前是否是GET请求方式
        /// </summary>
        /// <returns>是否接收到了Get请求</returns>
        public static bool IsGet()
        {
            return HttpContext.Current.Request.HttpMethod.Equals("GET");
        }

        /// <summary>
        /// 返回URL查询参数值
        /// </summary>
        /// <param name="name">参数名称</param>
        /// <returns>空则返回  string.Empty; </returns>
        public static string GetQuery(string name)
        {
            string str = HttpContext.Current.Request.QueryString[name];
            return str ?? string.Empty;
        }

        /// <summary>
        /// 返回URL查询参数值 如果不存在则返回Null
        /// </summary>
        /// <param name="name">参数名称</param>
        /// <returns>空则返回 Null</returns>
        public static string GetQueryOrNull(string name)
        {
            return HttpContext.Current.Request.QueryString[name];
        }

        /// <summary>
        /// 返回URL查询参数并将其转换为T类型  如果转换失败则返回默认值
        /// </summary>
        /// <typeparam name="T">基元值类型或DateTime</typeparam>
        /// <param name="name">参数名称</param>
        /// <param name="defaultValue">默认值 </param>
        /// <returns>转换成功则返回转换的值，否则返回defaultValue</returns>
        public static T GetQuery<T>(string name, T defaultValue)
        {
            string str = GetQueryOrNull(name);
            if (string.IsNullOrEmpty(str))
                return defaultValue;

            return str.ToType<T>(defaultValue);
        }

        /// <summary>
        /// 返回FORM表单参数值 如果不存在则返回Null
        /// </summary>
        /// <param name="name">参数名称</param>
        /// <returns>空则返回 Null</returns>
        public static string GetFormOrNull(string name)
        {
            return HttpContext.Current.Request.Form[name];
        }

        /// <summary>
        /// 获得FORM表单参数值
        /// </summary>
        /// <param name="name">参数名称</param>
        /// <returns>空则返回  string.Empty; </returns>
        public static string GetForm(string name)
        {
            string str = HttpContext.Current.Request.Form[name];
            return str ?? string.Empty;
        }

        /// <summary>
        /// 返回表单参数值并将其转换为T类型 如果转换失败则返回默认值
        /// </summary>
        /// <typeparam name="T">基元值类型或DateTime</typeparam>
        /// <param name="name">参数名称</param>
        /// <param name="defaultValue">默认值 </param>
        /// <returns>转换成功则返回转换的值，否则返回defaultValue</returns>
        public static T GetForm<T>(string name, T defaultValue)
        {
            string str = GetFormOrNull(name);
            if (string.IsNullOrEmpty(str))
                return defaultValue;

            return str.ToType<T>(defaultValue);
        }

        /// <summary>
        /// 返回 System.String 对象转义为Javascript脚本字符串常量之后的字符串
        /// </summary>
        /// <param name="str">一个 System.String 引用</param>
        /// <returns></returns>
        public static string ToJavascriptString(string str)
        {
            return ToJavascriptString(str, false);
        }

        /// <summary>
        /// 返回 System.String 对象转义为Javascript脚本字符串常量之后的字符串
        /// </summary>
        /// <param name="str">一个 System.String 引用</param>
        /// <param name="addDoubleQuotes">是否添加双引号</param>
        /// <returns></returns>
        public static string ToJavascriptString(string str, bool addDoubleQuotes)
        {
            if (str == null)
                str = string.Empty;

            const string QUETE = "\"";

            if (str.Length == 0)
            {
                if (!addDoubleQuotes)
                    return str;
                else
                    return QUETE + QUETE;
            }
            Regex _transferredRule = new Regex(@"(""|\\)", RegexOptions.Compiled);
            str = _transferredRule.Replace(str, "\\$1");
            StringBuilder sb = new StringBuilder(str);
            sb.Replace("\r", "\\r");
            sb.Replace("\n", "\\n");

            if (addDoubleQuotes)
            {
                sb.Insert(0, QUETE);
                sb.Append(QUETE);
            }

            return sb.ToString();
        }

        /// <summary>
        /// 返回来路页面的地址
        /// </summary>
        /// <returns></returns>
        public static string GetUrlReferrer()
        {
            return HttpContext.Current.Request.Headers["Referer"] ?? string.Empty;
        }


    }


}
