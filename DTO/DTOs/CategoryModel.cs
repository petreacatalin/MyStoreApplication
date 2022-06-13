using MyStore.Entities;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MyStore.DTOs
{
    public class CategoryModel
    {
        public CategoryModel()
        {
            //ProductsModel = new HashSet<ProductModel>();
        }
        public int Id { get; set; }
        //[Required]
        [StringLength(maximumLength: 50, ErrorMessage = " Category name is too long.")]
        public string CategoryName { get; set; }        
        //public ICollection<ProductModel> ProductsModel { get; set; }
    }
}
