
namespace XS.Blog.Entity
{
    /// <summary>
    /// 用户实体类
    /// </summary>
    public class UserInfo
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
        /// 用户名
        /// </summary>		
        public string Name { get; set; }

        /// <summary>
        /// 说明
        /// </summary>		
        public string Tag { get; set; }

        /// <summary>
        /// 登录名
        /// </summary>		
        public string LoginName { get; set; }

        /// <summary>
        /// 登录密码
        /// </summary>		
        public string LoginPwd { get; set; }

        /// <summary>
        /// 邮箱
        /// </summary>		
        public string Email { get; set; }
    }
}
