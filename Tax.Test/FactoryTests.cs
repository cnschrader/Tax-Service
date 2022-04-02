using NUnit.Framework;
using Tax.Common.Models;
using Tax.Common.Factories;

namespace Tax.Test;

[TestFixture]
public class FactoryTests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void ShouldReturnNewTaxJarCalculator()
    {
        var calculatorType = CalculatorType.TaxJarCalulator;
        TaxCalculatorFactory factory = new TaxCalculatorFactory();

        
        var actualCalculator = factory.GetCalculator(calculatorType);
        //var expectedCalculator = new TaxJarCalculator();

        Assert.IsNotNull(actualCalculator);

        //Assert.AreEqual(expectedCalculator, actualCalculator);
    }
}
