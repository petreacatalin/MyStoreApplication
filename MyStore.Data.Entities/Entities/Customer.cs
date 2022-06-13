using MyStore.Data.Entities.Entities;
using MyStore.Entities;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyStore
{
    public class Customer
    {
        public Customer()
        {
            
            FidelityCard = new FidelityCard();
        }
        public int Id { get; set; }

        //[ForeignKey(nameof(Order))]
        public int OrderId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public FidelityCard FidelityCard { get; set; }
        public ICollection<CustomerOrder> CustomerOrders { get; set; }
    }
}
