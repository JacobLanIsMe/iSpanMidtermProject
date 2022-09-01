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
    public partial class SelectedProductForm : Form
    {
        public SelectedProductForm()
        {
            InitializeComponent();
        }
        public string memberName
        {
            get { return lblWelcome.Text; }
            set { lblWelcome.Text = value; }
        }
        public string ProductNumInCart
        {
            get { return lblProductNumInCart.Text; }
            set { lblProductNumInCart.Text = value; }
        }
        public string memberRegion
        {
            get { return cbbRegion.Text; }
            set { cbbRegion.Text = value; }
        }
        public int productID { get; set; }
        public int memberID { get;set; }
        iSpanProjectEntities dbContext = new iSpanProjectEntities();
        private void SelectedProductForm_Load(object sender, EventArgs e)
        {
            string[] allRegion = dbContext.RegionLists.Select(i => i.Region).ToArray();
            cbbRegion.Items.AddRange(allRegion);
            
            memberID = CFunctions.GetMemberInfoFromHomePage();
            if (memberID > 0)
            {
                var q1 = dbContext.MemberAccounts.Where(i => i.MemberID == memberID).Select(i => i).FirstOrDefault();
                lblWelcome.Text = q1.Name;
                string memberRegion = q1.RegionList.Region;
                cbbRegion.SelectedItem = memberRegion;
            }
            var q = dbContext.ProductPics.Where(i => i.ProductID == productID).Select(i => new { productName = i.Product.ProductName, productPhoto = i.picture }).ToList();
            MemoryStream ms = new MemoryStream(q[0].productPhoto);
            pbProductPhoto.Image = Image.FromStream(ms);
            for (int i = 0; i < q.ToList().Count; i++)
            {
                MemoryStream ms1 = new MemoryStream(q[i].productPhoto);
                productPhotoList.Add(Image.FromStream(ms1));
                PictureBox pb = new PictureBox();
                pb.Image = Image.FromStream(ms1);
                pb.SizeMode = PictureBoxSizeMode.StretchImage;
                pb.Name = $"pb{i}";
                flowLayoutPanel1.Controls.Add(pb);
                pb.MouseEnter += ProductPhoto_MouseEnter;
                pb.MouseLeave += Pb_MouseLeave;
            }
            string productName = q[0].productName;
            lblProductName.Text = productName;


            var q2 = dbContext.ProductDetails.Where(i => i.ProductID == productID).Select(i => i);
            foreach (var p in q2)
            {
                Label label = new Label();
                label.Text = p.Style;
                label.Font = new Font("標楷體", 16);
                
                label.Margin = new Padding(0, 0, 10, 10);
                if (p.Quantity == 0)
                {
                    label.ForeColor = Color.DarkGray;
                    label.BorderStyle = BorderStyle.Fixed3D;
                }
                else
                {
                    label.BorderStyle = BorderStyle.FixedSingle;
                    
                }
                label.Click += Style_Click;
                label.MouseEnter += Style_MouseEnter;
                label.MouseLeave += Style_MouseLeave;
                flpStyle.Controls.Add(label);
            }

            List<decimal> priceList = q2.Select(i => i.UnitPrice).ToList();
            priceList.Sort();
            decimal maxPrice = priceList[priceList.Count - 1];
            decimal minPrice = priceList[0];
            string price = "";
            if (maxPrice == minPrice)
            {
                price = $"{minPrice.ToString("C0")}";
            }
            else
            {
                price = $"{minPrice.ToString("C0")} - {maxPrice.ToString("C0")}";
            }
            lblPrice.Text = price;

            var q3 = dbContext.Products.Where(i => i.ProductID == productID).Select(i => i);
            string sellerName = q3.Select(i => i.MemberAccount.Name).FirstOrDefault();
            lblSellerName.Text = $"{sellerName}的賣場";
            byte[] sellerPhoto = q3.Select(i => i.MemberAccount.MemPic).FirstOrDefault();
            MemoryStream ms2 = new MemoryStream(sellerPhoto);
            pbSellerPhoto.Image = Image.FromStream(ms2);
            string productDescription = q3.FirstOrDefault().Description;
            lblProductDescription.Text = productDescription;
            int sellerID = q3.FirstOrDefault().MemberID;
            int sellerProductNum = dbContext.Products.Where(i => i.MemberID == sellerID).Select(i => i).ToList().Count;
            lblSellerProductNum.Text = sellerProductNum.ToString();

        }

        private void Style_MouseLeave(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private void Style_MouseEnter(object sender, EventArgs e)
        {
            timer1.Stop();
            Label label = (Label)sender;
            byte[] bytes = dbContext.ProductDetails.Where(i => i.Style == label.Text && i.ProductID == productID).Select(i => i.Pic).FirstOrDefault();
            MemoryStream ms = new MemoryStream(bytes);
            pbProductPhoto.Image = Image.FromStream(ms);
        }

        private int productDetailID = 0;
        private string productRegion = "";
        private void Style_Click(object sender, EventArgs e)
        {
            Label label = (Label)sender;
            string style = label.Text;
            var q = dbContext.ProductDetails.Where(i => i.Style == style && i.ProductID == productID).Select(i => i).FirstOrDefault();
            productDetailID = q.ProductDetailID;
            productRegion = q.Product.RegionList.Region;
            lblPrice.Text = q.UnitPrice.ToString("c0");
            int qty = q.Quantity;
            lblQty.Text = $"庫存 {qty} 件";
            nudCount.Maximum = qty;
            foreach (Control control in flpStyle.Controls)
            {
                (control as Label).BackColor = Color.Transparent;
            }
            if (qty > 0)
            {
                label.BackColor = Color.MistyRose;
            }
        }

        private void Pb_MouseLeave(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private void ProductPhoto_MouseEnter(object sender, EventArgs e)
        {
            PictureBox pb = sender as PictureBox;
            pbProductPhoto.Image = pb.Image;
            timer1.Stop();
        }

        List<Image> productPhotoList = new List<Image>();
        private int productPhotoIndex = 0;
        private void timer1_Tick(object sender, EventArgs e)
        {
            productPhotoIndex++;
            if (productPhotoIndex >= productPhotoList.Count)
                productPhotoIndex = 0;
            pbProductPhoto.Image = productPhotoList[productPhotoIndex];
        }

        private void linkLabelLogin_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            LoginForm form = new LoginForm();
            form.ShowDialog();
        }

        private void btnAddToCart_Click(object sender, EventArgs e)
        {
            int detailID = 0;
            string outAdr = "";
            int qty = 0;
            if (productDetailID == 0 || productRegion == "")
            {
                MessageBox.Show("請選擇一個樣式");
                return;
            }
            else
            {
                detailID = productDetailID;
                outAdr = productRegion;
            }
            if (nudCount.Value == 0)
            {
                MessageBox.Show("請選擇訂購的數量");
                return;
            }
            else
            {
                qty = Convert.ToInt32(nudCount.Value);
            }
            
            COrderInfo orderInfo = new COrderInfo
            {
                MemberID = memberID,
                OrderDatetime = DateTime.Now,
                RecieveAdr = cbbRegion.Text,
                FinishDate = DateTime.Now,
                CouponID = 7,
                StatusID = 1,
                ProductDetailID = detailID,
                ShipperID = 2,
                Quantity = qty,
                ShippingDate = DateTime.Now,
                RecieveDate = DateTime.Now,
                OutAdr = outAdr,
                ShippingStatusID = 1,
            };
            int latestQuantity = 0;
            if (memberID == 0)
            {
                LoginForm form = new LoginForm();
                form.ShowDialog();
                if (memberID > 0)
                {
                    CFunctions.AddToCart(orderInfo, memberID);
                    CFunctions.SendMemberInfoToEachForm(memberID);
                    latestQuantity = CFunctions.UpgradeQuantity(productDetailID, -qty);
                    lblQty.Text = $"庫存 {latestQuantity} 件";
                    nudCount.Maximum = latestQuantity;
                }
                else
                {
                    return;
                }
            }
            else
            {
                CFunctions.AddToCart(orderInfo, memberID);
                CFunctions.SendMemberInfoToEachForm(memberID);
                latestQuantity = CFunctions.UpgradeQuantity(productDetailID, -qty);
                lblQty.Text = $"庫存 {latestQuantity} 件";
                nudCount.Maximum = latestQuantity;
            }
        }

        private void pbCart_Click(object sender, EventArgs e)
        {
            CartForm form = new CartForm();
            form.ShowDialog();
        }

        private void btnBuyNow_Click(object sender, EventArgs e)
        {
            CartForm form = new CartForm();
            form.IsBuyNow = true;
            form.ShowDialog();
        }
    }
}
