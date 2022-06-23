using Google.Ads.GoogleAds;
using Google.Ads.GoogleAds.Lib;
using Google.Ads.GoogleAds.V10.Errors;
using Google.Ads.GoogleAds.V10.Resources;
using Google.Ads.GoogleAds.V10.Services;

using Newtonsoft.Json;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdsAgain
{
    internal partial class Program
    {
        private static string GetAccountInformation(GoogleAdsClient client, long customerId)
        {
            // Get the GoogleAdsService.
            GoogleAdsServiceClient googleAdsService = client.GetService(
                Services.V10.GoogleAdsService);

            // Construct a query to retrieve the customer.
            // Add a limit of 1 row to clarify that selecting from the customer resource
            // will always return only one row, which will be for the customer
            // ID specified in the request.
            string query = "SELECT customer.id, customer.descriptive_name, " +
                "customer.currency_code, customer.time_zone, customer.tracking_url_template, " +
                "customer.auto_tagging_enabled, customer.status FROM customer LIMIT 1";

            // Executes the query and gets the Customer object from the single row of the response.
            SearchGoogleAdsRequest request = new SearchGoogleAdsRequest()
            {
                CustomerId = customerId.ToString(),
                Query = query
            };

            try
            {
                // Issue the search request.
                Customer customer = googleAdsService.Search(request).First().Customer;

                // Print account information.
                return JsonConvert.SerializeObject(new JSON() { Cargo = customer });
            }
            catch (GoogleAdsException e)
            {
                return JsonConvert.SerializeObject(new JSON() { Error = $"Failure: Message: {e.Message}, Failure: {e.Failure}, Request ID: {e.RequestId}" });
            }
        }
    }
}
