using System.Text;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp2
{
    public partial class MainWindow : Window
    {
        public Book currentBook { get; set; }

        public MainWindow()
        {
            InitializeComponent();
        }

 

        private void ShowBook()
        {
            if (TitleTextBox != null && PageCountTextBox != null && PriceTextBox != null)
            {
                TitleTextBox.Text = currentBook.Title;
                PageCountTextBox.Text = currentBook.PageCount.ToString();
                PriceTextBox.Text = currentBook.Price.ToString("F2");
            }
        }
        private void SaveBook_Click(object sender, RoutedEventArgs e)
        {
            if (int.TryParse(PageCountTextBox.Text, out int pages) &&
                decimal.TryParse(PriceTextBox.Text, out decimal price))
            {
                currentBook = new Book(TitleTextBox.Text, pages, price);
                UpdateResult();
            }
            else
            {
                MessageBox.Show("Пожалуйста, введите корректные данные!");
            }
        }

        private void UpdateBook()
        {
            if (TitleTextBox == null || PageCountTextBox == null || PriceTextBox == null)
                return;

            if (int.TryParse(PageCountTextBox.Text, out int pages) &&
                decimal.TryParse(PriceTextBox.Text, out decimal price))
            {
                currentBook.Title = TitleTextBox.Text;
                currentBook.PageCount = pages;
                currentBook.Price = price;
            }
        }

        private void IncreasePagesButton_Click(object sender, RoutedEventArgs e)
        {
            UpdateBook();
            currentBook.IncreasePages();
            ShowBook();
            UpdateResult();
        }

        private void ReducePriceButton_Click(object sender, RoutedEventArgs e)
        {
            UpdateBook();
            currentBook.ReducePriceIfManyPages();
            ShowBook();
            UpdateResult();
        }

        private void NumberValidation(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void DecimalValidation(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9.,]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void UpdateResult()
        {
            if (ResultTextBlock != null)
            {
                ResultTextBlock.Text = currentBook.ToString();
            }
        }

        private void TitleTextBox_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            if (IsLoaded && currentBook != null)
                if (IsLoaded && currentBook != null)
                {
                    UpdateBook();
                    UpdateResult();
                }
        }

        private void PageCountTextBox_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            if (IsLoaded && currentBook != null && int.TryParse(PageCountTextBox.Text, out int pages))
            {
                currentBook.PageCount = pages;
                UpdateResult();
            }
        }

        private void PriceTextBox_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            if (IsLoaded && currentBook != null && decimal.TryParse(PriceTextBox.Text, out decimal price))
            {
                currentBook.Price = price;
                UpdateResult();
            }
        }
    }
}