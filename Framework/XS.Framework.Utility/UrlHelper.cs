
namespace XS.Framework.Utility
{
    /// <summary>
    /// Url助手
    /// </summary>
    public class UrlHelper
    {
        /// <summary>
        /// 获得字符串型参数
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static string GetString(object obj)
        {
            if(obj != null)
            {
                return obj.ToString();
            }
            return "";
        }

        /// <summary>
        /// 获得整型参数
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static int GetInt(object obj)
        {
            if (obj != null)
            {
                return ConvertHelper.GetInt(obj);
            }
            return -1;
        }
    }
}
