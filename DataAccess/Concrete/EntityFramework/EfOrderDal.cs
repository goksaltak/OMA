using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Linq;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfOrderDal : EfEntityRepositoryBase<Order, OmaContext>, IOrderDal
    {
        public List<OrderDetailDto> GetOrderDetails(int id)
        {
            using (OmaContext context = new OmaContext())
            {
                var result = from o in context.Orders
                             join od in context.OrderDetails
                             on o.Id equals od.OrderId
                             join c in context.Customers
                             on o.CustomerId equals c.Id
                             join p in context.Products
                             on od.ProductId equals p.Id
                             where c.Id == id
                             select new OrderDetailDto
                             {
                                 OrderId = o.Id,
                                 Name = c.FirstName,
                                 LastName = c.LastName,
                                 Adress = o.OrderAddress,
                                 Barcode = p.Barcode,
                                 Description = p.Description,
                                 Quantity = od.Quantity,
                                 Price = od.Price
                             };

                return result.ToList();

            }
        }
    }
}
