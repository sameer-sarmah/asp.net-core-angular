using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using System.Text.Json.Serialization;

namespace asp.net_core_angular.Model
{
   public class OrderModel
    {
        public int id { get; set; }

        public CustomerModel customer { get; set; }
        [JsonPropertyName("shippedAddress")]
        public AddressModel shippedAddress { get; set; }

        public string orderStatus { get; set; }

        public DateTime orderDate { get; set; }

        public DateTime shippedDate { get; set; }

        public DateTime paidDate { get; set; }

        public double shippingFee { get; set; }

        public double taxes { get; set; }

        public string paymentType { get; set; }

        public List<OrderItemModel> orderItems { get; set; }
    }
}
