using Tax.Common.Interfaces;
using Tax.Common.Models;
using Tax.Processor.Interfaces;
using Tax.Processor;

namespace Tax.Common.Factories
{
    public class TaxCalculatorFactory : CalculatorFactory
	{
		public TaxCalculatorFactory() { }

		public override ICalculator GetCalculator(CalculatorType calculatorType)
		{
            switch (calculatorType)
            {
				case CalculatorType.TaxJarCalulator:
					return new TaxJarCalculator();
                default:
					throw new ArgumentException("Invalid Calculator Type.");
            }
        }
	}
}

