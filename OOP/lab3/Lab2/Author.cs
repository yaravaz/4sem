using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Lab2
{
    public class Author
    {
        [StringLength(30, MinimumLength = 3, ErrorMessage = "Недопустимая длина!")]
        public string FIO { get; set; }

        [StringLength(30, MinimumLength = 3, ErrorMessage = "Недопустимая длина!")]
        public string Country { get; set; }
        public int ID { get; set; }

        public Author() { }
        public Author(string fio, string country, int id)
        {
            FIO = fio;
            Country = country;
            ID = id;
        }
        public override string ToString()
        {
            return $"ФИО: {FIO}, Страна: {Country}, ID: {ID}; ";
        }
    }
}
