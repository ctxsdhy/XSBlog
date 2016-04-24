using System;

namespace XS.Framework.Common.Tip
{
    /// <summary>
    /// 提示特性。
    /// </summary>
    [AttributeUsage(AttributeTargets.All, AllowMultiple = true, Inherited = false)]
    public class TipAttribute : Attribute
    {
        private string _description;

        /// <summary>
        /// 构造函数
        /// </summary>
        public TipAttribute()
        {

        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="desc"></param>
        public TipAttribute(string desc)
        {
            _description = desc;
        }

        /// <summary>
        /// 获得提示内容
        /// </summary>
        public string Description
        {
            get
            {
                return _description;
            }
            set
            {
                _description = value;
            }
        }
    }
}
