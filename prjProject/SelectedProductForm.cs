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
        public int productID { get; set; }
        private int memberID = -1;
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

        private void Style_Click(object sender, EventArgs e)
        {
            Label label = (Label)sender;
            string style = label.Text;
            var q = dbContext.ProductDetails.Where(i => i.Style == style && i.ProductID == productID).Select(i => i).FirstOrDefault();
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

       
    }
}
