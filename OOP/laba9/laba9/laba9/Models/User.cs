using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace laba9.Models
{
    public class User
    {
        public int UserId { get; set; }
        [RegularExpression("^[\\p{L}\\s-]+$")]
        public string Name { get; set; }

        [RegularExpression("^[\\p{L}\\s-]+$")]
        public string Surname { get; set; }
        [Range(0, 100)]
        public int Age { get; set; }
        public List<Course> Courses { get; set; }

        public User()
        {
            Courses = new List<Course>();
        }
        /* public User(int userId, string name, string surname, int age)
         {
             UserId = userId;
             Name = name;
             Surname = surname;
             Age = age;
         }
         public User()
         {
             UserId = 1;
             Name = "UsName";
             Surname = "UsSurname";
             Age = 20;
         }
 */

        public override string ToString()
        {
            return $"User: {this.Name} {this.Surname}, {this.Age}y.o.\n";
        }

    }
}
