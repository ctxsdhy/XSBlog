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
    /// 相册数据层
    /// </summary>
    public class SqlAlbum : IAlbum
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
            strSql.Append("select count(1) from XSBlog_Album");
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

        #region 保存添加数据 Add(AlbumInfo entity)

        /// <summary>
        /// 保存添加数据 Add(AlbumInfo entity)
        /// </summary>
        /// <param name="entity">实体类(AlbumInfo)</param>
        ///<returns>返回新增的ID</returns>
        public void Add(AlbumInfo entity)
        {
            var strSql = new StringBuilder();
            strSql.Append("insert into XSBlog_Album(");
            strSql.Append("Guid,Name,Blog_Guid,User_Guid,Create_Time,Order_Id");
            strSql.Append(") values (");
            strSql.Append("@Guid,@Name,@Blog_Guid,@User_Guid,@Create_Time,@Order_Id");
            strSql.Append(") ");

            DbParameter[] parameters = {        
                        SqlHelper.MakeInParam("@Guid", (DbType) SqlDbType.UniqueIdentifier, Guid.NewGuid()) ,            
                        SqlHelper.MakeInParam("@Name", (DbType) SqlDbType.VarChar, entity.Name) ,            
                        SqlHelper.MakeInParam("@Blog_Guid", (DbType) SqlDbType.UniqueIdentifier, ConvertHelper.GetGuid(entity.BlogGuid)) ,            
                        SqlHelper.MakeInParam("@User_Guid", (DbType) SqlDbType.UniqueIdentifier, ConvertHelper.GetGuid(entity.UserGuid)),           
                        SqlHelper.MakeInParam("@Create_Time", (DbType) SqlDbType.DateTime, entity.CreateTime),            
                        SqlHelper.MakeInParam("@Order_Id", (DbType) SqlDbType.Int, entity.OrderId)         
              
            };

            SqlHelper.ExecuteNonQuery(strSql.ToString(), parameters);

        }

        #endregion

        #region 更新数据 Update(AlbumInfo entity)

        /// <summary>
        /// 更新数据 Update(AlbumInfo entity)
        /// </summary>
        /// <param name="entity">实体类(AlbumInfo)</param>
        ///<returns>true:保存成功; false:保存失败</returns>
        public bool Update(AlbumInfo entity)
        {
            var strSql = new StringBuilder();
            strSql.Append("update XSBlog_Album set ");

            strSql.Append(" Guid = @Guid , ");
            strSql.Append(" Name = @Name , ");
            strSql.Append(" Blog_Guid = @Blog_Guid , ");
            strSql.Append(" User_Guid = @User_Guid , ");
            strSql.Append(" Create_Time = @Create_Time,  ");
            strSql.Append(" Order_Id = @Order_Id  "); 
            strSql.Append(" where Guid=@Guid  ");

            DbParameter[] parameters = {            
                        SqlHelper.MakeInParam("@Guid", (DbType) SqlDbType.UniqueIdentifier, ConvertHelper.GetGuid(entity.Guid)) ,            
                        SqlHelper.MakeInParam("@Name", (DbType) SqlDbType.VarChar, entity.Name) ,            
                        SqlHelper.MakeInParam("@Blog_Guid", (DbType) SqlDbType.UniqueIdentifier, ConvertHelper.GetGuid(entity.BlogGuid)) ,            
                        SqlHelper.MakeInParam("@User_Guid", (DbType) SqlDbType.UniqueIdentifier, ConvertHelper.GetGuid(entity.UserGuid)) ,            
                        SqlHelper.MakeInParam("@Create_Time", (DbType) SqlDbType.DateTime, entity.CreateTime),            
                        SqlHelper.MakeInParam("@Order_Id", (DbType) SqlDbType.Int, entity.OrderId)              
              
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
            strSql.Append("delete from XSBlog_Album ");
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

        #region 物理删除数据 Delete(string ids)

        /// <summary>
        /// 物理删除数据 Delete(int id)
        /// </summary>
        /// <param name="guids">主键Id(int)</param>
        /// <returns>true:删除成功; false:删除失败</returns>
        public bool DeleteByGuIds(string guids)
        {
            var strSql = new StringBuilder();
            strSql.Append("delete from XSBlog_Album ");
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
        public AlbumInfo GetModel(string guid)
        {
            var strSql = new StringBuilder();
            strSql.Append("select Id, Guid, Name, Blog_Guid, User_Guid, Create_Time,Order_Id  ");
            strSql.Append("  from XSBlog_Album ");
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
        public AlbumInfo GetModelById(int id)
        {
            var strSql = new StringBuilder();
            strSql.Append("select Id, Guid, Name, Blog_Guid, User_Guid, Create_Time,Order_Id ");
            strSql.Append("  from XSBlog_Album ");
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
        /// <returns>返回List(AlbumInfo)类型数据,未查询到数据则返回null</returns>
        public List<AlbumInfo> GetList(string strWhere, string orderBy = null)
        {
            var strSql = new StringBuilder();
            strSql.Append("select Id, Guid, Name, Blog_Guid, User_Guid, Create_Time, Order_Id  ");
            strSql.Append("  from XSBlog_Album ");
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
        public List<AlbumInfo> GetList(int currentPageIndex, int pageSize, out int totalCount, string strWhere, string orderBy)
        {
            if (string.IsNullOrEmpty(strWhere))
            {
                strWhere = " 1=1 ";
            }
            strWhere = string.IsNullOrEmpty(strWhere) ? "" : " AND " + strWhere;
            if (string.IsNullOrEmpty(orderBy))
            {
            }
            return SqlMethodHelper.Find(SqlHelper.GetPagingStoredProcedureParameters("XSBlog_Album", "*", strWhere, orderBy, pageSize, currentPageIndex, 3), out totalCount, ReaderBind);
        }

        #endregion

        #endregion

        #region 私有方法

        /// <summary>
        /// 装载数据实体 AlbumInfo
        /// </summary>
        /// <param name="dr">数据读取器</param>
        /// <returns>AlbumInfo</returns>
        private AlbumInfo ReaderBind(IDataReader dr)
        {
            return new AlbumInfo
            {
                Id = SqlMethodHelper.Convert<decimal>(dr["Id"]),
                Guid = SqlMethodHelper.Convert<Guid>(dr["Guid"]).ToString(),
                Name = SqlMethodHelper.Convert<string>(dr["Name"]),
                BlogGuid = SqlMethodHelper.Convert<Guid>(dr["Blog_Guid"]).ToString(),
                UserGuid = SqlMethodHelper.Convert<Guid>(dr["User_Guid"]).ToString(),
                CreateTime = SqlMethodHelper.Convert<DateTime>(dr["Create_Time"]),
                OrderId = SqlMethodHelper.Convert<int>(dr["Order_Id"])	
            };
        }

        #endregion

        #region 扩展方法

        #endregion
    }
}
