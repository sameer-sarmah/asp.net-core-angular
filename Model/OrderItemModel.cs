using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace asp.net_core_angular.Model
{
    public class OrderItemModel
    {

        public int productId { get; set; }
        public string productName { get; set; }
        public double quantity { get; set; }
        public double unitPrice { get; set; }
        public double discount { get; set; }


    }
}
