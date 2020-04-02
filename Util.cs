using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using asp.net_core_angular.Data.entity;
using asp.net_core_angular.Model;

namespace asp.net_core_angular
{
    public class Util
    {
        public static AddressModel convertAddressEntityToModel(Address addressEntity) {
            AddressModel address = new AddressModel() { 
                address = addressEntity.address,
                city = addressEntity.city,
                country = addressEntity.country,
                phone = addressEntity.phone,
                state = addressEntity.state,
                zip = addressEntity.zip
            };
            return address;
        }

        public static CustomerModel convertCustomerEntityToModel(Customer customerEntity) {
            CustomerModel customer = new CustomerModel() {
                address = convertAddressEntityToModel(customerEntity.address),
                email = customerEntity.email,
                firstName = customerEntity.firstName,
                lastName = customerEntity.lastName,
                id = customerEntity.id
            };
            return customer;
        }

        public static OrderItemModel convertOrderItemEntityToModel(OrderItem orderItemEntity) {
            OrderItemModel orderItem = new OrderItemModel() { 
                discount=orderItemEntity.discount,
                quantity = orderItemEntity.quantity,
                unitPrice = orderItemEntity.price,
                productId = orderItemEntity.product.id,
                productName = orderItemEntity.product.name
            };
            return orderItem;

        }

        public static OrderModel convertOrderEntityToModel(Order orderEntity) {
            OrderModel order = new OrderModel() { 
                id = orderEntity.id,
                customer = convertCustomerEntityToModel(orderEntity.customer),
                shippedAddress = convertAddressEntityToModel(orderEntity.address),
                orderDate = orderEntity.orderDate,
                paidDate = orderEntity.paidDate,
                shippedDate = orderEntity.shippedDate,
                paymentType = orderEntity.paymentType,
                orderStatus = orderEntity.orderStatus.status,
                shippingFee = orderEntity.shippingFee,
                taxes = orderEntity.taxes,
                orderItems = orderEntity.orderItems.ConvertAll((orderItemEntity) => convertOrderItemEntityToModel(orderItemEntity))
            };
            return order;
        }
    }
}
