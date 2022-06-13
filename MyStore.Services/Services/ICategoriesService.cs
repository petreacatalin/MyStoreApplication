using MyStore.DTOs;
using MyStore.Entities;
using System.Collections;
using System.Collections.Generic;

namespace MyStore.Services.Services
{
    public interface ICategoriesService
    {
        CategoryModel AddCategory(CategoryModel categoryModel);
        CategoryModel GetById(int id);
        IEnumerable<CategoryModel> GetCategories();
        void Update ( CategoryModel categoryModel);
        Category Delete ( int? id );
    }
}