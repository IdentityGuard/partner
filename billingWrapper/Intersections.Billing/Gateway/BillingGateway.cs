using Intersections.Billing.Model;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Intersections.Billing.Gateway
{
    /// <summary>
    /// Abstract class to be implemented by different billing providers
    /// </summary>
    internal abstract class BillingGateway
    {
        /// <summary>
        /// Base address of Billing Provider REST Api
        /// </summary>
        protected internal string baseAddress;

        /// <summary>
        /// Collection of api Keys of Billing Provider
        /// </summary>
        protected internal NameValueCollection apiKeys;

        /// <summary>
        /// Collection of field names of Billing Provider
        /// </summary>
        protected internal NameValueCollection fieldNames;

        /// <summary>
        /// Get Billing Token from billing provider
        /// </summary>
        /// <param name="request">TokenRequest containing billing information</param>
        /// <param name="apiKey">Api Key provided by billing provider</param>
        /// <returns></returns>
        internal abstract Task<TokenResponse> getBillingToken(TokenRequest request, bool isTest);

        /// <summary>
        /// Translate Billing Provider field names to TokenResponse field names        
        /// </summary>
        /// <param name="fieldName"></param>
        /// <returns></returns>
        internal abstract string translateFieldName(string fieldName);

        /// <summary>
        /// Get Api Key based on key name
        /// </summary>
        /// <param name="fieldName"></param>
        /// <returns></returns>
        internal abstract string getApiKey(bool isTest);
    }
}
