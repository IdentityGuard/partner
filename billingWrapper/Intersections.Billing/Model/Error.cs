namespace Intersections.Billing.Model
{
    /// <summary>
    /// Represents an Error
    /// </summary>
    public class Error
    {
        /// <summary>
        /// Field name where error occured
        /// </summary>
        public string field { get; private set; }

        /// <summary>
        /// Error Message
        /// </summary>
        public string message { get; private set; }

        /// <summary>
        /// Create a fully realized instance of Error
        /// </summary>
        /// <param name="field"></param>
        /// <param name="message"></param>
        internal Error(string field, string message)
        {
            this.field = field;
            this.message = message;
        }
    }
}
