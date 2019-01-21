using Intersections.Billing.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Intersections.Billing.Test
{
    public partial class TestBillingToken : Form
    {
        public TestBillingToken()
        {
            InitializeComponent();
        }

        private async void buttonGetToken_Click(object sender, EventArgs e)
        {
            buttonGetToken.Enabled = false;
            textErrors.Clear();
            textResult.Clear();

            TokenRequest request = new TokenRequest(textCardNumber.Text.Trim().Replace("-", ""),
                textYear.Text.Trim(), textMonth.Text.Trim(), textCVV.Text.Trim()
                , textFirstName.Text.Trim(), textLastName.Text.Trim(), textAddress1.Text.Trim(), textCity.Text.Trim()
                , textState.Text.Trim(), textPostalCode.Text.Trim(), textCountry.Text.Trim());

            BillingToken billingToken = new BillingToken();
            bool isPreProd = true; // read from config file or as desired 

            TokenResponse response = await billingToken.get(request, isPreProd);
            textResult.Text = JsonConvert.SerializeObject(response, Formatting.Indented);

            if (response.errors != null)
            {
                foreach (var error in response.errors)
                {
                    textErrors.Text += error.field + ": " + error.message + "\r\n";
                }
            }

            buttonGetToken.Enabled = true;
        }
    }
}
