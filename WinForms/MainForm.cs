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

            _library = new Library("books.txt");
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

        private void updateToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (!(bookBox.SelectedItem is Book book))
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

        private void delToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (bookBox.SelectedIndex > -1)
            {
                int id = (bookBox.SelectedItem as Book).Id;
                _library.RemoveBook(id);
                bookBindingSource.ResetBindings(false);
            }
        }

        private void titleBox_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(titleBox.Text))
            {
                MessageBox.Show("Title cannot be empty.");
                e.Cancel = true;
            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _library.SaveChanges();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }


    }
}
