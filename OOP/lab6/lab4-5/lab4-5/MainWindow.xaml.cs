using lab4_5.Cursors;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Xml;

namespace lab4_5
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        goodPage goodPage = new goodPage();
                
        Book selectedItem;
        List<string> selectedAuthors = new List<string>();
        private string currentPage;
        private string key;
        private Stack<ObservableCollection<Book>> undoStates = new Stack<ObservableCollection<Book>>();
        private Stack<ObservableCollection<Book>> redoStates = new Stack<ObservableCollection<Book>>();
                
        public MainWindow()
        {
            InitializeComponent();
            ShowAll();
            Cursor = CursorCollection.GetCursor();
            Settings.changeLang += ChangeLang;
            Settings.changeTheme += ChangeTheme;
        }

        private void ToRussian()
        {
            Application.Current.Resources.MergedDictionaries.Remove(Settings.ResourceEnLang);
            Application.Current.Resources.MergedDictionaries.Add(Settings.ResourceRusLang);
            Settings.Lang = Settings.Languages.RU;
        }

        private void ToEnglish()
        {
            Application.Current.Resources.MergedDictionaries.Remove(Settings.ResourceRusLang);
            Application.Current.Resources.MergedDictionaries.Add(Settings.ResourceEnLang);
            Settings.Lang = Settings.Languages.EN;
        }

        private void SwitchLang(object sender, RoutedEventArgs e)
        {
            if ((bool)Lang.IsChecked)
                ToEnglish();
            else
                ToRussian();
        }
        private void SwitchTheme(object sender, RoutedEventArgs e)
        {
            if ((bool)Theme.IsChecked)
                ToPink();
            else
                ToBlue();
        }

        private void ToBlue()
        {
            Application.Current.Resources.MergedDictionaries.Remove(Settings.ResourcePinkTheme);
            Application.Current.Resources.MergedDictionaries.Add(Settings.ResourceBlueTheme);
            Application.Current.Resources.MergedDictionaries.Remove(Settings.ResourcePrimaryPink);
            Application.Current.Resources.MergedDictionaries.Add(Settings.ResourcePrimaryIndigo);
        }

        private void ToPink()
        {
            Application.Current.Resources.MergedDictionaries.Remove(Settings.ResourceBlueTheme);
            Application.Current.Resources.MergedDictionaries.Add(Settings.ResourcePinkTheme);
            Application.Current.Resources.MergedDictionaries.Remove(Settings.ResourcePrimaryIndigo);
            Application.Current.Resources.MergedDictionaries.Add(Settings.ResourcePrimaryPink);
        }

        private void ChangeLang()
        {
            switch (currentPage)
            {
                case "ShowAll":
                    ShowAll();
                    break;
                case "ShowFilter":
                    ShowFilter(key);
                    break;
            }
        }
        private void ChangeTheme()
        {
            switch (currentPage)
            {
                case "ShowAll":
                    ShowAll();
                    break;
                case "ShowFilter":
                    ShowFilter(key);
                    break;
            }
        }

        private void ShowAll()
        {
            books.Children.Clear();
            authors.Children.Clear();

            CheckBoxFant.IsChecked = false;
            CheckBoxAdve.IsChecked = false;
            CheckBoxMict.IsChecked = false;
            CheckBoxScie.IsChecked = false;
            CheckBoxPsih.IsChecked = false;
            minRating.Text = string.Empty;
            maxRating.Text = string.Empty;

            HashSet<string> authorsList = new HashSet<string>();
            if (BookInfo.books != null)
            {
                foreach (Book p in BookInfo.books)
                {
                    if (p.isActive == 1)
                    {
                        MakeCells(p);
                        authorsList.Add(p.PAuthor);
                    }
                }

                Border border = new Border();
                border.CornerRadius = new CornerRadius(30);
                border.BorderThickness = new Thickness(2);

                Button button = new Button();
                button.Style = (Style)Resources["AddButtonStyle"];
           
                border.Child = button;

                books.Children.Add(border);

                foreach (string author in authorsList)
                {
                    CheckBox checkBox = new CheckBox();
                    checkBox.Style = (Style)Resources["CheckBox"];
                    checkBox.Content = author;
                    checkBox.Checked += CheckBox_Checked;
                    checkBox.Unchecked += CheckBox_Unchecked;

                    authors.Children.Add(checkBox);
                }
            }
            currentPage = "ShowAll";
        }

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            CheckBox checkBox = (CheckBox)sender;
            selectedAuthors.Add(checkBox.Content.ToString());
        }

        private void CheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            CheckBox checkBox = (CheckBox)sender;
            selectedAuthors.Remove(checkBox.Content.ToString());
        }

        private void MakeCells(Book p)
        {
            Button btn = new Button();
            btn.Style = (Style)Resources["ButtonStyle"];

            StackPanel stackPanel = new StackPanel();
            stackPanel.Style = (Style)Resources["StackPanelStyle"];

            StackPanel stackPanelContent = new StackPanel();
            stackPanelContent.Style = (Style)Resources["StackPanelContentStyle"];

            Image image = new Image();

            var projectPath = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName;

            image.Source = new BitmapImage(new Uri(projectPath + "\\lab4-5\\images\\" + p.PImage));
            image.Style = (Style)Resources["ImageStyle"];

            TextBlock name = new TextBlock();
            name.HorizontalAlignment = HorizontalAlignment.Left;
            name.Text = p.PName;
            name.FontWeight = FontWeights.DemiBold;
            name.FontSize = 15;
            name.Margin = new Thickness(15, 0, 0, 0);
            name.Width = 130;
            name.TextTrimming = TextTrimming.CharacterEllipsis;


            TextBlock author = new TextBlock();
            author.HorizontalAlignment = HorizontalAlignment.Left;
            author.Text = p.PAuthor;
            author.FontSize = 13;
            author.Margin = new Thickness(15, 0, 0, 0);
            author.Width = 130;
            author.TextTrimming = TextTrimming.CharacterEllipsis;

            Label rating = new Label();
            rating.HorizontalAlignment = HorizontalAlignment.Left;
            rating.Content = "\u2605 " + p.Rating;
            rating.FontSize = 13;
            rating.Margin = new Thickness(15, 0, 0, 0);

            Button button = new Button();
            button.Style = (Style)Resources["ButtonDescription"];
            button.Name = "btn" + p.ProductCode.ToString();
            button.Content = (Canvas)Resources["myCanvas"];
            button.Height = 24;
            button.Width = 24;

            Button buttonContent = new Button();
            buttonContent.Style = (Style)Resources["ButtonStyle"];
            buttonContent.Name = "btn" + p.ProductCode.ToString();
            buttonContent.Click += new RoutedEventHandler(openDescription);

            stackPanel.Children.Add(image);
            stackPanel.Children.Add(name);
            stackPanel.Children.Add(author);
            stackPanel.Children.Add(rating);
            buttonContent.Content = stackPanel;

            stackPanelContent.Children.Add(buttonContent);
            stackPanelContent.Children.Add(button);

            btn.Content = stackPanelContent;
            btn.Name = "btn" + p.ProductCode.ToString();
            btn.Click += new RoutedEventHandler(selectItem);
            books.Children.Add(btn);

            }

        private void Refresh(object sender, RoutedEventArgs e)
        {
            ShowAll();
        }
        private void Refresh()
        {
            ShowAll();
        }

        private void Search(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                key = SearchField.Text;
                ShowFilter(key);
            }
        }

        private void ShowFilter(string key)
        {
            currentPage = "ShowFilter";
            books.Children.Clear();
            foreach (Book p in BookInfo.books)
            {
                if (p.isActive == 1 && (p.PName.ToUpper().Contains(key.ToUpper()) || p.PName.ToUpper().Contains(key.ToUpper())))
                {
                    MakeCells(p);
                }

            }
        }

        private void CategoryFilter(object sender, ExecutedRoutedEventArgs e)
        {
            string category = e.Parameter as string;

            books.Children.Clear();

            foreach (Book p in BookInfo.books)
            {
                if (p.isActive == 1 && (p.BookCategory == category))
                {
                    MakeCells(p);
                }

            }
        }

        private void PriceFilter(object sender, TextChangedEventArgs e)
        {
            double minPrice;
            double maxPrice;
            double.TryParse(minPriceTextBox.Text, out minPrice);
            double.TryParse(maxPriceTextBox.Text, out maxPrice);
            books.Children.Clear();

            foreach (Book p in BookInfo.books)
            {
                if(maxPrice != 0 && minPrice != 0)
                {
                    if (p.isActive == 1 && (p.Price >= minPrice) && (p.Price <= maxPrice))
                    {
                        MakeCells(p);
                    }
                }
                else if(maxPrice != 0)
                {
                    if (p.isActive == 1 && (p.Price <= maxPrice))
                    {
                        MakeCells(p);
                    }
                }
                else if(minPrice != 0)
                {
                    if (p.isActive == 1 && (p.Price >= minPrice))
                    {
                        MakeCells(p);
                    }
                }
                else if(maxPrice == 0 && minPrice == 0)
                {
                    if (p.isActive == 1)
                    {
                        MakeCells(p);
                    }
                }
            }

        }

        private void GlobalFilter(object sender, RoutedEventArgs e)
        {
            books.Children.Clear();
            Book filtredBooks = new Book();
            List<string> selectedGenres = new List<string>();
            if (CheckBoxFant.IsChecked == true)
                selectedGenres.Add("фантастика");
            if (CheckBoxAdve.IsChecked == true)
                selectedGenres.Add("приключения");
            if (CheckBoxMict.IsChecked == true)
                selectedGenres.Add("мистика");
            if (CheckBoxScie.IsChecked == true)
                selectedGenres.Add("научпоп");
            if (CheckBoxPsih.IsChecked == true)
                selectedGenres.Add("психология");

            double minRatingValue;
            double maxRatingValue;
            double.TryParse(minRating.Text, out minRatingValue);
            double.TryParse(maxRating.Text, out maxRatingValue);

            if (maxRatingValue != 0 && minRatingValue != 0 && minRatingValue<=5.0 && minRatingValue >= 1.0 && maxRatingValue <= 5.0 && maxRatingValue >= 1.0)
            {
                foreach(var book in BookInfo.books)
                {
                    if(book.isActive == 1 && ((book.Rating >= minRatingValue) && (book.Rating <= maxRatingValue)))
                    {
                        if (selectedAuthors.Count == 0 && selectedGenres.Count == 0)
                        {
                            MakeCells(book);
                        }
                        else if(selectedAuthors.Count != 0 && selectedAuthors.Contains(book.PAuthor) && selectedGenres.Count == 0)
                        {
                            MakeCells(book);
                        }
                        else if(selectedGenres.Count != 0 && selectedGenres.Contains(book.BookGenreValue) && selectedAuthors.Count == 0)
                        {
                            MakeCells(book);
                        }
                        else if(selectedGenres.Count != 0 && selectedAuthors.Count != 0 && (selectedGenres.Contains(book.BookGenreValue)) && (selectedAuthors.Contains(book.PAuthor)))
                        {
                            MakeCells(book);
                        }
                    }

                }
            }
            else if(maxRatingValue == 0 && minRatingValue == 0)
            {
                foreach (var book in BookInfo.books)
                {
                    if (book.isActive == 1)
                    {
                        if (selectedAuthors.Count == 0 && selectedGenres.Count == 0)
                        {
                            MakeCells(book);
                        }
                        else if (selectedAuthors.Count != 0 && selectedAuthors.Contains(book.PAuthor) && selectedGenres.Count == 0)
                        {
                            MakeCells(book);
                        }
                        else if (selectedGenres.Count != 0 && selectedGenres.Contains(book.BookGenreValue) && selectedAuthors.Count == 0)
                        {
                            MakeCells(book);
                        }
                        else if (selectedGenres.Count != 0 && selectedAuthors.Count != 0 && (selectedGenres.Contains(book.BookGenreValue)) && (selectedAuthors.Contains(book.PAuthor)))
                        {
                            MakeCells(book);
                        }
                    }

                }
            }
            else {
                new Message("WrongBookRating").ShowDialog();
            }

        }
        private void openDescription(object sender, RoutedEventArgs e)
        {
            string btn = (sender as Button).Name.ToString();
            int id = int.Parse(btn.Remove(0, 3));

            Book product = BookInfo.books.First(o => o.ProductCode == id);
            new Details(product).Show();
        }
        private void selectItem(object sender, RoutedEventArgs e)
        {
            string btn = (sender as Button).Name.ToString();
            int id = int.Parse(btn.Remove(0, 3));
            Book product = BookInfo.books.First(o => o.ProductCode == id);

            if (selectedItem != null)
            {

                foreach (var b in books.Children.OfType<Button>())
                {
                    if (b.Name == "btn" + selectedItem.ProductCode)
                    {
                        b.Background = Brushes.Transparent;
                        break;
                    }
                }
                selectedItem = null;
            }

            if (product.Equals(selectedItem))
            {
                (sender as Button).Background = Brushes.Transparent;
                selectedItem = null;
            }
            else
            {
                BrushConverter bc = new BrushConverter();
                (sender as Button).Background = (Brush)bc.ConvertFrom("#ebf0f7");
                selectedItem = product;
            }

        }

        private void Undo(object sender, RoutedEventArgs e)
        {
            try
            {
                ObservableCollection<Book> undoState = undoStates.Peek();
                ObservableCollection<Book> state = new ObservableCollection<Book>();
                foreach (var p in BookInfo.books)
                    state.Add(p.Clone() as Book);
                redoStates.Push(state);
                BookInfo.books.Clear();
                foreach (var r in undoState)
                {
                    BookInfo.books.Add(r.Clone() as Book);
                }

                undoStates.Pop();
                Refresh(sender, e);
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        private void Redo(object sender, RoutedEventArgs e)
        {
            try
            {
                ObservableCollection<Book> redoState = redoStates.Peek();
                ObservableCollection<Book> state = new ObservableCollection<Book>();
                foreach (var p in BookInfo.books)
                    state.Add(p.Clone() as Book);
                undoStates.Push(state);
                BookInfo.books.Clear();
                foreach (var r in redoState)
                {
                    BookInfo.books.Add(r.Clone() as Book);
                }
                redoStates.Pop();

                Refresh(sender, e);
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void DeleteBook(object sender, RoutedEventArgs e)
        {
            ObservableCollection<Book> state = new ObservableCollection<Book>();
            foreach (var p in BookInfo.books)
                state.Add(p.Clone() as Book);
            undoStates.Push(state);
            selectedItem.isActive = 0;
            new Message("Success").ShowDialog();
            ShowAll();
        }

        private void AddBook(object sender, RoutedEventArgs e)
        {
            ObservableCollection<Book> state = new ObservableCollection<Book>();
            foreach (var p in BookInfo.books)
                state.Add(p.Clone() as Book);
            undoStates.Push(state);
            goodPage pd = new goodPage();
            pd.Closed += (s, ee) => Refresh(sender, e);
            pd.Show();
        }

        private void EditBook(object sender, RoutedEventArgs e)
        {
            ObservableCollection<Book> state = new ObservableCollection<Book>();
            foreach (var p in BookInfo.books)
                state.Add(p.Clone() as Book);
            undoStates.Push(state);
            goodPage pd = new goodPage(selectedItem);
            pd.Closed += (s, ee) => Refresh(sender, e);
            pd.Show();
        }
        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);

            Application.Current.Shutdown();
        }

    }
}
