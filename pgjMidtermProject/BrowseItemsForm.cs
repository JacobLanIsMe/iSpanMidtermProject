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
    public partial class BrowseItemsForm : Form
    {
        public BrowseItemsForm()
        {
            InitializeComponent();
        }
        iSpanProjectEntities dbContext = new iSpanProjectEntities();

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
        public int productID { get; set; }
        public int itemQty
        {
            get
            {
                return Convert.ToInt32(numericCount.Value);
            }
        }
        private int memberID;
        private void BrowseItems_Load(object sender, EventArgs e)
        {

            CFunctions.MemberInfoFromMainForm(out string login, out string welcome, out string itemNumberInCart, out memberID);
            lblWelcome.Text = welcome;
            linkLabelLogin.Text = login;
            lblItemNumInCart.Text = itemNumInCart;
            var q_productDetail = dbContext.ProductDetails.Where(i => i.ProductID == productID).Select(i => i).FirstOrDefault();
            var q_product = dbContext.Products.Where(i => i.ProductID == productID).Select(i => i).FirstOrDefault();
            var q_memberAccount = dbContext.MemberAccounts.Where(i => i.MemberID == q_product.MemberID).Select(i=>i).FirstOrDefault();
            MemoryStream ms = new MemoryStream(q_productDetail.Pic);
            pbProductPhoto.Image = Image.FromStream(ms);
            lblProductName.Text = q_product.ProductName;
            lblProductPrice.Text = "$" + q_productDetail.UnitPrice.ToString("0");
            cbbShipper.Items.Add(q_product.Shipper.ShipperName);
            lblQty.Text = "還剩 " + q_productDetail.Quantity + "件";
            MemoryStream ms2 = new MemoryStream(q_memberAccount.MemPic);
            pbSellerPhoto.Image = Image.FromStream(ms2);
            lblSellerName.Text = q_memberAccount.Name;
            numericCount.Maximum = q_productDetail.Quantity;
            if (q_productDetail.Quantity == 0)
            {
                numericCount.Enabled = false;
            }

        }
        
        private void btnAddToCart_Click(object sender, EventArgs e)
        {
            if (lblItemNumInCart.Text == "") lblItemNumInCart.Text = "0";
            int Num = Convert.ToInt32(lblItemNumInCart.Text);
            Num += Convert.ToInt32(numericCount.Value) ;
            lblItemNumInCart.Text = Num.ToString("0");
            var q = dbContext.ProductDetails.Where(i => i.ProductID == productID).Select(i => i).FirstOrDefault();
            q.Quantity -= Convert.ToInt32(numericCount.Value);
            dbContext.SaveChanges();
            var q1 = dbContext.ProductDetails.Where(i => i.ProductID == productID).Select(i => i.Quantity).FirstOrDefault();
            lblQty.Text = "還剩 " + q1 + "件";
            
            foreach (Form form in Application.OpenForms)
            {
                if (form.GetType() == typeof(MainForm))
                {
                    MainForm f = (MainForm)form;
                    f.itemNumInCart = lblItemNumInCart.Text;
                }
            }
            var q2 = dbContext.MemberAccounts.Where(i => i.MemberID == memberID).Select(i => i).FirstOrDefault();
            Order order = new Order()
            {
                MemberID = memberID,
                OrderDatetime = DateTime.Now,
                RecieveAdr = q2.RegionList.Region + q2.Address,
                ProductID = productID,
                FinishDate = DateTime.Now.AddDays(1),
                StatusID = 1
            };
            dbContext.Orders.Add(order);
            dbContext.SaveChanges();
            var q3 = dbContext.Orders.Where(i => i.MemberID == memberID && i.ProductID == productID && i.StatusID == 1).Select(i => i).FirstOrDefault();
            var q4 = dbContext.ProductDetails.Where(i => i.ProductID == productID).Select(i => i).FirstOrDefault();
            var q5 = dbContext.Shippers.Where(i => i.ShipperName == cbbShipper.Text).Select(i => i.ShipperID).FirstOrDefault();
            OrderDetail orderDetail = new OrderDetail()
            {
                OrderID = q3.OrderID,
                ProductDetailID = q4.ProductDetailID,
                ShipperID = q5,
                Quantity = Convert.ToInt32(numericCount.Value),
                ShippingDate = DateTime.Now.AddDays(1),
                RecieveDate = DateTime.Now.AddDays(2),
                OutAdr = q4.Product.MemberAccount.RegionList.Region + q4.Product.MemberAccount.Address,
                ShippingStatusID = 1,
            };
            dbContext.OrderDetails.Add(orderDetail);
            dbContext.SaveChanges();
            CFunctions.ShowTheCountOfItemsInCart(memberID);
            
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
                itemsInCartForm.ShowCartOrBuyNow = false;
                itemsInCartForm.ShowDialog();
            }
            
        }

        private void btnBuyNow_Click(object sender, EventArgs e)
        {
            if (linkLabelLogin.Text == "登入")
            {
                LoginForm loginForm = new LoginForm();
                loginForm.ShowDialog();
            }
            ItemsInCartForm itemsInCartForm = new ItemsInCartForm();
            itemsInCartForm.ShowCartOrBuyNow = true;
            itemsInCartForm.ShowDialog();
        }
    }
}
