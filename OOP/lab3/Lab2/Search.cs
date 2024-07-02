using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlTypes;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab2
{
    public partial class Search : Form
    {
        protected Form1 form1;

        public Search(Form1 form)
        {
            InitializeComponent();

            searchByLabel.Text = "Поиск по имени";

            form1 = form;
        }

        protected virtual void searchButton_Click(object sender, EventArgs e)
        {
            List<FileBook> books = form1.GetBooks();
            List<FileBook> selectedBooks = new List<FileBook>();

            string pattern = $".*{Regex.Escape(textBoxSearch.Text)}.*";

            Regex regex = new Regex(pattern, RegexOptions.IgnoreCase);

            foreach (var str in books)
            {
                Match match = regex.Match(str.Name);
                if(match.Length > 0)
                {
                    selectedBooks.Add(str);
                }

            }

            form1.SetBooks(selectedBooks);

            Close();
        }
    }

    public partial class SearchByPublisher : Search
    {
        public SearchByPublisher(Form1 form) : base(form)
        {
            searchByLabel.Text = "Поиск по издательству";
        }

        protected override void searchButton_Click(object sender, EventArgs e)
        {
            List<FileBook> books = form1.GetBooks();
            List<FileBook> selectedBooks = new List<FileBook>();

            string pattern = $".*{Regex.Escape(textBoxSearch.Text)}.*";

            Regex regex = new Regex(pattern, RegexOptions.IgnoreCase);

            foreach (var str in books)
            {
                Match match = regex.Match(str.Publisher);
                if (match.Length > 0)
                {
                    selectedBooks.Add(str);
                }

            }

            form1.SetBooks(selectedBooks);

            Close();
        }
    }

    public partial class SearchByYear : Search
    {
        public SearchByYear(Form1 form) : base(form)
        {
            searchByLabel.Text = "Поиск по году";
        }

        protected override void searchButton_Click(object sender, EventArgs e)
        {
            List<FileBook> books = form1.GetBooks();
            List<FileBook> selectedBooks = new List<FileBook>();

            foreach(var str in books)
            {
                if(int.Parse(textBoxSearch.Text) == str.Year)
                {
                    selectedBooks.Add(str);
                }
            }
            
            form1.SetBooks(selectedBooks);

            Close();
        }
    }

    public partial class SearchByPage : Search
    {
        public SearchByPage(Form1 form) : base(form)
        {
            searchByLabel.Text = "Поиск по количеству страниц";
        }

        protected override void searchButton_Click(object sender, EventArgs e)
        {
            List<FileBook> books = form1.GetBooks();
            List<FileBook> selectedBooks = new List<FileBook>();

            foreach (var str in books)
            {
                if (int.Parse(textBoxSearch.Text) == str.NumOfPages)
                {
                    selectedBooks.Add(str);
                }
            }

            form1.SetBooks(selectedBooks);

            Close();
        }
    }
}
