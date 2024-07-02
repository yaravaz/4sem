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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace lab4_5
{
    public partial class PriceControl : UserControl
    {
        public double MinPrice
        {
            get { return (double)GetValue(MinPriceProperty); }
            set { SetValue(MinPriceProperty, value); }
        }

        public double MaxPrice
        {
            get { return (double)GetValue(MaxPriceProperty); }
            set { SetValue(MaxPriceProperty, value); }
        }

        public static readonly DependencyProperty MinPriceProperty =
            DependencyProperty.Register("MinPrice", typeof(double), typeof(PriceControl),
                new FrameworkPropertyMetadata(0.0, FrameworkPropertyMetadataOptions.None,
                    new PropertyChangedCallback(OnMinPriceChanged),
                    new CoerceValueCallback(CoerceMinPriceValue),
                    true, UpdateSourceTrigger.PropertyChanged),
                new ValidateValueCallback(ValidateMinPrice));

        public static readonly DependencyProperty MaxPriceProperty =
            DependencyProperty.Register("MaxPrice", typeof(double), typeof(PriceControl),
                new FrameworkPropertyMetadata(0.0, FrameworkPropertyMetadataOptions.None,
                    new PropertyChangedCallback(OnMaxPriceChanged),
                    new CoerceValueCallback(CoerceMaxPriceValue),
                    true, UpdateSourceTrigger.PropertyChanged),
                new ValidateValueCallback(ValidateMaxPrice));

        private static bool ValidateMinPrice(object value)
        {
            double minPrice = (double)value;
            return true;
        }

        private static bool ValidateMaxPrice(object value)
        {
            double maxPrice = (double)value;
            return true;
        }

        private static void OnMinPriceChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            PriceControl priceControl = (PriceControl)d;
            double newMinPrice = (double)e.NewValue;

            if (newMinPrice < 0)
            {
                priceControl.MinPrice = 0;
            }
            else if (newMinPrice > priceControl.MaxPrice)
            {
                priceControl.MaxPrice = newMinPrice + 20;
            }
            
        }

        private static void OnMaxPriceChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            PriceControl priceControl = (PriceControl)d;
            double newMaxPrice = (double)e.NewValue;

            if (newMaxPrice < 0)
            {
                priceControl.MinPrice = 20;
            }
            else if (newMaxPrice < priceControl.MinPrice)
            {
                if (newMaxPrice > 10)
                {
                    priceControl.MinPrice = newMaxPrice + 10;
                }
                else
                    priceControl.MinPrice = 0;
            }
           /* else if (newMaxPrice > 100)
            {
                priceControl.MaxPrice = 100;
            }*/

        }

        private static object CoerceMinPriceValue(DependencyObject d, object baseValue)
        {
            double minValue = (double)baseValue;
            if (minValue > 100)
            {
                minValue = 100;
            }
            else if(minValue < 0)
            {
                minValue = 0;
            }
            return minValue;
        }

        private static object CoerceMaxPriceValue(DependencyObject d, object baseValue)
        {
            double maxValue = (double)baseValue;
            if (maxValue > 100)
            {
                maxValue = 100;
            }
            return maxValue;
        }

        public event EventHandler<TextChangedEventArgs> PriceTextChanged;
        public static TextBox MinPriceTextBox;
        public static TextBox MaxPriceTextBox;

        public PriceControl()
        {
            InitializeComponent();
            MinPriceTextBox = minPriceTextBox;
            MaxPriceTextBox = maxPriceTextBox;

            minPriceTextBox.TextChanged += minPriceTextBox_TextChanged;
            maxPriceTextBox.TextChanged += maxPriceTextBox_TextChanged;

            
        }

        private void minPriceTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

            PriceFilter(sender, e);
        }

        private void maxPriceTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            PriceFilter(sender, e);
        }

        private void PriceFilter(object sender, TextChangedEventArgs e)
        {
            PriceTextChanged?.Invoke(this, e);
        }

    }
}
