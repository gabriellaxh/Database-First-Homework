using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.Models
{
    public class CustomerWithOrWithoutOrders
    {
        public string CustomerFullname { get; set; }

        public List<Order> Order { get; set; }
    }
}
