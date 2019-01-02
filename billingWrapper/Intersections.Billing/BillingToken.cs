using Intersections.Billing.Gateway;
using Intersections.Billing.Gateway.Recurly;
using Intersections.Billing.Model;
using Intersections.Billing.Model.Recurly;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Intersections.Billing
{
    public class BillingToken
    {
        /// <summary>
        /// Temporary constant until we have multiple billing providers
        /// </summary>
        private const string billingProvider = "recurly";

        /// <summary>
        /// Get Billing Token in exchange of Credit Card and Billing Information 
        /// </summary>
        /// <param name="tokenRequest">TokenRequest containing billing information</param>
        /// <returns>TokenResponse</returns>
        public async Task<TokenResponse> get(TokenRequest tokenRequest, bool isPreProd)
        {
            try
            {
                var context = new ValidationContext(tokenRequest);
                var results = new List<ValidationResult>();

                var isValid = Validator.TryValidateObject(tokenRequest, context, results, true);

                if (!isValid)
                {
                    TokenResponse tokenResponse = new TokenResponse();                    
                    foreach (var validationResult in results)
                    {
                        tokenResponse.addError(new Error(string.Join(", ", validationResult.MemberNames), validationResult.ErrorMessage));
                    }                    
                    return await Task.FromResult<TokenResponse>(tokenResponse);
                }
                else
                {
                    BillingGateway billingGateway = getBillingGateway();

                    return await billingGateway.getBillingToken(tokenRequest, isPreProd);
                }
            }
            catch(Exception ex)
            {
                TokenResponse tokenResponse = new TokenResponse();
                tokenResponse.addError(new Error("unknown", "Unknown Exception"));
                return tokenResponse;
            }
        }  
     
        /// <summary>
        /// Get Billing Gateway based on Billing Provider
        /// </summary>
        /// <returns></returns>
        private BillingGateway getBillingGateway()
        {
            if (billingProvider == "recurly")
                return new RecurlyGateway();
        }
    }
}
