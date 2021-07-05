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
        IDataResult<List<Tb_Order>> GetAll();
        IDataResult<List<OrderDetailDto>> GetOrderDetails();
        IDataResult<Tb_Order> GetById(int orderId);
        IResult Add(Tb_Order order);

    }
}
