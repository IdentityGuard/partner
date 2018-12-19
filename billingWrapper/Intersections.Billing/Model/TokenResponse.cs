using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Intersections.Billing.Model
{
    /// <summary>
    /// Represents Token Response
    /// </summary>
    public class TokenResponse
    {
        /// <summary>
        /// Billing Token
        /// </summary>
        public string token { get; private set; }

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
        /// Construct with given Billing Token
        /// </summary>
        /// <param name="token"></param>
        internal TokenResponse(string token)
        {
            this.token = token;
        }

        /// <summary>
        /// Add token to TokenResponse
        /// </summary>
        /// <param name="token"></param>
        internal void addToken(string token)
        {
            this.token = token;
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
