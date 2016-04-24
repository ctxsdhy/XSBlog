using System;

namespace XS.Blog.Entity
{
    /// <summary>
    /// 照片实体层
    /// </summary>
    public class PhotoInfo
    {
        /// <summary>
        /// Id
        /// </summary>		
        public int Id { get; set; }

        /// <summary>
        /// 主键
        /// </summary>		
        public string Guid { get; set; }

        /// <summary>
        /// 照片名
        /// </summary>		
        public string Name { get; set; }

        /// <summary>
        /// 简介
        /// </summary>		
        public string Tag { get; set; }

        /// <summary>
        /// 照片地址
        /// </summary>		
        public string ImageUrl { get; set; }

        /// <summary>
        /// 照片Key
        /// </summary>
        public string ImageKey { get; set; }

        /// <summary>
        /// 用户主键
        /// </summary>		
        public string UserGuid { get; set; }

        /// <summary>
        /// 相册主键
        /// </summary>		
        public string AlbumGuid { get; set; } 

        /// <summary>
        /// 创建时间
        /// </summary>		
        public DateTime Createtime { get; set; }

        /// <summary>
        /// 是封面
        /// </summary>		
        public bool IsCover { get; set; } 
    }
}
