using AutoMapper;
using MyStore.DTOs;
using MyStore.Entities;

namespace MyStore.Profiles
{
    public class CategoryProfile : Profile
    {
        public CategoryProfile()
        {
            CreateMap<Category, CategoryModel>().ReverseMap();
            CreateMap<CustomerModel, Customer>();
        }
    }
}
