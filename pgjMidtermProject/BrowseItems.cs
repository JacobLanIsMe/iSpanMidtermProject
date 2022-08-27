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
    public partial class BrowseItems : Form
    {
        public BrowseItems()
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
        public int productID { get; set; }

        private void BrowseItems_Load(object sender, EventArgs e)
        {
            CFunctions.MemberInfoFromMainForm(out string login, out string welcome, out string itemNumberInCart);
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
        }

        private void pbCart_Click(object sender, EventArgs e)
        {
            ItemsInCartForm itemsInCartForm = new ItemsInCartForm();
            itemsInCartForm.ShowDialog();
        }

        private void btnBuyNow_Click(object sender, EventArgs e)
        {
            ItemsInCartForm itemsInCartForm = new ItemsInCartForm();
            itemsInCartForm.ShowDialog();
        }
    }
}
