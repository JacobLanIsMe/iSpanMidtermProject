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
        public bool ShowCartOrBuyNow { get; set; }
        iSpanProjectEntities dbContext = new iSpanProjectEntities();
        private int memberID;
        List<CShowItemsInCart> itemList = new List<CShowItemsInCart>();
        private void ItemsInCartForm_Load(object sender, EventArgs e)
        {
            CFunctions.MemberInfoFromMainForm(out string login, out string welcome, out string itemNumInCart, out memberID);
            lblWelcome.Text = welcome;
            linkLabelLogin.Text = login;
            lblItemNumInCart.Text = itemNumInCart;
            if (ShowCartOrBuyNow)
            {
                int productID = -1;
                int itemQty = 0;
                foreach (Form form in Application.OpenForms)
                {
                    if (form.GetType() == typeof(BrowseItemsForm))
                    {
                        BrowseItemsForm f = (BrowseItemsForm)form;
                        productID = f.productID;
                        itemQty = f.itemQty;
                    }
                }
                var q = dbContext.Products.Where(i => i.ProductID == productID).Select(i => i).FirstOrDefault();
                var q1 = dbContext.ProductDetails.Where(i => i.ProductID == productID).Select(i => i).FirstOrDefault();
                MemoryStream ms = new MemoryStream(q1.Pic);
                CShowItemsInCart cShowItemsInCart = new CShowItemsInCart
                {
                    itemPhoto = Image.FromStream(ms),
                    itemName = q.ProductName,
                    itemStyle = q1.Style,
                    itemUnitPrice = q1.UnitPrice,
                    itemQty = itemQty,
                    summary = (q1.UnitPrice * itemQty).ToString("0"),
                };
                itemList.Add(cShowItemsInCart);
                dataGridView1.DataSource = itemList;
            }
            else
            {
                var q1 = dbContext.Orders.Where(i => i.MemberID == memberID && i.StatusID == 1).Select(i => i);
                foreach (var item in q1)
                {
                    var q2 = dbContext.ProductDetails.Where(i => i.ProductID == item.ProductID).Select(i => i).FirstOrDefault();
                    var q3 = dbContext.OrderDetails.Where(i => i.OrderID == item.OrderID && i.ProductDetailID == q2.ProductDetailID).Select(i => i.Quantity).FirstOrDefault();
                    MemoryStream ms = new MemoryStream(q2.Pic);
                    //Button btnDelete = new Button();
                    //btnDelete.Text = "刪除";
                    //btnDelete.Click += BtnDelete_Click;
                    CShowItemsInCart cShowItemsInCart = new CShowItemsInCart
                    {
                        itemPhoto = Image.FromStream(ms),
                        itemName = q2.Product.ProductName,
                        itemStyle = q2.Style,
                        itemUnitPrice = q2.UnitPrice,
                        itemQty = q3,
                        summary = (q2.UnitPrice * q3).ToString("0"),
                        //delete = btnDelete,
                    };
                    itemList.Add(cShowItemsInCart);
                }
                dataGridView1.DataSource = itemList;
                DataGridViewButtonColumn button = new DataGridViewButtonColumn();
                button.Text = "刪除";
                button.HeaderText = "刪除";
                button.Name = "btnDelete";
                int columnIndex = 6;
                if (dataGridView1.Columns["btnDelete"] == null)
                {
                    dataGridView1.Columns.Insert(columnIndex, button);
                }
                dataGridView1.CellClick += DataGridView1_CellClick;
            }
        }

        private void DataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dataGridView1.Columns["btnDelete"].Index)
            {
                DialogResult result = MessageBox.Show("是否確定要刪除此商品?", "是否要刪除", MessageBoxButtons.YesNoCancel);
                if (result == DialogResult.Yes)
                {
                    string productName = dataGridView1.CurrentRow.Cells["itemName"].Value.ToString();
                    int productID = dbContext.Products.Where(i => i.ProductName == productName).Select(i => i.ProductID).FirstOrDefault();
                    var q = dbContext.Orders.Where(i => i.MemberID == memberID && i.StatusID == 1 && i.ProductID == productID).Select(i => i).FirstOrDefault();

                    string style = dataGridView1.CurrentRow.Cells["itemStyle"].Value.ToString();
                    int productDetailID = dbContext.ProductDetails.Where(i => i.ProductID == productID && i.Style == style).Select(i => i.ProductDetailID).FirstOrDefault();
                    var q2 = dbContext.OrderDetails.Where(i => i.ProductDetailID == productDetailID && i.OrderID == q.OrderID).Select(i => i).FirstOrDefault();
                    dbContext.Orders.Remove(q);
                    dbContext.SaveChanges();
                    dbContext.OrderDetails.Remove(q2);
                    dbContext.SaveChanges();
                    int index = dataGridView1.CurrentRow.Index;

                    itemList.RemoveAt(index);
                    var list = new BindingList<CShowItemsInCart>(itemList);
                    dataGridView1.DataSource = list;
                }
            }
        }

        private void btnOrder_Click(object sender, EventArgs e)
        {

        }
    }
}
