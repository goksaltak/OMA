using Business.Abstract;
using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class ProductManager : IProductService
    {
        public IResult Add(Product product)
        {
            throw new NotImplementedException();
        }

        public IResult Delete(Product product)
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<Order>> GetAll()
        {
            throw new NotImplementedException();
        }

        public IResult Update(Product product)
        {
            throw new NotImplementedException();
        }
    }
}
