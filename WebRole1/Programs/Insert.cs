using System;
using System.Collections.Generic;
using System.Linq;
using WebRole1.Models;
using Westwind.Utilities;

namespace WebRole1.Programs
{
    public class Insert
    {
		public static void InsertData()
		{
			var db = new SchoolContext();

			// this function will generate and insert 100 users data
			List<Student> playerList = new List<Student>();

			Random random = new Random();
			const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";

			for (int i = 0; i < 100; i++)
			{
				playerList.Add(new Student
				{
					UserId = DataUtils.GenerateUniqueId(10),
					UserName = new string(Enumerable.Repeat(chars, 8)
								.Select(s => s[random.Next(s.Length)]).ToArray()),
					RankPoints = random.Next(0, 100)
				});
			}
			db.Students.AddRange(playerList);
			db.SaveChanges();

			GenerateLog.InitLogFile();
			GenerateLog.LogMethodCall(playerList);
		}
	}
}