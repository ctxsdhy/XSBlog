using System;
using System.Web;

namespace XS.Blog.Framework.HttpModule
{
    public class UrlModule : IHttpModule
    {
        private void Context_BeginRequest(object sender, EventArgs args)
        {
            //var application = sender as HttpApplication;

            //string oldUrl = application.Request.RawUrl;

            //if (oldUrl.IndexOf(".aspx") < 0)
            //{
            //    application.Context.RewritePath(oldUrl + ".aspx");
            //}
        }

        public void Init(HttpApplication context)
        {
            context.BeginRequest += Context_BeginRequest;  
        }

        public void Dispose()
        {
            //throw new NotImplementedException();
        }
    }
}
