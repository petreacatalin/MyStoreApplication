using MyStore.Data.Entities.Entities;
using System.Collections.Generic;

namespace MyStore.Entities
{
    public class Order
    {
        public Order()
        {
            
        }
        public int Id { get; set; }
        public int CustomerId { get; set; }        
        public int OrderDate { get; set; }        
        public string ShipAddress { get; set; }        
        public string ShipCountry { get; set; }
        public ICollection<CustomerOrder> CustomerOrders { get; set; }
    }
}
