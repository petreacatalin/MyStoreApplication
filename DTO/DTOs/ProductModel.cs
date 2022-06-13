using MyStore.Entities;

namespace MyStore.DTOs
{
    public class ProductModel
    {
        public ProductModel()
        {
            //CategoryModel  = new CategoryModel();
        }
        public int Id { get; set; }
        public string ProductName { get; set; }
        public decimal Unitprice { get; set; }        
        
        public virtual CategoryModel CategoryModel { get; set; }
    }
}
