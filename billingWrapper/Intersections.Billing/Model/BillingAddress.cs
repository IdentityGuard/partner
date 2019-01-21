namespace Intersections.Billing.Model
{
    /// <summary>
    /// Billing Address associated with the creditcard, that was used to generate the token
    /// </summary>
    public class BillingAddress
    {
        /// <summary>
        /// Address Line1
        /// </summary>
        public string street1 { get; private set; }
        /// <summary>
        /// Address line2
        /// </summary>
        public string street2 { get; private set; }
        /// <summary>
        /// City
        /// </summary>
        public string city { get; private set; }
        /// <summary>
        /// State
        /// </summary>
        public string state { get; private set; }
        /// <summary>
        /// Zipcode
        /// </summary>
        public string zip { get; private set; }

        public BillingAddress(string line1, string line2, string city, string state, string zip)
        {
            this.street1 = line1;
            this.street2 = line2;
            this.city = city;
            this.state = state;
            this.zip = zip;
        }
    }
}
