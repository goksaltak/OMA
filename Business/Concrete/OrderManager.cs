using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
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

        public IResult Add(Tb_Order order)
        {
          
            _orderDal.Add(order);
            return new SuccessResult(Messages.OrderAdded);
        }

        public IDataResult<List<Tb_Order>> GetAll()
        {
            return new SuccessDataResult<List<Tb_Order>>(_orderDal.GetAll(),Messages.ordersListed);
        }

        public IDataResult<Tb_Order> GetById(int orderId)
        {
            return new SuccessDataResult<Tb_Order>(_orderDal.Get(o => o.OrderId == orderId));
        }

        public IDataResult<List<OrderDetailDto>>GetOrderDetails()
        {
            return new SuccessDataResult<List<OrderDetailDto>>(_orderDal.GetOrderDetails());
        }
    }
}
