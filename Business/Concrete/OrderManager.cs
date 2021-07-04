using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class OrderManager : IOrderService
    {
        IOrderDal _orderDal;

        public OrderManager(IOrderDal customerDal)
        {
            _orderDal = customerDal;
        }
        public List<Tb_Order> GetAll()
        {
            throw new NotImplementedException();
        }

        public List<OrderDetailDto> GetOrderDetails()
        {
            return _orderDal.GetOrderDetails();
        }
    }
}
