using pgjMidtermProject;
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
    public partial class BigTypeForm : Form
    {
        public BigTypeForm()
        {
            InitializeComponent();
        }
        public int bigTypeID { get; set; }
        iSpanProjectEntities dbContext = new iSpanProjectEntities();
        private void BigTypeForm_Load(object sender, EventArgs e)
        {
            var q = dbContext.SmallTypes.Where(i => i.BigTypeID == bigTypeID).Select(i => i);
            foreach (var p in q)
            {
                LinkLabel linkLabel = new LinkLabel();
                linkLabel.Text = p.SmallTypeName;
                linkLabel.LinkColor = Color.Black;
                linkLabel.Margin = new Padding(0, 0, 0, 20);
                flpSmallType.Controls.Add(linkLabel);
                linkLabel.Click += SmallType_Click;
            }
            var q1 = dbContext.Products.Where(i => i.SmallType.BigTypeID == bigTypeID).Select(i => i);
            List<CtrlDisplayItem> productList = CFunctions.GetProductsForShow(q1);
            foreach (var p in productList)
            {
                flpProduct.Controls.Add(p);
                p.Click += CtrlDisplayItem_Click;
                foreach (Control control in p.Controls)
                {
                    control.Click += CtrlDisplayItem_Click;
                }
            }
        }

        private void CtrlDisplayItem_Click(object sender, EventArgs e)
        {
            int productID = -1;
            CFunctions.ClickItemAndShow(sender, out productID);
            SelectedProductForm form = new SelectedProductForm();
            form.productID = productID;
            form.ShowDialog();
        }

        private void SmallType_Click(object sender, EventArgs e)
        {
            
        }
    }
}
