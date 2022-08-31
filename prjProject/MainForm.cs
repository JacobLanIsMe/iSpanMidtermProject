using pgjMidtermProject;
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
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }
        iSpanProjectEntities dbContext = new iSpanProjectEntities();
        private void MainForm_Load(object sender, EventArgs e)
        {
            IQueryable<Product> q = dbContext.Products.Select(i => i);
            foreach (var p in q)
            {
                CtrlDisplayItem ctrlDisplayItem = new CtrlDisplayItem();
                var q1 = dbContext.ProductPics.Where(i => i.ProductID == p.ProductID).Select(i=>i.picture).FirstOrDefault();
                ctrlDisplayItem.productID = p.ProductID;
                if (q1 != null)
                {
                    MemoryStream ms = new MemoryStream(q1);
                    ctrlDisplayItem.itemPhoto = Image.FromStream(ms);
                }
                var q2 = dbContext.ProductDetails.Where(i => i.ProductID == p.ProductID).OrderBy(i=>i.UnitPrice).Select(i => i.UnitPrice).ToList();
                if (q2.Count > 0)
                {
                    decimal maxPrice = q2[q2.Count - 1];
                    decimal minPrice = q2[0];
                    if (maxPrice == minPrice)
                    {
                        ctrlDisplayItem.itemPrice = $"${minPrice}";
                    }
                    else
                    {
                        ctrlDisplayItem.itemPrice = $"${minPrice} - ${maxPrice}";
                    }
                }
                ctrlDisplayItem.itemName = p.ProductName;
                ctrlDisplayItem.itemDescription = p.Description;
                flowLayoutPanel1.Controls.Add(ctrlDisplayItem);
                ctrlDisplayItem.Click += CtrlDisplayItem_Click;
                foreach (Control control in ctrlDisplayItem.Controls)
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
    }
}
