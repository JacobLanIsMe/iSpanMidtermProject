using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pgjMidtermProject.models
{
    public class CShowItemsInCart
    {
        public Image itemPhoto { get; set; }
        public string itemName { get; set; }
        public string itemStyle { get; set; }
        public decimal itemUnitPrice { get; set; }
        public int itemQty { get; set; }
        public string summary { get; set; }
        //public Button delete { get; set; }
    }
}
