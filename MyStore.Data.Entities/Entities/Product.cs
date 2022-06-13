using System.Collections.Generic;

namespace MyStore.Entities
{
    public class Product
    {

        public int Id { get; set; }        
        public string ProductName { get; set; }
        public decimal Unitprice { get; set; }        
        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }
        
    }
}
