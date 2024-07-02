using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.IO;
using System.Linq;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Unicode;

namespace lab4_5
{
    public static class BookInfo
    {
        public static ObservableCollection<Book> books = new ObservableCollection<Book>();

        public static ObservableCollection<BookGenre> bookGenre { get; set; }
        private static JsonSerializerOptions options = new JsonSerializerOptions() { WriteIndented = true, Encoder = JavaScriptEncoder.Create(UnicodeRanges.BasicLatin, UnicodeRanges.Cyrillic), };

        static BookInfo()
        {
            string fileName1 = @"D:\лабы\ООП\lab4-5\lab4-5\lab4-5\Data\Book.json";
            string json1 = File.ReadAllText(fileName1);
            string fileName2 = @"D:\лабы\ООП\lab4-5\lab4-5\lab4-5\Data\BookGenre.json";
            string json2 = File.ReadAllText(fileName2);
            books.CollectionChanged += BooksChanged;

            if (json1.Length != 0)
            {
                InputInfo(json1, json2);
            }
            
        }

        private static void InputInfo(string json1, string json2)
        {
            books = JsonSerializer.Deserialize<ObservableCollection<Book>>(json1, options);
            bookGenre = JsonSerializer.Deserialize<ObservableCollection<BookGenre>>(json2, options);
            foreach (Book item in books)
                item.PropertyChanged += BookChanged;
            books.CollectionChanged += BooksChanged;
        }
        public static void BooksChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.NewItems != null)
                foreach (Book item in e.NewItems)
                    item.PropertyChanged += BookChanged;

            if (e.OldItems != null)
                foreach (Book item in e.OldItems)
                    item.PropertyChanged -= BookChanged;
            string fileName1 = @"D:\лабы\ООП\lab4-5\lab4-5\lab4-5\Data\Book.json";
            string json = JsonSerializer.Serialize(books, options);
            File.WriteAllText(fileName1, json);
        }
        public static void BookChanged(object sender, PropertyChangedEventArgs e)
        {
            string fileName1 = @"D:\лабы\ООП\lab4-5\lab4-5\lab4-5\Data\Book.json";
            string json = JsonSerializer.Serialize(books, options);
            File.WriteAllText(fileName1, json);
        }
    }
}
