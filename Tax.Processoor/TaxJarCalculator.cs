using System.Net.Http.Json;
using Tax.Processor.Interfaces;
using Tax.Processor.Models;

namespace Tax.Processor
{
    public class TaxJarCalculator : ICalculator
    {
        private string BaseUrl = "https://api.taxjar.com/v2/";
        private string Url = "";

        public TaxJarCalculator()
        {
        }

        public async Task<float> GetRate(int zip)
        {
            if (string.IsNullOrEmpty(zip.ToString())) throw new NullReferenceException("Zip cannot be null");

            Url = $"{BaseUrl}rates/{zip}";

            using (HttpResponseMessage response = await Client.ApiClient.GetAsync(Url))
            {
                if (response.IsSuccessStatusCode)
                {
                    var rate = await response.Content.ReadAsAsync<TaxRate>();

                    return rate.rate.combined_rate;
                }
                else
                {
                    throw new Exception($"Reason for failure: {response.ReasonPhrase}. Status Code: {response.StatusCode}");
                }
            }
        }

        public async Task<float> CalculateTaxForAnOrder(CalculationItems calculationItems)
        {
            if (!calculationItems.Validate(calculationItems))
            {
                throw new ArgumentNullException("CalculationItems cannot be null. Check amount, to country, and from country.");
            }

            Url = $"{BaseUrl}taxes";

            using (HttpResponseMessage response = await Client.ApiClient.PostAsJsonAsync(Url, calculationItems))
            {
                if (response.IsSuccessStatusCode)
                {
                    var taxJarResult = await response.Content.ReadAsAsync<TaxResult>();

                    float salesTax = PerformSalesTaxCalculation(taxJarResult.tax.amount_to_collect, taxJarResult.tax.order_total_amount);

                    return salesTax;
                }
                else
                {
                    throw new Exception($"Reason for failure: {response.ReasonPhrase}. Status Code: {response.StatusCode}");
                }
            }
        }

        public float PerformSalesTaxCalculation(float amountToCollect, float orderTotalAmount)
        {
            float total = amountToCollect + orderTotalAmount;
            return total;
        }
    }
}

