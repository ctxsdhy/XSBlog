using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using XS.Framework.Common.Extension;

namespace XS.Framework.Data
{
    /// <summary>
    /// 数据操作层的辅助类
    /// </summary>
    public class SqlMethodHelper
    {

        #region 类型转换
        /// <summary>
        /// 转换成 GUID
        /// </summary>
        /// <param name="o">待转换数据</param>
        /// <param name="defaultValue">为Null时使用的默认值</param>
        /// <returns></returns>
        public static Guid Convert(object o, Guid defaultValue)
        {

            if (o == null || o == DBNull.Value)
            {
                return defaultValue;
            }
            return new Guid(o.ToString());
        }
        /// <summary>
        /// 转换成 GUID 默认值 Guid.Empty
        /// </summary>
        /// <param name="o">待转换数据</param>
        /// <returns></returns>
        public static Guid Convert(object o)
        {
            return Convert(o, Guid.Empty);
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
        #endregion

        /// <summary>
        /// 查询一条数据,指定数据库的连接字符串
        /// </summary>
        /// <typeparam name="T">目标类型</typeparam>
        /// <param name="commandText">Sql语句</param>
        /// <param name="func">结果处理方法</param>
        /// <param name="paramslist">Sql参数</param>
        /// <returns></returns>
        public static T FindOne<T>(string commandText, Func<IDataReader, T> func, params DbParameter[] paramslist)
        {
            using (DbDataReader dr = SqlHelper.ExecuteReader(CommandType.Text, commandText, paramslist))
            {
                if (dr.Read())
                {
                    return func(dr);
                }
            }
            return default(T);
        }

        /// <summary>
        /// 查询数据
        /// </summary>
        /// <typeparam name="T">目标元数据类型</typeparam>
        /// <param name="commandText">Sql语句</param>
        /// <param name="func">结果处理方法</param>
        /// <param name="paramslist">Sql参数</param>
        /// <returns></returns>
        public static List<T> Find<T>(string commandText, Func<IDataReader, T> func, params DbParameter[] paramslist)
        {
            var list = new List<T>();
            using (DbDataReader dr = SqlHelper.ExecuteReader(CommandType.Text, commandText, paramslist))
            {
                if (dr != null)
                {
                    while (dr.Read())
                    {
                        list.Add(func(dr));
                    }
                }
            }
            return list;
        }

        /// <summary>
        /// 分页查询数据
        /// </summary>
        /// <typeparam name="T">目标元数据类型</typeparam>
        /// <param name="parameters">分页的参数</param>
        /// <param name="totalCount">返回记录数量</param>
        /// <param name="func">结果处理方法</param>
        /// <returns></returns>
        public static List<T> Find<T>(DbParameter[] parameters, out int totalCount, Func<IDataReader, T> func)
        {
            var list = new List<T>();
            parameters[6].Value = 1;
            totalCount = SqlHelper.GetRecordCount(parameters);
            if (totalCount > 0)
            {
                parameters[6].Value = 2;
                using (IDataReader dr = SqlHelper.ExecuteReader(parameters))
                {
                    if (dr != null)
                    {
                        while (dr.Read())
                        {
                            list.Add(func(dr));
                        }
                    }
                }
            }
            return list;
        }
    }
}
