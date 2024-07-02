using lab4_5.Cursors;
using lab4_5.Properties;
using System;
using System.Collections.Generic;
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
    /// Логика взаимодействия для Details.xaml
    /// </summary>
    public partial class Details : Window
    {
        public Details(Book book)
        {
            InitializeComponent();
            Cursor = CursorCollection.GetCursor();
            var projectPath = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName;
            var source = new BitmapImage(new Uri(projectPath + "\\lab4-5\\images\\" + book.PImage));
            BookImage.Source = source;
            BookName.Text = book.PName;
            BookAuthor.Text = book.PAuthor;
            Price.Text = book.Price.ToString() + " BYN";
            Rating.Text = "\u2605 " + book.Rating.ToString();
            BookDescription.Text = book.PDescription;
            BookCategory.Text = book.BookCategory.ToString();
            BookGenre.Text = book.BookGenreValue;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
