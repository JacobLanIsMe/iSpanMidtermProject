using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pgjMidtermProject.models
{
    public class CProduct
    {
        public string name { get; set; }
        public string smallType { get; set; }
        public string region { get; set; }
        public string adFee { get; set; }
        public string description { get; set; }
        public string shipper { get; set; }
        public string style { get; set; }
        public int quantity { get; set; }
        public decimal unitPrice { get; set; }
        public byte[] picture { get; set; }
    }
}
