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

        
    }
}
