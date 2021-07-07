using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            OrderDetailTest();
        }

       

        private static void OrderDetailTest()
        {
            OrderManager orderManager = new OrderManager(new EfOrderDal());
            foreach (var orderDetail in orderManager.GetOrderDetails(1).Data)
            {
                Console.WriteLine(orderDetail.OrderId + " " + orderDetail.Name+" "+orderDetail.LastName+" " + orderDetail.Adress + " " + orderDetail.Barcode+" "+orderDetail.Description+" "+
                    orderDetail.Quantity+" "+orderDetail.Price);
            }
        }
    }
}
