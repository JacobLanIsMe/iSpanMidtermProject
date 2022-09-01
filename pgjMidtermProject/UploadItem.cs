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
    public partial class UploadItem : Form
    {
        public UploadItem()
        {
            InitializeComponent();
        }
        int memberID = -1;
        iSpanProjectEntities dbContext = new iSpanProjectEntities();
        private void UploadItem_Load(object sender, EventArgs e)
        {
            var productSmallType = dbContext.SmallTypes.Select(i => i.SmallTypeName).ToArray();
            cbbProductSmallType.Items.AddRange(productSmallType);
            var productRegion = dbContext.RegionLists.Select(i => i.Region).ToArray();
            cbbProductRegion.Items.AddRange(productRegion);
            var productShipper = dbContext.Shippers.Select(i => i.ShipperName).ToArray();
            cbbShipper.Items.AddRange(productShipper);
            foreach (Form f in Application.OpenForms)
            {
                if (f.GetType() == typeof(MainForm))
                {
                    MainForm mainForm = (MainForm)f;
                    lblWelcome.Text = mainForm.welcome;
                    linkLabelLogin.Text = "會員資料";
                    memberID = mainForm.memberID;
                }
            }
        }
        List<CProduct> productList = new List<CProduct>();
        private void btnAddItem_Click(object sender, EventArgs e)
        {
            byte[] bytes = null;
            if (picbProductPhoto.Image != null)
            {
                MemoryStream ms = new MemoryStream();
                picbProductPhoto.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                bytes = ms.GetBuffer();
            }

            string productName = txtProductName.Text;
            string productSmallType = cbbProductSmallType.Text;
            string productRegion = cbbProductRegion.Text;
            string productAdFee = txtAdFee.Text;
            string productDescription = txtProductDescription.Text;
            string productShipper = cbbShipper.Text;
            string productStyle = txtStyle.Text;
            int productQuantity = Convert.ToInt32(txtQty.Text);
            decimal productUnitPrice = Convert.ToDecimal(txtUnitPrice.Text);
            if (productName == null || productSmallType == null || productRegion == null || productAdFee == null || productDescription == null || productShipper == null || productStyle == null || productQuantity == 0 || productUnitPrice == 0)
            {
                MessageBox.Show("有欄位沒填到!");
                return;
            }
            
            if (memberID == -1)
            {
                MessageBox.Show("memberID沒抓到");
            }
            else
            {
                CProduct p = new CProduct
                {
                    name = productName,
                    smallType = productSmallType,
                    region = productRegion,
                    adFee = productAdFee,
                    description = productDescription,
                    shipper = productShipper,
                    style = productStyle,
                    quantity = productQuantity,
                    unitPrice = productUnitPrice,
                    picture = bytes
                };
                productList.Add(p);
                var bindingList = new BindingList<CProduct>(productList);
                dataGridView1.DataSource = bindingList;

                foreach (Control con in splitContainer2.Panel2.Controls)
                {
                    if (con.GetType() == typeof(TextBox) || con.GetType() == typeof(ComboBox))
                    {
                        con.Text = "";
                    }
                    else if (con.GetType() == typeof(NumericUpDown))
                    {
                        con.Text = "0";
                    }
                    else if (con.GetType() == typeof(PictureBox))
                    {
                        picbProductPhoto.Image = null;
                    }
                    else
                    {
                        continue;
                    }
                }
            }
        }

        private void btnProductPhoto_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog()== DialogResult.OK)
            {
                string filePath = openFileDialog1.FileName;
                txtProductPhoto.Text = filePath;
                picbProductPhoto.Image = Image.FromFile(filePath);
            }
        }

        private void btnRemoveItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("是否確定刪除選擇的商品?", "刪除商品", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                int index = dataGridView1.CurrentRow.Index;
                productList.RemoveAt(index);
                var bindingList = new BindingList<CProduct>(productList);
                dataGridView1.DataSource = bindingList;
            }
            else
            {
                return;
            }
        }

        private void btnUpload_Click(object sender, EventArgs e)
        {
            if (productList.Count == 0 || productPhotoPath.Count == 0)
            {
                MessageBox.Show("尚未新增商品!");
            }
            else
            {
                try
                {
                    foreach (CProduct p in productList)
                    {
                        var q1 = dbContext.SmallTypes.Where(i => i.SmallTypeName == p.smallType).Select(i => i.SmallTypeID).FirstOrDefault();
                        var q2 = dbContext.RegionLists.Where(i => i.Region == p.region).Select(i => i.RegionID).FirstOrDefault();
                        var q3 = dbContext.Shippers.Where(i => i.ShipperName == p.shipper).Select(i => i.ShipperID).FirstOrDefault();
                        Product newProduct = new Product()
                        {
                            ProductName = p.name,
                            SmallTypeID = q1,
                            MemberID = memberID,
                            RegionID = q2,
                            AdFee = Convert.ToDecimal(p.adFee),
                            Description = p.description,
                            ShipperID = q3
                        };
                        dbContext.Products.Add(newProduct);
                        dbContext.SaveChanges();
                        var q4 = dbContext.Products.Where(i => i.ProductName == p.name && i.Description == p.description).Select(i => i.ProductID).FirstOrDefault();
                        ProductDetail newProductDetail = new ProductDetail()
                        {
                            ProductID = q4,
                            Style = p.style,
                            Quantity = p.quantity,
                            UnitPrice = p.unitPrice,
                            Pic = p.picture,
                        };
                        dbContext.ProductDetails.Add(newProductDetail);
                        dbContext.SaveChanges();
                        foreach (string photoPath in productPhotoPath)
                        {
                            Image img = Image.FromFile(photoPath);
                            MemoryStream ms = new MemoryStream();
                            img.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                            byte[] bytes = ms.GetBuffer();
                            ProductPic productPic = new ProductPic
                            {
                                ProductID = q4,
                                picture = bytes,
                            };
                            dbContext.ProductPics.Add(productPic);
                            dbContext.SaveChanges();
                        }

                    }


                    MessageBox.Show("上架成功");
            }
                catch (Exception ex)
            {
                MessageBox.Show("上架失敗");
            }
        }
            

        }
        List<string> productPhotoPath = new List<string>();
        private void btnProductPic_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                productPhotoPath.Add(openFileDialog1.FileName);
                lblShowImgPath.Text += openFileDialog1.FileName;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int productID = 17;
            string style = txtStyle.Text;
            int qty = Convert.ToInt32(txtQty.Text);
            decimal price = Convert.ToDecimal(txtUnitPrice.Text);

            MemoryStream ms = new MemoryStream();
            picbProductPhoto.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
            byte[] bytes = ms.GetBuffer();

            ProductDetail productDetail = new ProductDetail
            {
                ProductID = productID,
                Style = style,
                Quantity = qty,
                UnitPrice = price,
                Pic = bytes,
            };
            dbContext.ProductDetails.Add(productDetail);
            dbContext.SaveChanges();
        }
    }
}
