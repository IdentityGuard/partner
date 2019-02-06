using Intersections.Billing.Properties;
using System.ComponentModel.DataAnnotations;

namespace Intersections.Billing.Model
{
    /// <summary>
    /// Represents a TokenRequest
    /// </summary>
    public class TokenRequest
    {
        [Required(ErrorMessageResourceType = typeof(ValidationMessages)
            , ErrorMessageResourceName = "cardNumberRequired")]
        [StringLength(20, MinimumLength = 9, ErrorMessageResourceType = typeof(ValidationMessages)
            , ErrorMessageResourceName = "cardNumberLength")]
        [RegularExpression("^[-0-9]+$", ErrorMessageResourceType = typeof(ValidationMessages)
            , ErrorMessageResourceName = "cardNumberInvalid")]
        public string cardNumber { get; private set; }

        [Required(ErrorMessageResourceType = typeof(ValidationMessages)
            , ErrorMessageResourceName = "expirationYearRequired")]
        [StringLength(4, MinimumLength = 4, ErrorMessageResourceType = typeof(ValidationMessages)
            , ErrorMessageResourceName = "expirationYearLength")]
        [RegularExpression("^[0-9]+$", ErrorMessageResourceType = typeof(ValidationMessages)
            , ErrorMessageResourceName = "expirationYearInvalid")]
        public string expirationYear { get; private set; }

        [Required(ErrorMessageResourceType = typeof(ValidationMessages)
            , ErrorMessageResourceName = "expirationMonthRequired")]
        [StringLength(2, MinimumLength = 2, ErrorMessageResourceType = typeof(ValidationMessages)
            , ErrorMessageResourceName = "expirationMonthLength")]
        [RegularExpression("^[0-9]+$", ErrorMessageResourceType = typeof(ValidationMessages)
            , ErrorMessageResourceName = "expirationMonthInvalid")]
        public string expirationMonth { get; private set; }

        [Required(ErrorMessageResourceType = typeof(ValidationMessages)
            , ErrorMessageResourceName = "cvvRequired")]
        [StringLength(4, MinimumLength = 3, ErrorMessageResourceType = typeof(ValidationMessages)
            , ErrorMessageResourceName = "cvvLength")]
        [RegularExpression("^[0-9]+$", ErrorMessageResourceType = typeof(ValidationMessages)
            , ErrorMessageResourceName = "cvvInvalid")]
        public string cardCVV { get; private set; }

        [Required(ErrorMessageResourceType = typeof(ValidationMessages)
            , ErrorMessageResourceName = "firstNameRequired")]
        [RegularExpression(@"^[A-Za-z]*$", ErrorMessageResourceType = typeof(ValidationMessages)
            , ErrorMessageResourceName = "firstNameInvalid")]
        [StringLength(40, MinimumLength = 2, ErrorMessageResourceType = typeof(ValidationMessages)
            , ErrorMessageResourceName = "firstNameLength")]
        public string firstName { get; private set; }

        [Required(ErrorMessageResourceType = typeof(ValidationMessages)
            , ErrorMessageResourceName = "lastNameRequired")]
        [RegularExpression(@"^[A-Za-z-]*$", ErrorMessageResourceType = typeof(ValidationMessages)
            , ErrorMessageResourceName = "lastNameInvalid")]
        [StringLength(40, MinimumLength = 2, ErrorMessageResourceType = typeof(ValidationMessages)
            , ErrorMessageResourceName = "lastNameLength")]
        public string lastName { get; private set; }

        [Required(ErrorMessageResourceType = typeof(ValidationMessages)
            , ErrorMessageResourceName = "street1Required")]
        [StringLength(40, MinimumLength = 3, ErrorMessageResourceType = typeof(ValidationMessages)
            , ErrorMessageResourceName = "street1Length")]
        public string street1 { get; private set; }

        [Required(ErrorMessageResourceType = typeof(ValidationMessages)
            , ErrorMessageResourceName = "cityRequired")]
        [StringLength(40, MinimumLength = 2, ErrorMessageResourceType = typeof(ValidationMessages)
            , ErrorMessageResourceName = "cityLength")]
        [RegularExpression(@"^[A-Za-z ]*$", ErrorMessageResourceType = typeof(ValidationMessages)
            , ErrorMessageResourceName = "cityInvalid")]
        public string city { get; private set; }

        [Required(ErrorMessageResourceType = typeof(ValidationMessages)
            , ErrorMessageResourceName = "stateRequired")]
        [StringLength(2, MinimumLength = 2, ErrorMessageResourceType = typeof(ValidationMessages)
            , ErrorMessageResourceName = "stateLength")]
        [RegularExpression(@"^[A-Za-z]*$", ErrorMessageResourceType = typeof(ValidationMessages)
            , ErrorMessageResourceName = "stateInvalid")]
        public string state { get; private set; }

        [Required(ErrorMessageResourceType = typeof(ValidationMessages)
            , ErrorMessageResourceName = "postalCodeRequired")]
        [StringLength(5, MinimumLength = 5, ErrorMessageResourceType = typeof(ValidationMessages)
            , ErrorMessageResourceName = "postalCodeLength")]
        [RegularExpression("^[0-9]+$", ErrorMessageResourceType = typeof(ValidationMessages)
            , ErrorMessageResourceName = "postalCodeInvalid")]
        public string postalCode { get; private set; }

        [Required(ErrorMessageResourceType = typeof(ValidationMessages)
            , ErrorMessageResourceName = "countryRequired")]
        [StringLength(2, MinimumLength = 2, ErrorMessageResourceType = typeof(ValidationMessages)
            , ErrorMessageResourceName = "countryLength")]
        [RegularExpression(@"^[A-Za-z]*$", ErrorMessageResourceType = typeof(ValidationMessages)
            , ErrorMessageResourceName = "countryInvalid")]
        public string country { get; private set; }

        /// <summary>
        /// Create a fully realized instance of TokenRequest
        /// </summary>
        /// <param name="cardNumber">Credit Card Number</param>
        /// <param name="expirationYear">Credit Card Expiration Year</param>
        /// <param name="expirationMonth">Credit Card Expiration Month</param>
        /// <param name="cardCVV">Credit Card CVV/Security Code</param>
        /// <param name="firstName">Card Holder First Name</param>
        /// <param name="lastName">Card Holder Last Name</param>
        /// <param name="street1">Billing Address Street 1</param>        
        /// <param name="city">Billing Address City</param>
        /// <param name="state">Billing Address State</param>
        /// <param name="postalCode">Billing Address Postal/Zip Code</param>
        /// <param name="country">Billing Address Country</param>
        public TokenRequest(string cardNumber, string expirationYear, string expirationMonth
            , string cardCVV, string firstName, string lastName, string street1, string city
            , string state, string postalCode, string country)
        {
            this.cardNumber = cardNumber;
            this.expirationMonth = expirationMonth;
            this.expirationYear = expirationYear;
            this.cardCVV = cardCVV;
            this.firstName = firstName;
            this.lastName = lastName;
            this.street1 = street1;
            this.city = city;
            this.state = state;
            this.postalCode = postalCode;
            this.country = country;
        }
    }
}
