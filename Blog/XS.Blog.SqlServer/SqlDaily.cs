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
    /// 文章数据层
    /// </summary>
    public class SqlDaily : IDaily
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
            strSql.Append("select count(1) from XSBlog_Daily");
            strSql.Append(" where ");
            strSql.Append(" Guid = @Guid  ");

            DbParameter[] parameters = {
			            SqlHelper.MakeInParam("@Guid", (DbType) SqlDbType.UniqueIdentifier, ConvertHelper.GetGuid(guid))               
            };

            object obj = SqlHelper.ExecuteScalar(CommandType.Text, strSql.ToString(), parameters);
            if (obj == null)
            {
                return false;
            }
            return true;
        }

        #endregion

        #region 保存添加数据 Add(DailyInfo entity)

        /// <summary>
        /// 保存添加数据 Add(DailyInfo entity)
        /// </summary>
        /// <param name="entity">实体类(DailyInfo)</param>
        ///<returns>返回新增的ID</returns>
        public string Add(DailyInfo entity)
        {
            var guid = Guid.NewGuid();
            var strSql = new StringBuilder();
            strSql.Append("insert into XSBlog_Daily(");
            strSql.Append("Guid,Name,Content,Create_Time,Blog_Guid,User_Guid,Category_Guid,Is_Draft,Is_Stick,Is_Home,Is_Special, Page_View, Comments_Num");
            strSql.Append(") values (");
            strSql.Append("@Guid,@Name,@Content,@Create_Time,@Blog_Guid,@User_Guid,@Category_Guid,@Is_Draft,@Is_Stick,@Is_Home,@Is_Special,@Page_View,@Comments_Num");
            strSql.Append(") ");

            DbParameter[] parameters = {
			            SqlHelper.MakeInParam("@Guid", (DbType) SqlDbType.UniqueIdentifier, guid) ,            
                        SqlHelper.MakeInParam("@Name", (DbType) SqlDbType.VarChar, entity.Name) ,            
                        SqlHelper.MakeInParam("@Content", (DbType) SqlDbType.Text, entity.Content) ,            
                        SqlHelper.MakeInParam("@Create_Time", (DbType) SqlDbType.DateTime, entity.CreateTime) ,  
                        SqlHelper.MakeInParam("@Blog_Guid", (DbType) SqlDbType.UniqueIdentifier, ConvertHelper.GetGuid(entity.BlogGuid)) , 
                        SqlHelper.MakeInParam("@User_Guid", (DbType) SqlDbType.UniqueIdentifier, ConvertHelper.GetGuid(entity.UserGuid)) ,            
                        SqlHelper.MakeInParam("@Category_Guid", (DbType) SqlDbType.UniqueIdentifier, ConvertHelper.GetGuid(entity.CategoryGuid)) ,
                        SqlHelper.MakeInParam("@Is_Draft", (DbType) SqlDbType.Bit, entity.IsDraft) , 
                        SqlHelper.MakeInParam("@Is_Stick", (DbType) SqlDbType.Bit, entity.IsStick) , 
                        SqlHelper.MakeInParam("@Is_Home", (DbType) SqlDbType.Bit, entity.IsHome) , 
                        SqlHelper.MakeInParam("@Is_Special", (DbType) SqlDbType.Int, entity.IsSpecial),
                        SqlHelper.MakeInParam("@Page_View", (DbType) SqlDbType.Int, entity.PageView) ,
                        SqlHelper.MakeInParam("@Comments_Num", (DbType) SqlDbType.Int, entity.CommentsNum)
            };

            SqlHelper.ExecuteNonQuery(strSql.ToString(), parameters);
            return guid.ToString();
        }

        #endregion

        #region 更新数据 Update(DailyInfo entity)

        /// <summary>
        /// 更新数据 Update(DailyInfo entity)
        /// </summary>
        /// <param name="entity">实体类(DailyInfo)</param>
        ///<returns>true:保存成功; false:保存失败</returns>
        public bool Update(DailyInfo entity)
        {
            var strSql = new StringBuilder();
            strSql.Append("update XSBlog_Daily set ");

            strSql.Append(" Guid = @Guid , ");
            strSql.Append(" Name = @Name , ");
            strSql.Append(" Content = @Content , ");
            strSql.Append(" Create_Time = @Create_Time , ");
            strSql.Append(" Blog_Guid = @Blog_Guid , ");
            strSql.Append(" User_Guid = @User_Guid , ");
            strSql.Append(" Category_Guid = @Category_Guid, ");
            strSql.Append(" Is_Draft = @Is_Draft , ");
            strSql.Append(" Is_Stick = @Is_Stick , ");
            strSql.Append(" Is_Home = @Is_Home , ");
            strSql.Append(" Is_Special = @Is_Special, ");
            strSql.Append(" Page_View = @Page_View , ");
            strSql.Append(" Comments_Num = @Comments_Num ");
            strSql.Append(" where Guid=@Guid  ");

            DbParameter[] parameters = {
			            SqlHelper.MakeInParam("@Id", (DbType) SqlDbType.Decimal, entity.Id) ,            
                        SqlHelper.MakeInParam("@Guid", (DbType) SqlDbType.UniqueIdentifier, ConvertHelper.GetGuid(entity.Guid)) ,            
                        SqlHelper.MakeInParam("@Name", (DbType) SqlDbType.VarChar, entity.Name) ,            
                        SqlHelper.MakeInParam("@Content", (DbType) SqlDbType.Text, entity.Content) ,            
                        SqlHelper.MakeInParam("@Create_Time", (DbType) SqlDbType.DateTime, entity.CreateTime) ,
                        SqlHelper.MakeInParam("@Blog_Guid", (DbType) SqlDbType.UniqueIdentifier, ConvertHelper.GetGuid(entity.BlogGuid)) ,
                        SqlHelper.MakeInParam("@User_Guid", (DbType) SqlDbType.UniqueIdentifier, ConvertHelper.GetGuid(entity.UserGuid)) ,            
                        SqlHelper.MakeInParam("@Category_Guid", (DbType) SqlDbType.UniqueIdentifier, ConvertHelper.GetGuid(entity.CategoryGuid)) ,           
                        SqlHelper.MakeInParam("@Is_Draft", (DbType) SqlDbType.Bit, entity.IsDraft) ,
                        SqlHelper.MakeInParam("@Is_Stick", (DbType) SqlDbType.Bit, entity.IsStick) ,
                        SqlHelper.MakeInParam("@Is_Home", (DbType) SqlDbType.Bit, entity.IsHome) ,
                        SqlHelper.MakeInParam("@Is_Special", (DbType) SqlDbType.Int, entity.IsSpecial) ,
                        SqlHelper.MakeInParam("@Page_View", (DbType) SqlDbType.Int, entity.PageView) ,
                        SqlHelper.MakeInParam("@Comments_Num", (DbType) SqlDbType.Int, entity.CommentsNum)
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
            strSql.Append("delete from XSBlog_Daily ");
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

        #region 物理删除数据 DeleteByGuIds(string guids)

        /// <summary>
        /// 物理删除数据 DeleteByGuIds(string guids)
        /// </summary>
        /// <param name="guids">主键Id(int)</param>
        /// <returns>true:删除成功; false:删除失败</returns>
        public bool DeleteByGuIds(string guids)
        {
            var strSql = new StringBuilder();
            strSql.Append("delete from XSBlog_Daily ");
            strSql.Append(" where guid in (" + guids + ") ");

            int rows = SqlHelper.ExecuteNonQuery(CommandType.Text, strSql.ToString());
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
        public DailyInfo GetModel(string guid)
        {
            var strSql = new StringBuilder();
            strSql.Append("select Id, Guid, Name, Content, Create_Time, Blog_Guid, User_Guid, Category_Guid, Is_Draft, Is_Stick, Is_Home, Is_Special, Page_View, Comments_Num  ");
            strSql.Append("  from XSBlog_Daily ");
            strSql.Append(" where ");
            strSql.Append(" Guid = @Guid  ");

            DbParameter[] parameters = {
			            SqlHelper.MakeInParam("@Guid", (DbType) SqlDbType.UniqueIdentifier, ConvertHelper.GetGuid(guid))               
            };

            return SqlMethodHelper.FindOne(strSql.ToString(), ReaderBind, parameters);
        }

        #endregion

        #region 得到一个对象实体 GetModelById(int id)

        /// <summary>
        /// 得到一个对象实体 GetModelById(int id)
        /// </summary>
        public DailyInfo GetModelById(int id)
        {
            var strSql = new StringBuilder();
            strSql.Append("select Id, Guid, Name, Content, Create_Time, Blog_Guid, User_Guid, Category_Guid, Is_Draft, Is_Stick, Is_Home, Is_Special, Page_View, Comments_Num  ");
            strSql.Append("  from XSBlog_Daily ");
            strSql.Append(" where ");
            strSql.Append(" Id = @Id  ");

            DbParameter[] parameters = {
			            SqlHelper.MakeInParam("@Id", (DbType) SqlDbType.Int, id)               
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
        /// <returns>返回List(DailyInfo)类型数据,未查询到数据则返回null</returns>
        public List<DailyInfo> GetList(string strWhere, string orderBy = null)
        {
            var strSql = new StringBuilder();
            strSql.Append("select Id, Guid, Name, Content, Create_Time, Blog_Guid, User_Guid, Category_Guid, Is_Draft, Is_Stick, Is_Home, Is_Special, Page_View, Comments_Num  ");
            strSql.Append("  from XSBlog_Daily ");
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
        public List<DailyInfo> GetList(int currentPageIndex, int pageSize, out int totalCount, string strWhere, string orderBy)
        {
            if (!string.IsNullOrEmpty(strWhere))
            {
                strWhere = " and " + strWhere;
            }
            return SqlMethodHelper.Find(SqlHelper.GetPagingStoredProcedureParameters("XSBlog_Daily", "*", strWhere, orderBy, pageSize, currentPageIndex, 3), out totalCount, ReaderBind);
        }

        #endregion

        #endregion

        #region 私有方法

        /// <summary>
        /// 装载数据实体 DailyInfo
        /// </summary>
        /// <param name="dr">数据读取器</param>
        /// <returns>DailyInfo</returns>
        private DailyInfo ReaderBind(IDataReader dr)
        {
            return new DailyInfo
            {
                Id = SqlMethodHelper.Convert<decimal>(dr["Id"]),
                Guid = SqlMethodHelper.Convert<Guid>(dr["Guid"]).ToString(),
                Name = SqlMethodHelper.Convert<string>(dr["Name"]),
                Content = SqlMethodHelper.Convert<string>(dr["Content"]),
                CreateTime = SqlMethodHelper.Convert<DateTime>(dr["Create_Time"]),
                BlogGuid = SqlMethodHelper.Convert<Guid>(dr["Blog_Guid"]).ToString(),
                UserGuid = SqlMethodHelper.Convert<Guid>(dr["User_Guid"]).ToString(),
                CategoryGuid = SqlMethodHelper.Convert<Guid>(dr["Category_Guid"]).ToString(),
                IsDraft = SqlMethodHelper.Convert<bool>(dr["Is_Draft"]),
                IsStick = SqlMethodHelper.Convert<bool>(dr["Is_Stick"]),
                IsHome = SqlMethodHelper.Convert<bool>(dr["Is_Home"]),
                IsSpecial = SqlMethodHelper.Convert<int>(dr["Is_Special"]),
                PageView = SqlMethodHelper.Convert<int>(dr["Page_View"]),
                CommentsNum = SqlMethodHelper.Convert<int>(dr["Comments_Num"])
            };
        }

        #endregion

        #region 扩展方法

        /// <summary>
        /// 获得前几条数据
        /// </summary>
        /// <param name="count"></param>
        /// <param name="strWhere"></param>
        /// <param name="orderBy"></param>
        /// <returns></returns>
        public List<DailyInfo> GetTopList(int count, string strWhere, string orderBy)
        {
            var strSql = new StringBuilder();
            strSql.Append("select top " + count +
                          " Id, Guid, Name, Content, Create_Time, Blog_Guid, User_Guid, Category_Guid, Is_Draft, Is_Stick, Is_Home, Is_Special, Page_View, Comments_Num ");
            strSql.Append("  from XSBlog_Daily ");
            if (!string.IsNullOrEmpty(strWhere))
            {
                strSql.Append(" where " + strWhere);
            }
            if (!string.IsNullOrEmpty(orderBy))
            {
                strSql.Append(" order by " + orderBy);
            }
            return SqlMethodHelper.Find(strSql.ToString(), ReaderBind, null);
        }

        /// <summary>
        /// 更新浏览量
        /// </summary>
        /// <param name="guid"></param>
        /// <param name="pageView"></param>
        public void UpdatePageView(string guid, int pageView)
        {
            var strSql = new StringBuilder();
            strSql.Append("update XSBlog_Daily set ");

            strSql.Append(" Page_View = @Page_View ");
            strSql.Append(" where Guid=@Guid  ");

            DbParameter[] parameters = {
			            SqlHelper.MakeInParam("@Page_View", (DbType) SqlDbType.Int, pageView) ,            
                        SqlHelper.MakeInParam("@Guid", (DbType) SqlDbType.UniqueIdentifier, ConvertHelper.GetGuid(guid))
            };

            SqlHelper.ExecuteNonQuery(CommandType.Text, strSql.ToString(), parameters);
        }

        #endregion
    }
}
