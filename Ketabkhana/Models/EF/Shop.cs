//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Ketabkhana.Models.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class Shop
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Shop()
        {
            this.Books = new HashSet<Book>();
            this.OrderDetails = new HashSet<OrderDetail>();
        }
    
        public int id { get; set; }

        [Required(ErrorMessage = "Please enter Shop Name"), MaxLength(30), MinLength(2)]
        public string shopName { get; set; }

        [Required(ErrorMessage = "Please enter Shop Address"), MaxLength(100)]
        public string shopAddress { get; set; }

        [Required(ErrorMessage = "Please enter Username"), MaxLength(30), MinLength(4)]
        public string username { get; set; }

        [Required(ErrorMessage = "Please enter Email"), MaxLength(30)]
        [RegularExpression(@"^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$", ErrorMessage = "Email is not valid.")]
        public string email { get; set; }

        [Required(ErrorMessage = "Please enter Password"), MaxLength(15), MinLength(4)]
        public string password { get; set; }


    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Book> Books { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
    }
}