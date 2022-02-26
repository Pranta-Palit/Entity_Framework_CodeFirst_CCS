using WebRole1.Models;
using System.Linq;
using System.Collections.Generic;
using System;
using System.IO;

namespace WebRole1.Programs
{
    public class Sort
    {
        public static void print(string result)
        {
            GenerateLog.LogMethodCall(result);
        }
        public static List<Student> SortedData()
        {
            GenerateLog.LogMethodCall();

            string path = $@"{AppDomain.CurrentDomain.BaseDirectory}\Programs\Output\";
           
            var db = new SchoolContext();
            List<Student> data = (from s in db.Students
                        select s)
             .ToList();

            List<Student> sorted = data.OrderByDescending(x => x.RankPoints)
                                    .ThenBy(x => x.UserName)
                                    .Take(10)
                                    .ToList();

            File.WriteAllText(path+ "sortedData.txt", String.Join(Environment.NewLine, sorted));

            print(String.Join(Environment.NewLine, sorted));
            return sorted;
        }
    }
}