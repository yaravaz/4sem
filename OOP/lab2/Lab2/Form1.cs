using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace Lab2
{
    public partial class Form1 : Form
    {
        private readonly AuthorsForm _authorsForm = new AuthorsForm();
        
        public Form1()
        {
            InitializeComponent();
            _authorsForm.Hide();
        }

        private void authors_Click(object sender, EventArgs e)
        {
            _authorsForm.ShowDialog();
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            if(listBoxInfo.Items.Count == 0)
            {
                MessageBox.Show("Невозможно сохранить");
                return;
            }
            var BookFilesList = (from object item in listBoxInfo.Items select item as FileBook).ToList();

            using (var reader = new StreamWriter(@"D:\лабы\ООП\lab2\Lab2\JSON\Lab2.json"))
            {
                string jsonString = JsonConvert.SerializeObject(BookFilesList);
                reader.Write(jsonString);
            }
        }

        private void buttonLoad_Click(object sender, EventArgs e)
        {
            listBoxInfo.Items.Clear();
            var BookFilesList = new List<FileBook>();
            using (var reader = new StreamReader(@"D:\лабы\ООП\lab2\Lab2\JSON\Lab2.json"))
            {
                BookFilesList = JsonConvert.DeserializeObject<List<FileBook>>(reader.ReadToEnd());
            }

            foreach (var bookFile in BookFilesList)
                listBoxInfo.Items.Add(bookFile);
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            if (_authorsForm.CurrentAuthorsList == null) return;            

            var name = "";
            var publisher = "";
            var sizeFormat = "";
            var size = 0;
            var numberOfPages = 0;
            var numberOfChapters = 0;
            var udk = "";
            var format = Format.FB2;
            var pay = false;
            int year = DateTime.Now.Year;

            try
            {
                if (Controls.OfType<RadioButton>().Any(r => r.Checked) == false || textBoxName.Text == "" || 
                    SizeComboBox.SelectedIndex == -1 || textBoxSize.Text == "" || textBoxNumberOfPages.Text == "" || 
                    numericUpDownChapters.Text == "0" || textBoxUDK.Text == "" || textBoxPublisher.Text == "")
                    throw new Exception("Заполните поля!");
                if (textBoxName.Text.Length > 30 || textBoxSize.Text.Length > 30 || textBoxNumberOfPages.Text.Length > 30 ||
                    textBoxUDK.Text.Length > 30 || textBoxPublisher.Text.Length > 30)
                    throw new Exception("Превышен размер входных данных");

                name = textBoxName.Text;
                publisher = textBoxPublisher.Text;
                size = int.Parse(textBoxSize.Text);
                sizeFormat = SizeComboBox.Text;
                numberOfPages = int.Parse(textBoxNumberOfPages.Text);
                numberOfChapters = int.Parse(numericUpDownChapters.Text);
                pay = checkBoxPay.Checked;
                udk = textBoxUDK.Text;
                year = dateTimePicker.Value.Year;

                var checkedRadioButton = Controls.OfType<RadioButton>().First(r => r.Checked);
                switch (checkedRadioButton.Name)
                {
                    case "radioButtonPDF":
                        format = Format.PDF;
                        break;
                    case "radioButtonTXT":
                        format = Format.TXT;
                        break;
                    case "radioButtonFB2":
                        format = Format.FB2;
                        break;
                    case "radioButtonEPUB":
                        format = Format.EPUB;
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
            var authorsList = new List<Author>(_authorsForm.CurrentAuthorsList);
            var bookFile = new FileBook(format, size, sizeFormat, name, udk, numberOfPages, numberOfChapters, year, publisher, pay, authorsList);
            listBoxInfo.Items.Add(bookFile);

            _authorsForm.Clear();

        }

        private void textBoxSize_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar) || e.KeyChar == 8) return;
            e.Handled = true;
        }

        private void textBoxUDK_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar) || e.KeyChar == 8) return;
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

        private void clearButton_Click(object sender, EventArgs e)
        {
            listBoxInfo.Items.Clear();
        }
    }
}