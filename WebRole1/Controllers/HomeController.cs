using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebRole1.Models;

namespace WebRole1.Controllers
{
	public class HomeController : Controller
	{
		public ActionResult Index()
		{
			ViewBag.Title = "Home Page";


			var db = new SchoolContext();
			var model = Student.create();
			db.Students.Add(model);
			db.SaveChanges();
			


			return View();
		}
	}
}
