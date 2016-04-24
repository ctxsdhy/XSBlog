using System;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using XS.Framework.Data.DbProvider;

namespace XS.Blog.Data.SqlServer
{
    /// <summary>
    /// SqlServer数据库模型
    /// </summary>
    public class SqlServerProvider : IDbProvider
    {
        /// <summary>
        /// 返回DbProviderFactory实例
        /// </summary>
        /// <returns></returns>
        public DbProviderFactory Instance()
        {
            return SqlClientFactory.Instance;
        }

        /// <summary>
        /// 创建SQL参数
        /// </summary>
        /// <param name="paramName"></param>
        /// <param name="dbType"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        public DbParameter MakeParam(string paramName, DbType dbType, Int32 size)
        {
            SqlParameter param;

            if (size > 0)
                param = new SqlParameter(paramName, (SqlDbType)dbType, size);
            else
                param = new SqlParameter(paramName, (SqlDbType)dbType);

            return param;
        }

        /// <summary>
        /// 检索SQL参数信息并填充
        /// </summary>
        /// <param name="cmd"></param>
        public void DeriveParameters(IDbCommand cmd)
        {
            if ((cmd as SqlCommand) != null)
            {
                SqlCommandBuilder.DeriveParameters(cmd as SqlCommand);
            }
        }

        /// <summary>
        /// 是否支持全文搜索
        /// </summary>
        /// <returns></returns>
        public bool IsFullTextSearchEnabled()
        {
            return true;
        }

        /// <summary>
        /// 是否支持压缩数据库
        /// </summary>
        /// <returns></returns>
        public bool IsCompactDatabase()
        {
            return true;
        }

        /// <summary>
        /// 是否支持备份数据库
        /// </summary>
        /// <returns></returns>
        public bool IsBackupDatabase()
        {
            return true;
        }

        /// <summary>
        /// 返回刚插入记录的自增ID值, 如不支持则为""
        /// </summary>
        /// <returns></returns>
        public string GetLastIdSql()
        {
            return "SELECT SCOPE_IDENTITY()";
        }

        /// <summary>
        /// 是否支持数据库优化
        /// </summary>
        /// <returns></returns>
        public bool IsDbOptimize()
        {
            return true;
        }

        /// <summary>
        /// 是否支持数据库收缩
        /// </summary>
        /// <returns></returns>
        public bool IsShrinkData()
        {
            return true;
        }

        /// <summary>
        /// 是否支持存储过程
        /// </summary>
        /// <returns></returns>
        public bool IsStoreProc()
        {
            return true;
        }
    }
}
