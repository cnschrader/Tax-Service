namespace Tax.Processor.Models
{
    public class CalculationItems
    {
        public string from_country { get; set; }
        public string from_zip { get; set; }
        public string from_state { get; set; }
        public string from_city { get; set; }
        public string from_street { get; set; }
        public string to_country { get; set; }
        public string to_zip { get; set; }
        public string to_state { get; set; }
        public string to_city { get; set; }
        public string to_street { get; set; }
        public float amount { get; set; }
        public float shipping { get; set; }
        public List<NexusAddress> nexus_addresses { get; set; }

        public bool Validate(CalculationItems calculationItems)
        {
            if (calculationItems == null) return false;

            if (calculationItems.amount == 0F) return false;

            if (string.IsNullOrEmpty(calculationItems.from_country) || string.IsNullOrEmpty(calculationItems.to_country))
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}

