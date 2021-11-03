using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Ketabkhana.Models.VM
{
    public class BookModel
    {

        public int id { get; set; }

        [Required(ErrorMessage = "Please enter Book Title"), MaxLength(50), MinLength(2)]
        public string bookTitle { get; set; }

        [Required(ErrorMessage = "Please enter Book Author's Name"), MaxLength(30), MinLength(2)]
        public string author { get; set; }

        [Required(ErrorMessage = "Please enter Book Puslisher's Name"), MaxLength(30), MinLength(2)]
        public string publisher { get; set; }

        [Required(ErrorMessage = "Please enter Book Edition"), MaxLength(10)]
        public string edition { get; set; }

        [Required, DataType(DataType.Currency)]
        public double price { get; set; }

        public int shopId { get; set; }

        [Required]
        public int quantity { get; set; }
        public string thumbnail { get; set; }

    }
}