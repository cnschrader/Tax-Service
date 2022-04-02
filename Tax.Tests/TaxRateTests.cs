using NUnit.Framework;
using Tax.Processor;
using System.Threading.Tasks;

namespace Tax.Tests;

[TestFixture]
public class Tests
{
    

    [Test(ExpectedResult = 0.1025)]
    public async Task<float> Should_Get_Rate()
    {
        
        ApiHelper.InitializeClient();
        TaxJarCalculator taxJarCalculator = new TaxJarCalculator();
        int zip = 90002;
        var rate = await taxJarCalculator.GetRate(zip);
        Assert.IsNotNull(rate);
        return rate;
        
        
    }
}
