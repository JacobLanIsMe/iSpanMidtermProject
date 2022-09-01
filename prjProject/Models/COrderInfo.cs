using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace prjProject.Models
{
    public class COrderInfo
    {
        public int MemberID { get;set; }
        public DateTime OrderDatetime { get; set; }
        public string RecieveAdr { get; set; }
        public DateTime FinishDate { get; set; }
        public int CouponID { get; set; }
        public int StatusID { get; set; }
        public int ProductDetailID { get; set; }
        public int ShipperID { get; set; }
        public int Quantity { get; set; }
        public DateTime ShippingDate { get; set; }
        public DateTime RecieveDate { get; set; }
        public string OutAdr { get; set; }
        public int ShippingStatusID { get; set; }
    }
}
