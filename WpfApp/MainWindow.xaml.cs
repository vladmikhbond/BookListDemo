using BookLibrary;
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

namespace WpfApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Library library;

        public MainWindow()
        {
            InitializeComponent();
            library = new Library { PathToFile = "books.txt" };
            try
            {
                library.LoadFromFile();
            }
            catch (System.IO.FileNotFoundException)
            {
                MessageBox.Show($"File not found '{library.PathToFile}'");
            }

            bookList.ItemsSource = library.Books;
            if (bookList.Items.Count > 0)
                bookList.SelectedIndex = 0;
        }

        private void SaveMenuItem_Click(object sender, RoutedEventArgs e)
        {
            library.SaveToFile();
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
                library.AddBook(bookWindow.BookTitle, bookWindow.BookAuthors);
                
                bookList.SelectedIndex = bookList.Items.Count - 1;
            }
       }

        private void DelMenuItem_Click(object sender, RoutedEventArgs e)
        {
            if (bookList.SelectedIndex != -1)
            {
                library.RemoveBookAt(bookList.SelectedIndex);
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
