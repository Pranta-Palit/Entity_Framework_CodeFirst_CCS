using System.Linq;
using WebRole1.Models;

namespace WebRole1.Programs
{
    public class Update
    {
        public static void SetRankPoints()
        {
            var db = new SchoolContext();
            (from s in db.Students
             where s.RankPoints < 50
             select s)
             .ToList()
             .ForEach(x => x.RankPoints = 0);

            db.SaveChanges();

            GenerateLog.LogMethodCall();
        }
    }
}