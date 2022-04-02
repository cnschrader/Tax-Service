using Tax.Processor.Models;

namespace Tax.Processor.Interfaces
{
    public interface ICalculator
    {
        public Task<float> GetRate(int zip);

        public Task<float> CalculateTaxForAnOrder(CalculationItems calculationItems);
    }
}

