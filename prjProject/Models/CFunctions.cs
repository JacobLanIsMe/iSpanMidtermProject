using pgjMidtermProject;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace prjProject.Models
{
    public class CFunctions
    {

        public static void ClickItemAndShow(Object sender, out int productID)
        {
            Control c = sender as Control;
            CtrlDisplayItem ctrlDisplayItem;
            if (c.Parent.GetType() == typeof(CtrlDisplayItem))
            {
                ctrlDisplayItem = c.Parent as CtrlDisplayItem;
            }
            else
            {
                ctrlDisplayItem = c as CtrlDisplayItem;
            }
            productID = ctrlDisplayItem.productID;
        }

        public static List<CtrlDisplayItem> GetProductsForHomePage()
        {
            iSpanProjectEntities dbContext = new iSpanProjectEntities();
            List<CtrlDisplayItem> list = new List<CtrlDisplayItem>();
            var q = dbContext.Products.Select(i => i);
            foreach (var p in q)
            {
                var q1 = dbContext.ProductPics.Where(i => i.ProductID == p.ProductID).Select(i => i.picture).FirstOrDefault();
                var q2 = dbContext.ProductDetails.Where(i => i.ProductID == p.ProductID).OrderBy(i => i.UnitPrice).Select(i => i.UnitPrice).ToList();
                byte[] image = null;
                if (q1 != null)
                {
                    image = q1;
                }
                string productUnitPrice = "";
                if (q2.Count > 0)
                {
                    decimal maxPrice = q2[q2.Count - 1];
                    decimal minPrice = q2[0];
                    if (maxPrice == minPrice)
                    {
                        productUnitPrice = $"{minPrice.ToString("C0")}";
                    }
                    else
                    {
                        productUnitPrice = $"{minPrice.ToString("C0")} - {maxPrice.ToString("C0")}";
                    }
                }
                string productName = p.ProductName;
                string productDescription = p.Description;
                int productID = p.ProductID;
                CtrlDisplayItem ctrlDisplayItem = CFunctions.AddProductInfoToUserControl(productID, productName, productUnitPrice, productDescription, image);
                list.Add(ctrlDisplayItem);
            }
            return list;
        }

        public static CtrlDisplayItem AddProductInfoToUserControl(int productID, string productName, string productUnitPrice, string productDescription, byte[] image = null, int quantity = 1)
        {
            Image img = null;
            if (image != null)
            {
                MemoryStream ms = new MemoryStream(image);
                img = Image.FromStream(ms);
            }
            
            string qty = "";
            if (quantity == 0)
            {
                qty = "已售完";
            }
            CtrlDisplayItem ctrlDisplayItem = new CtrlDisplayItem
            {
                productID = productID,
                itemName = productName,
                itemPrice = productUnitPrice,
                itemDescription = productDescription,
                itemPhoto = img,
                SoldOut = qty,
            };
            return ctrlDisplayItem;
        }
        public static int GetMemberInfoFromHomePage()
        {
            int memberID = -1;
            foreach (Form form in Application.OpenForms)
            {
                if (form.GetType() == typeof(MainForm))
                {
                    MainForm f = (MainForm)form;
                    memberID = f.memberID;
                }
            }
            return memberID;
        }
        




    }
}
