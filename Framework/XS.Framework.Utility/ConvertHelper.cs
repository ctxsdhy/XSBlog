using System;
using XS.Framework.Common.Extension;

namespace XS.Framework.Utility
{
    /// <summary>
    /// 格式转换助手
    /// </summary>
    public class ConvertHelper
    {
        /// <summary>
        /// 转换成Int类型的参数
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static int GetInt(object obj)
        {
            const int defaultValue = -1;
            if (obj == null || obj.ToString().Trim().Length == 0)
                return defaultValue;

            int result;
            bool isSucceed = int.TryParse(obj.ToString(), out result);

            if (isSucceed)
                return result;

            return defaultValue;
        }

        /// <summary>
        /// 转换成Int类型的参数，如果不成功返回指定的默认值。
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="defaultValue"></param>
        /// <returns></returns>
        public static int GetInt(object obj, int defaultValue)
        {
            if (obj == null || obj.ToString().Length == 0)
                return defaultValue;

            int result;
            bool isSucceed = int.TryParse(obj.ToString(), out result);

            if (isSucceed)
                return result;

            return defaultValue;
        }

        /// <summary>
        /// 转换成Int类型的参数，如果不成功返回指定的默认值。
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="defaultValue"></param>
        /// <returns></returns>
        public static int? GetInt(object obj, int? defaultValue)
        {
            if (obj == null || obj.ToString().Length == 0)
                return defaultValue;

            int result;
            bool isSucceed = int.TryParse(obj.ToString(), out result);

            if (isSucceed)
                return result;

            return defaultValue;
        }

        /// <summary>
        /// 转换成字符串
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static string GetString(object obj)
        {
            if (obj == null || obj.ToString().Length == 0)
                return string.Empty;

            return obj.ToString();
        }

        /// <summary>
        /// 转换成字符串类型的参数，如果不成功返回指定的默认值。
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="defaultValue"></param>
        /// <returns></returns>
        public static string GetString(object obj, string defaultValue)
        {
            if (obj == null || obj.ToString().Length == 0)
                return defaultValue;

            return obj.ToString();
        }

        /// <summary>
        /// 获得日期，格式为yyyy-MM-dd，日期不对时返回空字符串
        /// </summary>
        /// <param name="date">要获取的日期</param>
        /// <returns></returns>
        public static string GetDate(object date)
        {
            return GetDate(date, "yyyy-MM-dd");
        }

        /// <summary>
        /// 获得时刻，格式为yyyy-MM-dd，日期不对时返回空字符串
        /// </summary>
        /// <param name="date">要获取的日期</param>
        /// <returns></returns>
        public static string GetMoment(object date)
        {
            return GetDate(date, "H:mm");
        }

        /// <summary>
        /// 获得完整日期，格式为yyyy-MM-dd，日期不对时返回空字符串
        /// </summary>
        /// <param name="date">要获取的日期</param>
        /// <returns></returns>
        public static string GetAllDate(object date)
        {
            return GetDate(date, "yyyy-MM-dd H:mm");
        }

        /// <summary>
        /// 获得日期月份，格式为yyyy年MM月，日期不对时返回空字符串
        /// </summary>
        /// <param name="date">获得日期月份</param>
        /// <returns></returns>
        public static string GetMonth(object date)
        {
            return GetDate(date, "yyyy年MM月");
        }

        /// <summary>
        /// 获得日期。日期不对时返回空字符串
        /// </summary>
        /// <param name="date">要获取的日期</param>
        /// <param name="format">要获取的日期的格式</param>
        /// <returns></returns>
        public static string GetDate(object date, string format)
        {
            string defaultValue = string.Empty;
            if (date == null || date.ToString().Length == 0)
                return defaultValue;

            DateTime dt;
            if (DateTime.TryParse(date.ToString(), out dt))
            {
                if (dt == DateTime.MinValue || dt.ToString("yyyy-MM-dd") == "9999-12-31"
                    || dt == DateTime.MaxValue || dt.ToString("yyyy-MM-dd") == "1900-01-01"
                    || dt.ToString("yyyy-MM-dd") == "0000-00-00" || dt.ToString("yyyy-MM-dd") == "0001-01-01")
                {
                    return defaultValue;
                }

                return dt.ToString(format);
            }
            return defaultValue;
        }

        /// <summary>
        /// 获得布尔值
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static bool GetBool(object obj)
        {
            if (obj == null || System.Convert.IsDBNull(obj) || string.IsNullOrEmpty(obj.ToString()))
                return false;

            if (obj.ToString() == "1")
                return true;

            bool result;
            if (bool.TryParse(obj.ToString(), out result))
            {
                return result;
            }
            return false;
        }

        /// <summary>
        /// 获得得浮点数
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static float GetFloat(object obj)
        {
            const float defaultValue = -1;
            if (obj == null || System.Convert.IsDBNull(obj) || string.IsNullOrEmpty(obj.ToString()))
                return defaultValue;

            return GetFloat(obj, defaultValue);
        }

        /// <summary>
        /// 获得浮点数
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="defaultValue"></param>
        /// <returns></returns>
        public static float GetFloat(object obj, float defaultValue)
        {
            float result;
            if (float.TryParse(obj.ToString(), out result))
            {
                return result;
            }
            return defaultValue;
        }

        /// <summary>
        /// 获得Decimal型数据，
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static decimal GetDecimal(object obj)
        {
            const decimal defaultValue = 0;
            if (obj == null || obj.ToString().Length == 0)
                return defaultValue;

            return GetDecimal(obj, defaultValue);
        }

        /// <summary>
        /// 获得Decimal型数据
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="defaultValue"></param>
        /// <returns></returns>
        public static decimal GetDecimal(object obj, decimal defaultValue)
        {
            if (obj == null)
                return defaultValue;

            decimal result;
            if (decimal.TryParse(obj.ToString(), out result))
            {
                return result;
            }
            return defaultValue;
        }

        /// <summary>
        /// 存入数据库的时间格式  --add by lsd 20090325
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static DateTime GetTime(object obj)
        {
            DateTime defaultValue = DateTime.MaxValue;

            if (obj == null || obj.ToString() == "")
                return defaultValue;
            try
            {
                DateTime result = System.Convert.ToDateTime(obj);
                //DateTime result = DateTime.ParseExact(obj.ToString(), "yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture);
                return result;
            }
            catch (Exception)
            {
                return defaultValue;
            }
        }

        /// <summary>
        /// 获得日期时间
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="defaultTime"></param>
        /// <returns></returns>
        public static DateTime GetDateTime(object obj, DateTime defaultTime)
        {
            DateTime defaultValue = defaultTime;

            if (obj == null || obj.ToString() == "")
                return defaultValue;

            DateTime result;
            if (DateTime.TryParse(obj.ToString(), out result))
            {
                if (result.Date != DateTime.MaxValue.Date && result.Date != DateTime.MinValue.Date)
                    return result;
            }
            return defaultValue;
        }


        /// <summary>
        /// 保留数字小数点后两位
        /// </summary>
        /// <param name="dnum">The dnum.</param>
        /// <returns></returns>
        public static string GetNumberDot2(object dnum)
        {
            if (dnum == null)
                return "0.00";
            try
            {
                return Math.Round(decimal.Parse(dnum.ToString()), 2).ToString();
            }
            catch (Exception)
            {
                return "0.00";
            }
        }

        public static Guid? GetGuid(string guid)
        {
            try
            {
                return new Guid(guid);
            }
            catch (Exception)
            {
                return null;
            }
        }

        /// <summary>
        /// 转换数据类型
        /// </summary>
        /// <typeparam name="T">目标类型</typeparam>
        /// <param name="o">待转换数据</param>
        /// <param name="defaultValue">默认值</param>
        /// <returns></returns>
        public static T Convert<T>(object o, T defaultValue)
        {
            return o.ToType(defaultValue);
        }

        /// <summary>
        /// 转换数据类型 默认值:default(T)
        /// </summary>
        /// <typeparam name="T">目标类型</typeparam>
        /// <param name="o">待转换数据</param>
        /// <returns></returns>
        public static T Convert<T>(object o)
        {
            return Convert(o, default(T));
        }
    }
}
