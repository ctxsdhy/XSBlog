﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using XS.Blog.Entity;

namespace XS.Blog.Data
{
    /// <summary>
    /// 相册接口
    /// </summary>
    public interface IPhoto
    {
        #region 基础方法

        #region 是否存在该记录 Exists(Guid Guid)

        /// <summary>
        /// 是否存在该记录 Exists(Guid Guid)
        /// </summary>
        /// <param name="guid">主键id</param>
        /// <returns>true:存在; false:不存在</returns>
        bool Exists(string guid);

        #endregion

        #region 保存添加数据 Add(PhotoInfo entity)

        /// <summary>
        /// 保存添加数据 Add(PhotoInfo entity)
        /// </summary>
        /// <param name="entity">实体类(PhotoInfo)</param>
        ///<returns>返回新增的ID</returns>
        void Add(PhotoInfo entity);

        #endregion

        #region 更新数据 Update(PhotoInfo entity)

        /// <summary>
        /// 更新数据 Update(PhotoInfo entity)
        /// </summary>
        /// <param name="entity">实体类(PhotoInfo)</param>
        ///<returns>true:保存成功; false:保存失败</returns>
        bool Update(PhotoInfo entity);

        #endregion

        #region 物理删除数据 Delete(Guid Guid)

        /// <summary>
        /// 物理删除数据 Delete(Guid Guid)
        /// </summary>
        /// <param name="guid">主键Id(int)</param>
        /// <returns>true:删除成功; false:删除失败</returns>
        bool Delete(string guid);

        #endregion

        /// <summary>
        /// 物理删除数据 Delete(int id)
        /// </summary>
        /// <param name="ids">主键Id(int)</param>
        /// <returns>true:删除成功; false:删除失败</returns>
        bool DeleteByGuIds(string ids);

        #region 得到一个对象实体 GetModel(Guid Guid)

        /// <summary>
        /// 得到一个对象实体 GetModel(Guid Guid)
        /// </summary>
        PhotoInfo GetModel(string guid);

        #endregion

        #region 得到一个对象实体 GetModelById(int id)

        /// <summary>
        /// 得到一个对象实体 GetModelById(int id)
        /// </summary>
        PhotoInfo GetModelById(int id);

        #endregion 

        #region 根据条件获取列表 GetList(string strWhere,string orderBy=null)

        /// <summary>
        /// 根据条件获取列表 GetList(string strWhere,string orderBy=null)
        /// </summary>
        /// <param name="strWhere">strWhere</param>
        /// <param name="orderBy">orderBy</param>
        /// <returns>返回List(PhotoInfo)类型数据,未查询到数据则返回null</returns>
        List<PhotoInfo> GetList(string strWhere, string orderBy = null);

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
        List<PhotoInfo> GetList(int currentPageIndex, int pageSize, out int totalCount, string strWhere, string orderBy);

        #endregion

        #endregion

        #region 扩展方法

        /// <summary>
        /// 获得照片的数量
        /// </summary>
        /// <returns></returns>
        int GetCount(string strWhere);

        /// <summary>
        /// 获得前几条数据
        /// </summary>
        /// <param name="count"></param>
        /// <param name="strWhere"></param>
        /// <param name="orderBy"></param>
        /// <returns></returns>
        List<PhotoInfo> GetTopList(int count, string strWhere, string orderBy);

        #endregion
    }
}
