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
    public partial class CartForm : Form
    {
        public CartForm()
        {
            InitializeComponent();
        }
        iSpanProjectEntities dbContext = new iSpanProjectEntities();
        public bool IsBuyNow { get; set; }
        public int productDetailID { get; set; }
        public int productCount { get; set; }
        int memberID = 0;
        private void CartForm_Load(object sender, EventArgs e)
        {
            memberID = CFunctions.GetMemberInfoFromHomePage();
            CFunctions.ShowMemberInfoAtHeader(memberID, out string memberName, out int productNumInCart);
            lblWelcome.Text = memberName;
            lblProductNumInCart.Text = productNumInCart.ToString();
            if (IsBuyNow)
            {
                var q = dbContext.ProductDetails.Where(i => i.ProductDetailID == productDetailID).Select(i => i).FirstOrDefault();
                MemoryStream ms = new MemoryStream(q.Pic);
                Image productPhoto = Image.FromStream(ms);
                string productName = q.Product.ProductName;
                string productStyle = q.Style;
                productName = $"{productName} - {productStyle}";
                decimal productPrice = q.UnitPrice;
                int productSumPrice = Convert.ToInt32(productPrice) * productCount;
                UCtrlShowItemsInCart uCtrl = CFunctions.AddOrderToUCtrl(productPhoto, productName, productPrice, productCount,productSumPrice);
                flpProductInCart.Controls.Add(uCtrl);
            }
            else
            {
                List<UCtrlShowItemsInCart> list = CFunctions.AddOrderToUCtrlInCartForm(memberID);
                foreach (var i in list)
                {
                    flpProductInCart.Controls.Add(i);
                }
            }
            foreach (UCtrlShowItemsInCart uCtrl in flpProductInCart.Controls)
            {
                foreach (Control control in uCtrl.Controls)
                {
                    if (control.GetType() == typeof(Button))
                    {
                        Button button = (Button)control;
                        button.Click += btnDelete_Click;
                    }
                    else if (control.GetType() == typeof(NumericUpDown))
                    {
                        NumericUpDown numericUpDown = (NumericUpDown)control;
                        numericUpDown.ValueChanged += nudCount_ValueChanged;
                    }
                    else if (control.GetType() == typeof(CheckBox))
                    {
                        CheckBox checkBox = (CheckBox)control;
                        checkBox.CheckedChanged += CheckBox_CheckedChanged;
                    }
                    else
                    {
                        continue;
                    }
                }
            }
        }

        private void CheckBox_CheckedChanged(object sender, EventArgs e)
        {
            int totalPrice = 0;
            CheckBox checkBox = (CheckBox)sender;
            foreach (UCtrlShowItemsInCart uCtrl in flpProductInCart.Controls)
            {
                if (uCtrl.IsChecked)
                {
                    totalPrice += Convert.ToInt32(uCtrl.productSumPrice.Replace("NT$", "").Replace(",", ""));
                }
                else
                {
                    continue;
                }
            }
            lblTotalPrice.Text = totalPrice.ToString("C0");
        }

        private void nudCount_ValueChanged(object sender, EventArgs e)
        {
            NumericUpDown numericUpDown = (NumericUpDown)sender;
            UCtrlShowItemsInCart parent = (UCtrlShowItemsInCart)numericUpDown.Parent;
            int productPrice = int.Parse(parent.productPrice.Replace("NT$", "").Replace(",",""));
            parent.productSumPrice = (Convert.ToInt32(parent.productCount) * productPrice).ToString("C0");

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("確定要刪除此商品嗎?", "是否要刪除?", MessageBoxButtons.YesNoCancel) == DialogResult.Yes)
            {
                if (IsBuyNow)
                {
                    Button button = (Button)sender;
                    flpProductInCart.Controls.Remove(button.Parent);
                }
                else
                {
                    Button button = (Button)sender;
                    int orderDetailID = (button.Parent as UCtrlShowItemsInCart).orderDetailID;
                    var q = dbContext.OrderDetails.Where(i => i.OrderDetailID == orderDetailID).Select(i => i).FirstOrDefault();
                    int quantity = q.Quantity;
                    int productDetailID = q.ProductDetailID;
                    CFunctions.UpgradeQuantity(productDetailID, quantity);
                    int orderID = q.OrderID;
                    dbContext.OrderDetails.Remove(q);
                    dbContext.SaveChanges();
                    var q1 = dbContext.OrderDetails.Where(i => i.OrderID == orderID).Select(i => i).ToList();
                    if (q1.Count < 1)
                    {
                        var q2 = dbContext.Orders.Where(i => i.OrderID == orderID).Select(i => i).FirstOrDefault();
                        dbContext.Orders.Remove(q2);
                        dbContext.SaveChanges();
                    }
                    flpProductInCart.Controls.Remove(button.Parent);
                }
            }
            else
            {
                return;
            }
        }

        private void cbChooseAll_CheckedChanged(object sender, EventArgs e)
        {
            if (cbChooseAll.Checked)
            {
                foreach (UCtrlShowItemsInCart cCtrl in flpProductInCart.Controls)
                {

                }
            }
        }
    }
}
