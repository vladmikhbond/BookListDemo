using System.Windows;
using WpfApp.Models;

namespace WpfApp
{
    /// <summary>
    /// Interaction logic for BookWindow.xaml
    /// </summary>
    public partial class BookWindow : Window
    {
        public Book Book { private set; get; }

        public BookWindow(Book book=null)
        {
            InitializeComponent();
            Book = book ?? new Book();
        }

        private void OkButton_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(titleBox.Text))
            {
                DialogResult = false;
                errorLabel.Text = "Title cannot be empty";
                return;
            }
            Book.Title = titleBox.Text.Trim();
            Book.Authors = authorBox.Text.Trim();
            DialogResult = true;
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
