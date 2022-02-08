using WebRole1.Models;
using System.Linq;
using System.Collections.Generic;
using System;
using System.IO;

namespace WebRole1.Programs
{
    public class Sort
    {
        public static void SortedData()
        {
            string myFile = @"F:\Visual Studio Workstation\Game Workspace\CCS\AzureCloudService1\AzureCloudService1\WebRole1\Programs\sortedData.txt";
            var db = new SchoolContext();
            List<Student> data = (from s in db.Students
                        select s)
             .ToList();

            List<Student> sorted = data.OrderByDescending(x => x.RankPoints)
                                    .ThenBy(x => x.UserName)
                                    .Take(10)
                                    .ToList();
            //System.Diagnostics.Debug.WriteLine(String.Join(Environment.NewLine, sorted));
            File.WriteAllText(myFile, String.Join(Environment.NewLine, sorted));

            //Console.ReadKey(false);
        }
    }
}