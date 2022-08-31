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
    public partial class CtrlDisplayItem : UserControl
    {
        public CtrlDisplayItem()
        {
            InitializeComponent();
        }
        public int productID { get; set; }
        public string SoldOut
        {
            get
            {
                return lblSoldOut.Text;
            }
            set
            {
                lblSoldOut.Text = value;
            }
        }
        public Image itemPhoto
        {
            get
            {
                return pbItemPhoto.Image;
            }
            set
            {
                pbItemPhoto.Image = value;
            }
        }
        public string itemDescription
        {
            get
            {
                return lblItemDescription.Text;
            }
            set
            {
                lblItemDescription.Text = value;
            }
        }
        public string itemPrice
        {
            get
            {
                return lblItemPrice.Text;
            }
            set
            {
                lblItemPrice.Text = value;
            }
        }
        public string itemName
        {
            get
            {
                return lblitemName.Text;
            }
            set
            {
                lblitemName.Text = value;
            }
        }
    }
}
