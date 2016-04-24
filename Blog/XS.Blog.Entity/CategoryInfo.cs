
namespace XS.Blog.Entity
{
    /// <summary>
    /// 分类实体类
    /// </summary>
    public class CategoryInfo
    {
        /// <summary>
        /// Id
        /// </summary>		
        public decimal Id { get; set; }

        /// <summary>
        /// 主键
        /// </summary>		
        public string Guid { get; set; }

        /// <summary>
        /// 类型名称
        /// </summary>		
        public string Name { get; set; }

        /// <summary>
        /// 照片地址
        /// </summary>		
        public string ImageUrl { get; set; }

        /// <summary>
        /// 照片Key
        /// </summary>
        public string ImageKey { get; set; }

        /// <summary>
        /// 父类主键
        /// </summary>
        public string ParentGuid { get; set; }

        /// <summary>
        /// 排序号
        /// </summary>
        public int OrderId { get; set; }

        /// <summary>
        /// 文章数量
        /// </summary>
        public int Count { get; set; }

        /// <summary>
        /// 博客主键
        /// </summary>
        public string BlogGuid { get; set; }

        /// <summary>
        /// 用户主键
        /// </summary>
        public string UserGuid { get; set; }
    }
}
