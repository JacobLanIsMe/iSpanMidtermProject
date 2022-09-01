using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace prjProject
{
    public partial class UCtrlShowItemsInCart : UserControl
    {
        public UCtrlShowItemsInCart()
        {
            InitializeComponent();
           
        }
        public int orderDetailID { get; set; }
        public bool IsChecked
        {
            get { return checkBox.Checked; }
            set { checkBox.Checked = value; }
        }
        public Image productPhoto
        {
            get { return pictureBox.Image; }
            set { pictureBox.Image = value; }
        }
        public string productName
        {
            get { return lblProductName.Text; }
            set { lblProductName.Text = value; }
        }

        public string productPrice
        {
            get { return lblPrice.Text; }
            set { lblPrice.Text = value; }
        }

        public int productCount
        {
            get { return Convert.ToInt32(nudCount.Value); }
            set { nudCount.Value = value; }
        }
        public int nudCountMaxValue
        {
            get { return Convert.ToInt32(nudCount.Maximum); }
            set { nudCount.Maximum = value; }
        }
        public string productSumPrice
        {
            get { return lblSum.Text; }
            set { lblSum.Text = value; }
        }

        private void nudCount_ValueChanged(object sender, EventArgs e)
        {
            lblSum.Text = (Convert.ToInt32(lblPrice.Text) * Convert.ToInt32(nudCount.Value)).ToString();
        }
    }
}
