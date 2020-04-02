using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using asp.net_core_angular.Data.entity;
using asp.net_core_angular.Data.repository;
using asp.net_core_angular.Model;
using asp.net_core_angular.Services.api;
using Microsoft.EntityFrameworkCore;

namespace asp.net_core_angular.Services.impl
{
    public class OrderService : IOrderService
    {
        private OrderContext orderContext;

        public OrderService(OrderContext orderContext)
        {
            this.orderContext = orderContext;
        }

        public OrderModel GetOrder(string orderId)
        {
            Order entity = orderContext.Order
                .Include(order => order.orderStatus)
                .Include(order => order.employee)
                .Include(order => order.customer)
                .Include(order => order.orderItems)
                .ThenInclude(orderItem => orderItem.product)
                .Where(order => order.id == int.Parse(orderId))
                .First();
            return Util.convertOrderEntityToModel(entity);
        }

        public List<OrderModel> GetOrders()
        {
             List<Order> entities = orderContext.Order
                .Include(order => order.orderStatus)
                .Include(order => order.employee)
                .Include(order => order.address)
                .Include(order => order.customer)
                .ThenInclude(customer => customer.address)
                .Include(order => order.orderItems)
                .ThenInclude(orderItem => orderItem.product)
                .ToList();
            return entities.ConvertAll(( order )=> Util.convertOrderEntityToModel(order) );
        }
    }
}
