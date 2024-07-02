using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace lab4_5
{
    public partial class Book : INotifyPropertyChanged
    {
        private int _productCode;
        private string _pName;
        private string _pAuthor;
        private double _price;
        private double _rating;
        private string _pImage;
        private string _PDescription;
        private short _isActive;
        private int _bookGenre;
        private string _bookCategory;

        public string BookGenreValue {  get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void RaisePropertyChangedEvent(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChangedEventArgs e = new PropertyChangedEventArgs(propertyName);
                PropertyChanged(this, e);
            }
        }

        public Book()
        {
        }

        [Key]
        public int ProductCode
        {
            get
            {
                return _productCode;
            }
            set
            {
                _productCode = value;
                RaisePropertyChangedEvent("BookCode");
            }
        }

        [Required(ErrorMessage = "WrongBookName")]
        [StringLength(45, ErrorMessage = "WrongBookName")]
        public string PName
        {
            get
            {
                return _pName;
            }
            set
            {
                _pName = value;
                RaisePropertyChangedEvent("PName");
            }
        }

        [Required(ErrorMessage = "WrongBookAuthor")]
        [RegularExpression(@"[A-Za-zА-Яа-я\s\-]{2,45}", ErrorMessage = "WrongBookAuthor")]
        public string PAuthor
        {
            get
            {
                return _pAuthor;
            }
            set
            {
                _pAuthor = value;
                RaisePropertyChangedEvent("PAuthor");
            }
        }

        [Range(1, 10000, ErrorMessage = "WrongBookPrice")]
        public double Price
        {
            get
            {
                return _price;
            }
            set
            {
                _price = value;
                RaisePropertyChangedEvent("BookPrice");
            }
        }
        [Range(1, 5, ErrorMessage = "WrongBookRating")]
        public double Rating
        {
            get
            {
                return _rating;
            }
            set
            {
                _rating = value;
                RaisePropertyChangedEvent("Rating");
            }
        }

        [StringLength(150, ErrorMessage = "WrongImageSource")]
        public string PImage
        {
            get
            {
                return _pImage;
            }
            set
            {
                _pImage = value;
                RaisePropertyChangedEvent("PImage");
            }
        }

        [StringLength(500)]
        public string PDescription
        {
            get
            {
                return _PDescription;
            }
            set
            {
                _PDescription = value;
                RaisePropertyChangedEvent("PDescription");
            }
        }

        public short isActive
        {
            get
            {
                return _isActive;
            }
            set
            {
                _isActive = value;
                RaisePropertyChangedEvent("isActive");
            }
        }
        [Range(1, 5, ErrorMessage = "WrongBookGenre")]
        public int BookGenre
        {
            get
            {
                return _bookGenre;
            }
            set
            {
                _bookGenre = value;
                RaisePropertyChangedEvent("BookGenre");
            }
        }

        [StringLength(45, ErrorMessage = "WrongBookCategory")]
        public string BookCategory
        {
            get
            {
                return _bookCategory;
            }
            set
            {
                _bookCategory = value;
                RaisePropertyChangedEvent("BookCategory");
            }
        }

        public virtual BookGenre bookGenre { get; set; }
    }
}
