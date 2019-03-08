
using BookLibrary;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinForms
{
    public partial class MainForm : Form
    {
        Library library;

        public MainForm()
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
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            bookBindingSource.DataSource = library.Books;
        }

        private void newToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            BookForm bookForm = new BookForm();
            if (bookForm.ShowDialog() == DialogResult.OK)
            {
                library.AddBook(bookForm.Title, bookForm.Authors);
                bookBindingSource.ResetBindings(false);
                bookBox.SelectedIndex = bookBox.Items.Count - 1;
            }            
        }

        private void delToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (bookBox.SelectedIndex > -1)
            {                
                library.RemoveBookAt(bookBox.SelectedIndex);
                bookBindingSource.ResetBindings(false);
            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            library.SaveToFile();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
