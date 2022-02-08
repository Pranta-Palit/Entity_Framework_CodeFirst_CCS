using System.ComponentModel.DataAnnotations;

namespace WebRole1.Models
{
	public class Student
	{
		[Key]
		public string UserId { get; set; }
		public string UserName { get; set; }
		public int RankPoints { get; set; }

		public override string ToString()
		{
			return "[" + UserId + " - " + UserName + " - " + RankPoints + "]";
		}
	}
}