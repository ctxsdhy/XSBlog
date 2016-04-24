using System;
using XS.Framework.Utility;

namespace XS.Framework.Data.DbProvider
{
    /// <summary>
    /// 数据库驱动
    /// </summary>
    public class DbProvider
    {
        private static IDbProvider _instance;
        private static readonly object LockHelper = new object();

        static DbProvider()
        {
            DataBaseCategory = "";
        }

        /// <summary>
        /// 数据库类型
        /// </summary>
        public static string DataBaseCategory { get; set; }

        /// <summary>
        /// 程序集名称
        /// </summary>
        public static string AssemblyName { get; set; }

        /// <summary>
        /// 得到具体数据库驱动
        /// </summary>
        /// <returns></returns>
        public static IDbProvider GetInstance()
        {
            if (_instance == null)
            {
                lock (LockHelper)
                {
                    if (_instance == null)
                    {
                        GetProvider();
                    }
                }
            }
            return _instance;
        }

        /// <summary>
        /// 创建具体数据库驱动
        /// </summary>
        private static void GetProvider()
        {
            try
            {
                _instance =
                    TypeResolverHelper.CreateInstance<IDbProvider>(
                        string.Format("{0}.Data.{1}", AssemblyName, DataBaseCategory),
                        string.Format("{0}.Data.{1}.{1}Provider", AssemblyName, DataBaseCategory));

            }
            catch
            {
                throw new Exception(string.Format("web.config中未找到配置项中的数据类别, 请检查数据类型名称是否正确, 例:SqlServer"));
            }
        }
    }
}
