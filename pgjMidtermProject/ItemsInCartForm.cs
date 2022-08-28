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
    public partial class ItemsInCartForm : Form
    {
        public ItemsInCartForm()
        {
            InitializeComponent();
        }
        iSpanProjectEntities dbContext = new iSpanProjectEntities();
        private int memberID;
        List<CShowItemsInCart> itemList = new List<CShowItemsInCart>();
        private void ItemsInCartForm_Load(object sender, EventArgs e)
        {
            CFunctions.MemberInfoFromMainForm(out string login, out string welcome, out string itemNumInCart, out memberID);
            lblWelcome.Text = welcome;
            linkLabelLogin.Text = login;
            lblItemNumInCart.Text = itemNumInCart;
            var q1 = dbContext.Orders.Where(i => i.MemberID == memberID && i.StatusID == 1).Select(i => i);
            foreach (var item in q1)
            {
                var q2 = dbContext.ProductDetails.Where(i => i.ProductID == item.ProductID).Select(i => i).FirstOrDefault();
                var q3 = dbContext.OrderDetails.Where(i => i.OrderID == item.OrderID && i.ProductDetailID == q2.ProductDetailID).Select(i => i.Quantity).FirstOrDefault();
                MemoryStream ms = new MemoryStream(q2.Pic);

                CShowItemsInCart cShowItemsInCart = new CShowItemsInCart
                {
                    itemPhoto = Image.FromStream(ms),
                    itemName = q2.Product.ProductName,
                    itemStyle = q2.Style,
                    itemUnitPrice = q2.UnitPrice,
                    itemQty = q3,
                    summary = (q2.UnitPrice * q3).ToString("0"),
                    delete = "刪除",
                };
                itemList.Add(cShowItemsInCart);
            }
            dataGridView1.DataSource = itemList;



        }
    }
}
