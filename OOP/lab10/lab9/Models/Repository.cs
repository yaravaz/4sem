using lab9.Infrastructure;
using lab9.Models.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab9.Models
{
    public class BookRepository : IBookRepository
    {
        private readonly ApplicationContext _context;

        public BookRepository(ApplicationContext context)
        {
            _context = context;
        }

        public Book GetById(int id)
        {
            return _context.Books.Find(id);
        }

        public IEnumerable<Book> GetAll()
        {
            return _context.Books.ToList();
        }

        public void Add(Book book)
        {
            _context.Books.Add(book);
        }

        public void Update(Book book)
        {
            _context.Books.Update(book);
        }

        public void Delete(Book book)
        {
            _context.Books.Remove(book);
        }
    }

    public class AuthorRepository : IAuthorRepository
    {
        private readonly ApplicationContext _context;

        public AuthorRepository(ApplicationContext context)
        {
            _context = context;
        }

        public Author GetById(int id)
        {
            return _context.Authors.Find(id);
        }

        public IEnumerable<Author> GetAll()
        {
            return _context.Authors.ToList();
        }

        public void Add(Author author)
        {
            _context.Authors.Add(author);
        }

        public void Update(Author author)
        {
            _context.Authors.Update(author);
        }

        public void Delete(Author author)
        {
            _context.Authors.Remove(author);
        }
    }
}
