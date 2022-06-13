namespace MyStore.Entities
{
    public class FidelityCard
    {
        
        public int Id { get; set; }
        public int Discount { get; set; }
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
    }
}
