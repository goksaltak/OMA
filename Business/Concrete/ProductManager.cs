using Business.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class ProductManager : IProductService
    {
        public List<Product> Getall()
        {
            throw new NotImplementedException();
        }

        public List<Product> GetAllByCategoryId(int Id)
        {
            throw new NotImplementedException();
        }
    }
}
