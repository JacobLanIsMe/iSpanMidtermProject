using pgjMidtermProject.models;
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

namespace pgjMidtermProject
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }
        public string itemNumInCart
        {
            get
            {
                return lblItemNumInCart.Text;
            }
            set
            {
                lblItemNumInCart.Text = value;
            }
        }
        public int memberID { get; set; }
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
        iSpanProjectEntities dbContext = new iSpanProjectEntities();
        private void linkLabelLogin_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (linkLabelLogin.Text == "登入")
            {
                LoginForm loginForm = new LoginForm();
                loginForm.ShowDialog(this);
            }
            else
            {
                MemberUpdateForm memberUpdateForm = new MemberUpdateForm();
                memberUpdateForm.ShowDialog();
            }
        }

        private void linkLabelRegister_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            RegisterForm register = new RegisterForm();
            register.ShowDialog(this);
        }

        private void lblToSellerForm_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (linkLabelLogin.Text!="會員資料")
            {
                LoginForm loginForm = new LoginForm();
                loginForm.ShowDialog();
            }
            else
            {
                SellerForm sellerForm = new SellerForm();
                //sellerForm.welcome = lblWelcome.Text;
                //sellerForm.memberName = "會員資料";
                sellerForm.ShowDialog();
            }
            
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            //var q = dbContext.Products.Select(i=>i).ToList();
            var q = dbContext.ProductDetails.Select(i => new { itemName = i.Product.ProductName, itemDescription = i.Product.Description, itemUnitPrice = i.UnitPrice, itemPhoto = i.Pic, itemQty = i.Quantity }).ToList();

            if (q.Count > 0)
            {
                foreach (var p in q)
                {
                    MemoryStream ms = new MemoryStream(p.itemPhoto);
                    Image photo = Image.FromStream(ms);
                    CtrlDisplayItem ctrlDisplayItem = new CtrlDisplayItem();
                    ctrlDisplayItem.itemName = p.itemName;
                    ctrlDisplayItem.itemDescription = p.itemDescription;
                    ctrlDisplayItem.itemPrice = "$" + p.itemUnitPrice.ToString("0") + "元";
                    ctrlDisplayItem.itemPhoto = photo;
                    if (p.itemQty == 0)
                    {
                        ctrlDisplayItem.SoldOut = "已售完";
                    }
                    flowLayoutPanel1.Controls.Add(ctrlDisplayItem);
                    ctrlDisplayItem.Click += CtrlDisplayItem_Click;
                    foreach (Control control in ctrlDisplayItem.Controls)
                    {
                        control.Click += CtrlDisplayItem_Click;
                    }
                }
            }
            else
            {
                return;
            }
        }

        private void CtrlDisplayItem_Click(object sender, EventArgs e)
        {
            if (linkLabelLogin.Text == "登入")
            {
                LoginForm loginForm = new LoginForm();
                loginForm.ShowDialog();
            }
            else
            {
                CFunctions.ClickItemAndShow(sender, out int productID);
                BrowseItemsForm browseItems = new BrowseItemsForm();
                browseItems.productID = productID;
                browseItems.ShowDialog();
            }
        }

        private void pbCart_Click(object sender, EventArgs e)
        {
            if (linkLabelLogin.Text == "登入")
            {
                LoginForm loginForm = new LoginForm();
                loginForm.ShowDialog();
            }
            else
            {
                ItemsInCartForm itemsInCartForm = new ItemsInCartForm();
                itemsInCartForm.ShowDialog();
            }
            
        }
    }
}
