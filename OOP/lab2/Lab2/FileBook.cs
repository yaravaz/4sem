using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        public string Name { get; set; }
        public string UDK { get; set; }
        public int NumOfPages { get; set; }
        public int NumOfChapters { get; set; }
        public int Year { get; set; }
        public string Publisher { get; set; }
        public bool Pay { get; set; }
        public List<Author> Authors { get; set; }

        public FileBook(Format format, int size, string sizeFormat, string name, string udk, int numofpages,int numofchapters, int year, string publisher, bool pay, List<Author> list)
        {
            Format = format;
            Size = size;
            SizeFormat = sizeFormat;
            Name = name;
            UDK = udk;
            NumOfPages = numofpages;
            NumOfChapters = numofchapters;
            Year = year;
            Publisher = publisher;
            Pay = pay;
            Authors = list;
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
            result = $"Format: {Format}, Size: {Size}, SizeFormat: {SizeFormat}, Name: {Name}, UDK: {UDK}," +
                $" Year: {Year}, NumOfPages: {NumOfPages}, NumOfChapters: {NumOfChapters}, Publisher: {Publisher}, Pay: {pay}, ";

            foreach (Author author in Authors)
            {
                result += author.ToString();
            }

            return result;
        }
    }
}