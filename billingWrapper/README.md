# Intersections Billing

This Microsoft .NET class library is developed to get the billing token from Recurly by encapsulating the logic to call Recurly token API. The library is lightweight and can be reference directly in any .NET application running version 4.5 or above.

## Installation instructions
Run the "Intersections.Billing.Setup.msi" or "setup.exe" provided under folder "Intersections.Billing.Setup\Release" and follow installation instructions. By default the application is installed in program files but the location can be changed in installation location dialog box. After the application is installed at desired location, reference "Intersections.Billing.dll" from the .Net project - > Add Reference.

#### Sample client code
```csharp
using Intersectionc.Billing;
using Intersections.Billing.Model;
 
private async void method() 
{
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
        // process errors as desired
    }            
  }
 
}
```

## Testing instructions
The application comes with a desktop based testing application. To install the testing application, run "Intersections.Billing.Test.Setup.msi" under folder "Intersections.Billing.Test.Setup\Release" and follow installation instructions to modify the default install location (program files). Once the application is installed run "Intersections.Billing.Test.exe" application which will open a form to provide test data and simulate different conditions.

## Troubleshooting
The BillingToken.get() method returns an instance of TokenResponse object. It contains billingInfo object and the list of error object. If the call succeeded, the "billingInfo" will be populated with the billingInfo value . If the call fails for any reason, the response will contain the list of errors explaining the field names and error messages. The "billingInfo" will be null in the failure scenario.

#### Sample Error Response
```javascript
{
"billingInfo":null,
"errors":
    [
    { "field":"cardNumber","message":"Number is not a valid credit card number"},
        { "field":"firstName","message":"First Name is required"}
    ]
}
```

#### Sample Success Response
```javascript
{  
   "billingInfo":{  
      "token":"ECw34O4vhdUVhwkGoXV7JA",
      "useHomeAddress":false,
      "address":{  
         "street1":"3901 Stonecroft Blvd",
         "street2":null,
         "city":"Chantilly",
         "state":"VA",
         "zip":"20151"
      },
      "creditCard":{  
         "expirationMonth":"06",
         "expirationYear":"2019",
         "type":"mastercard",
         "lastFour":"1111"
      }
   }
},
"errors": null
}
```
