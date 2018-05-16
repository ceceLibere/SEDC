using System.Web.Mvc;
using System.Web.Security;

namespace StudentAuthApplication.Controllers
{
    public class UsersController : Controller
    {
        [HttpGet]
        public ViewResult LogIn()
        {
            return View();
        }

        [HttpPost]
        public RedirectResult LogIn(string username, string password)
        {
            if (username == "risto.panchevski@gmail.com"
                && password == "password")
            {
                FormsAuthentication.SetAuthCookie(username, false);
                return new RedirectResult("~/Students/Create");
            }
            else
            {
                return new RedirectResult("~/Users/LogIn");
            }
        }

        [HttpGet]
        public RedirectResult LogOut()
        {
            FormsAuthentication.SignOut();
            return new RedirectResult("~/Students/List");
        }
    }
}