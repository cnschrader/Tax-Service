using Tax.Common.Factories;
using Tax.Common.Models;
using Tax.Processor.Interfaces;
using Tax.Controller.Models;

namespace Tax.Controller
{
    public class TaxService
    {
        TaxCalculatorFactory factory = new TaxCalculatorFactory();

        public ICalculator GetCalculatorBasedOnCustomer(CustomerType customerType)
        {
            try
            {
                switch (customerType)
                {
                    case CustomerType.ecommerceCustomer:
                        return factory.GetCalculator(CalculatorType.TaxJarCalulator);
                    default:
                        throw new ArgumentException("Invalid customer type.");
                }
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }
    }
}
