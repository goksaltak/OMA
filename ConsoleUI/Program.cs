using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            //CustomerTest();
            OrderDetailTest();
        }

        private static void CustomerTest()
        {
            CustomerManager customerManager = new CustomerManager(new EfCustomerDal());
            foreach (var customer in customerManager.GetAll())
            {
                Console.WriteLine(customer.Name + " " + customer.LastName + " " + customer.Adress);
            }
        }

        private static void OrderDetailTest()
        {
            OrderManager orderManager = new OrderManager(new EfOrderDal());
            foreach (var orderDetail in orderManager.GetOrderDetails())
            {
                Console.WriteLine(orderDetail.OrderId + " " + orderDetail.Name);
            }
        }
    }
}
