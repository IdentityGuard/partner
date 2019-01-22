namespace Intersections.Billing.Model
{
    /// <summary>
    /// Credit Card details to be sent in the response 
    /// </summary>
    public class CreditCard
    {
        public string expirationMonth { get; private set; }
        public string expirationYear { get; private set; }
        public string type { get; private set; }
        public string lastFour { get; private set; }

        public CreditCard(string expMonth, string expYear, string type, string lastFour)
        {
            this.expirationMonth = expMonth;
            this.expirationYear = expYear;
            this.type = type;
            this.lastFour = lastFour;
        }
    }
}
