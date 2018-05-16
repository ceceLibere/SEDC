using System.Linq;
using System.Web.Mvc;
using StudentAuthApplication.Cache;

namespace StudentAuthApplication.Controllers
{
    public class StudentsController : Controller
    {
        [HttpGet]
        public ViewResult List()
        {
            ViewBag.Students = StudentsCache.GetAll();

            return View();
        }

        [HttpGet]
        public ViewResult Details(int id)
        {
            ViewBag.StudentId = id;
            ViewBag.StudentName = StudentsCache.Get(id);

            return View();
        }

        [HttpGet]
        [Authorize]
        public ViewResult Create()
        {
            return View();
        }

        [HttpPost]
        [Authorize]
        public RedirectResult Create(string fullName)
        {
            var id = StudentsCache.GetAll().Max(student => student.Key) + 1;
            StudentsCache.Add(id, fullName);

            return new RedirectResult("~/Students/List");
        }
    }
}