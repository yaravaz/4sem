using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab4_5
{
    public partial class BookGenre
    {
        public virtual ICollection<Book> books { get; set; }

        public BookGenre()
        {
            books = new HashSet<Book>();
        }

        [Key]
        public int BookGenreId { get; set; }

        [Required]
        [StringLength(45)]
        public string PGenre { get; set; }

        
    }
}
