using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pgjMidtermProject.models
{
    public class CFunctions
    {

        
        public static void MemberInfoFromMainForm(out string login, out string welcome, out string itemNumInCart, out int memberID)
        {
            login = "";
            welcome = "";
            itemNumInCart = "";
            memberID = -1;
            foreach (Form form in Application.OpenForms)
            {
                if (form.GetType() == typeof(MainForm))
                {
                    MainForm f = (MainForm)form;
                    login = f.memberName;
                    welcome = f.welcome;
                    itemNumInCart = f.itemNumInCart;
                    memberID = f.memberID;
                    return;
                }
            }
        }
        public static void ShowTheCountOfItemsInCart(int memberID)
        {
            iSpanProjectEntities dbContext = new iSpanProjectEntities();
            var q = dbContext.Orders.Where(i => i.MemberID == memberID && i.StatusID == 1).Select(i => i).ToList().Count;
            if (q > 0)
            {
                foreach (Form form in Application.OpenForms)
                {
                    if (form.GetType() == typeof(MainForm))
                    {
                        MainForm f = (MainForm)form;
                        f.itemNumInCart = q.ToString();
                    }
                    else if (form.GetType() == typeof(BrowseItemsForm))
                    {
                        BrowseItemsForm f = (BrowseItemsForm)form;
                        f.itemNumInCart = q.ToString();
                    }
                    else if (form.GetType() == typeof(ItemsInCartForm))
                    {
                        ItemsInCartForm f = (ItemsInCartForm)form;
                        f.itemNumInCart = q.ToString();
                    }
                    else
                    {
                        continue;
                    }
                }
            }
            
        }
        public static bool IsMemberInfoAllFill(int memberID, string account, string name, string email, string phone, string region, string address, string biography, string pwd, string pwdConfirm, Image image, RadioButton domestic, RadioButton foreign)
        {
            iSpanProjectEntities dbContext = new iSpanProjectEntities();
            var q1 = dbContext.MemberAccounts.Where(i => i.MemberID == memberID).Select(i => i).FirstOrDefault();
            var q = dbContext.MemberAccounts.Where(i => i.MemberAcc == account).Select(i => i).ToList();
            if (account == "" || name == "" || email == "" || phone == "" || region == "" || address == "" || biography == "" || image == null)
            {
                MessageBox.Show("資料未填妥");
                return false;
            }
            else if ((q.Count > 0 && memberID == -1) || (q.Count > 0 && q1.MemberAcc!=account))
            {
                MessageBox.Show("此帳號已被註冊過了");
                return false;
            }
            else if (pwd != pwdConfirm)
            {
                MessageBox.Show("密碼輸入不同");
                return false;
            }
            else if (domestic.Checked==false && foreign.Checked == false)
            {
                MessageBox.Show("請選擇國內或國外");
                return false;
            }
            else
            {
                return true;
            }
        }
        public static void ClickItemAndShow(Object sender, out int productID)
        {
            Control c = sender as Control;
            iSpanProjectEntities dbContext = new iSpanProjectEntities();
            CtrlDisplayItem ctrlDisplayItem;
            if (c.Parent.GetType() == typeof(CtrlDisplayItem))
            {
                ctrlDisplayItem = c.Parent as CtrlDisplayItem;
            }
            else
            {
                ctrlDisplayItem = c as CtrlDisplayItem;
            }
            string itemName = ctrlDisplayItem.itemName;
            string itemDescription = ctrlDisplayItem.itemDescription;
            productID = dbContext.Products.Where(i => i.ProductName == itemName && i.Description == itemDescription).Select(i => i.ProductID).FirstOrDefault();
        }
    }
}
