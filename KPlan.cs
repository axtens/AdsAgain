using Google.Ads.GoogleAds;
using Google.Ads.GoogleAds.Lib;
using Google.Ads.GoogleAds.V10.Enums;
using Google.Ads.GoogleAds.V10.Errors;
using Google.Ads.GoogleAds.V10.Resources;
using Google.Ads.GoogleAds.V10.Services;

using Newtonsoft.Json;

using System.Collections.Generic;

namespace AdsAgain
{
    internal class KPlan
    {
        internal long customerId;
        private readonly GoogleAdsClient client;


        internal KPlan(GoogleAdsClient client, long customerId)
        {

            this.customerId = customerId;
            this.client = client;
        }

        internal string CreateKeywordPlan(string Name, KeywordPlanForecastIntervalEnum.Types.KeywordPlanForecastInterval keywordPlanForecastInterval)
        {
            KeywordPlanServiceClient service = client.GetService(Services.V10.KeywordPlanService);
            KeywordPlanOperation keywordPlanOperation = new KeywordPlanOperation
            {
                Create = new KeywordPlan
                {
                    
                    Name = Name,
                    ForecastPeriod = new KeywordPlanForecastPeriod
                    {
                        DateInterval = keywordPlanForecastInterval
                    }
                }
            };
            var response = service.MutateKeywordPlans(this.customerId.ToString(), new KeywordPlanOperation[1] { keywordPlanOperation });
            return JsonConvert.SerializeObject(new JSON() { Cargo = response }); //.Results[0].ResourceName;
        }

        internal string CreateKeywordPlanCampaign(string plan, string Name, long cpcBidMicros, KeywordPlanNetworkEnum.Types.KeywordPlanNetwork keywordPlanNetworkEnum, long geoTargetConstant, long languageConstant)
        {
            KeywordPlanCampaignServiceClient serviceClient = this.client.GetService(Services.V10.KeywordPlanCampaignService);
            var campaign = new KeywordPlanCampaign()
            {
                Name = Name,
                CpcBidMicros = cpcBidMicros,
                KeywordPlanNetwork = keywordPlanNetworkEnum,
                KeywordPlan = plan
            };
            campaign.GeoTargets.Add(new KeywordPlanGeoTarget()
            {
                GeoTargetConstant = ResourceNames.GeoTargetConstant(geoTargetConstant)
            });
            campaign.LanguageConstants.Add(ResourceNames.LanguageConstant(languageConstant));
            KeywordPlanCampaignOperation operation = new KeywordPlanCampaignOperation()
            {
                Create = campaign
            };
            var response = serviceClient.MutateKeywordPlanCampaigns(customerId.ToString(), new KeywordPlanCampaignOperation[] { operation });
            return JsonConvert.SerializeObject(new JSON() { Cargo = response }); //.Results[0].ResourceName;
        }

        internal string CreateKeywordPlanAdGroup(string plan, string Name, long cpcBidMicros)
        {
            // Get the KeywordPlanAdGroupService.
            KeywordPlanAdGroupServiceClient serviceClient = client.GetService(
                Services.V10.KeywordPlanAdGroupService);

            // Create the keyword plan ad group.
            KeywordPlanAdGroup adGroup = new KeywordPlanAdGroup()
            {
                KeywordPlanCampaign = plan,
                Name = Name,
                CpcBidMicros = cpcBidMicros
            };

            KeywordPlanAdGroupOperation operation = new KeywordPlanAdGroupOperation()
            {
                Create = adGroup
            };

            // Add the ad group.
            MutateKeywordPlanAdGroupsResponse response =
                serviceClient.MutateKeywordPlanAdGroups(
                    customerId.ToString(), new KeywordPlanAdGroupOperation[] { operation });

            // Display the result.
            return JsonConvert.SerializeObject(new JSON() { Cargo = response }); // response.Results[0].ResourceName;
        }

        internal string CreateKeywordPlanAdGroupKeywords(string plan, (long cpcBidMicros, KeywordMatchTypeEnum.Types.KeywordMatchType matchType, string text)[] tuple)
        {
            // Get the KeywordPlanAdGroupKeywordService.
            KeywordPlanAdGroupKeywordServiceClient serviceClient = client.GetService(
                Services.V10.KeywordPlanAdGroupKeywordService);

            var keywordPlanAdGroupKeywords = new List<KeywordPlanAdGroupKeyword>();

            foreach (var t in tuple)
            {
                keywordPlanAdGroupKeywords.Add(new KeywordPlanAdGroupKeyword()
                {
                    KeywordPlanAdGroup = plan,
                    CpcBidMicros = t.cpcBidMicros,
                    MatchType = t.matchType,
                    Text = t.text
                });
            }


            KeywordPlanAdGroupKeyword[] kpAdGroupKeywords = keywordPlanAdGroupKeywords.ToArray();

            // Create an operation for each plan keyword.
            List<KeywordPlanAdGroupKeywordOperation> operations =
                new List<KeywordPlanAdGroupKeywordOperation>();

            foreach (KeywordPlanAdGroupKeyword kpAdGroupKeyword in kpAdGroupKeywords)
            {
                operations.Add(new KeywordPlanAdGroupKeywordOperation
                {
                    Create = kpAdGroupKeyword
                });
            }

            // Add the keywords.
            MutateKeywordPlanAdGroupKeywordsResponse response =
                serviceClient.MutateKeywordPlanAdGroupKeywords(customerId.ToString(), operations);

            //var plans = new List<string>();
            // Display the results.
            /*foreach (MutateKeywordPlanAdGroupKeywordResult result in response.Results)
            {
                Console.WriteLine(
                    $"Created ad group keyword for keyword plan: {result.ResourceName}.");
                plans.Add( result.ResourceName);
            }
            return plans.ToArray();*/
            return JsonConvert.SerializeObject(new JSON() { Cargo = response });
        }

        internal string CreateKeywordPlanCampaignNegativeKeywords(string plan, KeywordMatchTypeEnum.Types.KeywordMatchType keywordMatchType, string text)
        {
            // Get the KeywordPlanCampaignKeywordService.
            KeywordPlanCampaignKeywordServiceClient service = client.GetService(
                Services.V10.KeywordPlanCampaignKeywordService);

            // Create the campaign negative keyword for the keyword plan.
            KeywordPlanCampaignKeyword kpCampaignNegativeKeyword = new KeywordPlanCampaignKeyword()
            {
                KeywordPlanCampaign = plan,
                MatchType = keywordMatchType,
                Text = text,
                Negative = true
            };

            KeywordPlanCampaignKeywordOperation operation = new KeywordPlanCampaignKeywordOperation
            {
                Create = kpCampaignNegativeKeyword
            };

            // Add the campaign negative keyword.
            MutateKeywordPlanCampaignKeywordsResponse response =
                service.MutateKeywordPlanCampaignKeywords(customerId.ToString(),
                    new KeywordPlanCampaignKeywordOperation[] { operation });

            // Display the result.
            //MutateKeywordPlanCampaignKeywordResult result = response.Results[0];
            //return result.ResourceName;
            return JsonConvert.SerializeObject(new JSON() { Cargo = response });
        }
    }
}
