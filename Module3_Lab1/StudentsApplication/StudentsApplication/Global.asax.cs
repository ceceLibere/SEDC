using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using StudentsApplication.Cache;

namespace StudentsApplication
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            StudentsCache.Add(1, "Student 1");
            StudentsCache.Add(2, "Student 2");
            StudentsCache.Add(3, "Student 3");
        }
    }
}
