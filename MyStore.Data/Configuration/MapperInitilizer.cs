using AutoMapper;
using MyStore.Data;
using MyStore.DTOs;
using MyStore.Entities;

namespace MyStore.Profiles
{
    public class MapperInitilizer : Profile
    {
        public MapperInitilizer()
        {
            CreateMap<Category, CategoryModel>();
                //.ForMember(dst => dst.ProductsModel, map => map.Ignore());
            CreateMap<CategoryModel, Category>()
                .ForMember(dst => dst.Products, map => map.Ignore());
                
            //.ForMember(x => x.Id, x => x.Ignore())
            //.ForMember(x => x.CategoryName, x => x.Ignore())
            //.ForMember(x => x.ProductId, x => x.Ignore());          

            CreateMap<Customer, CustomerModel>();
            CreateMap<CustomerModel, Customer>()
                .ForMember(dst => dst.CustomerOrders, map => map.Ignore());

            CreateMap<Product, ProductModel>();
            CreateMap<ProductModel, Product>();

            CreateMap<ApiUser, UserModel>();
            CreateMap<UserModel, ApiUser>();
        }
    }
}
