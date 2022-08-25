//------------------------------------------------------------------------------
// <auto-generated>
//     這個程式碼是由範本產生。
//
//     對這個檔案進行手動變更可能導致您的應用程式產生未預期的行為。
//     如果重新產生程式碼，將會覆寫對這個檔案的手動變更。
// </auto-generated>
//------------------------------------------------------------------------------

namespace pgjMidtermProject
{
    using System;
    using System.Collections.Generic;
    
    public partial class Product
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Product()
        {
            this.Comments = new HashSet<Comment>();
            this.Likes = new HashSet<Like>();
            this.Orders = new HashSet<Order>();
            this.ProductDetails = new HashSet<ProductDetail>();
            this.ProductPics = new HashSet<ProductPic>();
        }
    
        public int ProductID { get; set; }
        public string CourtName { get; set; }
        public int SmallTypeID { get; set; }
        public int EventID { get; set; }
        public int MemberID { get; set; }
        public int RegionID { get; set; }
        public decimal AdFee { get; set; }
        public string Description { get; set; }
        public int ShipperID { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Comment> Comments { get; set; }
        public virtual EventToProduct EventToProduct { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Like> Likes { get; set; }
        public virtual MemberAccount MemberAccount { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Order> Orders { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ProductDetail> ProductDetails { get; set; }
        public virtual Shipper Shipper { get; set; }
        public virtual SmallType SmallType { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ProductPic> ProductPics { get; set; }
        public virtual RegionList RegionList { get; set; }
    }
}
