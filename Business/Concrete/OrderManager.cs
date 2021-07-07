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

        public IResult Add(Order order)
        {
            order.CreatedOn = DateTime.Now;
            _orderDal.Add(order);
            return new SuccessResult(Messages.OrderAdded);
        }

        public IResult Delete(int id)
        {
            _orderDal.Delete(id);
            return new SuccessResult(Messages.OrderDeleted);
        }

        public IDataResult<List<Order>> GetAll()
        {
            return new SuccessDataResult<List<Order>>(_orderDal.GetAll(),Messages.OrdersListed);
        }

        public IDataResult<Order> GetById(int id)
        {
            return new SuccessDataResult<Order>(_orderDal.Get(o => o.Id == id));
        }

        public IDataResult<List<OrderDetailDto>>GetOrderDetails(int id)
        {
            return new SuccessDataResult<List<OrderDetailDto>>(_orderDal.GetOrderDetails(id));
        }

        public IResult Update(Order order)
        {
            var entity = _orderDal.Get(o => o.Id == order.Id);
            if (entity != null)
            {
                entity.CustomerId = order.CustomerId;
                entity.OrderAddress = order.OrderAddress;
                entity.ModifiedOn = DateTime.Now;
                entity.ModifiedUser = order.ModifiedUser;

                _orderDal.Update(entity);
                return new SuccessResult(Messages.CustomerUpdated);
            }
            return new ErrorResult(Messages.CustomerNotFound);
        }
    }
}
