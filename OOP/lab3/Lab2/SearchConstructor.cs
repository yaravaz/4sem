using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab2
{
    public partial class SearchConstructor : Form
    {
        private Form1 form;
        public SearchConstructor(Form1 form1)
        {
            InitializeComponent();

            form = form1;
        }

        private void SearchConstructorButton_Click(object sender, EventArgs e)
        {
            try
            {
                List<FileBook> books = form.GetBooks();
                List<FileBook> selectedBooks = new List<FileBook>();

                if (textBoxSearchName.Text != "")
                {
                    string pattern = $".*{Regex.Escape(textBoxSearchName.Text)}.*";

                    Regex regex = new Regex(pattern, RegexOptions.IgnoreCase);

                    foreach (var str in books)
                    {
                        Match match = regex.Match(str.Name);
                        if (match.Length > 0)
                        {
                            selectedBooks.Add(str);
                        }

                    }

                    books = selectedBooks;
                    selectedBooks = new List<FileBook>();

                }

                if (textBoxPublisherSearch.Text != "")
                {
                    string pattern = $".*{Regex.Escape(textBoxPublisherSearch.Text)}.*";

                    Regex regex = new Regex(pattern, RegexOptions.IgnoreCase);

                    foreach (var str in books)
                    {
                        Match match = regex.Match(str.Publisher);
                        if (match.Length > 0)
                        {
                            selectedBooks.Add(str);
                        }

                    }

                    books = selectedBooks;
                    selectedBooks = new List<FileBook>();
                }

                if (textBoxFrom.Text != "")
                {
                    int pageAmount = Convert.ToInt32(textBoxFrom.Text);

                    books = books
                            .Where(book => book.NumOfPages >= pageAmount)
                            .ToList();
                }
                if (textBoxTo.Text != "")
                {
                    int pageAmount = Convert.ToInt32(textBoxTo.Text);

                    books = books
                            .Where(book => book.NumOfPages <= pageAmount)
                            .ToList();
                }

                if (textBoxFrom2.Text != "")
                {
                    int chapters = Convert.ToInt32(textBoxFrom2.Text);

                    books = books
                            .Where(book => book.NumOfChapters >= chapters)
                            .ToList();
                }
                if (textBoxTo2.Text != "")
                {
                    int chapters = Convert.ToInt32(textBoxTo2.Text);

                    books = books
                            .Where(book => book.NumOfChapters <= chapters)
                            .ToList();
                }

                form.SetBooks(books);

                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
                Close();
            }
        }
    }
}
