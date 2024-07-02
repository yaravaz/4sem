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
    /// <summary>
    /// Логика взаимодействия для RatingControl.xaml
    /// </summary>
    public partial class RatingControl : UserControl
    {

        public static readonly DependencyProperty RatingProperty =
            DependencyProperty.Register("Rating", typeof(double), typeof(RatingControl),
                new FrameworkPropertyMetadata(0.0, FrameworkPropertyMetadataOptions.None,
                    new PropertyChangedCallback(OnRatingChanged),
                    new CoerceValueCallback(CorrectRating),
                    true, UpdateSourceTrigger.PropertyChanged),
                new ValidateValueCallback(ValidateRating));

        public double Rating
        {
            get { return (double)GetValue(RatingProperty); }
            set { SetValue(RatingProperty, value); }
        }

        public static TextBox RatingField;

        public RatingControl()
        {
            InitializeComponent();
            RatingField = ratingField;
        }

        private static void OnRatingChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            /*RatingControl ratingControl = (RatingControl)d;
            double rating = (double)e.NewValue;

            if (rating < 0)
            {
                ratingControl.Rating = 0;
            }
            else if (rating > 5)
            {
                ratingControl.Rating = 5;
            }*/
        }
        private static bool ValidateRating(object value)
        {
            double rating = (double)value;
            return true;
        }

        private static object CorrectRating(DependencyObject d, object baseValue)
        {
            double rating = (double)baseValue;
            if(rating <= 0.0)
            {
                rating = 1.0;
            }
            else if(rating > 5.0)
            {
                rating = 5.0;
            }
            return rating;
        }
    }
}
