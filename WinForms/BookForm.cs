using System;
using System.Windows.Forms;
using WinForms.Models;

namespace WinForms
{
    public partial class BookForm : Form
    {
        public Book Book { private set; get; }

        public BookForm(Book book)
        {
            InitializeComponent();
            Book = book;
            titleBox.Text = Book.Title;
            authorBox.Text = Book.Authors;
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(titleBox.Text))
            {
                DialogResult = DialogResult.None;
                errorLabel.Text = "Title cannot be empty";
                return;
            }
            Book.Title = titleBox.Text.Trim();
            Book.Authors = authorBox.Text.Trim();
        }

    }
}
