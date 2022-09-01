using pgjMidtermProject;
using prjProject.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace prjProject
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }
        public string memberName
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
        public string ProductNumInCart
        {
            get
            {
                return lblProductNumInCart.Text;
            }
            set
            {
                lblProductNumInCart.Text = value;
            }
        }
        public int memberID { get; set; }
        iSpanProjectEntities dbContext = new iSpanProjectEntities();
        private void MainForm_Load(object sender, EventArgs e)
        {
            var q = dbContext.Products.Select(i => i);
            List<CtrlDisplayItem> list = CFunctions.GetProductsForShow(q);
            foreach (CtrlDisplayItem i in list)
            {
                flpProduct.Controls.Add(i);
                i.Click += CtrlDisplayItem_Click;
                foreach (Control control in i.Controls)
                {
                    control.Click += CtrlDisplayItem_Click;
                }
            }
            var q1 = dbContext.BigTypes.Select(i => i.BigTypeName);
            foreach (var bigType in q1)
            {
                LinkLabel linkLabel = new LinkLabel();
                linkLabel.Text = bigType;
                linkLabel.LinkColor = Color.Black;
                linkLabel.Margin = new Padding(0, 0, 0, 20);
                flpBigType.Controls.Add(linkLabel);
                linkLabel.Click += BigType_Click;
            }

            
        }

        private void BigType_Click(object sender, EventArgs e)
        {
            LinkLabel linkLabel = sender as LinkLabel;
            string bigType = linkLabel.Text;
            int bigTypeID = dbContext.BigTypes.Where(i => i.BigTypeName == bigType).Select(i => i.BigTypeID).FirstOrDefault();
            BigTypeForm form = new BigTypeForm();
            form.bigTypeID = bigTypeID;
            form.ShowDialog();
        }

        private void CtrlDisplayItem_Click(object sender, EventArgs e)
        {
            int productID = -1;
            CFunctions.ClickItemAndShow(sender, out productID);
            SelectedProductForm form = new SelectedProductForm();
            form.productID = productID;
            form.memberID = memberID;
            form.ProductNumInCart = ProductNumInCart;
            form.ShowDialog();
        }

        private void linkLabelLogin_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            LoginForm form = new LoginForm();
            form.ShowDialog();
        }

        private void pbCart_Click(object sender, EventArgs e)
        {
            if (memberID == 0)
            {
                LoginForm form = new LoginForm();
                form.ShowDialog();
            }
            else
            {
                CartForm form = new CartForm();
                form.ShowDialog();
            }
        }
    }
}
