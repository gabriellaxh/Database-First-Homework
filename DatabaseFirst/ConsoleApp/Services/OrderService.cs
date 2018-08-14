using ConsoleApp.Models;
using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.Services
{
    public class OrderService
    {
        public void MakeAnOrder(CustomerEntity customer, ProductEntity product, int quantity)
        {
            using (var context = new OnlineShopEntities())
            {
                var newOrder = new Order()
                {
                    CustomerId = customer.Id
                };

                var newOrderItem = new OrderItem
                {
                    OrderId = newOrder.Id,
                    ProductId = product.Id,
                    Quantity = quantity
                };

                context.Orders.Add(newOrder);
                context.OrderItems.Add(newOrderItem);
                context.SaveChanges();
            }
        }
    }
}
