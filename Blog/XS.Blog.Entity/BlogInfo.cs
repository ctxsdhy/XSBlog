
namespace XS.Blog.Entity
{
    /// <summary>
    /// 博客实体类
    /// </summary>
    public class BlogInfo
    {
        /// <summary>
		/// Id
        /// </summary>		
        public decimal Id{get;set;} 
        		
		/// <summary>
		/// 主键
        /// </summary>		
        public string Guid{get;set;} 
        		
		/// <summary>
		/// 博客名
        /// </summary>		
        public string Name{get;set;} 
        		
		/// <summary>
		/// 说明
        /// </summary>		
        public string Tag{get;set;} 
        		
		/// <summary>
		/// 序号
        /// </summary>		
        public int Order{get;set;} 
    }
}
