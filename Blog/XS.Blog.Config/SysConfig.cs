using System.Configuration;

namespace XS.Blog.Config
{
    /// <summary>
    /// 系统配置
    /// </summary>
    public class SysConfig
    {
        /// <summary>
        /// 程序集名称
        /// </summary>
        public static string AssemblyName
        {
            get { return "XS.Blog"; }
        }

        /// <summary>
        /// 数据库类型
        /// </summary>
        public static string DataBaseCategory => ConfigurationManager.AppSettings["XSBlogDataBaseCategory"];

        /// <summary>
        /// 数据库类型名称
        /// </summary>
        public static string DataBaseCategoryName => "XSBlogDataBaseCategory";

        /// <summary>
        /// 数据库连接字符串
        /// </summary>
        public static string DataBaseString => ConfigurationManager.ConnectionStrings["XSBlogDataBase"].ConnectionString;

        /// <summary>
        /// 获得七牛公钥
        /// </summary>
        /// <returns></returns>
        public static string AccessKey => ConfigurationManager.AppSettings["QiniuAccessKey"];

        /// <summary>
        /// 获得七牛公钥
        /// </summary>
        /// <returns></returns>
        public static string SecretKey => ConfigurationManager.AppSettings["QiniuSecretKey"];
    }
}
