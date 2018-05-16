using System.Web.Mvc;
using StudentsApplication.Cache;

namespace StudentsApplication.Controllers
{
    public class StudentsController : Controller
    {
        // GET: Students
        [ActionName("List")]
        public ActionResult List()
        {
            ViewBag.Students = StudentsCache.GetAll();
            return View();
        }

        [HttpGet]
        public ActionResult Details(int id)
        {

            ViewBag.StudentId = id;
            ViewBag.StudentName = StudentsCache.Get(id);
            return View();
        }
    }
}