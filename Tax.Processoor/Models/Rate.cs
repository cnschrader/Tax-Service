namespace Tax.Processor.Models
{
	public class Rate
	{
        public float state_rate { get; set; }
        public float county_rate { get; set; }
        public float city_rate { get; set; }
        public float combined_district_rate { get; set; }
        public float combined_rate { get; set; }
    }
}

