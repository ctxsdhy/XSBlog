using System.Collections.Generic;
using XS.Blog.Data;
using XS.Blog.Data.DataProvider;
using XS.Blog.Entity;

namespace XS.Blog
{
    public class MoodManager
    {
        private readonly IMood _mood = DataProvider.GetInstance().GetMoodDal();

        #region 基础方法

        #region 是否存在该记录 Exists(Guid Guid)

        /// <summary>
        /// 是否存在该记录 Exists(Guid Guid)
        /// </summary>
        /// <param name="guid">主键id</param>
        /// <returns>true:存在; false:不存在</returns>
        public bool Exists(string guid)
        {
            return _mood.Exists(guid);
        }

        #endregion

        #region 保存添加数据 Add(MoodInfo entity)

        /// <summary>
        /// 保存添加数据 Add(MoodInfo entity)
        /// </summary>
        /// <param name="entity">实体类(MoodInfo)</param>
        ///<returns>返回新增的ID</returns>
        public void Add(MoodInfo entity)
        {
            _mood.Add(entity);
        }

        #endregion

        #region 更新数据 Update(MoodInfo entity)

        /// <summary>
        /// 更新数据 Update(MoodInfo entity)
        /// </summary>
        /// <param name="entity">实体类(MoodInfo)</param>
        ///<returns>true:保存成功; false:保存失败</returns>
        public bool Update(MoodInfo entity)
        {
            return _mood.Update(entity);
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
            return _mood.Delete(guid);
        }

        #endregion

        #region 物理删除数据 DeleteByGuIds(string ids)

        /// <summary>
        /// 物理删除数据 DeleteByGuIds(string ids)
        /// </summary>
        /// <param name="ids">主键Id(int)</param>
        /// <returns>true:删除成功; false:删除失败</returns>
        public bool DeleteByGuIds(string ids)
        {
            return _mood.DeleteByGuIds(ids);
        }

        #endregion

        #region 得到一个对象实体 GetModel(Guid Guid)

        /// <summary>
        /// 得到一个对象实体 GetModel(Guid Guid)
        /// </summary>
        public MoodInfo GetModel(string guid)
        {
            return _mood.GetModel(guid);
        }

        #endregion

        #region 根据条件获取列表 GetList(string strWhere,string orderBy=null)

        /// <summary>
        /// 根据条件获取列表 GetList(string strWhere,string orderBy=null)
        /// </summary>
        /// <param name="strWhere">strWhere</param>
        /// <param name="orderBy">orderBy</param>
        /// <returns>返回List(MoodInfo)类型数据,未查询到数据则返回null</returns>
        public List<MoodInfo> GetList(string strWhere, string orderBy = null)
        {
            return _mood.GetList(strWhere, orderBy);
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
        public List<MoodInfo> GetList(int currentPageIndex, int pageSize, out int totalCount, string strWhere, string orderBy)
        {
            return _mood.GetList(currentPageIndex, pageSize, out totalCount, strWhere, orderBy);
        }

        #endregion

        #endregion

        #region 扩展方法

        #endregion
    }
}
