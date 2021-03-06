﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace asp.net_core_angular.Data.entity
{
    [Table("order_item")]
    public class OrderItem
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("order_id")]
        public Order order { get; set; }

        [ForeignKey("product_id")]
        public Product product { get; set; }

        public double quantity { get; set; }
        [Column(name: "unit_price")]

        public double price { get; set; }
        public double discount { get; set; }


    }
}
