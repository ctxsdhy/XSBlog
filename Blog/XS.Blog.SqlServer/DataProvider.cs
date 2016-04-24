using System.Text;
using XS.Blog.Data.DataProvider;

namespace XS.Blog.Data.SqlServer
{
    /// <summary>
    /// 数据驱动
    /// </summary>
    public class DataProvider : IDataProvider
    {
        /// <summary>
        /// 得到博客数据访问层
        /// </summary>
        /// <returns></returns>
        public IBlog GetBlogDal()
        {
            return new SqlBlog();
        }

        /// <summary>
        /// 得到用户数据访问层
        /// </summary>
        /// <returns></returns>
        public IUser GetUserDal()
        {
            return new SqlUser();
        }

        /// <summary>
        /// 得到文章数据访问层
        /// </summary>
        /// <returns></returns>
        public IDaily GetDailyDal()
        {
            return new SqlDaily();
        }

        /// <summary>
        /// 得到分类数据访问层
        /// </summary>
        /// <returns></returns>
        public ICategory GetCategoryDal()
        {
            return new SqlCategory();
        }

        /// <summary>
        /// 得到心情数据访问层
        /// </summary>
        /// <returns></returns>
        public IMood GetMoodDal()
        {
            return new SqlMood();
        }

        /// <summary>
        /// 得到相册数据访问层
        /// </summary>
        /// <returns></returns>
        public IAlbum GetAlbumDal()
        {
            return new SqlAlbum();
        }

        /// <summary>
        /// 得到照片数据访问层
        /// </summary>
        /// <returns></returns>
        public IPhoto GetPhotoDal()
        {
            return new SqlPhoto();
        }
    }
}