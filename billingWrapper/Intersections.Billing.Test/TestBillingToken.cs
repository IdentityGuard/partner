using Intersections.Billing.Model;
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

            TokenRequest request = new TokenRequest(textCardNumber.Text, textYear.Text, textMonth.Text, textCVV.Text
                , textFirstName.Text, textLastName.Text, textAddress1.Text, textCity.Text
                , textState.Text, textPostalCode.Text, textCountry.Text);

            BillingToken billingToken = new BillingToken();
            string intxApiKey = ConfigurationManager.AppSettings["Intersections.Billing.ApiKey"];
            TokenResponse response = await billingToken.get(request, intxApiKey);

            textResult.Text = response.token;
                                                
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
