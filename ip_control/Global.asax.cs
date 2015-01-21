using System;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;


namespace ip_control
{
    public class Global : HttpApplication
    {
        protected void Application_Start(object sender, EventArgs e)
        {
            MvcHandler.DisableMvcResponseHeader = true;
            HtmlHelper.ClientValidationEnabled =
            HtmlHelper.UnobtrusiveJavaScriptEnabled = false;

            GlobalFilters.Filters.Add(new HandleErrorAttribute());

            RegisterRoutes(RouteTable.Routes);

            PrepareIocContainer();
        }

        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.MapRoute("Default", "{controller}/{action}/{id}", new { controller = "Home", action = "Index", id = UrlParameter.Optional });
        }

        private void PrepareIocContainer()
        {
           
        }

        protected void Application_PreSendRequestHeaders(object sender, EventArgs e)
        {
            HttpContext.Current.Response.Headers.Remove("X-Powered-By");
            HttpContext.Current.Response.Headers.Remove("X-AspNet-Version");
            HttpContext.Current.Response.Headers.Remove("X-AspNetMvc-Version");

            HttpContext.Current.Response.Headers.Set("Server", "Server - 1");
        }
    }
}