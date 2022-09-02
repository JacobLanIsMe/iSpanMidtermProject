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

        public static List<CtrlDisplayItem> GetProductsForShow(IQueryable<Product> q)
        {
            iSpanProjectEntities dbContext = new iSpanProjectEntities();
            List<CtrlDisplayItem> list = new List<CtrlDisplayItem>();
            
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
        
        public static void SendMemberInfoToEachForm(int memberID)
        {
            iSpanProjectEntities dbContext = new iSpanProjectEntities();
            var q = dbContext.MemberAccounts.Where(i => i.MemberID == memberID).Select(i => i).FirstOrDefault();
            var productNumInCart = dbContext.OrderDetails.Where(i => i.Order.MemberID == memberID && i.Order.StatusID == 1).Select(i => i).ToList().Count;
            foreach (Form form in Application.OpenForms)
            {
                if (form.GetType() == typeof(MainForm))
                {
                    MainForm f = (MainForm)form;
                    f.memberName = q.Name;
                    f.ProductNumInCart = productNumInCart.ToString();
                    f.memberID = memberID;
                }
                else if (form.GetType() == typeof(SelectedProductForm))
                {
                    SelectedProductForm f = (SelectedProductForm)form;
                    f.memberID = memberID;
                    f.memberName = q.Name;
                    f.ProductNumInCart = productNumInCart.ToString();
                    f.memberRegion = q.RegionList.Region;
                }
                else
                {
                    continue;
                }
            }
        }
        
        public static void AddToCart(COrderInfo orderInfo, int memberID)
        {
            iSpanProjectEntities dbContext = new iSpanProjectEntities();
            var q = dbContext.Orders.Where(i => i.MemberID == memberID && i.StatusID == 1).Select(i => i).ToList();
            if (q.Count > 0)
            {
                OrderDetail orderDetail = new OrderDetail
                {
                    OrderID = q[0].OrderID,
                    ProductDetailID = orderInfo.ProductDetailID,
                    ShipperID = orderInfo.ShipperID,
                    Quantity = orderInfo.Quantity,
                    ShippingDate = orderInfo.ShippingDate,
                    RecieveDate = orderInfo.RecieveDate,
                    OutAdr = orderInfo.OutAdr,
                    ShippingStatusID = orderInfo.ShippingStatusID,
                };
                dbContext.OrderDetails.Add(orderDetail);
                dbContext.SaveChanges();
            }
            else
            {
                Order order = new Order
                {
                    MemberID = orderInfo.MemberID,
                    OrderDatetime = orderInfo.OrderDatetime,
                    RecieveAdr = orderInfo.RecieveAdr,
                    FinishDate = orderInfo.FinishDate,
                    CouponID = orderInfo.CouponID,
                    StatusID = 1
                };
                dbContext.Orders.Add(order);
                dbContext.SaveChanges();
                int orderID = dbContext.Orders.Where(i => i.MemberID == orderInfo.MemberID && i.StatusID == 1).Select(i => i.OrderID).FirstOrDefault();
                OrderDetail orderDetail = new OrderDetail
                {
                    OrderID = orderID,
                    ProductDetailID = orderInfo.ProductDetailID,
                    ShipperID = orderInfo.ShipperID,
                    Quantity = orderInfo.Quantity,
                    ShippingDate = orderInfo.ShippingDate,
                    RecieveDate = orderInfo.RecieveDate,
                    OutAdr = orderInfo.OutAdr,
                    ShippingStatusID = orderInfo.ShippingStatusID,
                };
                dbContext.OrderDetails.Add(orderDetail);
                dbContext.SaveChanges();
            }
        }
        public static int UpgradeQuantity(int productDetailID, int count)
        {
            iSpanProjectEntities dbContext = new iSpanProjectEntities();
            var q = dbContext.ProductDetails.Where(i => i.ProductDetailID == productDetailID).Select(i => i).FirstOrDefault();
            q.Quantity += count;
            dbContext.SaveChanges();
            var q1= dbContext.ProductDetails.Where(i => i.ProductDetailID == productDetailID).Select(i => i).FirstOrDefault();
            int latestQuantity = q1.Quantity;
            return latestQuantity;
        }

        public static void ShowMemberInfoAtHeader(int memberID, out string memberName, out int productNumInCart)
        {
            iSpanProjectEntities dbContext = new iSpanProjectEntities();
            memberName = dbContext.MemberAccounts.Where(i => i.MemberID == memberID).Select(i => i.Name).FirstOrDefault();
            productNumInCart = dbContext.OrderDetails.Where(i => i.Order.MemberID == memberID).Select(i => i).ToList().Count;
        }

        public static List<UCtrlShowItemsInCart> AddProductToUCtrlInCartForm(int memberID)
        {
            iSpanProjectEntities dbContext = new iSpanProjectEntities();
            List<UCtrlShowItemsInCart> list = new List<UCtrlShowItemsInCart>();
            int orderID = dbContext.Orders.Where(i => i.MemberID == memberID && i.StatusID == 1).Select(i => i.OrderID).FirstOrDefault();
            var q = dbContext.OrderDetails.Where(i => i.OrderID == orderID).Select(i => i);
            foreach (var p in q)
            {
                byte[] bytes = p.ProductDetail.Pic;
                MemoryStream ms = new MemoryStream(bytes);
                Image image = Image.FromStream(ms);
                string productName = p.ProductDetail.Product.ProductName;
                string productStyle = p.ProductDetail.Style;
                decimal productPrice = p.ProductDetail.UnitPrice;
                int productCount = p.Quantity;
                int productQuantity = p.ProductDetail.Quantity;
                int sumPrice = Convert.ToInt32(productPrice) * productCount;
                int orderDetailID = p.OrderDetailID;
                UCtrlShowItemsInCart uCtrl = new UCtrlShowItemsInCart
                {
                    orderDetailID = orderDetailID,
                    productPhoto = image,
                    productName = $"{productName} - {productStyle}",
                    productPrice = $"{productPrice.ToString("C0")}",
                    productCount = productCount,
                    nudCountMaxValue = productQuantity,
                    productSumPrice = $"{sumPrice.ToString("C0")}"
                };
                list.Add(uCtrl);
            }
            return list;
        }
        public static bool IsAllInfoChecked(int productDetailID, string productRegion, decimal nudCountValue, out int detailID, out string outAdr, out int qty)
        {
            detailID = 0;
            outAdr = "";
            qty = 0;
            if (productDetailID == 0 || productRegion == "")
            {
                MessageBox.Show("請選擇一個樣式");
                return false;
            }
            else
            {
                detailID = productDetailID;
                outAdr = productRegion;
            }
            if (nudCountValue == 0)
            {
                MessageBox.Show("請選擇訂購的數量");
                return false;
            }
            else
            {
                qty = Convert.ToInt32(nudCountValue);
            }
            return true;
        }

    }
}
