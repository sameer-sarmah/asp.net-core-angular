using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using asp.net_core_angular.Model;
using asp.net_core_angular.Services.api;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace asp.net_core_angular.Controllers
{
    [Route("api/order")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private IOrderService orderService;

        public OrderController(IOrderService orderService)
        {
            this.orderService = orderService;
        }

        [HttpGet("{orderId}")]
        public OrderModel GetOrderById(string orderId) {
            return orderService.GetOrder(orderId);
        }
        [HttpGet]
        public List<OrderModel> GetOrders()
        {
            return orderService.GetOrders();
        }
    }
}