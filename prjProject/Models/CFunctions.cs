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
    }
}
