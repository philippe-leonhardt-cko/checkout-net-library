[![Checkout.com](https://cdn.checkout.com/img/checkout-logo-online-payments.jpg)](https://checkout.com/)

# Checkout .NET Standard Library
[![Build Status](https://travis-ci.org/philippe-leonhardt-cko/checkout-net-library.svg?branch=develop)](https://travis-ci.org/philippe-leonhardt-cko/checkout-net-library)

[Checkout.com](https://checkout.com/) is a software platform that has integrated 100% of the value chain to create payment infrastructures that truly make a difference.

## Target Frameworks

The library targets the following frameworks: 
- .NET Standard 1.3 or higher (that includes .NET Core)
- .NET Framework 4.5
- .NET Framework 4.0

## Installation
In order to use the Checkout.com .NET Standard Library you have two installation options:
>1. Either install the library through NuGet by searching for the NuGet package name [*Checkout.ApiClient*](https://www.nuget.org/packages/Checkout.APIClient/) and installing it;
>2. Or download the source code from our [master branch on GitHub](https://github.com/checkout/checkout-net-library/tree/master) and reference it in your solution.

## Initial Setup

### Pre Requirements
- [![PCI Logo][pcilogo]](https://www.pcisecuritystandards.org/) It is a requirement that all Checkout.com merchants validate their *PCI DSS* (**P**ayment **C**ard **I**ndustry **D**ata **S**ecurity **S**tandard) compliance annually. Details about your required level of compliance depend on the Checkout.com solution you want to use. [Read on in our Docs](https://docs.checkout.com/docs/pci-compliance#section-validate-your-pci-compliance) for the details. The [*PCI Security Standard Council*](https://www.pcisecuritystandards.org/) maintains, evolves and promotes the *PCI DSS*.
- Before using the *Checkout.ApiClient* SDK, you require your *Secret Key* that you can get [here](https://docs.checkout.com/docs/business-level-administration#section-view-api-keys) from your Merchant Account a.k.a *The Hub*;
  > If you do not have access to *The Hub* yet, simply go to https://checkout.com and click the "Get Sandbox" button to create a Sandbox Account.
- You have the *Checkout.ApiClient* SDK installed either from [NuGet](https://www.nuget.org/packages/Checkout.APIClient/) or from our [master branch on GitHub](https://github.com/checkout/checkout-net-library/tree/master) and you have referenced it in your project.

### Using the SDK

Add the library namespace `Checkout` to your solution like this:   
```csharp
using Checkout;
```

If you get class name conflicts please add a namespace alias as shown below:
```csharp
using CheckoutEnvironment = Checkout.Helpers.Environment;
```

## Debug Mode

If you enable the debug mode the HttpRequests and HttpResponses will be logged to console. Set this option to `false` when going live. Default is `false`.

## Build

To build the library from source, .NET Framework 4.6.1 or later is required.

## Going Live

- In the _Account Keys_ section of the configuration options, place your **live** keys
- In the _Basic_ section of the configuration options, switch the _Environment_ to **live**
- Ensure that you have correctly configured the Redirection URLs and Webhooks in your **live** Checkout.com HUB

## Reference 

You can find our complete Documentation [here](http://docs.checkout.com/ "here").

### Useful URIs
- [Codes](https://docs.checkout.com/docs/codes)
- [Test Credit Card Numbers](https://docs.checkout.com/docs/testing#section-test-card-numbers)

---

If you would like to get an account manager, please contact us at sales@checkout.com  
For help during the integration process you can contact us at integration@checkout.com  
For support, you can contact us at support@checkout.com

*Checkout.com is authorised and regulated as a Payment institution by the UK Financial Conduct Authority.*

[pcilogo]: https://www.pcisecuritystandards.org/touch-icon-iphone.png (PCI Security Standard Council \(R\))
