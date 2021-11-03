using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ketabkhana.Models.VM
{
    public class OrderDetailModel
    {

        public int id { get; set; }

        public int bookId { get; set; }
        public int orderId { get; set; }
        public int shopId { get; set; }
        public double unitPrice { get; set; }
        public int quantity { get; set; }
    }
}