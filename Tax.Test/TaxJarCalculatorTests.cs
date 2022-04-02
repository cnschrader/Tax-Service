using NUnit.Framework;
using Tax.Processor.Models;
using System.Threading.Tasks;
using Tax.Processor;
using System.Collections.Generic;
using System;

namespace Tax.Test;

[TestFixture]
public class TaxJarCalculatorTests
{
    [SetUp]
    public void Setup()
    {
        Client.InitializeClient();
    }

    [Test]
    public void ShouldCalculateSalesTax()
    {
        float amountToCollect = 5.5F;
        float OrderTotalAmount = 10F;

        var actualSalesTax = amountToCollect + OrderTotalAmount;
        var expectedSalesTax = 15.5F;

        Assert.AreEqual(expectedSalesTax, actualSalesTax);
    }

    [Test]
    public async Task ShouldThrowExceptionWithMessageGetRate()
    {
        TaxJarCalculator taxJarCalculator = new TaxJarCalculator();

        AsyncTestDelegate del = async Task () => await taxJarCalculator.GetRate(0);

        var ex = Assert.ThrowsAsync<Exception>(del);
        Assert.That(ex.Message, Is.EqualTo("Reason for failure: Not Found. Status Code: NotFound"));
    }

    [Test]
    public async Task ShouldThrowExceptionWithMessageCalculateSalesTax()
    {
        TaxJarCalculator taxJarCalculator = new TaxJarCalculator();

        CalculationItems calculationItems = new CalculationItems()
        {
            from_country = null,
            from_zip = "64124",
            from_state = "MO",
            from_city = "Kansas City",
            from_street = "325 Maple Blvd",
            to_country = "US",
            to_zip = "35233",
            to_state = "AL",
            to_city = "Birmingham",
            to_street = "1701 1st Ave S #101",
            amount = 35,
            shipping = 2.5F,
            nexus_addresses = new List<NexusAddress>
            {
                new NexusAddress()
                {
                    country = "US",
                    zip = "35233",
                    state = "AL",
                    city = "Birmingham",
                    street = "1701 1st Ave S #101"
                }
            }
        };

        AsyncTestDelegate del = async Task () => await taxJarCalculator.CalculateTaxForAnOrder(calculationItems);

        var ex = Assert.ThrowsAsync<ArgumentNullException>(del);
        Assert.That(ex.Message, Is.EqualTo("Value cannot be null. (Parameter 'CalculationItems cannot be null. Check amount, to country, and from country.')"));
    }

    [Test]
    public async Task ShouldGetRateFromTaxJarCalculator()
    {
        TaxJarCalculator taxJarCalculator = new TaxJarCalculator();
        var zip = 90002;

        var actualRate = await taxJarCalculator.GetRate(zip);
        var expectedRate = 0.1025F;

        Assert.AreEqual(expectedRate, actualRate);
    }

    [Test]
    public async Task ShouldCalculateSalesTaxFromTaxJarCalculator()
    {
        TaxJarCalculator taxJarCalculator = new TaxJarCalculator();

        CalculationItems calculationItems = new CalculationItems()
        {
            from_country = "US",
            from_zip = "64124",
            from_state = "MO",
            from_city = "Kansas City",
            from_street = "325 Maple Blvd",
            to_country = "US",
            to_zip = "35233",
            to_state = "AL",
            to_city = "Birmingham",
            to_street = "1701 1st Ave S #101",
            amount = 35,
            shipping = 2.5F,
            nexus_addresses = new List<NexusAddress>
            {
                new NexusAddress()
                {
                    country = "US",
                    zip = "35233",
                    state = "AL",
                    city = "Birmingham",
                    street = "1701 1st Ave S #101"
                }
            }
        };

        var actualSalesTax = await taxJarCalculator.CalculateTaxForAnOrder(calculationItems);
        var expectedSalesTax = 41F;

        Assert.AreEqual(expectedSalesTax, actualSalesTax);

    }
}