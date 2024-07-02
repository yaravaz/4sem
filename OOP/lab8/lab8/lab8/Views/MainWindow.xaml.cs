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
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using System.Runtime.Remoting.Messaging;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Collections;
using lab8.ViewModels;
using System.Diagnostics;
using Microsoft.Win32;

namespace lab8
{
    
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void CellClickHandler(object sender, MouseButtonEventArgs e)
        {
            DataGridCell cell = (DataGridCell)sender;

            if (cell != null && cell.Column is DataGridTemplateColumn)
            {
                OpenFileDialog open = new OpenFileDialog();
                bool? response = open.ShowDialog();
                if (response.HasValue)
                {
                    if (response.Value == true)
                    {
                        string path = open.FileName;

                        TextBlock urlTextBlock = FindChild<TextBlock>(cell, "url");

                        if (urlTextBlock != null)
                        {
                            urlTextBlock.Text = path;

                            BindingExpression bindingExpression = urlTextBlock.GetBindingExpression(TextBlock.TextProperty);
                            bindingExpression?.UpdateSource();

                        }

                    }
                }
            }
        }

        private T FindVisualParent<T>(DependencyObject child) where T : DependencyObject
        {
            DependencyObject parentObject = VisualTreeHelper.GetParent(child);

            if (parentObject == null)
                return null;

            T parent = parentObject as T;
            if (parent != null)
                return parent;
            else
                return FindVisualParent<T>(parentObject);
        }

        private T FindChild<T>(DependencyObject parent, string childName) where T : DependencyObject
        {
            for (int i = 0; i < VisualTreeHelper.GetChildrenCount(parent); i++)
            {
                var child = VisualTreeHelper.GetChild(parent, i);

                if (child is T element && child is FrameworkElement frameworkElement && frameworkElement.Name == childName)
                    return element;

                T result = FindChild<T>(child, childName);
                if (result != null)
                    return result;
            }

            return null;
        }
        private void TextBlock_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                if (sender is TextBlock textBlock && textBlock.DataContext is TextBlock item)
                {
                    string imageUrl = item.Text;

                }
            }
        }
    }
}
