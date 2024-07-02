using lab4_5.Cursors;
using lab4_5.Properties;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace lab4_5
{
    /// <summary>
    /// Логика взаимодействия для goodPage.xaml
    /// </summary>
    public partial class goodPage : Window
    {
        private Book book;
        private string img;
        private RatingControl _ratingControl = new RatingControl();


        public goodPage()
        {
            InitializeComponent();
            EditBtn.Visibility = Visibility.Collapsed;
            AddBtn.Visibility = Visibility.Visible;
            Cursor = CursorCollection.GetCursor();
            _ratingControl = ratingControl;
            
        }

        public goodPage(Book book)
        {
            InitializeComponent();
            EditBtn.Visibility = Visibility.Visible;
            AddBtn.Visibility = Visibility.Collapsed;
            Cursor = CursorCollection.GetCursor();

            nameField.Text = book.PName;
            authorField.Text = book.PAuthor;
            descriptionField.Text = book.PDescription;
            priceField.Text = book.Price.ToString();
            ratingControl.ratingField.Text = book.Rating.ToString();
            categoryField.Text = book.BookCategory.ToString();

            string selection = "genre" + book.BookGenre;

            BookGenre.SelectedItem = BookGenre.Items.GetItemAt(book.BookGenre - 1);

            var projectPath = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName;

            var source = new BitmapImage(new Uri(projectPath + "\\lab4-5\\images\\" + book.PImage));
            ImageBrush imgBrush = new ImageBrush(source);

            image.Fill = imgBrush;
            image.Stroke = Brushes.Transparent;
            this.book = book;
        }

        private void Close(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void AddImage(object sender, RoutedEventArgs e)
        {
            var filePicker = new OpenFileDialog();

            filePicker.DefaultExt = ".jpg";
            filePicker.Filter = "JPG Files (*.jpg)|*.jpg|JPEG Files (*.jpeg)|*.jpeg|PNG Files (*.png)|*.png";

            bool? result = filePicker.ShowDialog();

            if (result == true)
            {
                string filePath = filePicker.FileName;

                string[] parts = filePath.Split('\\');

                string fileName = parts[parts.Length - 1];
                img = fileName;

                var projectPath = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName;

                var source = new BitmapImage(new Uri(projectPath + "\\lab4-5\\images\\" + fileName));
                ImageBrush imgBrush = new ImageBrush(source);

                image.Fill = imgBrush;
                image.Stroke = Brushes.Transparent;
            }
        }

        private void EditBookInfo(object sender, RoutedEventArgs e)
        {
            try
            {
                var item = BookInfo.books.First(o => o.ProductCode == book.ProductCode);

                item.PName = nameField.Text;
                item.PAuthor = authorField.Text;
                item.PDescription = descriptionField.Text;
                item.BookCategory = categoryField.SelectedValue.ToString();
                if (priceField.Text.Length != 0)
                {
                    try
                    {
                        item.Price = double.Parse(priceField.Text);
                    }
                    catch (FormatException)
                    {
                        throw new FormatException("WrongBookPrice");
                    }
                }
                else
                    throw new ArgumentException("WrongBookPrice");
                if (ratingControl.ratingField.Text.Length != 0)
                {
                    try
                    {
                        item.Rating = double.Parse(ratingControl.ratingField.Text);
                    }
                    catch (FormatException)
                    {
                        throw new FormatException("WrongBookRating");
                    }
                }
                else
                    throw new ArgumentException("WrongBookRating");

                item.BookGenre = BookGenre.SelectedIndex + 1;
                ListBoxItem selectedItem = (ListBoxItem)BookGenre.SelectedItem;
                book.BookGenreValue = selectedItem.Content.ToString();
                if (img != null)
                    item.PImage = img;

                var results = new List<System.ComponentModel.DataAnnotations.ValidationResult>();
                var context = new ValidationContext(item);
                if (!Validator.TryValidateObject(item, context, results, true))
                    new Message(results.First().ToString()).ShowDialog();
                else
                {
                    new Message("Success").ShowDialog();
                    Close();
                }
            }
            catch (ArgumentException ex)
            {
                new Message(ex.Message).ShowDialog();
            }
            catch (FormatException ex)
            {
                new Message(ex.Message).ShowDialog();
            }
        }

        private void AddProduct(object sender, RoutedEventArgs e)
        {
            try
            {
                book = new Book();
                int code;
                if(BookInfo.books.Count == 0)
                {
                    code = 1;
                }
                else
                {
                    code = BookInfo.books.Last().ProductCode + 1;
                }

                book.ProductCode = code;
                book.PName = nameField.Text;
                book.PAuthor = authorField.Text;
                book.PDescription = descriptionField.Text;                
                if (categoryField.SelectedValue != null)
                {
                    try
                    {
                        book.BookCategory = categoryField.SelectedValue.ToString();
                    }
                    catch (FormatException)
                    {
                        throw new FormatException("WrongBookCategory");
                    }
                }
                else
                {
                    throw new ArgumentException("WrongBookCategory");
                }
                if (priceField.Text.Length != 0)
                {
                    try
                    {
                        book.Price = double.Parse(priceField.Text);
                    }
                    catch (FormatException)
                    {
                        throw new FormatException("WrongBookPrice");
                    }
                }
                else
                    throw new ArgumentException("WrongBookPrice");
                if (ratingControl.ratingField.Text.Length != 0)
                {
                    try
                    {
                        book.Rating = double.Parse(ratingControl.ratingField.Text);
                    }
                    catch (FormatException)
                    {
                        throw new FormatException("WrongBookRating");
                    }
                }
                else
                    throw new ArgumentException("WrongBookRating");
                book.BookGenre = BookGenre.SelectedIndex + 1;
                ListBoxItem selectedItem = (ListBoxItem)BookGenre.SelectedItem;
                book.BookGenreValue = selectedItem.Content.ToString();
                if (img != null)
                    book.PImage = img;
                else
                    throw new ArgumentException("WrongImageSource");

                book.isActive = 1;
                var results = new List<System.ComponentModel.DataAnnotations.ValidationResult>();
                var context = new ValidationContext(book);
                if (!Validator.TryValidateObject(book, context, results, true))
                    new Message(results.First().ToString()).ShowDialog();
                else
                {
                    BookInfo.books.Add(book);
                    new Message("Success").ShowDialog();

                    book.PropertyChanged += BookInfo.BookChanged;
                    Close();
                }
            }
            catch (ArgumentException ex)
            {
                new Message(ex.Message).ShowDialog();
            }
            catch (FormatException ex)
            {
                new Message(ex.Message).ShowDialog();
            }
        }
        
    }
}
