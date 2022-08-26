using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pgjMidtermProject
{
    public partial class SellerForm : Form
    {
        public SellerForm()
        {
            InitializeComponent();
        }
        public string memberName
        {
            get
            {
                return linkLabelLogin.Text;
            }
            set
            {
                linkLabelLogin.Text = value;
            }
        }
        public string welcome
        {
            get
            {
                return lblWelcome.Text;
            }
            set
            {
                lblWelcome.Text = value;
            }
        }
        private void linkLabelUploadItem_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            UploadItem uploadItem = new UploadItem();
            uploadItem.ShowDialog();
        }
    }
}
