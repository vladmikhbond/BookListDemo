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
            Title = titleBox.Text.Trim();
            Authors = authorBox.Text.Trim();
        }

        private void BookForm_Validating(object sender, CancelEventArgs e)
        {
           
        }
    }
}
