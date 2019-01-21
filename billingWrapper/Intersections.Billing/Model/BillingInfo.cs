namespace Intersections.Billing.Model
{
    /// <summary>
    /// Billing Information that will be sent as the object to the caller as the response
    /// which contains toke,, billingaddress, creditcard information and useHomeAddress as false all the time
    /// </summary>
    public class BillingInfo
    {
        /// <summary>
        /// Recurly token
        /// </summary>
        public string token { get; private set; }
        /// <summary>
        /// Use Home Address: always set to true for now
        /// </summary>
        public bool useHomeAddress { get; private set; }

        /// <summary>
        /// BillingAddress
        /// </summary>
        public BillingAddress address { get; private set; }

        /// <summary>
        /// Credit Card information to be populated from the request
        /// </summary>
        public CreditCard creditCard { get; private set; }

        /// <summary>
        /// Constructor to builds the object
        /// </summary>
        /// <param name="token"></param>
        /// <param name="useHomeAddress"></param>
        /// <param name="address"></param>
        /// <param name="creditCard"></param>
        public BillingInfo(string token, bool useHomeAddress, BillingAddress address, CreditCard creditCard)
        {
            this.token = token;
            this.useHomeAddress = false;
            this.address = address;
            this.creditCard = creditCard;
        }
    }
}
