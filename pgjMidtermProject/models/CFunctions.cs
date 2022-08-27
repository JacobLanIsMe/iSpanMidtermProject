using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pgjMidtermProject.models
{
    public class CFunctions
    {
        public static void MemberInfoFromMainForm(out string login, out string welcome, out string itemNumInCart)
        {
            login = "";
            welcome = "";
            itemNumInCart = "";
            foreach (Form form in Application.OpenForms)
            {
                if (form.GetType() == typeof(MainForm))
                {
                    MainForm f = (MainForm)form;
                    login = "會員資料";
                    welcome = f.welcome;
                    itemNumInCart = f.itemNumInCart;
                    return;
                }
            }
        }

        
    }
}
