using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace Lab2
{
    [Serializable]
    public enum Format
    {
        PDF,
        TXT,
        FB2,
        EPUB
    }
    public class FileBook
    {
        public Format Format { get; set; }
        public int Size { get; set; }
        public string SizeFormat {  get; set; }

        [StringLength(30, MinimumLength = 3, ErrorMessage = "Недопустимая длина для имени!")]
        public string Name { get; set; }
        //[RegularExpression("[0-9]{1,3}[.][0-9]{1,3}", ErrorMessage = "UDC неверен!")]
        [UDCAttribute(ErrorMessage = "UDC неверен!")]
        public string UDK { get; set; }
        public int NumOfPages { get; set; }
        [Range(1, 120, ErrorMessage = "Недопустимое количество глав!")]
        public int NumOfChapters { get; set; }
        [Range(1455, 2024, ErrorMessage = "Неверный год!")]
        public int Year { get; set; }
        [Range(1455, 2024, ErrorMessage = "Неверный год!")]
        public int DataUpload {  get; set; }
        [RegularExpression("^[a-zA-Zа-яА-Я]{3,30}$", ErrorMessage = "Недопустимая длина в поле издателя!")]
        public string Publisher { get; set; }
        public bool Pay { get; set; }
        public List<Author> Authors { get; set; }

        public FileBook(FileBook book)
        {
            Format = book.Format;
            Size = book.Size;
            SizeFormat = book.SizeFormat;
            Name = book.Name;
            UDK = book.UDK;
            NumOfPages = book.NumOfPages;
            NumOfChapters = book.NumOfChapters;
            Year = book.Year;
            DataUpload = book.DataUpload;
            Publisher = book.Publisher;
            Pay = book.Pay;
            Authors = book.Authors;
        }
        public FileBook() 
        {
            Name = "";
            Publisher = "";
            SizeFormat = "";
            Size = 0;
            NumOfPages = 0;
            NumOfChapters = 0;
            UDK = "";
            Format = Format.FB2;
            Pay = false;
            Year = DateTime.Now.Year;
            DataUpload = DateTime.Now.Year;
        }

        public override string ToString()
        {
            string pay = "";
            string result = "";
            if (Pay)
            {
                pay = "Бесплатно";
            }
            else
            {
                pay = "Платно";
            }
            result = $"Name: {Name}, Publisher: {Publisher}, Year: {Year}, Format: {Format}, Size: {Size}, NumOfPages: {NumOfPages}," +
                $" DataUpload: {DataUpload}, SizeFormat: {SizeFormat}, UDK: {UDK}, NumOfChapters: {NumOfChapters}, Pay: {pay}, ";

            foreach (Author author in Authors)
            {
                result += author.ToString();
            }

            return result;
        }
    }
}