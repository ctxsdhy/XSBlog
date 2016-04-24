
namespace XS.Framework.Common.WebBase
{
    public abstract class NormalHttpHandler : HttpHandlerBase
    {
        /// <summary>
        /// 是否是Ajax请求
        /// </summary>
        public bool IsAjaxRequest { get; private set; }

        public override void ProcessMain()
        {
            if (Request.Headers["X-Requested-With"] == "XMLHttpRequest")
            {
                //如果是Ajax请求
                IsAjaxRequest = true;
            }

            Main();
        }

        public abstract void Main();
    }
}
