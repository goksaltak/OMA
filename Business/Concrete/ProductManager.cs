using Business.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class ProductManager : IProductService
    {
        public List<Tb_Product> Getall()
        {
            throw new NotImplementedException();
        }

        public List<Tb_Product> GetAllByCategoryId(int Id)
        {
            throw new NotImplementedException();
        }
    }
}
