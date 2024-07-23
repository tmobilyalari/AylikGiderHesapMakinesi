using System;
using System.Collections.Generic;
using System.Globalization;
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

namespace GELIRGIDERHESAPAPP
{
    /// <summary>
    /// MainWindow.xaml etkileşim mantığı
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            InitializeTextBoxes();
        }

        private void InitializeTextBoxes()
        {

                for (int month = 1; month <= 12; month++)
                {
                    int i = month;
                    string monthName = CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(month);


                TextBox textBox = new TextBox
                {
                    Margin = new Thickness(5),
                    Width = 200,
                    Height = 25
                };
                TextBoxContainer.Items.Add(textBox);
                TextBlock textBlock = new TextBlock()
                {
                    Margin = new Thickness(5),
                    Width = 200,
                    Height = 25,

                };
                TextBlockContainer.Items.Add(monthName);
            };
            
        }

        private void CalculateSum_Click(object sender, RoutedEventArgs e)
        {
            double sum = 0;
            foreach (var item in TextBoxContainer.Items)
            {
                if (item is TextBox textBox)
                {
                    if (double.TryParse(textBox.Text, out double value))
                    {
                        sum += value;
                    }
                }
            }
            ResultTextBox.Text = sum.ToString();
        }

        private void CalculateDifference_Click(object sender, RoutedEventArgs e)
        {
            double? difference = null;
            foreach (var item in TextBoxContainer.Items)
            {
                if (item is TextBox textBox)
                {
                    if (double.TryParse(textBox.Text, out double value))
                    {
                        if (difference == null)
                        {
                            difference = value;
                        }
                        else
                        {
                            difference -= value;
                        }
                    }
                }
            }
            ResultTextBox.Text = difference?.ToString();
        }

        private void CopyResult_Click(object sender, RoutedEventArgs e)
        {
            Clipboard.SetText(ResultTextBox.Text);
            MessageBox.Show("Sonucunuz Kopyalandı!");
        }
    }
}
    
