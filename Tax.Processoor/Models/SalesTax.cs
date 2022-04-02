namespace Tax.Processor.Models
{
    public class SalesTax
    {
        public float order_total_amount { get; set; }
        public float amount_to_collect { get; set; }
        public bool has_nexus { get; set; }
    }
}
