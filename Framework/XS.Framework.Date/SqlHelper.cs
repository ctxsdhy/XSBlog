using System;
using System.Data;
using System.Data.Common;
using XS.Framework.Data.DbProvider;

namespace XS.Framework.Data
{
    public class SqlHelper
    {
        #region 私有属性

        /// <summary>
        /// DbProviderFactory实例
        /// </summary>
        private static DbProviderFactory _factory;

        /// <summary>
        /// IDbProvider接口
        /// </summary>
        private static IDbProvider Provider
        {
            get { return DbProvider.DbProvider.GetInstance(); }
        }

        static SqlHelper()
        {
            ConnectionString = null;
        }

        #region 数据库连接字符串

        /// <summary>
        /// 数据库连接字符串
        /// </summary>
        public static string ConnectionString { get; set; }

        #endregion

        /// <summary>
        /// DbFactory实例
        /// </summary>
        private static DbProviderFactory Factory
        {
            get { return _factory ?? (_factory = Provider.Instance()); }
        }

        private const string GetPagingStoredProcedureName = "sp_GetListByPage";

        #endregion

        #region 私有方法

        /// <summary>
        /// 将DbParameter参数数组(参数值)分配给DbCommand命令.
        /// 这个方法将给任何一个参数分配DBNull.Value;
        /// 该操作将阻止默认值的使用.
        /// </summary>
        /// <param name="command">命令名</param>
        /// <param name="commandParameters">DbParameters数组</param>
        private static void AttachParameters(DbCommand command, DbParameter[] commandParameters)
        {
            if (command == null) throw new ArgumentNullException("command");
            if (commandParameters != null)
            {
                foreach (DbParameter p in commandParameters)
                {
                    if (p != null)
                    {
                        // 检查未分配值的输出参数,将其分配以DBNull.Value.
                        if ((p.Direction == ParameterDirection.InputOutput || p.Direction == ParameterDirection.Input) &&
                            (p.Value == null))
                        {
                            p.Value = DBNull.Value;
                        }
                        command.Parameters.Add(p);
                    }
                }
            }
        }

        /// <summary>
        /// 预处理用户提供的命令
        /// </summary>
        /// <param name="command"></param>
        /// <param name="connection"></param>
        /// <param name="commandType"></param>
        /// <param name="commandText"></param>
        /// <param name="commandParameters"></param>
        /// <param name="mustCloseConnection"></param>
        private static void PrepareCommand(DbCommand command, DbConnection connection, CommandType commandType, string commandText, DbParameter[] commandParameters, out bool mustCloseConnection)
        {
            if (command == null) throw new ArgumentNullException("command");
            if (string.IsNullOrEmpty(commandText)) throw new ArgumentNullException("commandText");

            if (connection.State != ConnectionState.Open)
            {
                mustCloseConnection = true;
                connection.Open();
            }
            else
            {
                mustCloseConnection = false;
            }

            // 给命令分配一个数据库连接.
            command.Connection = connection;
            // 设置命令文本(存储过程名或SQL语句)
            command.CommandText = commandText;
            // 设置命令类型.
            command.CommandType = commandType;
            // 分配命令参数
            if (commandParameters != null)
                AttachParameters(command, commandParameters);
            return;
        }

        #endregion

        #region ExecuteNonQuery

        public static int ExecuteNonQuery(string commandText)
        {
            return ExecuteNonQuery(CommandType.Text, commandText, null);
        }

        public static int ExecuteNonQuery(string commandText, DbParameter[] commandParameters)
        {
            return ExecuteNonQuery(CommandType.Text, commandText, commandParameters);
        }

        public static int ExecuteNonQuery(CommandType commandType, string commandText)
        {
            return ExecuteNonQuery(commandType, commandText, null);
        }

        public static int ExecuteNonQuery(CommandType commandType, string commandText, DbParameter[] commandParameters)
        {
            if (string.IsNullOrEmpty(ConnectionString)) throw new ArgumentNullException("ConnectionString");

            using (DbConnection connection = Factory.CreateConnection())
            {
                if (connection != null)
                {
                    connection.ConnectionString = ConnectionString;

                    return ExecuteNonQuery(connection, commandType, commandText, commandParameters);
                }
            }
            return 0;
        }

        private static int ExecuteNonQuery(DbConnection connection, CommandType commandType, string commandText, DbParameter[] commandParameters = null)
        {
            if (connection == null) throw new ArgumentNullException("connection");

            DbCommand cmd = Factory.CreateCommand();
            bool mustCloseConnection;
            PrepareCommand(cmd, connection, commandType, commandText, commandParameters, out mustCloseConnection);

            int retval = 0;
            try
            {
                if (cmd != null) retval = cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            if (cmd != null) cmd.Parameters.Clear();
            if (mustCloseConnection)
                connection.Close();
            return retval;
        }

        #endregion

        #region ExecuteDataSet

        public static DataSet ExecuteDataset(string commandText)
        {
            return ExecuteDataset(CommandType.Text, commandText, null);
        }

        public static DataSet ExecuteDataset(CommandType commandType, string commandText)
        {
            return ExecuteDataset(commandType, commandText, null);
        }

        public static DataSet ExecuteDataset(CommandType commandType, string commandText, params DbParameter[] commandParameters)
        {
            if (string.IsNullOrEmpty(ConnectionString)) throw new ArgumentNullException("ConnectionString");

            using (DbConnection connection = Factory.CreateConnection())
            {
                if (connection != null)
                {
                    connection.ConnectionString = ConnectionString;

                    return ExecuteDataset(connection, commandType, commandText, commandParameters);
                }
            }
            return null;
        }

        public static DataSet ExecuteDataset(DbConnection connection, CommandType commandType, string commandText)
        {
            return ExecuteDataset(connection, commandType, commandText, null);
        }

        public static DataSet ExecuteDataset(DbConnection connection, CommandType commandType, string commandText, params DbParameter[] commandParameters)
        {
            if (connection == null) throw new ArgumentNullException("connection");

            connection.ConnectionString = ConnectionString;
            connection.Open();

            DbCommand cmd = Factory.CreateCommand();
            bool mustCloseConnection;
            PrepareCommand(cmd, connection, commandType, commandText, commandParameters, out mustCloseConnection);

            using (DbDataAdapter da = Factory.CreateDataAdapter())
            {
                if (da != null)
                {
                    da.SelectCommand = cmd;
                    var ds = new DataSet();

                    try
                    {
                        da.Fill(ds);
                    }
                    catch (Exception ex)
                    {

                        throw new Exception(ex.Message);
                    }

                    if (cmd != null) cmd.Parameters.Clear();

                    if (mustCloseConnection)
                        connection.Close();

                    return ds;
                }
            }
            return null;
        }

        #endregion

        #region ExecuteReader

        public static DbDataReader ExecuteReader(CommandType commandType, string commandText)
        {
            return ExecuteReader(commandType, commandText, null);
        }

        public static DbDataReader ExecuteReader(CommandType commandType, string commandText, params DbParameter[] commandParameters)
        {
            if (string.IsNullOrEmpty(ConnectionString)) throw new ArgumentNullException("ConnectionString");
            DbConnection connection = null;
            try
            {
                connection = Factory.CreateConnection();
                if (connection != null)
                {
                    connection.ConnectionString = ConnectionString;

                    return ExecuteReader(connection, commandType, commandText, commandParameters);
                }
            }
            catch (Exception ex)
            {
                if (connection != null) connection.Close();
                throw new Exception(ex.Message);
            }
            return null;
        }

        public static IDataReader ExecuteReader(DbParameter[] parameters)
        {
            return ExecuteReader(CommandType.StoredProcedure, GetPagingStoredProcedureName, parameters);
        }

        public static int GetRecordCount(DbParameter[] parameters)
        {
            object obj = ExecuteScalar(CommandType.StoredProcedure, GetPagingStoredProcedureName, parameters);
            int recordCount = obj == null || obj == DBNull.Value ? 0 : Convert.ToInt32(obj);
            return recordCount;
        }

        private static DbDataReader ExecuteReader(DbConnection connection, CommandType commandType, string commandText, DbParameter[] commandParameters)
        {
            if (connection == null) throw new ArgumentNullException("connection");

            connection.ConnectionString = ConnectionString;
            connection.Open();

            bool mustCloseConnection = false;

            DbCommand cmd = Factory.CreateCommand();
            try
            {
                PrepareCommand(cmd, connection, commandType, commandText, commandParameters, out mustCloseConnection);

                if (cmd != null)
                {
                    DbDataReader dataReader = cmd.ExecuteReader(CommandBehavior.CloseConnection);

                    bool canClear = true;
                    foreach (DbParameter commandParameter in cmd.Parameters)
                    {
                        if (commandParameter.Direction != ParameterDirection.Input)
                            canClear = false;
                    }

                    if (canClear)
                    {
                        cmd.Parameters.Clear();
                    }

                    return dataReader;
                }
            }
            catch
            {
                if (mustCloseConnection)
                    connection.Close();
                throw;
            }
            return null;
        }

        #endregion

        #region ExecuteScalar

        public static object ExecuteScalar(string commandText)
        {
            return ExecuteScalar(CommandType.Text, commandText, null);
        }

        public static object ExecuteScalar(CommandType commandType, string commandText)
        {
            return ExecuteScalar(commandType, commandText, null);
        }

        public static object ExecuteScalar(string commandText, params DbParameter[] commandParameters)
        {
            return ExecuteScalar(CommandType.Text, commandText, commandParameters);
        }

        public static object ExecuteScalar(CommandType commandType, string commandText, params DbParameter[] commandParameters)
        {
            if (string.IsNullOrEmpty(ConnectionString)) throw new ArgumentNullException("ConnectionString");
            using (DbConnection connection = Factory.CreateConnection())
            {
                if (connection != null)
                {
                    connection.ConnectionString = ConnectionString;

                    return ExecuteScalar(connection, commandType, commandText, commandParameters);
                }
            }
            return null;
        }

        public static object ExecuteScalar(DbConnection connection, CommandType commandType, string commandText, params DbParameter[] commandParameters)
        {
            if (connection == null) throw new ArgumentNullException("connection");

            connection.ConnectionString = ConnectionString;
            connection.Open();

            DbCommand cmd = Factory.CreateCommand();

            bool mustCloseConnection;
            PrepareCommand(cmd, connection, commandType, commandText, commandParameters, out mustCloseConnection);

            if (cmd != null)
            {
                object retval = cmd.ExecuteScalar();

                cmd.Parameters.Clear();

                if (mustCloseConnection)
                    connection.Close();

                return retval;
            }
            return null;
        }

        #endregion

        #region MakeParam

        public static DbParameter MakeInParam(string paramName, DbType dbType, int size, object value)
        {
            return MakeParam(paramName, dbType, size, ParameterDirection.Input, value);
        }

        public static DbParameter MakeOutParam(string paramName, DbType dbType, int size)
        {
            return MakeParam(paramName, dbType, size, ParameterDirection.Output, null);
        }

        public static DbParameter MakeInParam(string paramName, DbType dbType, object value)
        {
            return MakeParam(paramName, dbType, 0, ParameterDirection.Input, value);
        }

        public static DbParameter MakeOutParam(string paramName, DbType dbType)
        {
            return MakeParam(paramName, dbType, 0, ParameterDirection.Output, null);
        }

        public static DbParameter MakeParam(string paramName, DbType dbType, Int32 size, ParameterDirection direction, object value)
        {
            DbParameter param = Provider.MakeParam(paramName, dbType, size);

            param.Direction = direction;
            if (!(direction == ParameterDirection.Output && value == null))
                param.Value = value;

            return param;
        }

        #endregion

        #region Helper

        /// <summary>
        /// 获得分页存储过程参数
        /// </summary>
        /// <param name="table"></param>
        /// <param name="field"></param>
        /// <param name="where"></param>
        /// <param name="orderby"></param>
        /// <param name="pageSize"></param>
        /// <param name="pageIndex"></param>
        /// <param name="getRecordType">获取记录的方式，1：获得记录总数，2：获得记录集，3：两个都获得</param>
        /// <returns></returns>
        public static DbParameter[] GetPagingStoredProcedureParameters(string table, string field, string where, string orderby, int pageSize, int pageIndex, int getRecordType)
        {
            //请确保第六项为IsReCount
            DbParameter[] parameters = {
                                            SqlHelper.MakeInParam("@TableName", (DbType) SqlDbType.VarChar, table),
                                            SqlHelper.MakeInParam("@FieldsString", (DbType) SqlDbType.VarChar,field),
                                            SqlHelper.MakeInParam("@OrderString", (DbType) SqlDbType.VarChar, orderby),
                                            SqlHelper.MakeInParam("@PageSize", (DbType) SqlDbType.Int, pageSize),
                                            SqlHelper.MakeInParam("@PageIndex", (DbType) SqlDbType.Int, pageIndex),
                                            SqlHelper.MakeInParam("@WhereString", (DbType) SqlDbType.VarChar, where),
                                            SqlHelper.MakeInParam("@GetRecordType", (DbType) SqlDbType.VarChar, getRecordType),
                                            SqlHelper.MakeOutParam("@TotalRecord", (DbType) SqlDbType.Int)
                                        };
            return parameters;
        }

        #endregion
    }
}
