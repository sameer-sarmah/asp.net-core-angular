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
    public class CustomerService : ICustomerService
    {
        private OrderContext orderContext;

        public CustomerService(OrderContext orderContext)
        {
            this.orderContext = orderContext;
        }

        public CustomerModel GetCustomer(string customerId)
        {
            Customer entity = orderContext.Customer
                .Include(customer => customer.address)
                .Where(customer => customer.id == int.Parse(customerId))
                .First();
            return Util.convertCustomerEntityToModel(entity);
        }
    }
}
