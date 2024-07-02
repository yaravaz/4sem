using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace lab4_5
{
    public static class Settings
    {
        public static event Action changeLang;
        public static event Action changeTheme;
        public enum Languages
        {
            RU,
            EN
        }
        public enum Themes
        {
            BLUE,
            PINK
        }
        private static Languages _lang;
        private static Themes _theme;
        public static Languages Lang
        {
            get
            {
                return _lang;
            }
            set
            {
                _lang = value;
                changeLang?.Invoke();
            }
        }
        public static Themes Theme
        {
            get
            {
                return _theme;
            }
            set
            {
                _theme = value;
                changeTheme?.Invoke();
            }
        }
        public static ResourceDictionary ResourceLights = new ResourceDictionary();
        public static ResourceDictionary ResourceDefaults = new ResourceDictionary();
        public static ResourceDictionary ResourcePrimaryIndigo = new ResourceDictionary();
        public static ResourceDictionary ResourcePrimaryPink = new ResourceDictionary();
        public static ResourceDictionary ResourceAccentLime = new ResourceDictionary();
        public static ResourceDictionary ResourceStyles = new ResourceDictionary();
        public static ResourceDictionary ResourceEnLang = new ResourceDictionary();
        public static ResourceDictionary ResourceRusLang = new ResourceDictionary();
        public static ResourceDictionary ResourcePinkTheme = new ResourceDictionary();
        public static ResourceDictionary ResourceBlueTheme = new ResourceDictionary();
        static Settings()

        {
            Lang = Languages.RU;
            ResourceLights.Source = new Uri("pack://application:,,,/MaterialDesignThemes.Wpf;component/Themes/MaterialDesignTheme.Light.xaml");
            ResourceDefaults.Source = new Uri("pack://application:,,,/MaterialDesignThemes.Wpf;component/Themes/MaterialDesignTheme.Defaults.xaml");
            ResourcePrimaryPink.Source = new Uri("pack://application:,,,/MaterialDesignColors;component/Themes/Recommended/Primary/MaterialDesignColor.Pink.xaml");
            ResourcePrimaryIndigo.Source = new Uri("pack://application:,,,/MaterialDesignColors;component/Themes/Recommended/Primary/MaterialDesignColor.Indigo.xaml");
            ResourceAccentLime.Source = new Uri("pack://application:,,,/MaterialDesignColors;component/Themes/Recommended/Accent/MaterialDesignColor.Lime.xaml");
            ResourceStyles.Source = new Uri("pack://application:,,,/Resources/Styles.xaml");
            ResourceEnLang.Source = new Uri("pack://application:,,,/Resources/DictionaryEn.xaml");
            ResourceRusLang.Source = new Uri("pack://application:,,,/Resources/DictionaryRus.xaml");
            ResourcePinkTheme.Source = new Uri("pack://application:,,,/Resources/PinkTheme.xaml");
            ResourceBlueTheme.Source = new Uri("pack://application:,,,/Resources/BlueTheme.xaml");
        }
    }
}
