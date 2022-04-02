using Tax.Processor;
using Tax.Processor.Models;
using Tax.Controller;
using Tax.Controller.Models;

Client.InitializeClient();
Console.WriteLine("Initializing Client");

try
{
    Service service = new Service(CustomerType.ecommerceCustomer);
    var zip = 90002;
    var rate = await service.GetRate(zip);
    Console.WriteLine($"The combined tax rate for zip {zip} is {rate}.");

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
    Console.WriteLine($"The sales tax for an order from {calculationItems.from_city} to {calculationItems.to_city} is {salesTax}.");

}
catch (NullReferenceException ex)
{
    Console.WriteLine(ex.Message);
}
catch (ArgumentNullException ex)
{
    Console.WriteLine(ex.Message);
}
catch (Exception ex)
{
    Console.WriteLine(ex.Message);
}




