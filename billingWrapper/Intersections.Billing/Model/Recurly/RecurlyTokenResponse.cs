using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Intersections.Billing.Model.Recurly
{
    /// <summary>
    /// Represents Response from Recurly token api
    /// </summary>
    internal class RecurlyTokenResponse
    {
        public string id { get; set; }
        public RecurlyTokenError error { get; set; }
    }

    internal class RecurlyTokenError
    {
        public string code { get; set; }
        public string message { get; set; }
        public string[] fields { get; set; }
    }
}
