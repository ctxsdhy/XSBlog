using System.Collections.Generic;
using XS.Blog.Data;
using XS.Blog.Data.DataProvider;
using XS.Blog.Entity;

namespace XS.Blog
{
    /// <summary>
    /// 照片业务层
    /// </summary>
    public class PhotoManager
    {
        private readonly IPhoto _photo = DataProvider.GetInstance().GetPhotoDal();

        #region 基础方法

        #region 是否存在该记录 Exists(Guid Guid)

        /// <summary>
        /// 是否存在该记录 Exists(Guid Guid)
        /// </summary>
        /// <param name="guid">主键id</param>
        /// <returns>true:存在; false:不存在</returns>
        public bool Exists(string guid)
        {
            return _photo.Exists(guid);
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
            _photo.Add(entity);
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
            return _photo.Update(entity);
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
            return _photo.Delete(guid);
        }

        #endregion

        #region 物理删除数据 Delete(string ids)

        /// <summary>
        /// 物理删除数据 Delete(int id)
        /// </summary>
        /// <param name="ids">主键Id(int)</param>
        /// <returns>true:删除成功; false:删除失败</returns>
        public bool DeleteByGuIds(string ids)
        {
            return _photo.DeleteByGuIds(ids);
        }

        #endregion

        #region 得到一个对象实体 GetModel(Guid Guid)

        /// <summary>
        /// 得到一个对象实体 GetModel(Guid Guid)
        /// </summary>
        public PhotoInfo GetModel(string guid)
        {
            return _photo.GetModel(guid);
        }

        #endregion

        #region 得到一个对象实体 GetModelById(int id)

        /// <summary>
        /// 得到一个对象实体 GetModelById(int id)
        /// </summary>
        public PhotoInfo GetModelById(int id)
        {
            return _photo.GetModelById(id);
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
            return _photo.GetList(strWhere, orderBy);
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
            return _photo.GetList(currentPageIndex, pageSize, out totalCount, strWhere, orderBy);
        }

        #endregion

        #endregion

        #region 扩展方法

        /// <summary>
        /// 获得照片的数量
        /// </summary>
        /// <returns></returns>
        public int GetCount(string strWhere)
        {
            return _photo.GetCount(strWhere);
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
            return _photo.GetTopList(count, strWhere, orderBy);
        }

        #endregion
    }
}
