using Tax.Controller.Models;
using Tax.Processor.Interfaces;
using Tax.Processor.Models;

namespace Tax.Controller
{
    public class Service
    {
        TaxService service = new TaxService();
        ICalculator calculator;

        public Service(CustomerType customerType)
        {
            calculator = InitializeCalculator(customerType);
        }

        public ICalculator InitializeCalculator(CustomerType customerType)
        {
            ICalculator calculator = service.GetCalculatorBasedOnCustomer(customerType);
            return calculator;
        }

        public async Task<float> GetRate(int zip)
        {
            return await calculator.GetRate(zip);
        }

        public async Task<float> CalculateSalesTaxOnAnOrder(CalculationItems calculationItems)
        {
            return await calculator.CalculateTaxForAnOrder(calculationItems);
        }
    }
}

