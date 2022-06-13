using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyStore.Entities
{
    public class Category
    {
        public Category()
        {
            Products = new HashSet<Product>();
        }
        public int Id { get; set; }
        public string CategoryName { get; set; }

        
        public virtual ICollection<Product> Products { get; set; }
    }
}
