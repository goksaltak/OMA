using Business.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using DataAccess.Abstract;
using Core.Utilities.Results;
using Business.Constants;

namespace Business.Concrete
{

    public class CustomerManager : ICustomerService
    {
        ICustomerDal _customerDal;
        IOrderDal _orderDal;


        public CustomerManager(ICustomerDal customerDal, IOrderDal orderDal)
        {
            _customerDal = customerDal;
            _orderDal = orderDal;
        }

        public IResult Add(Customer customer)
        {
            customer.CreatedOn = DateTime.Now;
            _customerDal.Add(customer);
            return new SuccessResult(Messages.CustomerAdded);
        }

        public IResult Delete(int id)
        {
            var orderCount = _orderDal.Count(o => o.CustomerId == id);
            if (orderCount > 0)
            {
                return new ErrorResult(Messages.CustomerExist);

            }
            _customerDal.Delete(id);
            return new SuccessResult(Messages.CustomerDeleted);
        }

        public IDataResult<List<Customer>> GetAll()
        {
            return new SuccessDataResult<List<Customer>>(_customerDal.GetAll(), Messages.CustomersListed);

        }

        public IDataResult<Customer> GetById(int id)
        {
            return new SuccessDataResult<Customer>(_customerDal.Get(o => o.Id == id));
        }

        public IResult Update(Customer customer)
        {
            var entity = _customerDal.Get(o => o.Id == customer.Id);
            if (entity!=null)
            {
                entity.FirstName = customer.FirstName;
                entity.LastName = customer.LastName;
                entity.Address = customer.Address;
                entity.ModifiedOn = DateTime.Now;
                entity.ModifiedUser = customer.ModifiedUser;

                _customerDal.Update(entity);
                return new SuccessResult(Messages.CustomerUpdated);
            }
            return new ErrorResult(Messages.CustomerNotFound);
        }
    }
}
