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
    public class SqlPhoto : IPhoto
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
            strSql.Append("select count(1) from XSBlog_Photo");
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

        #region 保存添加数据 Add(PhotoInfo entity)

        /// <summary>
        /// 保存添加数据 Add(PhotoInfo entity)
        /// </summary>
        /// <param name="entity">实体类(PhotoInfo)</param>
        ///<returns>返回新增的ID</returns>
        public void Add(PhotoInfo entity)
        {
            var strSql = new StringBuilder();
            strSql.Append("insert into XSBlog_Photo(");
            strSql.Append("Guid,Name,Tag,Image_Url,Image_Key,User_Guid,Album_Guid,Create_time,Is_Cover");
            strSql.Append(") values (");
            strSql.Append("@Guid,@Name,@Tag,@Image_Url,@Image_Key,@User_Guid,@Album_Guid,@Create_time,@Is_Cover");
            strSql.Append(") ");

            DbParameter[] parameters = {
			            SqlHelper.MakeInParam("@Guid", (DbType) SqlDbType.UniqueIdentifier, Guid.NewGuid()) ,            
                        SqlHelper.MakeInParam("@Name", (DbType) SqlDbType.VarChar, entity.Name) ,            
                        SqlHelper.MakeInParam("@Tag", (DbType) SqlDbType.VarChar, entity.Tag) ,            
                        SqlHelper.MakeInParam("@Image_Url", (DbType) SqlDbType.VarChar, entity.ImageUrl) ,      
                        SqlHelper.MakeInParam("@Image_Key", (DbType) SqlDbType.UniqueIdentifier, ConvertHelper.GetGuid(entity.ImageKey)) ,
                        SqlHelper.MakeInParam("@User_Guid", (DbType) SqlDbType.UniqueIdentifier, ConvertHelper.GetGuid(entity.UserGuid)) ,            
                        SqlHelper.MakeInParam("@Album_Guid", (DbType) SqlDbType.UniqueIdentifier, ConvertHelper.GetGuid(entity.AlbumGuid)) ,            
                        SqlHelper.MakeInParam("@Create_time", (DbType) SqlDbType.DateTime, entity.Createtime) ,            
                        SqlHelper.MakeInParam("@Is_Cover", (DbType) SqlDbType.Bit, entity.IsCover)             
              
            };

            SqlHelper.ExecuteNonQuery(strSql.ToString(), parameters);

        }

        #endregion

        #region 更新数据 Update(PhotoInfo entity)

        /// <summary>
        /// 更新数据 Update(PhotoInfo entity)
        /// </summary>
        /// <param name="entity">实体类(PhotoInfo)</param>
        ///<returns>true:保存成功; false:保存失败</returns>
        public bool Update(PhotoInfo entity)
        {
            var strSql = new StringBuilder();
            strSql.Append("update XSBlog_Photo set ");

            strSql.Append(" Guid = @Guid , ");
            strSql.Append(" Name = @Name , ");
            strSql.Append(" Tag = @Tag , ");
            strSql.Append(" Image_Url = @Image_Url , ");
            strSql.Append(" Image_Key = @Image_Key, ");
            strSql.Append(" User_Guid = @User_Guid , ");
            strSql.Append(" Album_Guid = @Album_Guid , ");
            strSql.Append(" Create_time = @Create_time , ");
            strSql.Append(" Is_Cover = @Is_Cover  ");
            strSql.Append(" where Guid=@Guid  ");

            DbParameter[] parameters = {
			            SqlHelper.MakeInParam("@Id", (DbType) SqlDbType.Int, entity.Id) ,            
                        SqlHelper.MakeInParam("@Guid", (DbType) SqlDbType.UniqueIdentifier, ConvertHelper.GetGuid(entity.Guid)) ,            
                        SqlHelper.MakeInParam("@Name", (DbType) SqlDbType.VarChar, entity.Name) ,            
                        SqlHelper.MakeInParam("@Tag", (DbType) SqlDbType.VarChar, entity.Tag) ,            
                        SqlHelper.MakeInParam("@Image_Url", (DbType) SqlDbType.VarChar, entity.ImageUrl) ,            
                        SqlHelper.MakeInParam("@Image_Key", (DbType) SqlDbType.UniqueIdentifier, ConvertHelper.GetGuid(entity.ImageKey)) ,
                        SqlHelper.MakeInParam("@User_Guid", (DbType) SqlDbType.UniqueIdentifier, ConvertHelper.GetGuid(entity.UserGuid)) ,            
                        SqlHelper.MakeInParam("@Album_Guid", (DbType) SqlDbType.UniqueIdentifier, ConvertHelper.GetGuid(entity.AlbumGuid)) ,            
                        SqlHelper.MakeInParam("@Create_time", (DbType) SqlDbType.DateTime, entity.Createtime) ,            
                        SqlHelper.MakeInParam("@Is_Cover", (DbType) SqlDbType.Bit, entity.IsCover)             
              
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
            strSql.Append("delete from XSBlog_Photo ");
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
            strSql.Append("delete from XSBlog_Photo ");
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
        public PhotoInfo GetModel(string guid)
        {
            var strSql = new StringBuilder();
            strSql.Append("select Id, Guid, Name, Tag, Image_Url, Image_Key, User_Guid, Album_Guid, Create_time, Is_Cover  ");
            strSql.Append("  from XSBlog_Photo ");
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
        public PhotoInfo GetModelById(int id)
        {
            var strSql = new StringBuilder();
            strSql.Append("select Id, Guid, Name, Tag, Image_Url, Image_Key, User_Guid, Album_Guid, Create_time, Is_Cover ");
            strSql.Append("  from XSBlog_Photo ");
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
        /// <returns>返回List(PhotoInfo)类型数据,未查询到数据则返回null</returns>
        public List<PhotoInfo> GetList(string strWhere, string orderBy = null)
        {
            var strSql = new StringBuilder();
            strSql.Append("select Id, Guid, Name, Tag, Image_Url, Image_Key, User_Guid, Album_Guid, Create_time, Is_Cover  ");
            strSql.Append("  from XSBlog_Photo ");
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
        public List<PhotoInfo> GetList(int currentPageIndex, int pageSize, out int totalCount, string strWhere, string orderBy)
        {
            if (string.IsNullOrEmpty(strWhere))
            {
                strWhere = " 1=1 ";
            }
            strWhere = string.IsNullOrEmpty(strWhere) ? "" : " AND " + strWhere;
            if (string.IsNullOrEmpty(orderBy))
            {
            }
            return SqlMethodHelper.Find(SqlHelper.GetPagingStoredProcedureParameters("XSBlog_Photo", "*", strWhere, orderBy, pageSize, currentPageIndex, 3), out totalCount, ReaderBind);
        }

        #endregion

        #endregion

        #region 私有方法

        /// <summary>
        /// 装载数据实体 PhotoInfo
        /// </summary>
        /// <param name="dr">数据读取器</param>
        /// <returns>PhotoInfo</returns>
        private PhotoInfo ReaderBind(IDataReader dr)
        {
            return new PhotoInfo
            {
                Id = SqlMethodHelper.Convert<int>(dr["Id"]),
                Guid = SqlMethodHelper.Convert<Guid>(dr["Guid"]).ToString(),
                Name = SqlMethodHelper.Convert<string>(dr["Name"]),
                Tag = SqlMethodHelper.Convert<string>(dr["Tag"]),
                ImageUrl = SqlMethodHelper.Convert<string>(dr["Image_Url"]),
                ImageKey = SqlMethodHelper.Convert<Guid>(dr["Image_Key"]).ToString(),
                UserGuid = SqlMethodHelper.Convert<Guid>(dr["User_Guid"]).ToString(),
                AlbumGuid = SqlMethodHelper.Convert<Guid>(dr["Album_Guid"]).ToString(),
                Createtime = SqlMethodHelper.Convert<DateTime>(dr["Create_time"]),
                IsCover = SqlMethodHelper.Convert<bool>(dr["Is_Cover"])
            };
        }

        #endregion

        #region 扩展方法

        /// <summary>
        /// 获得照片的数量
        /// </summary>
        /// <returns></returns>
        public int GetCount(string strWhere)
        {
            var strSql = new StringBuilder();
            strSql.Append(" select count(1) ");
            strSql.Append(" from XSBlog_Photo ");
            if (!string.IsNullOrEmpty(strWhere))
            {
                strSql.Append(" where " + strWhere);
            }
            return ConvertHelper.GetInt(SqlHelper.ExecuteScalar(strSql.ToString()));
        }

        /// <summary>
        /// 获得前几条数据
        /// </summary>
        /// <param name="count"></param>
        /// <param name="strWhere"></param>
        /// <param name="orderBy"></param>
        /// <returns></returns>
        public List<PhotoInfo> GetTopList(int count, string strWhere, string orderBy)
        {
            var strSql = new StringBuilder();
            strSql.Append("select top " + count +
                          " Id, Guid, Name, Tag, Image_Url, Image_Key, User_Guid, Album_Guid, Create_time, Is_Cover  ");
            strSql.Append("  from XSBlog_Photo ");
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

        #endregion
    }
}
