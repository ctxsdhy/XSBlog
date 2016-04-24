using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Text;
using XS.Blog.Entity;
using XS.Framework.Data;
using XS.Framework.Utility;

namespace XS.Blog.Data.SqlServer
{
    /// <summary>
    /// 用户数据层
    /// </summary>
    public class SqlUser : IUser
    {
        #region 基础方法

        #region 是否存在该记录 Exists(Guid Guid)

        /// <summary>
        /// 是否存在该记录 Exists(Guid Guid)
        /// </summary>
        /// <param name="guid">主键id</param>
        /// <returns>true:存在; false:不存在</returns>
        public bool Exists(string guid)
        {
            var strSql = new StringBuilder();
            strSql.Append("select count(1) from XSBlog_User");
            strSql.Append(" where ");
            strSql.Append(" Guid = @Guid  ");

            DbParameter[] parameters = {
			            SqlHelper.MakeInParam("@Guid", (DbType) SqlDbType.UniqueIdentifier, Guid.NewGuid())               
            };

            object obj = SqlHelper.ExecuteScalar(CommandType.Text, strSql.ToString(), parameters);
            if (obj == null)
            {
                return false;
            }
            return true;
        }

        #endregion

        #region 保存添加数据 Add(UserInfo entity)

        /// <summary>
        /// 保存添加数据 Add(UserInfo entity)
        /// </summary>
        /// <param name="entity">实体类(UserInfo)</param>
        ///<returns>返回新增的ID</returns>
        public void Add(UserInfo entity)
        {
            var strSql = new StringBuilder();
            strSql.Append("insert into XSBlog_User(");
            strSql.Append("Guid,Name,Tag,Login_Name,Login_Pwd,Email");
            strSql.Append(") values (");
            strSql.Append("@Guid,@Name,@Tag,@Login_Name,@Login_Pwd,@Email");
            strSql.Append(") ");

            DbParameter[] parameters = {
			            SqlHelper.MakeInParam("@Guid", (DbType) SqlDbType.UniqueIdentifier, Guid.NewGuid()) ,            
                        SqlHelper.MakeInParam("@Name", (DbType) SqlDbType.VarChar, entity.Name) ,            
                        SqlHelper.MakeInParam("@Tag", (DbType) SqlDbType.VarChar, entity.Tag) ,            
                        SqlHelper.MakeInParam("@Login_Name", (DbType) SqlDbType.VarChar, entity.LoginName) ,            
                        SqlHelper.MakeInParam("@Login_Pwd", (DbType) SqlDbType.VarChar, entity.LoginPwd) ,            
                        SqlHelper.MakeInParam("@Email", (DbType) SqlDbType.VarChar, entity.Email)             
              
            };

            SqlHelper.ExecuteNonQuery(strSql.ToString(), parameters);

        }

        #endregion

        #region 更新数据 Update(UserInfo entity)

        /// <summary>
        /// 更新数据 Update(UserInfo entity)
        /// </summary>
        /// <param name="entity">实体类(UserInfo)</param>
        ///<returns>true:保存成功; false:保存失败</returns>
        public bool Update(UserInfo entity)
        {
            var strSql = new StringBuilder();
            strSql.Append("update XSBlog_User set ");

            strSql.Append(" Guid = @Guid , ");
            strSql.Append(" Name = @Name , ");
            strSql.Append(" Tag = @Tag , ");
            strSql.Append(" Login_Name = @Login_Name , ");
            strSql.Append(" Login_Pwd = @Login_Pwd , ");
            strSql.Append(" Email = @Email  ");
            strSql.Append(" where Guid=@Guid  ");

            DbParameter[] parameters = {
			            SqlHelper.MakeInParam("@Id", (DbType) SqlDbType.Decimal, entity.Id) ,            
                        SqlHelper.MakeInParam("@Guid", (DbType) SqlDbType.UniqueIdentifier, Guid.NewGuid()) ,            
                        SqlHelper.MakeInParam("@Name", (DbType) SqlDbType.VarChar, entity.Name) ,            
                        SqlHelper.MakeInParam("@Tag", (DbType) SqlDbType.VarChar, entity.Tag) ,            
                        SqlHelper.MakeInParam("@Login_Name", (DbType) SqlDbType.VarChar, entity.LoginName) ,            
                        SqlHelper.MakeInParam("@Login_Pwd", (DbType) SqlDbType.VarChar, entity.LoginPwd) ,            
                        SqlHelper.MakeInParam("@Email", (DbType) SqlDbType.VarChar, entity.Email)             
              
            };

            int rows = SqlHelper.ExecuteNonQuery(CommandType.Text, strSql.ToString(), parameters);
            if (rows > 0)
            {
                return true;
            }
            return false;
        }

        #endregion

        #region 物理删除数据 Delete(Guid Guid)

        /// <summary>
        /// 物理删除数据 Delete(Guid Guid)
        /// </summary>
        /// <param name="guid">主键Id(int)</param>
        /// <returns>true:删除成功; false:删除失败</returns>
        public bool Delete(string guid)
        {

            var strSql = new StringBuilder();
            strSql.Append("delete from XSBlog_User ");
            strSql.Append(" where Guid=@Guid ");

            DbParameter[] parameters = {
			            SqlHelper.MakeInParam("@Guid", (DbType) SqlDbType.UniqueIdentifier, ConvertHelper.GetGuid(guid))               
            };

            int rows = SqlHelper.ExecuteNonQuery(CommandType.Text, strSql.ToString(), parameters);
            if (rows > 0)
            {
                return true;
            }
            return false;
        }

        #endregion


        #region 得到一个对象实体 GetModel(Guid Guid)

        /// <summary>
        /// 得到一个对象实体 GetModel(Guid Guid)
        /// </summary>
        public UserInfo GetModel(string guid)
        {
            var strSql = new StringBuilder();
            strSql.Append("select Id, Guid, Name, Tag, Login_Name, Login_Pwd, Email  ");
            strSql.Append("  from XSBlog_User ");
            strSql.Append(" where ");
            strSql.Append(" Guid = @Guid  ");

            DbParameter[] parameters = {
			            SqlHelper.MakeInParam("@Guid", (DbType) SqlDbType.UniqueIdentifier, ConvertHelper.GetGuid(guid))               
            };

            return SqlMethodHelper.FindOne(strSql.ToString(), ReaderBind, parameters);
        }

        #endregion

        #region 根据条件获取列表 GetList(string strWhere,string orderBy=null)

        /// <summary>
        /// 根据条件获取列表 GetList(string strWhere,string orderBy=null)
        /// </summary>
        /// <param name="strWhere">strWhere</param>
        /// <param name="orderBy">orderBy</param>
        /// <returns>返回List(UserInfo)类型数据,未查询到数据则返回null</returns>
        public List<UserInfo> GetList(string strWhere, string orderBy = null)
        {
            var strSql = new StringBuilder();
            strSql.Append("select Id, Guid, Name, Tag, Login_Name, Login_Pwd, Email  ");
            strSql.Append("  from XSBlog_User ");
            if (!string.IsNullOrEmpty(strWhere))
            {
                strSql.Append(" where " + strWhere);
            }
            if (string.IsNullOrEmpty(orderBy))
            {
            }
            else
            {
                strSql.Append(" order by " + orderBy);
            }
            return SqlMethodHelper.Find(strSql.ToString(), ReaderBind, null);
        }

        #endregion

        #region 根据条件分页获取列表 GetList(int currentPageIndex, int pageSize, out int totalCount, string strWhere, string orderBy)

        /// <summary>
        /// 根据条件分页获取列表 GetList(int currentPageIndex, int pageSize, out int totalCount, string strWhere, string orderBy)
        /// </summary>
        /// <param name="currentPageIndex">当前页码(int)</param>
        /// <param name="pageSize">分页大小(int)</param>
        /// <param name="totalCount">总记录数(out int)</param>
        /// <param name="strWhere">查询条件(string)</param>
        /// <param name="orderBy">排序字段(string)</param>
        /// <returns>返回List&lt;CustomersInfo&gt;类型数据,未查询到数据则返回null</returns>
        public List<UserInfo> GetList(int currentPageIndex, int pageSize, out int totalCount, string strWhere, string orderBy)
        {
            if (string.IsNullOrEmpty(strWhere))
            {
                strWhere = " 1=1 ";
            }
            strWhere = string.IsNullOrEmpty(strWhere) ? "" : " AND " + strWhere;
            if (string.IsNullOrEmpty(orderBy))
            {
            }
            return SqlMethodHelper.Find(SqlHelper.GetPagingStoredProcedureParameters("XSBlog_User", "*", strWhere, orderBy, pageSize, currentPageIndex, 3), out totalCount, ReaderBind);
        }

        #endregion

        #endregion

        #region 私有方法

        /// <summary>
        /// 装载数据实体 UserInfo
        /// </summary>
        /// <param name="dr">数据读取器</param>
        /// <returns>UserInfo</returns>
        private UserInfo ReaderBind(IDataReader dr)
        {
            return new UserInfo
            {
                Id = SqlMethodHelper.Convert<decimal>(dr["Id"]),
                Guid = SqlMethodHelper.Convert<Guid>(dr["Guid"]).ToString(),
                Name = SqlMethodHelper.Convert<string>(dr["Name"]),
                Tag = SqlMethodHelper.Convert<string>(dr["Tag"]),
                LoginName = SqlMethodHelper.Convert<string>(dr["Login_Name"]),
                LoginPwd = SqlMethodHelper.Convert<string>(dr["Login_Pwd"]),
                Email = SqlMethodHelper.Convert<string>(dr["Email"])
            };
        }

        #endregion


        #region 扩展方法

        /// <summary>
        /// 验证用户登录
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="userPwd"></param>
        /// <returns></returns>
        public string GetValidate(string userName, string userPwd)
        {
            var strSql = new StringBuilder();
            strSql.Append("select top 1 Guid from XSBlog_User");
            strSql.Append(" where ");
            strSql.Append(" Login_Name = @LoginName and Login_Pwd = @LoginPwd ");

            DbParameter[] parameters = {
			            SqlHelper.MakeInParam("@LoginName", (DbType) SqlDbType.VarChar, userName),
                        SqlHelper.MakeInParam("@LoginPwd", (DbType) SqlDbType.VarChar, userPwd)               
            };

            object obj = SqlHelper.ExecuteScalar(CommandType.Text, strSql.ToString(), parameters);
            if (obj == null)
            {
                return "";
            }
            return obj.ToString();
        }

        #endregion
    }
}
