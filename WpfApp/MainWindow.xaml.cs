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
                //library.LoadFromFile();
            }
            catch (System.IO.FileNotFoundException)
            {
                MessageBox.Show($"File not found '{library.PathToFile}'");
            }
        }

        private void SaveMenuItem_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ExitMenuItem_Click(object sender, RoutedEventArgs e)
        {

        }

        private void NewMenuItem_Click(object sender, RoutedEventArgs e)
        {

        }

        private void DelMenuItem_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
