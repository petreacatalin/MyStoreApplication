using MyStore.DTOs;
using System;
using MyStore.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyStore.Services.Services
{
    public interface ICustomersService
    {
        CustomerModel AddCustomer(CustomerModel customerModel);
        CustomerModel GetById(int id);
        IEnumerable<CustomerModel> GetCustomers();
        void Update(CustomerModel customerModel);
        Customer Delete(int? id);
    }
}
