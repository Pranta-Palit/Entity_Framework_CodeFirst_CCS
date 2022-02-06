using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebRole1.Models;
using Westwind.Utilities;

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

			
			using (SchoolContext dbobj = new SchoolContext())
			{
				dbobj.Database.Log = Console.WriteLine;

				List<Student> deps = new List<Student>();

				Random random = new Random();
				const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
				const string nums = "0123456789";

				for (int i = 0; i < 100; i++)
				{
					string FN = new string(Enumerable.Repeat(chars, 8)
		.Select(s => s[random.Next(s.Length)]).ToArray());

					string LN = new string(Enumerable.Repeat(chars, 8)
		.Select(s => s[random.Next(s.Length)]).ToArray());

					string Addr = new string(Enumerable.Repeat(nums, 2)
		.Select(s => s[random.Next(s.Length)]).ToArray());
					//Email = DataUtils.GenerateUniqueId() + "@css.com",
					string email = FN + "." + LN + "@css.com";
					DateTime eDate = DateTime.Now;
					deps.Add(new Student
					{
						FirstName = FN,
						LastName = LN,
						EnrollmentDate = eDate,
						Address = Addr,
						Email = email
					});
				}
				dbobj.Students.AddRange(deps);

				dbobj.SaveChanges();

				Console.WriteLine("{0} Students added ", deps.Count);
				Console.ReadKey();

			}


			return View();
		}
	}
}
