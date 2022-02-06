using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Web;

namespace WebRole1.Models
{
    public class Student
    {
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime EnrollmentDate { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }


        public static Student create()
        {
            var model = new Student()
            {
                FirstName = "Pranta",
                LastName = "Palit",
                EnrollmentDate = DateTime.Now,
                Address = "Chittagong",
                Email = "ppalit.cghs@gmail.com",
            };

            return model;
        }

    }
}