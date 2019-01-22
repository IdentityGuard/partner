using Intersections.Billing.Gateway.Recurly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Intersections.Billing.Gateway
{
    class GatewayFactory
    {
        public BillingGateway getBillingGateway(string gateway)
        {
            if (gateway == "recurly")
            {
                return new RecurlyGateway();
            }
            return null;
        }
    }
}
