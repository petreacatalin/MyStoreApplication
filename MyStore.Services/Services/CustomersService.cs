using AutoMapper;
using MyStore.DTOs;
using MyStore.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyStore.Services.Services
{
    public class CustomersService : ICustomersService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CustomersService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public IEnumerable<CustomerModel> GetCustomers()
        {
            var customers = _unitOfWork.Customers.GetAll();
            var results = _mapper.Map<IList<CustomerModel>>(customers);
            return results;
        }

        public CustomerModel GetById(int id)
        {
            var customer = _unitOfWork.Customers.GetById(id);
            var result = _mapper.Map<CustomerModel>(customer);
            return result;
        }

        public CustomerModel AddCustomer(CustomerModel itemModel)
        {
            Customer customerToAdd = _mapper.Map<Customer>(itemModel);
            _unitOfWork.Customers.Insert(customerToAdd);
            _unitOfWork.Save();
            var newCustomer = _mapper.Map<CustomerModel>(customerToAdd);
            return newCustomer;
        }

        public void Update(CustomerModel customerModel)
        {
            var customer = _unitOfWork.Customers.GetById(customerModel.Id);
            _mapper.Map(customerModel, customer);
            _unitOfWork.Customers.Update(customer);
            _unitOfWork.Save();
        }

        public Customer Delete(int? id)
        {
            var _item = _unitOfWork.Customers.GetById(id);
            if (_item != null)
            {
                _unitOfWork.Customers.Delete(_item.Id);
                _unitOfWork.Save();
            }
            return _item;
        }
    }
}
