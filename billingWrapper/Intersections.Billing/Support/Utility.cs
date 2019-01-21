using System.Text.RegularExpressions;

namespace Intersections.Billing.Support
{
    /// <summary>
    /// Helper class to support the functionality
    /// </summary>
    public class Utility
    {
        /// <summary>
        /// Visa: Starts with 4
        /// MasterCard: Start with: 2221-2720, 51-55
        /// Discover: Start with: 6011, 622126-622925, 644-649, 65
        /// AMEX: Start with: 34, 37
        /// </summary>
        private const string cardRegex = "^(?:(?<Visa>(?:4[0-9]{0,}))" +
                                         "|(?<MasterCard>(?:5[1-5]|222[1-9]|22[3-9]|2[3-6]|27[01]|2720)[0-9]{0,})" +
                                         "|(?<Discover>(?:6011|65|64[4-9]|62212[6-9]|6221[3-9]|622[2-8]|6229[01]|62292[0-5])[0-9]{0,})" +
                                         "|(?<Amex>(?:3[47][0-9]{0,})))$";

        /// <summary>
        /// Returns the CardType if a regex match is found in the input card
        /// </summary>
        /// <param name="cardNum"></param>
        /// <returns></returns>
        public static CreditCardType? GetCardTypeFromNumber(string cardNum)
        {
            //Create new instance of Regex comparer with our
            //credit card regex pattern
            Regex cardTest = new Regex(cardRegex);

            //Compare the supplied card number with the regex
            //pattern and get reference regex named groups
            GroupCollection gc = cardTest.Match(cardNum).Groups;

            //Compare each card type to the named groups to 
            //determine which card type the number matches
            if (gc[CreditCardType.Visa.ToString()].Success)
            {
                return CreditCardType.Visa;
            }
            else if (gc[CreditCardType.Amex.ToString()].Success)
            {
                return CreditCardType.Amex;
            }
            else if (gc[CreditCardType.MasterCard.ToString()].Success)
            {
                return CreditCardType.MasterCard;
            }
            else if (gc[CreditCardType.Discover.ToString()].Success)
            {
                return CreditCardType.Discover;
            }
            else
            {
                //Card type is not supported by our system, return null
                //(You can modify this code to support more (or less)
                // card types as it pertains to your application)
                return null;
            }
        }
        /// <summary>
        /// Enumerations to store accepted credit cards
        /// </summary>
        public enum CreditCardType
        {
            Visa,
            MasterCard,
            Discover,
            Amex
        }
    }
}
