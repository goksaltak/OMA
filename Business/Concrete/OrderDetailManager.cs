using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class OrderDetailManager:IOrderDetailService
    {
        IOrderDetailDal _orderDetailDal;

        public OrderDetailManager(IOrderDetailDal orderDetailDal)
        {
            _orderDetailDal = orderDetailDal;
        }

        public IResult Add(OrderDetail orderDetail)
        {
            orderDetail.CreatedOn = DateTime.Now;
            _orderDetailDal.Add(orderDetail);
            return new SuccessResult(Messages.OrderDetailAdded);
        }

        public IResult Delete(int id)
        {
            _orderDetailDal.Delete(id);
            return new SuccessResult(Messages.OrderDetailDeleted);
        }

        public IDataResult<List<OrderDetail>> GetAll()
        {
            return new SuccessDataResult<List<OrderDetail>>(_orderDetailDal.GetAll(), Messages.OrderDetailsListed);

        }

        public DataResult<OrderDetail> GetById(int id)
        {
            return new SuccessDataResult<OrderDetail>(_orderDetailDal.Get(o => o.Id == id));
        }

        public IResult Update(OrderDetail orderDetail)
        {
            var entity = _orderDetailDal.Get(o => o.Id == orderDetail.Id);
            if (entity != null)
            {
                entity.ProductId = orderDetail.ProductId;
                entity.Quantity = orderDetail.Quantity;
                entity.Price = orderDetail.Price;
                entity.ModifiedOn = DateTime.Now;
                entity.ModifiedUser = orderDetail.ModifiedUser;

                _orderDetailDal.Update(entity);
                return new SuccessResult(Messages.OrderDetailUpdated);
            }
            return new ErrorResult(Messages.OrderDetailNotFound);
        }
    }
}
