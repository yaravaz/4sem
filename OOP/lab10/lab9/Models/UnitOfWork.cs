    using lab9.Infrastructure;
using lab9.Models.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab9.Models
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationContext _context;
        private IBookRepository _bookRepository;
        private IAuthorRepository _authorRepository;

        public UnitOfWork(ApplicationContext context)
        {
            _context = context;
        }

        public IBookRepository BookRepository => _bookRepository ??= new BookRepository(_context);

        public IAuthorRepository AuthorRepository => _authorRepository ??= new AuthorRepository(_context);

        public void Save()
        {
            _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
