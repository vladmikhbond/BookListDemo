using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using WinForms.Models;

namespace WinForms
{
    public partial class MainForm : Form
    {
        Library _library;

        public MainForm()
        {     
            InitializeComponent();

            List<Book> books = new List<Book>() {
                new Book(1, "Book1", "Author1"),
                new Book(1, "Book1", "Author1"), };

            _library = new Library("books.txt");
            try
            {
                _library.LoadFromFile();
            }
            catch (System.IO.FileNotFoundException)
            {
                MessageBox.Show($"Library file not found '{_library.PathToFile}'");
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            bookBindingSource.DataSource = _library.Books;
        }

        private void newToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            BookForm bookForm = new BookForm(new Book());

            if (bookForm.ShowDialog() == DialogResult.OK)
            {
                _library.AddBook(bookForm.Book);
                bookBindingSource.ResetBindings(false);
                bookBox.SelectedIndex = bookBox.Items.Count - 1;
            }            
        }

        private void delToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (bookBox.SelectedIndex > -1)
            {                
                _library.RemoveBookAt(bookBox.SelectedIndex);
                bookBindingSource.ResetBindings(false);
            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _library.SaveToFile();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void titleBox_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(titleBox.Text))
            {
                MessageBox.Show("Title cannot be empty.");
                e.Cancel = true;
            }
        }

        private void editToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Book book = (Book)bookBox.SelectedItem;
            if (book == null)
            {
                return;
            }
            BookForm bookForm = new BookForm(book);

            if (bookForm.ShowDialog() == DialogResult.OK)
            {               
                bookBindingSource.ResetBindings(false);
                bookBox.SelectedIndex = bookBox.Items.Count - 1;
            }

        }
    }
}
