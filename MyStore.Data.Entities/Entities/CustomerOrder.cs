using MyStore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyStore.Data.Entities.Entities
{
    public class CustomerOrder
    {
        public int CustomerId { get; set; }
        public int OrderId { get; set; }
        public Customer Customer { get; set; }
        public Order Order { get; set; }

    }
}
