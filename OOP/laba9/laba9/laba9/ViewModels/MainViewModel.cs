using laba9.Infrastructure.Commands;
using laba9.Models;
using laba9.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using laba9.EF.Context;
//using MessageBox = System.Windows.MessageBox;
using Microsoft.EntityFrameworkCore;
using System.Data;
using System.ComponentModel;
using System.Collections.ObjectModel;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.EntityFrameworkCore.Storage;
using System.ComponentModel.DataAnnotations;


namespace laba9.ViewModels
{
    internal class MainViewModel : ViewModel
    {
        ApplicationContext db = new();

        #region Properties and collections

        private ObservableCollection<string> _serchByList = null!;
        public ObservableCollection<string> SerchByList
        {
            get => _serchByList ?? new ObservableCollection<string> { "Name", "Descr / Surn", "All" };
            set => Set(ref _serchByList, value);
        }

        private ObservableCollection<Course>? _coursesDT;
        public ObservableCollection<Course>? CoursesDT
        {
            get => _coursesDT;
            set => Set(ref _coursesDT, value);
        }
        private ObservableCollection<User>? _usersDT;
        public ObservableCollection<User>? UsersDT
        {
            get => _usersDT;
            set => Set(ref _usersDT, value);
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
        private User? _selUserForCourse;
        public User? SelUserForCourse
        {
            get => _selUserForCourse;
            set => Set(ref _selUserForCourse, value);
        }
        private Course? _selCourseForUser;
        public Course? SelCourseForUser
        {
            get => _selCourseForUser;
            set => Set(ref _selCourseForUser, value);
        }

        private string _usersTextBlock = "";
        public string UsersTextBlock
        {
            get => _usersTextBlock;
            set => Set(ref _usersTextBlock, value);
        }

        private string _coursesTextBlock = "";
        public string CoursesTextBlock
        {
            get => _coursesTextBlock;
            set => Set(ref _coursesTextBlock, value);
        }
        private string _searchText;
        public string SearchText
        {
            get => _searchText;
            set => Set(ref _searchText, value);
        }
        private int _selectedSeacrhIndex;
        public int SelectedSeacrhIndex
        {
            get => _selectedSeacrhIndex;
            set => Set(ref _selectedSeacrhIndex, value);
        }


        #endregion

        #region Commands

        private void DeleteUserFromCourse(object param)
        {
            using var transaction = db.Database.BeginTransaction();

            try
            {
                db.ChangeTracker.AutoDetectChangesEnabled = true;
                var course = selItem as Course;
                foreach (var user in course.Users)
                {
                    db.Users.Attach(user);
                }

                if (course.Users.Any(c => c.UserId == SelUserForCourse.UserId))
                {
                    course.Users.Remove(SelUserForCourse);
                    foreach (var user in course.Users)
                    {
                        if (Equals(user, SelUserForCourse))
                        {
                            user.Courses.Remove(course);

                        }
                    }
                    
                    db.Update(course);
                    UsersTextBlock = "";
                    foreach (var user in course.Users)
                    {
                        UsersTextBlock += user.ToString();
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
            finally
            {
                /* transaction.Dispose();
                 db.Dispose();*/
            }
        }

        private void DeleteCourseFromUser(object param)
        {
            using var transaction = db.Database.BeginTransaction();

            try
            {
                db.ChangeTracker.AutoDetectChangesEnabled = true;
                var user = selItem as User;
                foreach (var course in user.Courses)
                {
                    db.Courses.Attach(course);
                }

                if (user.Courses.Any(c => c.CourseID == SelCourseForUser.CourseID))
                {
                    user.Courses.Remove(SelCourseForUser);
                    foreach (var course in user.Courses)
                    {
                        if (Equals(course, SelCourseForUser))
                        {
                            course.Users.Remove(user);

                        }
                    }
                    db.Update(user);
                    CoursesTextBlock = "";
                    foreach (var course in user.Courses)
                    {
                        CoursesTextBlock += course.ToString();
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
            finally
            {
                /* transaction.Dispose();
                 db.Dispose();*/
            }
        }
        private void AddUserToCourse(object param)
        {
            using var transaction = db.Database.BeginTransaction();
            
                try
                {
                    db.ChangeTracker.AutoDetectChangesEnabled = true;
                    var course = selItem as Course;
                    foreach (var user in course.Users)
                    {
                        db.Users.Attach(user);
                    }

                    if (!course.Users.Any(c => c.UserId == SelUserForCourse.UserId))
                    {
                        course.Users.Add(SelUserForCourse);
                        foreach (var user in course.Users)
                        {
                            if (Equals(user, SelUserForCourse))
                            {
                                user.Courses.Add(course);

                            }
                        }
                        UsersTextBlock += SelUserForCourse.ToString();
                        db.Update(course);
                        db.SaveChanges();
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
                    /* transaction.Dispose();
                     db.Dispose();*/
                }
        }
        private void AddCourseToUser(object param)
        {
            using var transaction = db.Database.BeginTransaction();
            
                try
                {
                    db.ChangeTracker.AutoDetectChangesEnabled = true;
                    var user = selItem as User;
                    foreach (var course in user.Courses)
                    {
                        db.Courses.Attach(course);
                    }

                    if (!user.Courses.Any(c => c.CourseID == SelCourseForUser.CourseID))
                    {
                        user.Courses.Add(SelCourseForUser);
                        foreach (var course in user.Courses)
                        {
                            if (Equals(course, SelCourseForUser))
                            {
                                course.Users.Add(user);

                            }
                        }
                        CoursesTextBlock += SelCourseForUser.ToString();
                        db.Update(user);
                        db.SaveChanges();
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
                    /* transaction.Dispose();
                     db.Dispose();*/
                }
        }

        private void OnSelectionCh(object ob)
        {
            try
            {
                if (PageIndex == 0)
                {
                    var course = selItem as Course;

                    if (course != null)
                    {
                        UsersTextBlock = "";
                        foreach (var us in course.Users)
                        {
                            UsersTextBlock += us.ToString();
                        }
                    }
                    else
                    {
                        UsersTextBlock = string.Empty;
                    }
                }
                else
                {
                    var user = selItem as User;

                    if (user != null)
                    {
                        CoursesTextBlock = "";
                        foreach (var c in user.Courses)
                        {
                            CoursesTextBlock += c.ToString();
                        }
                    }
                    else
                    {
                        CoursesTextBlock = string.Empty;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                //transaction.Dispose();
                //db.Dispose();
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
                                if (entry.Entity is Course)
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
                                if (entry.Entity is User)
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
                    /*transaction.Dispose();
                    db.Dispose();*/
                }
            
                
        }

        private void OnAddingElementCommandExecuted(object ob)
        {
            using var transaction = db.Database.BeginTransaction();
            try
            {
                if (PageIndex == 0)
                {
                    var addingCourse = selItem as Course;
                    if (!db.Courses.Any(c => c.CourseID == addingCourse.CourseID))
                    {

                        db.Courses.Add(addingCourse);
                    }
                }
                else
                {
                    var addingUser = selItem as User;
                    if (!db.Users.Any(c => c.UserId == addingUser.UserId))
                    {
                        db.Users.Add(addingUser);
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
                db.Dispose();
            }
        }

        /* private void OnAddingElementCommandExecuted(object ob)
         {
             using var transaction = db.Database.BeginTransaction();

             try
             {
                 if (PageIndex == 0)
                 {
                     var addingCourse = selItem as Course;
                     if (!db.Courses.Any(c => c.CourseID == addingCourse.CourseID))
                     {
                         // Проверка валидности элемента перед добавлением в базу данных
                         var validationResults = new List<ValidationResult>();
                         var validationContext = new ValidationContext(addingCourse);
                         if (Validator.TryValidateObject(addingCourse, validationContext, validationResults, true))
                         {
                             db.Courses.Add(addingCourse);

                             // Обновление DataGrid
                             //UpdateDataGrid();
                         }
                         else
                         {
                             // Ошибка валидации, не добавляем элемент в базу данных и не обновляем DataGrid
                             string errorMessage = string.Join("\n", validationResults.Select(r => r.ErrorMessage));
                             MessageBox.Show($"Неправильный элемент.\n{errorMessage}");
                         }
                     }
                 }
                 else
                 {
                     var addingUser = selItem as User;
                     if (!db.Users.Any(c => c.UserId == addingUser.UserId))
                     {
                         // Проверка валидности элемента перед добавлением в базу данных
                         var validationResults = new List<ValidationResult>();
                         var validationContext = new ValidationContext(addingUser);
                         if (Validator.TryValidateObject(addingUser, validationContext, validationResults, true))
                         {
                             db.Users.Add(addingUser);

                             // Обновление DataGrid
                             //UpdateDataGrid();
                         }
                         else
                         {
                             // Ошибка валидации, не добавляем элемент в базу данных и не обновляем DataGrid
                             string errorMessage = string.Join("\n", validationResults.Select(r => r.ErrorMessage));
                             MessageBox.Show($"Неправильный элемент.\n{errorMessage}");
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
                 *//*transaction.Dispose();
                 db.Dispose();*//*
             }
         }*/

        private void OnSaveChanges(object obj)
        {
            using var transaction = db.Database.BeginTransaction();
            
                try
                {
                    if (PageIndex == 0)
                    {
                        var changedCourse = selItem as Course;
                        var entity = db.Courses.FirstOrDefault(e => e.CourseID == changedCourse.CourseID);

                        if (entity != null)
                        {
                            entity = changedCourse;
                            db.SaveChanges();
                        }
                    }
                    else
                    {
                        var changedUser = selItem as User;
                        var entity = db.Users.FirstOrDefault(e => e.UserId == changedUser.UserId);

                        if (entity != null)
                        {
                            entity = changedUser;
                            db.SaveChanges();
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
                    /*transaction.Dispose();
                    db.Dispose();*/
                }
            
                
        }

        
        
        private void OnSelectionSearchByChanged(object ob)
        {
            using var transaction = db.Database.BeginTransaction();
            
                try
                {
                    string entity = PageIndex == 0 ? "Courses" : "Users";
                    string secParam = PageIndex == 0 ? "Description" : "Surname";
                    string sqlSearch = "";
                    switch (SelectedSeacrhIndex)
                    {
                        case 0:
                            sqlSearch = $"select * from {entity} where Name like '%{SearchText}%';";
                            break;
                        case 1:
                            sqlSearch = $"select * from {entity} where {secParam} like '%{SearchText}%';";
                            break;
                        case 2:
                            sqlSearch = $"select * from {entity} where Name like '%{SearchText}%' or {secParam} like '%{SearchText}%';";
                            break;
                    }

                    //var searchResults = db.Courses.Where(e => String.Sub).ToList();

                    if (PageIndex == 0)
                    {
                        var searchResults = db.Courses.FromSqlRaw(sqlSearch).ToList();
                        CoursesDT = new ObservableCollection<Course>(searchResults);

                    }
                    else
                    {
                        var searchResults = db.Users.FromSqlRaw(sqlSearch).ToList();
                        UsersDT = new ObservableCollection<User>(searchResults);
                    }
                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                }
                finally
                {
                    /* transaction.Dispose();
                     db.Dispose();*/
                }
            
                


        }

        public BCommand AddingItemCommand { get; }
        public BCommand DeleteItemCommand { get; }
        public BCommand AddUserToCourseCommand { get; }
        public BCommand AddCourseToUserCommand { get; }
        public BCommand DeleteUserFromCourseCommand { get; }
        public BCommand DeleteCourseFromUserCommand { get; }
        public BCommand CourseSelectionChCommand {  get; }
        public BCommand SaveChangesCommand {  get; }
        public BCommand OnSelectionSearchByChangedCommand { get; }
       
        #endregion

        private async void LoadData()
        {
            await db.Courses.Include(c => c.Users).LoadAsync();
            CoursesDT = db.Courses.Local.ToObservableCollection();
            await db.Users.Include(c => c.Courses).LoadAsync();
            /*await Application.Current.Dispatcher.InvokeAsync(() =>
            {
                db.Users.Include(c => c.Courses).Load();
            });*/
            UsersDT = db.Users.Local.ToObservableCollection();
        }

        public MainViewModel()
        {
            LoadData();
            AddingItemCommand = new BCommand(OnAddingElementCommandExecuted, (obj) => selItem != null);
            DeleteItemCommand = new BCommand(OnDeleteItemCommandExecuted, (obj) => selItem!=null);
            AddUserToCourseCommand = new BCommand(AddUserToCourse, (obj) => selItem != null && SelUserForCourse != null);
            CourseSelectionChCommand = new BCommand(OnSelectionCh, (obj) => selItem != null);
            SaveChangesCommand = new BCommand(OnSaveChanges, (obj) => selItem != null);
            OnSelectionSearchByChangedCommand = new BCommand(OnSelectionSearchByChanged, (obj) => SelectedSeacrhIndex != -1);
            AddCourseToUserCommand = new BCommand(AddCourseToUser, (obj) => selItem != null && SelCourseForUser != null);
            DeleteUserFromCourseCommand = new BCommand(DeleteUserFromCourse, (obj) => selItem != null && SelUserForCourse != null);
            DeleteCourseFromUserCommand = new BCommand(DeleteCourseFromUser, (obj) => selItem != null && SelCourseForUser != null);

        }
    }
}
