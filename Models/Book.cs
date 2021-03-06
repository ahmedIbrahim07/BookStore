//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace BookStore.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Book
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Book()
        {
            this.AddToCarts = new HashSet<AddToCart>();
            this.Orders = new HashSet<Order>();
        }
    
        public int ISBN { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string Version { get; set; }
        public string Lang { get; set; }
        public decimal Price { get; set; }
        public string Year { get; set; }
        public int Stock { get; set; }
        public int Publisher_ID { get; set; }
        public string IMG { get; set; }
        public string Coclusion { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<AddToCart> AddToCarts { get; set; }
        public virtual Publisher Publisher { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Order> Orders { get; set; }
    }
}
