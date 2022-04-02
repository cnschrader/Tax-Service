using Tax.Processor.Interfaces;
using Tax.Common.Models;

namespace Tax.Common.Interfaces
{
	public abstract class CalculatorFactory
	{
		public abstract ICalculator GetCalculator(CalculatorType calculatorType);
	}
}

