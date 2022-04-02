using NUnit.Framework;
using Tax.Processor.Models;
using System.Collections.Generic;

namespace Tax.Test;

[TestFixture]
public class ValidationTests
{
    [SetUp]
    public void Setup()
    {
    }

    [TestCase("", "US", 34)]
    [TestCase("US", "", 34)]
    [TestCase("US", "US", 0)]
    [TestCase(null, "US", 34)]
    [TestCase("US", null, 34)]
    public void ShouldValidateCalculationItemProperties(string fromCountry, string tocountry, int amount)
    {
        CalculationItems calculationItems = new CalculationItems()
        {
            from_country = fromCountry,
            from_zip = "64124",
            from_state = "MO",
            from_city = "Kansas City",
            from_street = "325 Maple Blvd",
            to_country = tocountry,
            to_zip = "35233",
            to_state = "AL",
            to_city = "Birmingham",
            to_street = "1701 1st Ave S #101",
            amount = amount,
            shipping = 4,
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

        Assert.IsFalse(calculationItems.Validate(calculationItems));
    }
}