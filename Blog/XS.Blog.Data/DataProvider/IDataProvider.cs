namespace XS.Blog.Data.DataProvider
{
    /// <summary>
    /// 数据访问层接口
    /// </summary>
    public interface IDataProvider
    {
        /// <summary>
        /// 得到博客数据访问层
        /// </summary>
        /// <returns></returns>
        IBlog GetBlogDal();

        /// <summary>
        /// 得到用户数据访问层
        /// </summary>
        /// <returns></returns>
        IUser GetUserDal();

        /// <summary>
        /// 得到文章数据访问层
        /// </summary>
        /// <returns></returns>
        IDaily GetDailyDal();

        /// <summary>
        /// 得到分类数据访问层
        /// </summary>
        /// <returns></returns>
        ICategory GetCategoryDal();

        /// <summary>
        /// 得到心情数据访问层
        /// </summary>
        /// <returns></returns>
        IMood GetMoodDal();

        /// <summary>
        /// 得到相册数据访问层
        /// </summary>
        /// <returns></returns>
        IAlbum GetAlbumDal();

        /// <summary>
        /// 得到照片数据访问层
        /// </summary>
        /// <returns></returns>
        IPhoto GetPhotoDal();
    }
}
