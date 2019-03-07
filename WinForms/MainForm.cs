
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
        Library lib;

        public MainForm()
        {     
            InitializeComponent();

            lib = new Library { PathToFile = "books.txt" };
            lib.LoadFromFile();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            bookBindingSource.DataSource = lib.Books;
        }

        private void newToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            BookForm bookForm = new BookForm();
            if (bookForm.ShowDialog() == DialogResult.OK)
            {
                lib.AddBook(bookForm.Title, bookForm.Authors);
                bookBindingSource.ResetBindings(false);
                bookBox.SelectedIndex = bookBox.Items.Count - 1;
            }            
        }

        private void delToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (bookBox.SelectedIndex > -1)
            {                
                lib.RemoveBookAt(bookBox.SelectedIndex);
                bookBindingSource.ResetBindings(false);
            }
        }
    }
}
