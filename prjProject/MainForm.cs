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

            }
            set
            {

            }
        }
        public int memberID { get; set; }
        iSpanProjectEntities dbContext = new iSpanProjectEntities();
        private void MainForm_Load(object sender, EventArgs e)
        {
            List<CtrlDisplayItem> list = CFunctions.GetProductsForHomePage();
            foreach (CtrlDisplayItem i in list)
            {
                flpProduct.Controls.Add(i);
                i.Click += CtrlDisplayItem_Click;
                foreach (Control control in i.Controls)
                {
                    control.Click += CtrlDisplayItem_Click;
                }
            }
            var q = dbContext.BigTypes.Select(i => i.BigTypeName);
            foreach (var bigType in q)
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
            form.ShowDialog();
        }

        private void linkLabelLogin_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            LoginForm form = new LoginForm();
            form.ShowDialog();
        }
    }
}
