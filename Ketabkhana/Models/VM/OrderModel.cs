using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Ketabkhana.Models.VM
{
    public class OrderModel
    {
        public int id { get; set; }

        public double amount { get; set; }

        public string status { get; set; }

        public int customerId { get; set; }
    }
}