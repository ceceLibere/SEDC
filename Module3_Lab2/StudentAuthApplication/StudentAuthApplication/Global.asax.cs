using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using StudentAuthApplication.Cache;

namespace StudentAuthApplication
{
    public class MvcApplication : HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            StudentsCache.Add(1, "Student 1");
            StudentsCache.Add(2, "Student 2");
            StudentsCache.Add(3, "Student 3");
        }
    }
}
