using System.Collections.Generic;

namespace Intersections.Billing.Model
{
    /// <summary>
    /// Represents Token Response
    /// </summary> 
    public class TokenResponse
    {
        public BillingInfo billingInfo { get; private set;  }

        /// <summary>
        /// List of Error
        /// </summary>
        public List<Error> errors { get; private set; }

        /// <summary>
        /// Default Constructor
        /// </summary>
        public TokenResponse()
        {
            this.errors = new List<Error>();
        }

        /// <summary>
        /// Add token to TokenResponse
        /// </summary>
        /// <param name="token"></param>
        internal void addBillingInfo(BillingInfo billingInfo)
        {
            this.billingInfo = billingInfo;
        }

        /// <summary>
        /// Add Error to TokenResponse
        /// </summary>
        /// <param name="token"></param>
        internal void addError(Error error)
        {
            this.errors.Add(error);
        }
    }



}
