using NUnit.Framework;
using Tax.Processor;
using Tax.Processor.Models;
using Tax.Controller;
using Tax.Controller.Models;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Tax.Test;

[TestFixture]
public class TaxServiceTests
{
    [SetUp]
    public void Setup()
    {
        Client.InitializeClient();
    }

    [Test]
    public async Task ShouldGetRateWithService()
    {
        Service service = new Service(CustomerType.ecommerceCustomer);
        var zip = 90002;

        var rate = await service.GetRate(zip);
        Assert.AreEqual(0.1025F, rate);
    }

    [Test]
    public async Task ShouldCalculateSalesTaxForAnOrderWithService()
    {
        Service service = new Service(CustomerType.ecommerceCustomer);

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

        var salesTax = await service.CalculateSalesTaxOnAnOrder(calculationItems);

        Assert.AreEqual(41F, salesTax);
    }
}