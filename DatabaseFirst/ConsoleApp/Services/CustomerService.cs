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

        //TODO..
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
                    var orderToDel = context.Orders.Where(x => x.CustomerId == customer.Id).FirstOrDefault();

                    var orderItemToDel = context.OrderItems.Where(x => x.OrderId == orderToDel.Id).FirstOrDefault();

                    if (orderToDel != null && orderItemToDel != null)
                    {
                        context.OrderItems.Remove(orderItemToDel);
                        context.Orders.Remove(orderToDel);
                    }

                    context.Customers.Remove(customer);
                }

                context.SaveChanges();
            }
        }

        public List<Customer> SelectCustomers()
        {
            using(var context = new OnlineShopEntities())
            {
                var customers = context.Customers.Skip(4).ToList();

                return customers;
            }
        }

        public int SumAllCustomers()
        {
            using(var context = new OnlineShopEntities())
            {
                var sum = context.Customers.Count();
                return sum;
            }
        }
    }
}
