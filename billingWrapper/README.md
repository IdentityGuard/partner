# Intersections Billing

This Microsoft .NET class library is developed to get the billing token from Recurly by encapsulating the logic to call Recurly token API. The library is lightweight and can be reference directly in any .NET application running version 4.5 or above.

# Installation instructions
Run the "Intersections.Billing.Setup.msi" or "setup.exe" provided and follow installation instructions. By default the application is installed in program files but the location can be changed in installation location dialog box. After the application is installed at desired location, reference "Intersections.Billing.dll" from the .Net project - > Add Reference.

# Testing instructions
The application comes with a desktop based testing application. To install the testing application, run "Intersections.Billing.Test.Setup.msi" and follow installation instructions to modify the default install location (program files). Once the application is installed run "Intersections.Billing.Test.exe" application which will open a form to provide test data and simulate different conditions.

# Troubleshooting
The BillingToken.get() method returns an instance of TokenResponse object. It contains token and the list of error object. If the call succeeded, the "token" will be populated with the token value. If the call fails for any reason, the response will contain the list of errors explaining the field names and error messages. The "token" will be null in the failure scenario.
