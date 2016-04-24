using System;
using XS.Blog.Config;
using XS.Framework.Data;
using XS.Framework.Data.DbProvider;
using XS.Framework.Utility;

namespace XS.Blog.Data.DataProvider
{
    /// <summary>
    /// 数据驱动
    /// </summary>
    public class DataProvider
    {
        private static IDataProvider _instance;
        private static readonly object LockHelper = new object();

        /// <summary>
        /// 创建具体数据访问层
        /// </summary>
        static DataProvider()
        {
            GetProvider();
        }

        /// <summary>
        /// 得到具体数据访问层
        /// </summary>
        /// <returns></returns>
        public static IDataProvider GetInstance()
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

            //设置数据库驱动的类型
            if (string.IsNullOrEmpty(DbProvider.DataBaseCategory))
                DbProvider.DataBaseCategory = SysConfig.DataBaseCategory;

            //设置数据库驱动程序集名称
            if (string.IsNullOrEmpty(DbProvider.AssemblyName))
                DbProvider.AssemblyName = SysConfig.AssemblyName;

            //设置数据Helper默认连接字符串
            if (string.IsNullOrEmpty(SqlHelper.ConnectionString))
                SqlHelper.ConnectionString = SysConfig.DataBaseString;

            return _instance;
        }

        /// <summary>
        /// 创建具体数据访问层
        /// </summary>
        private static void GetProvider()
        {
            try
            {
                string databaseCategory = SysConfig.DataBaseCategory;
                string assemblyName = SysConfig.AssemblyName;
                _instance =
                    TypeResolverHelper.CreateInstance<IDataProvider>(
                        string.Format("{0}.Data.{1}", assemblyName, databaseCategory),
                        string.Format("{0}.Data.{1}.DataProvider", assemblyName, databaseCategory));
            }
            catch
            {
                throw new Exception(string.Format("web.config中未定义{0}项或未找到配置项中的数据类别, 请检查数据类型名称是否正确, 例:SqlServer", SysConfig.DataBaseCategoryName));
            }
        }
    }
}
