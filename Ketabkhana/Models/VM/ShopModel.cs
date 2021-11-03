using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Ketabkhana.Models.VM
{
    public class ShopModel
    {
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
    }
}