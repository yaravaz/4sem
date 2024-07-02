using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace laba9.Models
{
    public class Course
    {
        public int CourseID { get; set; }
        [RegularExpression("^[\\p{L}\\s-]+$")]
        public string Name { get; set; }
        public string Description { get; set; }
        [Range(0.1, 90000000)]
        public double Cost { get; set; } = 1;
        public List<User> Users { get; set; }
        public Course() 
        {
            Users = new List<User>();
        }

        public override string ToString()
        {
            return $"Course: {this.Name}, {this.Cost}$\n"; 
        }

    }
}
