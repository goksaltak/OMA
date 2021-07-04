using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IProductService
    {
        List<Product> Getall();
        List<Product> GetAllByCategoryId(int Id);
    }
}
