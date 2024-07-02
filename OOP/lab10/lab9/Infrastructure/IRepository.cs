using lab9.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab9.Infrastructure
{
    public interface IBookRepository
    {
        Book GetById(int id);
        IEnumerable<Book> GetAll();
        void Add(Book book);
        void Update(Book book);
        void Delete(Book book);
    }

    public interface IAuthorRepository
    {
        Author GetById(int id);
        IEnumerable<Author> GetAll();
        void Add(Author author);
        void Update(Author author);
        void Delete(Author author);
    }
}
