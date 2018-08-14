using ConsoleApp.Models;
using ConsoleApp.Services;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp
{
    public class Program
    {
        static void Main(string[] args)
        {
            //Add10Customers();
            //MakeAnOrder();
            //UpdateLastname();
            //DeleteCustomers();
            //SelectCustomers();
            //SumTotalUsers();
            //GetCustomersAndOrders();
            GetCustomersWithOrWithoutOrders();
        }

        public static void Add10Customers()
        {
            var customerService = new CustomerService();

            customerService.AddCustomer(new CustomerEntity
            {
                Firstname = "Georgi",
                Lastname = "Miroslavov",
                PhoneNumber = "0896574235",
                SecondPhoneNumber = "0289356",
                Address = "ul.Kapina"
            });

            customerService.AddCustomer(new CustomerEntity
            {
                Firstname = "Dragomir",
                Lastname = "Slavov",
                PhoneNumber = "0891456835",
                SecondPhoneNumber = "0286345",
                Address = "ul.Lipov cvqt"
            });

            customerService.AddCustomer(new CustomerEntity
            {
                Firstname = "Mihail",
                Lastname = "Hristov",
                PhoneNumber = "0892563785",
                SecondPhoneNumber = "0285632",
                Address = "ul.Evlogi Georgiev"
            });

            customerService.AddCustomer(new CustomerEntity
            {
                Firstname = "Stefan",
                Lastname = "Atanasov",
                PhoneNumber = "0893547568",
                SecondPhoneNumber = "0210256",
                Address = "ul.Ovcha Kupel"
            });

            customerService.AddCustomer(new CustomerEntity
            {
                Firstname = "Evgeni",
                Lastname = "Antonov",
                PhoneNumber = "0894756325",
                SecondPhoneNumber = "0212589",
                Address = "ul.Kapana 15"
            });

            customerService.AddCustomer(new CustomerEntity
            {
                Firstname = "Tatiana",
                Lastname = "Marinova",
                PhoneNumber = "0885162479",
                SecondPhoneNumber = "0235678",
                Address = "ul.Zaharna fabrika 183"
            });

            customerService.AddCustomer(new CustomerEntity
            {
                Firstname = "Svetla",
                Lastname = "Petrova",
                PhoneNumber = "083567865",
                SecondPhoneNumber = "063455341",
                Address = "ul.Nikola Vapcarov 4"
            });

            customerService.AddCustomer(new CustomerEntity
            {
                Firstname = "Iveta",
                Lastname = "Ivanova",
                PhoneNumber = "0893564751",
                SecondPhoneNumber = "0552541",
                Address = "ul.Snejna burq 6"
            });

            customerService.AddCustomer(new CustomerEntity
            {
                Firstname = "Elitsa",
                Lastname = "Stefanova",
                PhoneNumber = "0863456225",
                SecondPhoneNumber = "021154614",
                Address = "ul.Shipchenska 78"
            });

            customerService.AddCustomer(new CustomerEntity
            {
                Firstname = "Nikola",
                Lastname = "Kirilov",
                PhoneNumber = "0896322541",
                SecondPhoneNumber = "09653453",
                Address = "ul.Prolaz 80"
            });
        }

        public static void MakeAnOrder()
        {
            var orderService = new OrderService();

            orderService.MakeAnOrder(17, 3, 6);
        }

        public static void UpdateLastname()
        {
            var customerService = new CustomerService();

            customerService.UpdateCustomers();
        }

        public static void DeleteCustomers()
        {
            var customerService = new CustomerService();

            customerService.DeleteCustomers();
        }

        public static void SelectCustomers()
        {
            var customerService = new CustomerService();

            var selectedCustomers = customerService.SelectCustomers();

            foreach (var customer in selectedCustomers)
            {
                Console.WriteLine(customer.Firstname + " " + customer.Lastname);
            }
        } 

        public static void SumTotalUsers()
        {
            var customerService = new CustomerService();

            int customersCount = customerService.SumAllCustomers();

            Console.WriteLine(customersCount);
        }

        public static void GetCustomersAndOrders()
        {
            var customerService = new CustomerService();
            var list = customerService.GetCustomersAndOrders();

            foreach (var match in list)
            {
                Console.WriteLine($"Customer Fullname: {match.CustomerFullname}, Order Id: {match.OrderId}");
            }
        }

        public static void GetCustomersWithOrWithoutOrders()
        {
            var customerService = new CustomerService();
            var list = customerService.GetCustomersWithOrWithoutOrders();

            foreach (var match in list)
            {
                Console.WriteLine(string.Format("Customer Fullname: {0}, Order Id: {1}", match.CustomerFullname, match.Order.Count > 0 ? match.Order[0].Id.ToString() : "No orders"));
            }
        }
    }
}
