using System.Collections.Generic;
using System.Web;
using XS.Blog.Data;
using XS.Blog.Data.DataProvider;
using XS.Blog.Entity;

namespace XS.Blog
{
    /// <summary>
    /// 分类业务层
    /// </summary>
    public class CategoryManager
    {
        private readonly ICategory _category = DataProvider.GetInstance().GetCategoryDal();
		
		#region 基础方法
        
        #region 是否存在该记录 Exists(Guid Guid)
   		
   		/// <summary>
        /// 是否存在该记录 Exists(Guid Guid)
        /// </summary>
        /// <param name="guid">主键id</param>
        /// <returns>true:存在; false:不存在</returns>
		public bool Exists(string guid)
		{
			return _category.Exists(guid);
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
			 _category.Add(entity);
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
			return _category.Update(entity);
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
			return _category.Delete(guid);
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
            return _category.DeleteByGuIds(ids);
        }

        #endregion

        #region 得到一个对象实体 GetModel(Guid Guid)

        /// <summary>
		/// 得到一个对象实体 GetModel(Guid Guid)
		/// </summary>
		public CategoryInfo GetModel(string guid)
		{
			return _category.GetModel(guid);
		}
		
		#endregion 
 
        #region 得到一个对象实体 GetModelById(int categoryId)

        /// <summary>
        /// 得到一个对象实体 GetModelById(int categoryId)
        /// </summary>
        public CategoryInfo GetModelById(int categoryId)
        {
            return _category.GetModelById(categoryId);
        }

        #endregion 
		
		#region 根据条件获取列表 GetList(string strWhere,string orderBy=null)
		
        /// <summary>
        /// 根据条件获取列表 GetList(string strWhere,string orderBy=null)
        /// </summary>
        /// <param name="strWhere">strWhere</param>
        /// <param name="orderBy">orderBy</param>
        /// <returns>返回List(CategoryInfo)类型数据,未查询到数据则返回null</returns>
        public List<CategoryInfo> GetList(string strWhere,string orderBy=null)
        {
        	return _category.GetList(strWhere, orderBy);
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
        	return _category.GetList(currentPageIndex, pageSize, out totalCount, strWhere, orderBy);
        }
        
        #endregion
        
		#endregion
		
		#region 扩展方法

        /// <summary>
        /// 得到分类名称
        /// </summary>
        /// <param name="guid"></param>
        /// <returns></returns>
        public string GetName(string guid)
        {
            var info = GetModel(guid);
            if (info != null)
            {
                return info.Name;
            }
            return "";
        }

        /// <summary>
        /// 根据条件获取列表和文章数量 GetList(string strWhere,string orderBy=null)
        /// </summary>
        /// <param name="strWhere">strWhere</param>
        /// <param name="orderBy">orderBy</param>
        /// <returns>返回List(CategoryInfo)类型数据,未查询到数据则返回null</returns>
        public List<CategoryInfo> GetListAndCount(string strWhere, string orderBy = null)
        {
            return _category.GetListAndCount(strWhere, orderBy);
        }

        /// <summary>
        /// 获得没有类型的文章数量
        /// </summary>
        /// <returns></returns>
        public int GetNoCategroyCount(string strWhere)
        {
            return _category.GetNoCategroyCount(strWhere);
        }

        /// <summary>
        /// 获得这个类型的文章数量
        /// </summary>
        /// <returns></returns>
        public int GetCategroyCountByGuid(string guid, string strWhere)
        {
            return _category.GetCategroyCountByGuid(guid, strWhere);
        }

        #region 获得树形列表

        /// <summary>
        /// 获得树形列表
        /// </summary>
        /// <returns></returns>
        public List<CategoryInfo> GetTreeList()
        {
            var list = _category.GetTreeList();
            var returnList = new List<CategoryInfo>();

            foreach (var info in list)
            {
                if (info.ParentGuid == "00000000-0000-0000-0000-000000000000")
                {
                    returnList.AddRange(GetSortList(list, info, "├─"));
                }
            }
            return returnList;
        }

        /// <summary>
        /// 对树形进行排序
        /// </summary>
        /// <param name="list"></param>
        /// <param name="info"></param>
        /// <param name="tag"></param>
        /// <returns></returns>
        private List<CategoryInfo> GetSortList(List<CategoryInfo> list, CategoryInfo info, string tag)
        {
            var _list = new List<CategoryInfo>();
            info.Name = tag + info.Name;
            _list.Add(info);

            foreach (var model in list)
            {
                if (model.ParentGuid == info.Guid)
                {
                    _list.AddRange(GetSortList(list, model, HttpUtility.HtmlDecode("&nbsp;&nbsp;&nbsp;&nbsp;") + tag));
                }
            }
            return _list;
        }

        #endregion

        #endregion
    }
}
