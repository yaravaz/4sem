using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab9.Models
{
    public class Author
    {
        public int AuthorId {  get; set; }
        [RegularExpression("^[\\p{L}\\s-]+$")]
        public string Nickname { get; set; }
        [RegularExpression("^[\\p{L}\\s-]+$")]
        public string Country { get; set; }
        [Range(1400, 2010)]
        public int BirthYear { get; set; }
        public List<Book> Books { get; set; }

        public Author()
        {
            Books = new List<Book>();
        }

        public string BookNames => string.Join(", ", Books.Select(book => book.Name));

        public override string ToString()
        {
            return $"{Nickname}({BirthYear}) из {Country}";
        }
    }
}
