using ConsoleApp.Models;
using DataAccess;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp.Services
{
    public class CustomerService
    {
        public void AddCustomer(CustomerEntity customerToAdd)
        {
            using (var context = new OnlineShopEntities())
            {
                var newCusomer = new Customer
                {
                    Id = customerToAdd.Id,
                    Firstname = customerToAdd.Firstname,
                    Lastname = customerToAdd.Lastname,
                    PhoneNumber = customerToAdd.PhoneNumber,
                    SecondPhoneNumber = customerToAdd.SecondPhoneNumber,
                    Address = customerToAdd.Address
                };

                context.Customers.Add(newCusomer);
                context.SaveChanges();
            }
        }

        public void UpdateCustomers()
        {
            using (var context = new OnlineShopEntities())
            {
                var customersToUpdate = context.Customers
                                               .Take(2)
                                               .ToList();

                foreach (var customer in customersToUpdate)
                {
                    customer.Lastname = "Ivanov";
                }

                context.SaveChanges();
            }
        }

        public void DeleteCustomers()
        {
            using (var context = new OnlineShopEntities())
            {
                var customersToDel = context
                                       .Customers
                                       .Where(x => x.Lastname == "Ivanov")
                                       .ToList();


                foreach (var customer in customersToDel)
                {
                    var ordersToDelete = context.Orders.Where(o => o.CustomerId == customer.Id);

                    foreach (var order in ordersToDelete)
                    {
                        var orderItemsToDelete = context.OrderItems.Where(oi => oi.OrderId == order.Id);

                        foreach (var orderItem in orderItemsToDelete)
                        {
                            context.OrderItems.Remove(orderItem);
                        }

                        context.Orders.Remove(order);
                    }

                    context.Customers.Remove(customer);
                }

                context.SaveChanges();
            }
        }

        public List<CustomerEntity> SelectCustomers()
        {
            using (var context = new OnlineShopEntities())
            {
                var customers = context.Customers
                                       .OrderBy(x => x.Id)
                                       .Skip(4)
                                       .Select(c => new CustomerEntity
                                       {
                                           Id = c.Id,
                                           Firstname = c.Firstname,
                                           Lastname = c.Lastname,
                                           PhoneNumber = c.PhoneNumber,
                                           SecondPhoneNumber = c.SecondPhoneNumber,
                                           Address = c.Address
                                       })
                                       .ToList();

                return customers;
            }
        }

        public int SumAllCustomers()
        {
            using (var context = new OnlineShopEntities())
            {
                var sum = context.Customers.Count();
                return sum;
            }
        }

        public List<CustomersWithOrders> GetCustomersAndOrders()
        {
            using (var context = new OnlineShopEntities())
            {
                var customersAndOrders = context
                                                .Customers
                                                .Join(context.Orders,
                                                c => c.Id,
                                                o => o.CustomerId,
                                                (c, o) => new CustomersWithOrders
                                                {
                                                    CustomerFullname = c.Firstname + " " + c.Lastname,
                                                    OrderId = o.Id
                                                })
                                                .ToList();

                return customersAndOrders;
            }
        }

        public List<CustomerWithOrWithoutOrders> GetCustomersWithOrWithoutOrders()
        {
            using (var context = new OnlineShopEntities())
            {
                var customersWithOrWithoutOrders = context.Customers
                                                          .GroupJoin(context.Orders,
                                                          c => c.Id,
                                                          o => o.CustomerId,
                                                          (c, orders) => new CustomerWithOrWithoutOrders
                                                          {
                                                              CustomerFullname = c.Firstname + " " + c.Lastname,
                                                              Order = (List<Order>)orders
                                                          })
                                                          .ToList();
                return customersWithOrWithoutOrders;
            }
        }
    }
}
