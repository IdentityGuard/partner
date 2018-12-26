using Intersections.Billing.Model;
using Intersections.Billing.Model.Recurly;
using Intersections.Billing.Support;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Intersections.Billing.Gateway.Recurly
{
    /// <summary>
    /// Represents the Gateway to Recurly
    /// </summary>
    internal class RecurlyGateway : BillingGateway
    {
        /// <summary>
        /// Default Constructor
        /// </summary>
        internal RecurlyGateway()
        {
            this.baseAddress = Properties.AppSettings.recurlyBaseUrl;
            mapFieldNames();
            setApiKeys();
        }

        /// <summary>
        /// Map recurly fieldNames to expected field names
        /// </summary>
        private void mapFieldNames()
        {
            this.fieldNames = new NameValueCollection();
            fieldNames.Add("number","cardNumber");
            fieldNames.Add("year", "expirationYear");
            fieldNames.Add("month", "expirationMonth");
            fieldNames.Add("cvv", "cardCVV");
            fieldNames.Add("first_name", "firstName");
            fieldNames.Add("last_name", "lastName");
            fieldNames.Add("address1", "street1");            
            fieldNames.Add("postal_code", "postalCode");            
            fieldNames.Add("key", "apiKey");
            fieldNames.Add("invalid-public-key", "apiKey");
        }

        /// <summary>
        /// Set the public keys to call recurly
        /// can be removed later to fetch from a centralized location
        /// </summary>
        private void setApiKeys()
        {
            this.apiKeys = new NameValueCollection();
            apiKeys.Add("PRE_PROD", "ewr1-QuQ5jo88WfCpNPz2kTb8ES");
            apiKeys.Add("PROD", "ewr1-PXf7pbi1Fn8MrkEwUzJGbh");
        }

        /// <summary>
        /// Get the recurly key based on Test environment flag        
        /// </summary>
        internal override string getApiKey(bool isTest)
        {
            if (isTest)
                return apiKeys["PRE_PROD"];
            else
                return apiKeys["PROD"];            
        }

        /// <summary>
        /// Get Billing Token from Recurly
        /// </summary>
        /// <param name="request">TokenRequest containing billing information</param>
        /// <returns>TokenResponse</returns>
        internal override async Task<TokenResponse> getBillingToken(TokenRequest request, bool isTest)
        {
            string apiPath = Properties.AppSettings.recurlyTokenPath;
            string apiKey = getApiKey(isTest);

            //setup request data
            var formContent = new[]
                {
                new KeyValuePair<string, string>("number", Convert.ToString(request.cardNumber)),
                new KeyValuePair<string, string>("year", Convert.ToString(request.expirationYear)),
                new KeyValuePair<string, string>("month", Convert.ToString(request.expirationMonth)),
                new KeyValuePair<string, string>("cvv", Convert.ToString(request.cardCVV)),
                new KeyValuePair<string, string>("first_name", Convert.ToString(request.firstName)),
                new KeyValuePair<string, string>("last_name", Convert.ToString(request.lastName)),
                new KeyValuePair<string, string>("address1", Convert.ToString(request.street1)),                
                new KeyValuePair<string, string>("city", Convert.ToString(request.city)),
                new KeyValuePair<string, string>("state", Convert.ToString(request.state)),
                new KeyValuePair<string, string>("country", Convert.ToString(request.country)),
                new KeyValuePair<string, string>("postal_code", Convert.ToString(request.postalCode)),            
                new KeyValuePair<string, string>("key", apiKey)
                };

            //call recurly api endpoint for token
            var apiResponse = await RestHelper.PostFormContentRequest(baseAddress, apiPath, null, formContent);

            //parse the response body to object
            RecurlyTokenResponse recurlyResponse = JsonConvert.DeserializeObject<RecurlyTokenResponse>(apiResponse.Item2);

            //prepare TokenResponse object
            TokenResponse response = new TokenResponse();
            response.addToken(recurlyResponse.id);
            if (recurlyResponse.error != null)
            {
                if ((recurlyResponse.error.fields != null))
                {
                    foreach (var field in recurlyResponse.error.fields)
                    {
                        response.addError(new Error(translateFieldName(field), recurlyResponse.error.message));
                    }
                }
                else
                {
                    response.addError(new Error(translateFieldName(recurlyResponse.error.code), recurlyResponse.error.message));
                }
            }

            return response;
        }

        /// <summary>
        /// Translate recurly field names to TokenResponse field names
        /// </summary>
        /// <param name="fieldName"></param>
        /// <returns></returns>
        internal override string translateFieldName(string fieldName)
        {
            return !string.IsNullOrEmpty(fieldNames.Get(fieldName)) ? fieldNames[fieldName] : fieldName;
        }
    }
}
