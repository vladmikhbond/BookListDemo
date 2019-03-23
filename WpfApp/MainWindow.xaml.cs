using System.Windows;
using System.Windows.Controls;
using WpfApp.Models;

namespace WpfApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Library _library;

        public MainWindow()
        {
            InitializeComponent();
            _library = new Library("books.txt");
            try
            {
                _library.LoadFromFile();
            }
            catch (System.IO.FileNotFoundException)
            {
                MessageBox.Show($"Library file not found '{_library.PathToFile}'");
            }

            bookList.ItemsSource = _library.Books;
            if (bookList.Items.Count > 0)
                bookList.SelectedIndex = 0;
        }

        private void SaveMenuItem_Click(object sender, RoutedEventArgs e)
        {
            _library.SaveToFile();
        }

        private void ExitMenuItem_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void NewMenuItem_Click(object sender, RoutedEventArgs e)
        {
            var bookWindow = new BookWindow();

            if (bookWindow.ShowDialog() == true)
            {
                _library.AddBook(bookWindow.Book);                
                bookList.SelectedIndex = bookList.Items.Count - 1;
            }
       }

        private void DelMenuItem_Click(object sender, RoutedEventArgs e)
        {
            if (bookList.SelectedIndex != -1)
            {
                _library.RemoveBookAt(bookList.SelectedIndex);
            }
        }

        private void BookList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            authorsBox.DataContext = bookList.SelectedValue;
            titleBox.DataContext = bookList.SelectedValue;

        }

        private void Window_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            bookList.Height = ActualHeight - 75;
        }
    }
}
