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
    public partial class BookForm : Form
    {
        public string Title { private set; get; }
        public string Authors { private set; get; }

        public BookForm()
        {
            InitializeComponent();
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(titleBox.Text))
            {
                DialogResult = DialogResult.None;
                errorLabel.Text = "Title cannot be empty";
                return;
            }
            Title = titleBox.Text.Trim();
            Authors = authorBox.Text.Trim();

        }
    }
}
