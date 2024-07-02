using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab9.Models
{
    public class Book
    {
        public int BookId { get; set; }
        public string Name { get; set; }
        public string Publisher { get; set; }
        [Range(1450, 2024)]
        public int PublishYear { get; set; }
        public string Description { get; set; }
        public Author Author { get; set; }

        public override string ToString()
        {
            return $"{Name} выпущена {Publisher}({PublishYear})";
        }
    }
}
