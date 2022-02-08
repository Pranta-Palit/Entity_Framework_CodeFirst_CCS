using System.Web.Mvc;
using WebRole1.Models;
using WebRole1.Programs;

namespace WebRole1.Controllers
{
	public class HomeController : Controller
	{
		public ActionResult Index()
		{
			//var db = new SchoolContext();
			//db.Students.AddRange(Insert.InsertData());
			//db.SaveChanges();

			return View();
		}
	}
}
