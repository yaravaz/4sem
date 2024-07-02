using lab4_5.Cursors;
using System;
using System.Collections.Generic;
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
    /// Логика взаимодействия для Message.xaml
    /// </summary>
    public partial class Message : Window
    {
        public Message(string errorMessage)
        {
            InitializeComponent();
            Cursor = CursorCollection.GetCursor();
            switch (errorMessage)
            {
                case "WrongBookName":
                    MessageContainer.Text = "ErrorBookName";
                    break;
                case "WrongBookAuthor":
                    MessageContainer.Text = "ErrorBookAuthor";
                    break;
                case "WrongBookCategory":
                    MessageContainer.Text = "ErrorBookCategory";
                    break;
                case "WrongBookPrice":
                    MessageContainer.Text = "ErrorBookPrice";
                    break;
                case "WrongBookRating":
                    MessageContainer.Text = "ErrorBookRating";
                    break;
                case "WrongBookGenre":
                    MessageContainer.Text = "ErrorBookGenre";
                    break;
                case "WrongImageSource":
                    MessageContainer.Text = "ErrorProductImage";
                    break;
                case "Success":
                    MessageContainer.Text = "Success";
                    break;
                default:
                    MessageContainer.Text = errorMessage;
                    break;  
            }
        }

        private void OKButton(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
