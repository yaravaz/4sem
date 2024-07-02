using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.Json;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;


namespace Lab2
{
    public partial class Form1 : Form
    {
        private readonly AuthorsForm _authorsForm = new AuthorsForm();
        private List<FileBook> _books;
        private List<FileBook> _selectedBooks;
        private List<FileBook> _prevPosition;
        private List<FileBook> _nextPosition;
        private Timer timer;
        
        public Form1(FileBook boook)
        {
            InitializeComponent();
            try
            {
                _authorsForm.Hide();

                using (var reader = new StreamReader(@"D:\лабы\ООП\lab3\Lab2\JSON\Lab3.json"))
                {
                    _books = JsonSerializer.Deserialize<List<FileBook>>(reader.ReadToEnd());
                }

                _selectedBooks = _books;

                foreach(var filebook in _books)
                {
                    listBoxInfo.Items.Add(filebook);
                }

                ObjectCountLabel.Text = "Количество объектов: " + listBoxInfo.Items.Count.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

            timer = new Timer();
            timer.Interval = 1000;
            timer.Tick += Timer_Tick;
            timer.Start();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            TimeLabel.Text = DateTime.Now.ToString("HH:mm:ss dd.MM.yyyy");
        }

        private void authors_Click(object sender, EventArgs e)
        {
            _authorsForm.ShowDialog();
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (_authorsForm.CurrentAuthorsList == null) return;

            FileBook book = new FileBook();

            try
            {
                if (Controls.OfType<RadioButton>().Any(r => r.Checked) == false || textBoxName.Text == "" || 
                    SizeComboBox.SelectedIndex == -1 || textBoxSize.Text == "" || textBoxNumberOfPages.Text == "" || 
                    numericUpDownChapters.Text == "0" || textBoxUDK.Text == "" || textBoxPublisher.Text == "" || textBoxYear.Text == "")
                    throw new Exception("Заполните поля!");

                book.Name = textBoxName.Text;
                book.Publisher = textBoxPublisher.Text;
                book.Size = int.Parse(textBoxSize.Text);
                book.SizeFormat = SizeComboBox.Text;
                book.NumOfPages = int.Parse(textBoxNumberOfPages.Text);
                book.NumOfChapters = int.Parse(numericUpDownChapters.Text);
                book.Pay = checkBoxPay.Checked;
                book.UDK = textBoxUDK.Text;
                book.Year = int.Parse(textBoxYear.Text);
                book.DataUpload = dateTimePicker.Value.Year;

                var checkedRadioButton = Controls.OfType<RadioButton>().First(r => r.Checked);
                switch (checkedRadioButton.Name)
                {
                    case "radioButtonPDF":
                        book.Format = Format.PDF;
                        break;
                    case "radioButtonTXT":
                        book.Format = Format.TXT;
                        break;
                    case "radioButtonFB2":
                        book.Format = Format.FB2;
                        break;
                    case "radioButtonEPUB":
                        book.Format = Format.EPUB;
                        break;
                }
            }
            catch (OverflowException)
            {
                MessageBox.Show("Числа великоваты");
                return;
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
                return;
            }

            if (_authorsForm.textBoxName.Text == "" && _authorsForm.textBoxCountry.Text == "" && _authorsForm.textBoxID.Text == "")
            {
                MessageBox.Show("Пожалуйста, заполните информацию об авторе!");
                return;
            }
            book.Authors = new List<Author>(_authorsForm.CurrentAuthorsList);

            try
            {
                var context = new ValidationContext(book);
                var results = new List<ValidationResult>();
                if (!Validator.TryValidateObject(book, context, results, true))
                {
                    foreach (var error in results)
                    {
                        throw new Exception(error.ErrorMessage);
                    }
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
                return;
            }


            var bookFile = new FileBook(book);
            _books.Add(book);

            LastMoveLabel.Text = "Действие: добавление";

            listBoxInfo.Items.Clear();

            foreach (var filebook in _books)
            {
                listBoxInfo.Items.Add(filebook);
            }

            ObjectCountLabel.Text = "Количество объектов: " + listBoxInfo.Items.Count.ToString();

            WriteToJson();

            _authorsForm.Clear();
            ClearFrom();
        }

        public void ClearFrom()
        {
            textBoxName.Text = string.Empty;
            textBoxPublisher.Text = string.Empty;
            textBoxNumberOfPages.Text = string.Empty;
            textBoxSize.Text = string.Empty;
            textBoxUDK.Text = string.Empty;
            textBoxYear.Text = string.Empty;
            dateTimePicker.Checked = false;
            numericUpDownChapters.Value = 0;
            SizeComboBox.SelectedIndex = -1;
            radioButtonEPUB.Checked = false;
            radioButtonFB2.Checked = false;
            radioButtonPDF.Checked = false;
            radioButtonTXT.Checked = false;
            checkBoxPay.Checked = false;
        }

        private void UpdateBookList()
        {
            listBoxInfo.Items.Clear();

            foreach (var filebook in _selectedBooks)
            {
                listBoxInfo.Items.Add(filebook);
            }

            ObjectCountLabel.Text = "Количество объектов: " + listBoxInfo.Items.Count.ToString();
        }

        public void SetBooks(List<FileBook> books)
        {
            _selectedBooks = books;
            UpdateBookList();
        }
        public List<FileBook> GetBooks()
        {
            return _books;
        }

        public void WriteToJson()
        {
            var BookFilesList = (from object item in listBoxInfo.Items select item as FileBook).ToList();

            using (var reader = new StreamWriter(@"D:\лабы\ООП\lab3\Lab2\JSON\Lab3.json"))
            {
                string jsonString = JsonSerializer.Serialize(BookFilesList);
                reader.Write(jsonString);
            }
        }

        private void textBoxSize_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar) || e.KeyChar == 8) return;
            e.Handled = true;
        }

        private void textBoxUDK_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar) || e.KeyChar == 8 || e.KeyChar == '.') return;
            e.Handled = true;
        }

        private void textBoxNumberOfPages_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar) || e.KeyChar == 8) return;
            e.Handled = true;
        }

        private void textBoxPublisher_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsLetter(e.KeyChar) || e.KeyChar == 8 || e.KeyChar == 32) return;
            e.Handled = true;
        }

        private void textBoxYear_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar) || e.KeyChar == 8) return;
            e.Handled = true;
        }

        private void ByNameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _prevPosition = (from object item in listBoxInfo.Items select item as FileBook).ToList();
            _nextPosition = null;

            Search search = new Search(this);
            search.Show();

            LastMoveLabel.Text = "Действие: поиск(имя)";
        }

        private void byPublisherToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _prevPosition = (from object item in listBoxInfo.Items select item as FileBook).ToList();
            _nextPosition = null;

            SearchByPublisher search = new SearchByPublisher(this);
            search.Show();

            LastMoveLabel.Text = "Действие: поиск(издатель)";
        }

        private void ByYearToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _prevPosition = (from object item in listBoxInfo.Items select item as FileBook).ToList();
            _nextPosition = null;

            SearchByYear search = new SearchByYear(this);
            search.Show();

            LastMoveLabel.Text = "Действие: поиск(год)";
        }

        private void ByPageAmountToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _prevPosition = (from object item in listBoxInfo.Items select item as FileBook).ToList();
            _nextPosition = null;

            SearchByPage search = new SearchByPage(this);
            search.Show();

            LastMoveLabel.Text = "Действие: поиск(кол-во страниц)";
        }

        private void BySelectorsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _prevPosition = (from object item in listBoxInfo.Items select item as FileBook).ToList();
            _nextPosition = null;

            SearchConstructor search = new SearchConstructor(this);
            search.Show();

            LastMoveLabel.Text = "Действие: поиск(конструктор)";
        }

        private void NameSortToolStripMenuIte_Click(object sender, EventArgs e)
        {
            _prevPosition = (from object item in listBoxInfo.Items select item as FileBook).ToList();
            _nextPosition = null;

            if (_selectedBooks.Count == 0)
            {
                _selectedBooks = _books;
            }

            _selectedBooks = _selectedBooks.OrderBy(book => book.Name).ToList();
            UpdateBookList();

            LastMoveLabel.Text = "Действие: сортировка(имя)";
        }

        private void YearSortToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _prevPosition = (from object item in listBoxInfo.Items select item as FileBook).ToList();
            _nextPosition = null;

            if (_selectedBooks.Count == 0)
            {
                _selectedBooks = _books;
            }
            _selectedBooks = _selectedBooks.OrderBy(book => book.Year).ToList();
            UpdateBookList();

            LastMoveLabel.Text = "Действие: сортировка(год)";
        }

        private void PageAmountSortToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _prevPosition = (from object item in listBoxInfo.Items select item as FileBook).ToList();
            _nextPosition = null;

            if (_selectedBooks.Count == 0)
            {
                _selectedBooks = _books;
            }
            _selectedBooks = _selectedBooks.OrderBy(book => book.NumOfPages).ToList();
            UpdateBookList();

            LastMoveLabel.Text = "Действие: сортировка(кол-во страниц)";
        }

        private void SaveSortedToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                string booksJSON = JsonSerializer.Serialize(_selectedBooks);
                File.WriteAllText(@"D:\лабы\ООП\lab3\Lab2\JSON\Lab3_2.json", booksJSON);

                MessageBox.Show("Сохранение прошло успешно", "Сохранение");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }

            LastMoveLabel.Text = "Действие: сохранение";
        }

        private void InfoAboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Разработано Вовна Ярославой, V. 1.2.2", "О программе");

            LastMoveLabel.Text = "Действие: информация о программе";
        }

        private void showToolPanelButton_Click(object sender, EventArgs e)
        {
            toolStrip.Show();
            showToolPanelButton.Hide();

            LastMoveLabel.Text = "Действие: показать панель";
        }

        private void HideToolStripButton_Click(object sender, EventArgs e)
        {
            toolStrip.Hide();
            showToolPanelButton.Show();

            LastMoveLabel.Text = "Действие: спрятать панель";
        }

        private void ClearToolStripButton_Click(object sender, EventArgs e)
        {

            using (var reader = new StreamReader(@"D:\лабы\ООП\lab3\Lab2\JSON\Lab3.json"))
            {
                _books = JsonSerializer.Deserialize<List<FileBook>>(reader.ReadToEnd());
            }

            listBoxInfo.Items.Clear();

            _selectedBooks.Clear();

            foreach (var filebook in _books)
            {
                listBoxInfo.Items.Add(filebook);
            }

            ObjectCountLabel.Text = "Количество объектов: " + listBoxInfo.Items.Count.ToString();

            LastMoveLabel.Text = "Действие: очистить фильтры";
        }

        private void DeleteToolStripButton_Click(object sender, EventArgs e)
        {

            FileBook book = listBoxInfo.SelectedItem as FileBook;
            if (_books.Contains(book))
            {
                _books.Remove(book);
            }
            if (_selectedBooks.Contains(book))
            {
                _selectedBooks.Remove(book);
            }
            listBoxInfo.Items.Remove(listBoxInfo.SelectedItem);

            WriteToJson();

            ObjectCountLabel.Text = "Количество объектов: " + listBoxInfo.Items.Count.ToString();

            LastMoveLabel.Text = "Действие: удаление объекта";
        }

        private void DownToolStripButton_Click(object sender, EventArgs e)
        {
            if(_selectedBooks.Count != 0 && _prevPosition != _selectedBooks && _prevPosition != null)
            {
                _nextPosition = _selectedBooks;
                _selectedBooks = _prevPosition;

            }

            if(_selectedBooks.Count != 0)
            {
                UpdateBookList();
            }

            LastMoveLabel.Text = "Действие: назад";
        }

        private void UpToolStripButton_Click(object sender, EventArgs e)
        {
            if(_selectedBooks.Count != 0 && _nextPosition != _selectedBooks && _nextPosition != null)
            {
                _prevPosition = _selectedBooks;
                _selectedBooks = _nextPosition;
            }

            if (_selectedBooks.Count != 0)
            {
                UpdateBookList();
            }

            LastMoveLabel.Text = "Действие: вперёд";
        }
    }
}
