using System;

namespace XS.Blog.Entity
{
    /// <summary>
    /// 心情实体类
    /// </summary>
    public class MoodInfo
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
        /// 名称
        /// </summary>		
        public string Name { get; set; }

        /// <summary>
        /// 内容
        /// </summary>		
        public string Content { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>		
        public DateTime CreateTime { get; set; }

        /// <summary>
        /// 博客主键
        /// </summary>
        public string BlogGuid { get; set; }

        /// <summary>
        /// 创建用户
        /// </summary>		
        public string UserGuid { get; set; } 
    }
}
