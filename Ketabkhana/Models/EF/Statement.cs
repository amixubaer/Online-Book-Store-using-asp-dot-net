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

    public partial class Statement
    {
        public int id { get; set; }

        [Required]
        public string date { get; set; }
        
        [Required(ErrorMessage = "Please enter expenditure")]
        public string expenditure { get; set; }

        [Required(ErrorMessage = "Please enter amount"), DataType(DataType.Currency)]
        public double amount { get; set; }
    }
}
