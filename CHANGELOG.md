# CHANGELOG
Starting with version 1.4.0 this project adheres to [Semantic Versioning](http://semver.org/spec/v2.0.0.html).
The lock symbol (:lock:) marks security related updates.

# [Unreleased] :soon:

# [1.4.0](https://github.com/checkout/checkout-net-library/tree/1.4.0.0) (2018-02-xx)

> ### This release is a port to **.NET Standard 1.3** and closes *#23*

## :warning: BREAKING CHANGES
- :lock: **deprecated:** <a name="security_1"></a>.NET 4.0 for only supporting early TLS 1.0
    > The Payment Card Industry Security Standards Council (PCI SSC) is extending the migration completion date to 30 June 2018 for transitioning from SSL and TLS 1.0 to a secure version of TLS (currently v1.1 or higher)... [more](https://blog.pcisecuritystandards.org/migrating-from-ssl-and-early-tls)
- **changed:** `RecurringPaymentsService.Value` to be of type int

## Changes
- **added:** support for passing `AppSettings` in the `APIClient(AppSettings settings)` constructor in favor of configuring AppSettings via custom App Configuration files `App.Debug.config` and `App.Release.config`
    ```csharp
    AppSettings settings = new AppSettings()
    {
        SecretKey = "sk_test_32b9cb39-1cd6-4f86-b750-7069a133667d",
        PublicKey = "pk_test_2997d616-471e-48a5-ba86-c775ed3ac38a",
        MaxResponseContentBufferSize = 10240,
        RequestTimeout = 60,
        DebugMode = true,
        Environment = Checkout.Helpers.Environment.Sandbox
    };

    CheckoutClient = new APIClient(settings);
    ```
- :lock: **changed:** `ServicePointManager.SecurityProtocol` 

# [1.3.0.9](https://github.com/checkout/checkout-net-library/tree/1.3.0.9) (2018-01-22)

## Features
- **added:** support for dynamic redirect URLs in Charge Requests

# [1.3.0.7](https://github.com/checkout/checkout-net-library/tree/1.3.0.7) (2017-10-19)

## Bug Fixes
- **added:** support for Billing Details in Charge with Card Token , closes *#24*

## Features
- **added:** support for Attempt Non 3D in Charge Request

# [1.3.0.6](https://github.com/checkout/checkout-net-library/tree/1.3.0.6) (2016-10-26)

## Features
- **added:** Bin property to `ApiServices.Cards.ResponseModels.Card`