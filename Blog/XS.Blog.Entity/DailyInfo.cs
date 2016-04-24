using System;

namespace XS.Blog.Entity
{
    /// <summary>
    /// 文章实体类
    /// </summary>
    public class DailyInfo
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
        /// 文章标题
        /// </summary>		
        public string Name { get; set; }

        /// <summary>
        /// 文章内容
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

        /// <summary>
        /// 文章分类
        /// </summary>		
        public string CategoryGuid { get; set; }

        /// <summary>
        /// 是否草稿
        /// </summary>
        public bool IsDraft { get; set; }

        /// <summary>
        /// 是否置顶
        /// </summary>
        public bool IsStick { get; set; }

        /// <summary>
        /// 是否首页显示
        /// </summary>
        public bool IsHome { get; set; }

        /// <summary>
        /// 是否特殊显示
        /// </summary>
        public int IsSpecial { get; set; }

        /// <summary>
        /// 阅读数量
        /// </summary>
        public int PageView { get; set; }

        /// <summary>
        /// 评论数量
        /// </summary>
        public int CommentsNum { get; set; }
    }
}
