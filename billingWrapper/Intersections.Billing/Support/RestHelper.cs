using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace Intersections.Billing.Support
{
    internal class RestHelper
    {        
        /// <summary>
        /// Helper method to communicate with REST API endpoint with Form Content
        /// </summary>
        /// <param name="baseAddress">Base address of the REST API</param>
        /// <param name="requestPath">Request pasth of the REST API</param>
        /// <param name="requestHeaders">Request Headers</param>
        /// <param name="formContent">Form Content Data</param>
        /// <returns>Tuple of responseCode and responseBody</returns>
        internal static async Task<Tuple<string, string>> PostFormContentRequest(string baseAddress,string requestPath, Dictionary<string, string> requestHeaders, KeyValuePair<string, string>[] formContent)
        {
            using (var client = new HttpClient())
            {
                //setup client
                client.BaseAddress = new Uri(baseAddress);                

                // Add Headers
                if (requestHeaders != null)
                {
                    foreach (var header in requestHeaders)
                    {
                        client.DefaultRequestHeaders.Add(header.Key, header.Value);
                    }
                }

                //specify TLS1.2 to be used
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

                //setup Form Content data
                var formUrlEncodedContent = new FormUrlEncodedContent(formContent);
                                
                //send request
                HttpResponseMessage responseMessage = await client.PostAsync(requestPath, formUrlEncodedContent);

                //read response
                responseMessage.EnsureSuccessStatusCode();
                var responseJson = await responseMessage.Content.ReadAsStringAsync();
                string responseCode = responseMessage.StatusCode.ToString();
                return new Tuple<string, string>(responseCode, responseJson);
            }
        }
    }
}
