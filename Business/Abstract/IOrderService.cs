using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IOrderService
    {
        List<Tb_Order> GetAll();
        List<OrderDetailDto> GetOrderDetails();

    }
}
