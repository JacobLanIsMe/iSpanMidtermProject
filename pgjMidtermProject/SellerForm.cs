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
    public partial class SellerForm : Form
    {
        public SellerForm()
        {
            InitializeComponent();
        }
        iSpanProjectEntities dbContext = new iSpanProjectEntities();

        int memberID;
        private void SellerForm_Load(object sender, EventArgs e)
        {
            CFunctions.MemberInfoFromMainForm(out string login, out string welcome, out string itemNumInCart, out memberID);
            linkLabelLogin.Text = "會員資料";
            lblWelcome.Text = welcome;
            var q1 = dbContext.MemberAccounts.Where(i => i.MemberID == memberID).Select(i => i).FirstOrDefault();

            MemoryStream ms1 = new MemoryStream(q1.MemPic);
            pbSellerPhoto.Image = Image.FromStream(ms1);
            lblSellerName.Text = q1.Name + "的賣場";

            var q = dbContext.ProductDetails.Where(i => i.Product.MemberID == memberID).Select(i => new { itemName = i.Product.ProductName, itemPrice = i.UnitPrice, itemDescription = i.Product.Description, itemPhoto = i.Pic, itemQty = i.Quantity });
            foreach (var p in q)
            {
                MemoryStream ms = new MemoryStream(p.itemPhoto);
                CtrlDisplayItem ctrlDisplayItem = new CtrlDisplayItem();
                ctrlDisplayItem.itemName = p.itemName;
                ctrlDisplayItem.itemDescription = p.itemDescription;
                ctrlDisplayItem.itemPrice = p.itemPrice.ToString();
                ctrlDisplayItem.itemPhoto = Image.FromStream(ms);
                if (p.itemQty == 0)
                    ctrlDisplayItem.SoldOut = "已售完";
                else
                    ctrlDisplayItem.SoldOut = "";
                flowLayoutPanel1.Controls.Add(ctrlDisplayItem);
                ctrlDisplayItem.Click += CtrlDisplayItem_Click;
            }
            lblProductCount.Text = "商品: " + q.ToList().Count;

        }

        private void CtrlDisplayItem_Click(object sender, EventArgs e)
        {
            ManageProductForm manageProductForm = new ManageProductForm();
            manageProductForm.ShowDialog();
        }

        private void linkLabelUploadItem_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            UploadItem uploadItem = new UploadItem();
            uploadItem.ShowDialog();
        }

        private void linkLabelLogin_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            MemberUpdateForm memberUpdateForm = new MemberUpdateForm();
            memberUpdateForm.ShowDialog();
        }
    }
}
