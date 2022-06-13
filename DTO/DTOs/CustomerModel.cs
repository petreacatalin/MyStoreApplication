using MyStore.Entities;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MyStore.DTOs
{
    public class CustomerModel
    {
        public CustomerModel()
        {
            //Orders = new List<Order>();
            //FidelityCard = new FidelityCard();
        }
        public int Id { get; set; }
        //public int OrderId { get; set; }

        [StringLength(maximumLength: 100, ErrorMessage = " Customer name is too long.")]
        public string Name { get; set; }

        [EmailAddress]
        public string Email { get; set; }
        public string Address { get; set; }

        //public FidelityCard FidelityCard { get; set; }
        //public ICollection<Order> Orders { get; set; }
    }
}
