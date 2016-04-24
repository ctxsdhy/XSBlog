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
    /// 分类数据层
    /// </summary>
    public class SqlCategory : ICategory
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
            strSql.Append("select count(1) from XSBlog_Category");
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

        #region 保存添加数据 Add(CategoryInfo entity)

        /// <summary>
        /// 保存添加数据 Add(CategoryInfo entity)
        /// </summary>
        /// <param name="entity">实体类(CategoryInfo)</param>
        ///<returns>返回新增的ID</returns>
        public void Add(CategoryInfo entity)
        {
            var strSql = new StringBuilder();
            strSql.Append("insert into XSBlog_Category(");
            strSql.Append("Guid,Name,Order_Id,Blog_Guid,User_Guid,Image_Url,Image_Key,Parent_Guid");
            strSql.Append(") values (");
            strSql.Append("@Guid,@Name,@OrderId,@BlogGuid,@UserGuid,@Image_Url,@Image_Key,@Parent_Guid");
            strSql.Append(") ");

            DbParameter[] parameters = {
			            SqlHelper.MakeInParam("@Guid", (DbType) SqlDbType.UniqueIdentifier, Guid.NewGuid()) ,            
                        SqlHelper.MakeInParam("@Name", (DbType) SqlDbType.VarChar, entity.Name),
                        SqlHelper.MakeInParam("@OrderId", (DbType) SqlDbType.Int, entity.OrderId),
                        SqlHelper.MakeInParam("@BlogGuid", (DbType) SqlDbType.UniqueIdentifier, ConvertHelper.GetGuid(entity.BlogGuid)),
                        SqlHelper.MakeInParam("@UserGuid", (DbType) SqlDbType.UniqueIdentifier, ConvertHelper.GetGuid(entity.UserGuid)),
                        SqlHelper.MakeInParam("@Image_Url", (DbType) SqlDbType.VarChar, entity.ImageUrl),
                        SqlHelper.MakeInParam("@Image_Key", (DbType) SqlDbType.UniqueIdentifier, ConvertHelper.GetGuid(entity.ImageKey)),
                        SqlHelper.MakeInParam("@Parent_Guid", (DbType) SqlDbType.UniqueIdentifier, ConvertHelper.GetGuid(entity.ParentGuid))
            };

            SqlHelper.ExecuteNonQuery(strSql.ToString(), parameters);

        }

        #endregion

        #region 更新数据 Update(CategoryInfo entity)

        /// <summary>
        /// 更新数据 Update(CategoryInfo entity)
        /// </summary>
        /// <param name="entity">实体类(CategoryInfo)</param>
        ///<returns>true:保存成功; false:保存失败</returns>
        public bool Update(CategoryInfo entity)
        {
            var strSql = new StringBuilder();
            strSql.Append("update XSBlog_Category set ");

            strSql.Append(" Guid = @Guid , ");
            strSql.Append(" Name = @Name , ");
            strSql.Append(" Order_Id = @OrderId ,  ");
            strSql.Append(" Blog_Guid = @BlogGuid , ");
            strSql.Append(" User_Guid = @UserGuid , ");
            strSql.Append(" Image_Url = @Image_Url , ");
            strSql.Append(" Image_Key = @Image_Key , ");
            strSql.Append(" Parent_Guid = @Parent_Guid ");
            strSql.Append(" where Guid=@Guid  ");

            DbParameter[] parameters = {
			            SqlHelper.MakeInParam("@Id", (DbType) SqlDbType.Decimal, entity.Id) ,            
                        SqlHelper.MakeInParam("@Guid", (DbType) SqlDbType.UniqueIdentifier, ConvertHelper.GetGuid(entity.Guid)) ,            
                        SqlHelper.MakeInParam("@Name", (DbType) SqlDbType.VarChar, entity.Name) ,           
                        SqlHelper.MakeInParam("@OrderId", (DbType) SqlDbType.Int, entity.OrderId) ,
                        SqlHelper.MakeInParam("@BlogGuid", (DbType) SqlDbType.UniqueIdentifier, ConvertHelper.GetGuid(entity.BlogGuid)) ,
                        SqlHelper.MakeInParam("@UserGuid", (DbType) SqlDbType.UniqueIdentifier, ConvertHelper.GetGuid(entity.UserGuid)) ,
                        SqlHelper.MakeInParam("@Image_Url", (DbType) SqlDbType.VarChar, entity.ImageUrl) , 
                        SqlHelper.MakeInParam("@Image_Key", (DbType) SqlDbType.UniqueIdentifier, ConvertHelper.GetGuid(entity.ImageKey)) ,  
                        SqlHelper.MakeInParam("@Parent_Guid", (DbType) SqlDbType.UniqueIdentifier, ConvertHelper.GetGuid(entity.ParentGuid)) ,    
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
            strSql.Append("delete from XSBlog_Category ");
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
            strSql.Append("delete from XSBlog_Category ");
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
        public CategoryInfo GetModel(string guid)
        {
            var strSql = new StringBuilder();
            strSql.Append("select Id, Guid, Name ,Order_Id, Blog_Guid, User_Guid, Image_Url, Image_Key, Parent_Guid ");
            strSql.Append("  from XSBlog_Category ");
            strSql.Append(" where ");
            strSql.Append(" Guid = @Guid  ");

            DbParameter[] parameters = {
			            SqlHelper.MakeInParam("@Guid", (DbType) SqlDbType.UniqueIdentifier, ConvertHelper.GetGuid(guid))               
            };

            return SqlMethodHelper.FindOne(strSql.ToString(), ReaderBind, parameters);
        }

        #endregion

        #region 得到一个对象实体 GetModelById(int categoryId)

        /// <summary>
        /// 得到一个对象实体 GetModelById(int categoryId)
        /// </summary>
        public CategoryInfo GetModelById(int categoryId)
        {
            var strSql = new StringBuilder();
            strSql.Append("select Id, Guid, Name ,Order_Id, Blog_Guid, User_Guid, Image_Url, Image_Key, Parent_Guid ");
            strSql.Append("  from XSBlog_Category ");
            strSql.Append(" where ");
            strSql.Append(" Id = @Id  ");

            DbParameter[] parameters = {
			            SqlHelper.MakeInParam("@Id", (DbType) SqlDbType.Int, categoryId)               
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
        /// <returns>返回List(CategoryInfo)类型数据,未查询到数据则返回null</returns>
        public List<CategoryInfo> GetList(string strWhere, string orderBy = null)
        {
            var strSql = new StringBuilder();
            strSql.Append("select Id, Guid, Name ,Order_Id, Blog_Guid, User_Guid, Image_Url, Image_Key, Parent_Guid ");
            strSql.Append("  from XSBlog_Category ");
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
        public List<CategoryInfo> GetList(int currentPageIndex, int pageSize, out int totalCount, string strWhere, string orderBy)
        {
            if (string.IsNullOrEmpty(strWhere))
            {
                strWhere = " 1=1 ";
            }
            strWhere = string.IsNullOrEmpty(strWhere) ? "" : " AND " + strWhere;
            if (string.IsNullOrEmpty(orderBy))
            {
            }
            return SqlMethodHelper.Find(SqlHelper.GetPagingStoredProcedureParameters("XSBlog_Category", "*", strWhere, orderBy, pageSize, currentPageIndex, 3), out totalCount, ReaderBind);
        }

        #endregion

        #endregion

        #region 私有方法

        /// <summary>
        /// 装载数据实体 CategoryInfo
        /// </summary>
        /// <param name="dr">数据读取器</param>
        /// <returns>CategoryInfo</returns>
        private CategoryInfo ReaderBind(IDataReader dr)
        {
            return new CategoryInfo
            {
                Id = SqlMethodHelper.Convert<decimal>(dr["Id"]),
                Guid = SqlMethodHelper.Convert<Guid>(dr["Guid"]).ToString(),
                Name = SqlMethodHelper.Convert<string>(dr["Name"]),
                OrderId = SqlMethodHelper.Convert<int>(dr["Order_Id"]),
                BlogGuid = SqlMethodHelper.Convert<Guid>(dr["Blog_Guid"]).ToString(),
                UserGuid = SqlMethodHelper.Convert<Guid>(dr["User_Guid"]).ToString(),
                ImageUrl = SqlMethodHelper.Convert<string>(dr["Image_Url"]),
                ImageKey = SqlMethodHelper.Convert<Guid>(dr["Image_Key"]).ToString(),
                ParentGuid = SqlMethodHelper.Convert<Guid>(dr["Parent_Guid"]).ToString()
            };
        }

        #endregion

        #region 扩展方法

        /// <summary>
        /// 根据条件获取列表和文章数量 GetList(string strWhere,string orderBy=null)
        /// </summary>
        /// <param name="strWhere">strWhere</param>
        /// <param name="orderBy">orderBy</param>
        /// <returns>返回List(CategoryInfo)类型数据,未查询到数据则返回null</returns>
        public List<CategoryInfo> GetListAndCount(string strWhere, string orderBy = null)
        {
            var strSql = new StringBuilder();
            strSql.Append(" select c.*,(select count(1) from XSBlog_Daily d where d.Category_Guid = c.Guid) as Count ");
            strSql.Append("  from XSBlog_Category c ");
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
            var list = new List<CategoryInfo>();
            using (DbDataReader dr = SqlHelper.ExecuteReader(CommandType.Text, strSql.ToString()))
            {
                if (dr != null)
                {
                    while (dr.Read())
                    {
                        var info = ReaderBind(dr);
                        info.Count = ConvertHelper.GetInt(dr["count"]);
                        list.Add(info);
                    }
                }
            }
            return list;
        }

        /// <summary>
        /// 获得没有类型的文章数量
        /// </summary>
        /// <returns></returns>
        public int GetNoCategroyCount(string strWhere)
        {
            var strSql = new StringBuilder();
            strSql.Append(" select count(1) ");
            strSql.Append(" from XSBlog_Daily d  ");
            strSql.Append(" where d.Category_Guid  ");
            strSql.Append(" not in (select Guid from XSBlog_Category) ");
            if (!string.IsNullOrEmpty(strWhere))
            {
                strSql.Append(" and " + strWhere);
            }
            return ConvertHelper.GetInt(SqlHelper.ExecuteScalar(strSql.ToString()));
        }

        /// <summary>
        /// 获得这个类型的文章数量
        /// </summary>
        /// <returns></returns>
        public int GetCategroyCountByGuid(string guid, string strWhere)
        {
            var strSql = new StringBuilder();
            strSql.Append(" select count(1) ");
            strSql.Append(" from XSBlog_Daily d ");
            strSql.Append(" where d.Category_Guid ='" + guid +"'");
            strSql.Append(" not in (select Guid from XSBlog_Category) ");
            if (!string.IsNullOrEmpty(strWhere))
            {
                strSql.Append(" and " + strWhere);
            }
            return ConvertHelper.GetInt(SqlHelper.ExecuteScalar(strSql.ToString()));
        }

        #region 获得树形列表

        /// <summary>
        /// 获得树形列表
        /// </summary>
        /// <returns></returns>
        public List<CategoryInfo> GetTreeList()
        {
            var strSql = new StringBuilder();
            strSql.Append(" select Id, Guid, Name, parent_Guid, Order_Id, Image_Url, Image_Key, Blog_Guid, User_Guid ");
            strSql.Append(" from dbo.F_XSBlog_GetCategorys('00000000-0000-0000-0000-000000000000') ");
            strSql.Append(" order by order_id ");
            return SqlMethodHelper.Find(strSql.ToString(), ReaderBind, null);
        }

        #endregion

        #endregion
    }
}
