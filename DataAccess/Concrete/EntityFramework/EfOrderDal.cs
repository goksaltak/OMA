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
    public class EfOrderDal : EfEntityRepositoryBase<Tb_Order, OmaContext>, IOrderDal
    {
        public List<OrderDetailDto> GetOrderDetails()
        {
            using (OmaContext context = new OmaContext())
            {
                var result = from o in context.tb_Order
                             join od in context.tb_OrderDetail
                             on o.OrderId equals od.OrderId
                             join c in context.tb_Customer
                             on o.CustomerId equals c.Id
                             select new OrderDetailDto
                             {
                                 OrderId = od.OrderId,Name=c.Name
                             };

                return result.ToList();


            }
        }
    }
}
