using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IOrderService
    {
        IDataResult<List<Order>> GetAll();
        IDataResult<List<OrderDetailDto>> GetOrderDetails(int id);
        IDataResult<Order> GetById(int id);
        IResult Add(Order order);
        IResult Update(Order order);
        IResult Delete(int id);
    }
}
