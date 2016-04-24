using System;

namespace XS.Blog.Entity
{
    /// <summary>
    /// 相册实体类
    /// </summary>
    public class AlbumInfo
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
        /// 相册名
        /// </summary>		
        public string Name { get; set; }

        /// <summary>
        /// 博客主键
        /// </summary>		
        public string BlogGuid { get; set; }

        /// <summary>
        /// 用户主键
        /// </summary>		
        public string UserGuid { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>		
        public DateTime CreateTime { get; set; } 

        /// <summary>
        /// 序号
        /// </summary>
        public int OrderId { get; set; }
    }
}
