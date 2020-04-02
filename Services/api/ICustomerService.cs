using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using asp.net_core_angular.Data.entity;
using asp.net_core_angular.Model;

namespace asp.net_core_angular.Services.api
{
    public interface ICustomerService
    {
        public CustomerModel GetCustomer(string customerId);
    }
}
