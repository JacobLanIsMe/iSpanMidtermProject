using prjProject.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
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
        int memberID = 0;
        private void CartForm_Load(object sender, EventArgs e)
        {
            memberID = CFunctions.GetMemberInfoFromHomePage();
            CFunctions.ShowMemberInfoAtHeader(memberID, out string memberName, out int productNumInCart);
            lblWelcome.Text = memberName;
            lblProductNumInCart.Text = productNumInCart.ToString();
            if (IsBuyNow)
            {

            }
            else
            {
                List<UCtrlShowItemsInCart> list = CFunctions.AddProductToUCtrlInCartForm(memberID);
                foreach (var i in list)
                {
                    flowLayoutPanel1.Controls.Add(i);
                    foreach (Control control in i.Controls)
                    {
                        if (control.GetType() == typeof(Button))
                        {
                            Button button = (Button)control;
                            button.Click += btnDelete_Click;
                        }
                        else
                        {
                            continue;
                        }
                    }
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("確定要刪除此商品嗎?", "是否要刪除?", MessageBoxButtons.YesNoCancel) == DialogResult.Yes)
            {
                Button button = (Button)sender;
                int orderDetailID = (button.Parent as UCtrlShowItemsInCart).orderDetailID;
                var q = dbContext.OrderDetails.Where(i => i.OrderDetailID == orderDetailID).Select(i => i).FirstOrDefault();
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
                flowLayoutPanel1.Controls.Remove(button.Parent);
            }
            else
            {
                return;
            }
        }
    }
}
