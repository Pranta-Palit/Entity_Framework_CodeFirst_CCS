//using System;
//using System.Collections.Generic;
//using System.Linq;
//using WebRole1.Models;
//using Westwind.Utilities;
//using System.IO;


//namespace WebRole1.Programs
//{
//    public class Program
//    {
//        public Program()
//        {

//        }
//		static void InsertData()
//		{
//			var db = new SchoolContext();

//			// this function will generate and insert 100 users data
//			List<Student> playerList = new List<Student>();

//			Random random = new Random();
//			const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";

//			for (int i = 0; i < 100; i++)
//			{
//				playerList.Add(new Student
//				{
//					UserId = DataUtils.GenerateUniqueId(10),
//					UserName = new string(Enumerable.Repeat(chars, 8)
//								.Select(s => s[random.Next(s.Length)]).ToArray()),
//					RankPoints = random.Next(0, 100)
//				});
//			}
//			db.Students.AddRange(playerList);
//			db.SaveChanges();
//		}

//		static List<Student> SortedData()
//		{
//			string myFile = @"F:\Visual Studio Workstation\Game Workspace\CCS\AzureCloudService1\AzureCloudService1\WebRole1\Programs\sortedData.txt";
//			var db = new SchoolContext();
//			List<Student> data = (from s in db.Students
//								  select s)
//			 .ToList();

//			List<Student> sorted = data.OrderByDescending(x => x.RankPoints)
//									.ThenBy(x => x.UserName)
//									.Take(10)
//									.ToList();
//			//System.Diagnostics.Debug.WriteLine(String.Join(Environment.NewLine, sorted));
//			File.WriteAllText(myFile, String.Join(Environment.NewLine, sorted));

//			//Console.ReadKey(false);
//			return sorted;
//		}

//		static void SetRankPoints()
//		{
//			var db = new SchoolContext();
//			(from s in db.Students
//			 where s.RankPoints < 50
//			 select s)
//			 .ToList()
//			 .ForEach(x => x.RankPoints = 0);

//			db.SaveChanges();
//		}
//	}
//}
//}