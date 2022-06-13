using AutoMapper;
using MyStore.DTOs;

namespace MyStore.Profiles
{
    public class CustomerProfile : Profile
    {
        public CustomerProfile()
        {
            CreateMap<Customer, CustomerModel>();
            CreateMap<CustomerModel, Customer>()
                .ForMember(dst => dst.CustomerOrders, map => map.Ignore());
                
        }
    }   
    
}
