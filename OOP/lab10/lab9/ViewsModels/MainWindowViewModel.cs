using lab9.Command;
using lab9.Models;
using laba9.ViewModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using lab9.Models.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using lab9.Infrastructure;
using Microsoft.VisualBasic.ApplicationServices;

namespace lab9.ViewsModels
{
    internal class MainWindowViewModel : ViewModel
    {
        ApplicationContext db = new();
        private readonly IUnitOfWork _unitOfWork;

        private ObservableCollection<string> _searchByList = null!;
        public ObservableCollection<string> SearchByList
        {
            get => _searchByList ?? new ObservableCollection<string> { "название", "издательство / страна", "все" };
            set => Set(ref _searchByList, value);
        }

        private ObservableCollection<Book>? _booksDT;
        public ObservableCollection<Book>? BooksDT
        {
            get => _booksDT;
            set => Set(ref _booksDT, value);
        }
        private ObservableCollection<Author>? _authorsDT;
        public ObservableCollection<Author>? AuthorsDT
        {
            get => _authorsDT;
            set => Set(ref _authorsDT, value);
        }
        private object? _selItem;
        public object? selItem
        {
            get => _selItem;
            set => Set(ref _selItem, value);
        }
        private int _pageIndex;
        public int PageIndex
        {
            get => _pageIndex;
            set => Set(ref _pageIndex, value);
        }
        private Book? _selBookForAuthor;
        public Book? SelBookForAuthor
        {
            get => _selBookForAuthor;
            set => Set(ref _selBookForAuthor, value);
        }
        private Author? _selAuthorForBook;
        public Author? SelAuthorForBook
        {
            get => _selAuthorForBook;
            set => Set(ref _selAuthorForBook, value);
        }

        private string _booksTextBlock = "";
        public string BooksTextBlock
        {
            get => _booksTextBlock;
            set => Set(ref _booksTextBlock, value);
        }

        
        private string _searchText;
        public string SearchText
        {
            get => _searchText;
            set => Set(ref _searchText, value);
        }
        private int _selectedSearchIndex;
        public int SelectedSearchIndex
        {
            get => _selectedSearchIndex;
            set => Set(ref _selectedSearchIndex, value);
        }
        private void DeleteBookFromAuthor(object param)
        {
            using var transaction = db.Database.BeginTransaction();

            try
            {
                db.ChangeTracker.AutoDetectChangesEnabled = true;
                var author = selItem as Author;
                foreach (var book in author.Books)
                {
                    db.Books.Attach(book);
                }

                if (author.Books.Any(c => c.BookId == SelBookForAuthor.BookId))
                {
                    author.Books.Remove(SelBookForAuthor);
                    db.Update(author);
                    BooksTextBlock = "";
                    foreach (var book in author.Books)
                    {
                        BooksTextBlock += book.ToString();
                    }
                    db.SaveChanges();
                }
                transaction.Commit();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                transaction.Rollback();
            }
        }
        private void AddAuthorToBook(object param)
        {
            using var transaction = db.Database.BeginTransaction();

            try
            {
                db.ChangeTracker.AutoDetectChangesEnabled = true;
                var book = selItem as Book;
                if (book.Author.Nickname != "default")
                    db.Authors.Attach(book.Author);

                book.Author = SelAuthorForBook;
                if (Equals(book.Author, SelAuthorForBook))
                {
                    book.Author.Books.Add(book);
                }
                db.Update(book);
                db.SaveChanges();

                transaction.Commit();

                BooksDT = null;
                AuthorsDT = null;
                LoadData();


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                transaction.Rollback();
            }
        }
        private void AddBookToAuthor(object param)
        {
            
            using var transaction = db.Database.BeginTransaction();

            try
            {
                db.ChangeTracker.AutoDetectChangesEnabled = true;
                var author = selItem as Author;
                foreach (var book in author.Books)
                {
                    db.Books.Attach(book);
                }

                if (!author.Books.Any(c => c.BookId == SelBookForAuthor.BookId))
                {
                    author.Books.Add(SelBookForAuthor);
                    BooksTextBlock += SelBookForAuthor.ToString();
                    db.Update(author);
                    db.SaveChanges();
                }
                transaction.Commit();
                BooksDT = null;
                AuthorsDT = null;
                LoadData();

            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message);
                transaction.Rollback();
            }
            finally
            {
                transaction.Dispose();
            }
        }

        private void OnSelectionCh(object ob)
        {
            try
            {
                if (PageIndex == 1)
                {
                    var author = selItem as Author;

                    if (author != null)
                    {
                        BooksTextBlock = "";
                        foreach (var b in author.Books)
                        {
                            BooksTextBlock += b.ToString();
                        }
                    }
                    else
                    {
                        BooksTextBlock = string.Empty;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
        private void OnDeleteItemCommandExecuted(object ob)
        {
            using var transaction = db.Database.BeginTransaction();

            try
            {
                try
                {
                    db.Remove(selItem);
                    db.SaveChanges();
                }
                catch (DbUpdateConcurrencyException ex)
                {
                    foreach (var entry in ex.Entries)
                    {
                        if (PageIndex == 0)
                        {
                            if (entry.Entity is Book)
                            {
                                var databaseValues = entry.GetDatabaseValues();

                                if (databaseValues == null)
                                {
                                    continue;
                                }

                                db.Remove(entry.Entity);
                                db.SaveChanges();
                            }
                            else
                            {
                                throw;
                            }
                        }
                        else
                        {
                            if (entry.Entity is Author)
                            {
                                var databaseValues = entry.GetDatabaseValues();

                                if (databaseValues == null)
                                {
                                    continue;
                                }

                                db.Remove(entry.Entity);
                                db.SaveChanges();
                            }
                            else
                            {
                                throw;
                            }
                        }

                    }
                }
                transaction.Commit();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                transaction.Rollback();
            }
            finally
            {
                transaction.Dispose();
            }


        }

        private void OnAddingElementCommandExecuted(object ob)
        {
            using var transaction = db.Database.BeginTransaction();
            try
            {
                if (PageIndex == 0)
                {
                    var addingBook = selItem as Book;
                    if (!db.Books.Any(c => c.BookId == addingBook.BookId))
                    {
                        db.Books.Add(addingBook);
                    }
                }
                else
                {
                    var addingAuthor = selItem as Author;
                    if (!db.Authors.Any(c => c.AuthorId == addingAuthor.AuthorId))
                    {
                        db.Authors.Add(addingAuthor);
                    }
                }
                db.SaveChanges();
                transaction.Commit();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                transaction.Rollback();
            }
            finally
            {
                transaction.Dispose();
            }
        }

        private void OnSaveChanges(object obj)
        {
/*            using var transaction = db.Database.BeginTransaction();*/

            try
            {
                if (PageIndex == 0)
                {
                    var changedBook = selItem as Book;
                    var entity = db.Books.FirstOrDefault(e => e.BookId == changedBook.BookId);

                    if (entity != null)
                    {
                        entity = changedBook;
                        BooksDT = null;
                        AuthorsDT = null;
                        LoadData();
                        db.SaveChanges();
                    }
                }
                else
                {
                    var changedAuthor = selItem as Author;
                    var entity = db.Authors.FirstOrDefault(e => e.AuthorId == changedAuthor.AuthorId);

                    if (entity != null)
                    {
                        entity = changedAuthor;
                        BooksDT = null;
                        AuthorsDT = null;
                        LoadData();
                        db.SaveChanges();
                    }

                }
                /*transaction.Commit();*/
            }
            catch (Exception ex)
            {
                if(!ex.Message.Contains("A second operation was started on this context instance before a previous operation completed."))
                {
                    MessageBox.Show(ex.Message);
                }

                /*transaction.Rollback();*/
            }
            finally
            {
                //transaction.Dispose();
            }
        }



        private void OnSelectionSearchByChanged(object ob)
        {
            using var transaction = db.Database.BeginTransaction();

            try
            {
                string entity = PageIndex == 0 ? "Books" : "Authors";
                string name = PageIndex == 0 ? "Name" : "NickName";
                string secParam = PageIndex == 0 ? "Publisher" : "Country";
                string sqlSearch = "";
                switch (SelectedSearchIndex)
                {
                    case 0:
                        sqlSearch = $"select * from {entity} where {name} like '%{SearchText}%';";
                        break;
                    case 1:
                        sqlSearch = $"select * from {entity} where {secParam} like '%{SearchText}%';";
                        break;
                    case 2:
                        sqlSearch = $"select * from {entity} where {name} like '%{SearchText}%' or {secParam} like '%{SearchText}%';";
                        break;
                }


                if (PageIndex == 0)
                {
                    var searchResults = db.Books.FromSqlRaw(sqlSearch).ToList();
                    BooksDT = new ObservableCollection<Book>(searchResults);

                }
                else
                {
                    var searchResults = db.Authors.FromSqlRaw(sqlSearch).ToList();
                    AuthorsDT = new ObservableCollection<Author>(searchResults);
                }
                transaction.Commit();
            }
            catch (Exception ex)
            {
                transaction.Rollback();
            }
            finally
            {
                transaction.Dispose();
            }
        }

        public BaseCommand AddingItemCommand { get; }
        public BaseCommand DeleteItemCommand { get; }
        public BaseCommand AddAuthorToBookCommand { get; }
        public BaseCommand AddBookToAuthorCommand { get; }
        public BaseCommand DeleteBookFromAuthorCommand { get; }
        public BaseCommand SelectionChCommand { get; }
        public BaseCommand SaveChangesCommand { get; }
        public BaseCommand OnSelectionSearchByChangedCommand { get; }


        private async void LoadData()
        {
            var books = await Task.Run(() => _unitOfWork.BookRepository.GetAll());
            BooksDT = new ObservableCollection<Book>(books);

            var authors = await Task.Run(() => _unitOfWork.AuthorRepository.GetAll());
            AuthorsDT = new ObservableCollection<Author>(authors);
        }

        public MainWindowViewModel()
        {
            _unitOfWork = new UnitOfWork(new ApplicationContext());
            LoadData();
            AddingItemCommand = new BaseCommand(OnAddingElementCommandExecuted, (obj) => selItem != null);
            DeleteItemCommand = new BaseCommand(OnDeleteItemCommandExecuted, (obj) => selItem != null);
            AddAuthorToBookCommand = new BaseCommand(AddAuthorToBook, (obj) => selItem != null && SelAuthorForBook != null);
            SelectionChCommand = new BaseCommand(OnSelectionCh, (obj) => selItem != null);
            SaveChangesCommand = new BaseCommand(OnSaveChanges, (obj) => selItem != null);
            OnSelectionSearchByChangedCommand = new BaseCommand(OnSelectionSearchByChanged, (obj) => SelectedSearchIndex != -1);
            AddBookToAuthorCommand = new BaseCommand(AddBookToAuthor, (obj) => selItem != null && SelBookForAuthor != null);
            DeleteBookFromAuthorCommand = new BaseCommand(DeleteBookFromAuthor, (obj) => selItem != null && SelBookForAuthor != null);

        }
    }
}
