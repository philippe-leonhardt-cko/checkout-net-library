[![Checkout.com](https://cdn.checkout.com/img/checkout-logo-online-payments.jpg)](https://checkout.com/)

# Checkout .NET Standard Library

[Checkout.com](https://checkout.com/) is a software platform that has integrated 100% of the value chain to create payment infrastructures that truly make a difference.

## Target Frameworks

The library targets the following frameworks: 
* .NET Standard 1.3 or higher
* .NET Framework 4.5
* .NET Framework 4.0

## How to use the library

### 1. Installation
In order to use the Checkout .Net Standard Library you have two options:
>1. Either install the library through NuGet by searching for the NuGet package name *Checkout.ApiClient* and installing it 
>2. Or download the source code from our [master branch on GitHub](https://github.com/checkout/checkout-net-library/tree/master) and reference it in your solution.

After that add the library namespace `Checkout` in your code like this:   
```csharp
using Checkout;
```

If you get class name conflicts please add a namespace alias as shown below:
```csharp
using CheckoutEnvironment = Checkout.Helpers.Environment;
```

### 2. Configuration
Before initializing a new instance of the `ApiClient(CheckoutConfiguration configuration)` class, you will be required to **specify the configuration**.
The `CheckoutConfiguration` object consists of the following settable parameters:

Parameter|Description|Required|Type|Default Value
:---|---|:---:|---|---
SecretKey|Your SecretKey is provided to you in The Hub - see [where to find it](https://docs.checkout.com/docs/business-level-administration#section-view-api-keys).|true|`string`|`null`
PublicKey|Your PublicKey is provided to you in The Hub - see [where to find it](https://docs.checkout.com/docs/business-level-administration#section-view-api-keys).|true|`string`|`null`
Environment|You may set this to either `Checkout.Helpers.Environment.Sandbox` or `Checkout.Helpers.Environment.Live`.<br /><br />Default is `Checkout.Helpers.Environment.Sandbox`|false|`enum`|`null`
MaxResponseContentBufferSize|Sets the maximum number of bytes to buffer when reading the response.<br /><br />Default is `10240`.|false|`int`|`10240`
RequestTimeout|Set your default number of seconds to wait before the request times out on the ApiHttpClient.<br /><br />Default is `60`.|false|`int`| `60`
DebugMode|If set to `true`, the HttpRequests and HttpResponses will be logged to console. Set this option to `false` when going Live.<br /><br />Default is `false`.|false|`bool`|`false`

E.g. specifying your configuration for Sandbox could look like this:
```csharp
CheckoutConfiguration configuration = new CheckoutConfiguration()
{
	SecretKey = "sk_test_{your_secret_key}",
	PublicKey = "pk_test_{your_public_key}",
	DebugMode = true
};
```

Then, you can pass the configuration to the constructor of the `ApiClient` class ...
```csharp
ApiClient CheckoutClient = new ApiClient(configuration);
```
... and you are set up to be using our various API endpoints.

>Congratulations for installing and configuring the Checkout .NET Standard Library! If you want to learn what's next, continue reading about our API endpoints.

## Endpoints 
There are various API endpoints that the `ApiClient` interacts with.
>Make sure you visit our [Docs](https://docs.checkout.com/docs/api-quickstart) if you want to learn in more detail about the endpoints and how they interact. There is even full [examples for transaction lifecycles](https://docs.checkout.com/docs/integration-options) and more details about our fully proprietory solutions that are worth checking out.

Supporting Docs:
- [Codes](https://docs.checkout.com/docs/codes)

## API Methods

Each Endpoint has its own **Service** and each Service respectively contains methods. There are **Interfaces** for all Services.

Endpoint|Service|Interface
---|---|---
Cards|`CardService`|[ICardService](#IcardService)
Charges|`ChargeService`|[IChargeService](#IChargeService)
Customers|`CustomerService`|[ICustomerService](#ICustomerService)
Lookups|`LookupsService`|[ILookupsService](#ILookupsService)
Payouts|`PayoutsService`|[IPayoutsService](#IPayoutsService)
RecurringPayments|`RecurringPaymentsService`|[IRecurringPaymentsService](#IRecurringPaymentsService)
Reporting|`ReportingService`|[IReportingService](#IReportingService)
Tokens|`TokenService`|[ITokenService](#ITokenService)

> After initializing the `ApiClient`, you can make any API Calls by simply writing `{ApiClient_instance}.{Service}.{Method}`. Every API Call is a RESTful HttpRequest that returns an HttpResponse<T> with a corresponding Generic Type Object. The properties of the Generic Type Object are accessible through the HttpResponse<T\>.Model property.
>
> Have a look at this example:
>```csharp
>// Adding the Checkout namespace
>using Checkout;
>
>// Creating an instance of CheckoutConfiguration with configurations for Sandbox
>CheckoutConfiguration sandbox_configuration = new CheckoutConfiguration()
>{
>	SecretKey = "sk_test_{your_secret_key}",
>	PublicKey = "pk_test_{your_public_key}",
>	DebugMode = true
>};
>
>try
>{
>	// Initializing the ApiClient using the Sandbox configuration
>	ApiClient CheckoutClient = new ApiClient(sandbox_configuration);
>
>	// Making an API Call to find details about the bank with Bank Identification Number (BIN) 465945
>	string bin = "465945";
>	HttpResponse<CountryInfo> response = CheckoutClient.LookupService.GetBinLookup(bin);
>
>	// Any HttpResponse has a public "Model" property that gives access to the underlying properties of the returned Generic Type - here: CountryInfo
>	Console.WriteLine(response.Model.Bin);
>	Console.WriteLine(response.Model.IssuerCountryISO2);
>	Console.WriteLine(response.Model.CountryName);
>	Console.WriteLine(response.Model.BankName);
>	Console.WriteLine(response.Model.CardScheme);
>	Console.WriteLine(response.Model.CardType);
>	Console.WriteLine(response.Model.CardCategory);
>
>	/* Output to the console:
>	"465945"
>	"GB"
>	"United Kingdom"
>	"HSBC BANK PLC"
>	"Visa"
>	"Debit"
>	"Consumer"
>	*/
>}
>catch (Exception e)
>{
>	// ... Handle exception
>}
>```

<br />
<br />

### Available methods on the Interfaces:

<div id="ICardService" />

#### ICardService
```csharp
namespace Checkout.ApiServices.Cards
{
    public interface ICardService
    {
        HttpResponse<Card> CreateCard(string customerId, CardCreate requestModel);
        HttpResponse<Card> CreateCard(string customerId, string cardToken);
        HttpResponse<OkResponse> DeleteCard(string customerId, string cardId);
        HttpResponse<Card> GetCard(string customerId, string cardId);
        HttpResponse<CardList> GetCardList(string customerId);
        HttpResponse<OkResponse> UpdateCard(string customerId, string cardId, CardUpdate requestModel);
    }
}
```
<br />

<div id="IChargeService" />

#### IChargeService
```csharp
namespace Checkout.ApiServices.Charges
{
    public interface IChargeService
    {
        HttpResponse<Capture> CaptureCharge(string chargeId, ChargeCapture requestModel);
        HttpResponse<Charge> ChargeWithCard(CardCharge requestModel);
        HttpResponse<Charge> ChargeWithCardId(CardIdCharge requestModel);
        HttpResponse<Charge> ChargeWithCardToken(CardTokenCharge requestModel);
        HttpResponse<Charge> ChargeWithDefaultCustomerCard(DefaultCardCharge requestModel);
        HttpResponse<Charge> ChargeWithLocalPayment(LocalPaymentCharge requestModel);
        HttpResponse<Charge> GetCharge(string chargeId);
        HttpResponse<ChargeHistory> GetChargeHistory(string chargeId);
        HttpResponse<Refund> RefundCharge(string chargeId, ChargeRefund requestModel);
        HttpResponse<OkResponse> UpdateCharge(string chargeId, ChargeUpdate requestModel);
        HttpResponse<Charge> VerifyCharge(string paymentToken);
        HttpResponse<Void> VoidCharge(string chargeId, ChargeVoid requestModel);
    }
}
```
<br />

<div id="ICustomerService" />

#### ICustomerService
```csharp
namespace Checkout.ApiServices.Customers
{
    public interface ICustomerService
    {
        HttpResponse<Customer> CreateCustomer(CustomerCreate requestModel);
        HttpResponse<OkResponse> DeleteCustomer(string customerId);
        HttpResponse<Customer> GetCustomer(string identifier);
        HttpResponse<CustomerList> GetCustomerList(CustomerGetList request);
        HttpResponse<OkResponse> UpdateCustomer(string customerId, CustomerUpdate requestModel);
    }
}
```

<br />

<div id="ILookupsService" />

#### ILookupsService
```csharp
namespace Checkout.ApiServices.Lookups
{
    public interface ILookupsService
    {
        HttpResponse<CountryInfo> GetBinLookup(string bin);
        HttpResponse<LocalPaymentData> GetLocalPaymentIssuerIds(string lppId);
    }
}
```

<br />

<div id="IPayoutsService" />

#### IPayoutsService
```csharp
namespace Checkout.ApiServices.Payouts
{
    public interface IPayoutsService
    {
        HttpResponse<Payout> MakePayout(BasePayout requestModel);
    }
}
```
<br />

<div id="IRecurringPaymentsService" />

#### IRecurringPaymentsService 
```csharp
namespace Checkout.ApiServices.RecurringPayments
{
    public interface IRecurringPaymentsService
    {
        HttpResponse<OkResponse> CancelCustomerPaymentPlan(string customerPlanId);
        HttpResponse<OkResponse> CancelPaymentPlan(string planId);
        HttpResponse<SinglePaymentPlanCreateResponse> CreatePaymentPlan(SinglePaymentPlanCreateRequest requestModel);
        HttpResponse<CustomerPaymentPlan> GetCustomerPaymentPlan(string customerPlanId);
        HttpResponse<ResponsePaymentPlan> GetPaymentPlan(string planId);
        HttpResponse<QueryCustomerPaymentPlanResponse> QueryCustomerPaymentPlan(QueryCustomerPaymentPlanRequest requestModel);
        HttpResponse<QueryPaymentPlanResponse> QueryPaymentPlan(QueryPaymentPlanRequest requestModel);
        HttpResponse<OkResponse> UpdateCustomerPaymentPlan(string customerPlanId, CustomerPaymentPlanUpdate requestModel);
        HttpResponse<OkResponse> UpdatePaymentPlan(string planId, PaymentPlanUpdate requestModel);
    }
}
```

<br />

<div id="IReportingService" />

#### IReportingService
```csharp
namespace Checkout.ApiServices.Reporting
{
    public interface IReportingService
    {
        HttpResponse<QueryChargebackResponse> QueryChargeback(QueryRequest requestModel);
        HttpResponse<QueryTransactionResponse> QueryTransaction(QueryRequest requestModel);
    }
}
```

<br />

<div id="ITokenService" />

#### ITokenService
```csharp
namespace Checkout.ApiServices.Reporting
{
    public interface IReportingService
    {
        HttpResponse<QueryChargebackResponse> QueryChargeback(QueryRequest requestModel);
        HttpResponse<QueryTransactionResponse> QueryTransaction(QueryRequest requestModel);
    }
}
```
<br />

## Examples

Have a look at a few more examples. More detailed information on various Models to be passed in the API Methods are available in our [Merchant API Reference](https://docs.checkout.com/docs/additional-apis). It is assumed that you already have instantiated your `ApiClient` with name **CheckoutClient**.

### Charges

#### Charge with full Card Details (PCI compliant merchants only)
- API Method: `ChargeWithCard(CardCharge requestModel)`
- requires: `CardCharge requestModel`

```csharp
// Create CardCharge requestModel
var cardChargeRequestModel = new CardCharge()
{
	Email = "myEmail@hotmail.com",
	AutoCapture = "Y",
	AutoCapTime = 0,
	Currency = "Usd",
	TrackId = "TRK12345",
	TransactionIndicator = "1",
	CustomerIp = "82.23.168.254",
	Description = "Ipad for Ebs travel",
	Value = "100",
	Card = new CardCreate()
	{
		ExpiryMonth = "06",
		ExpiryYear = "2018",
		Cvv = "100",
		Number = "4242424242424242",
		Name = "Mehmet Ali",
		BillingDetails = new Address()
		{
			AddressLine1 = "Flat 1",
			AddressLine2 = "Glading Fields",
			Postcode = "N16 2BR",
			City = "London",
			State = "Hackney",
			Country = "GB",
			Phone = new Phone()
			{
				CountryCode = "44",
				Number = "203 583 44 55"
			}
		}
	},
	Products = new List<Product>(){
		new Product{ 
			Name = "iPad 3", 
			Price = 100, 
			Quantity = 1, 
			ShippingCost = 10.5, 
			Description = "Gold edition", 
			Image = "http://goofle.com/?id=12345", 
			Sku = "TR12345",
			TrackingUrl = "http://tracket.com?id=123456"
		}
	},
	ShippingDetails = new Address()
	{
		AddressLine1 = "Flat 1",
		AddressLine2 = "Glading Fields",
		Postcode = "N16 2BR",
		City = "London",
		State = "Hackney",
		Country = "GB",
		Phone = new Phone()
		{
			CountryCode = "44",
			Number = "203 583 44 55"
		}
	},
	Metadata = new Dictionary<string, string>()
	{
		{ "extraInformation", "EBS travel" }
	},
	Udf1 = "udf1 string",
	Udf2 = "udf2 string",
	Udf3 = "udf3 string",
	Udf4 = "udf4 string",
	Udf5 = "udf5 string"
};

try
{
	// Submit your request and receive a response from the API Endpoint
	HttpResponse<Charge> response = CheckoutClient.ChargeService.ChargeWithCard(cardChargeRequestModel);

	if (!response.HasError)
	{
		// Access the response object retrieved from the API
		var charge = response.Model;
		// ... Do stuff
	}
	else
	{
		// API has returned an error object. You can access the details in the error property of the response.
		// response.error
		// ... Handle error
	}
}
catch (Exception e)
{
	// ... Handle exception
}
```

### Customers

#### Create customer with card example

```csharp
// Create payload
var customerCreateRequest = new CustomerCreate()
{
	Name = "Miss Matt Quigley",
	Description = "New customer created",
	Email = "myEmail1@hotmail.com",
	Phone =  new Phone()
			{
				CountryCode = "44",
				Number = "203 583 44 55"
			},
	Metadata = new Dictionary<string, string>() { { "Category", "UK customer" } },
	Card =  new CardCreate()
	{
		ExpiryMonth = "06",
		ExpiryYear = "2018",
		Cvv = "100",
		Number = "4242424242424242",
		Name = "Miss Matt Quigley",
		BillingDetails = new Address()
		{
			AddressLine1 = "Flat 1",
			AddressLine2 = "Glading Fields",
			Postcode = "N16 2BR",
			City = "London",
			State = "Hackney",
			Country = "GB",
			Phone = new Phone()
			{
				CountryCode = "44",
				Number = "203 583 44 55"
			}
		}
	}
};

try
{
	// Submit your request and receive an apiResponse
	HttpResponse<Customer> apiResponse = CheckoutClient.CustomerService.CreateCustomer(customerCreateRequest);

	if (!apiResponse.HasError)
	{
		// Access the response object retrieved from the api
		var customer = apiResponse.Model;
	}
	else
	{
		// Api has returned an error object. You can access the details in the error property of the apiResponse.
		// apiResponse.error
	}
}
catch (Exception e)
{
	//... Handle exception
}
```

#### Cards
##### Create card
```csharp
// Create payload
var cardCreateRequest = new CardCreate()
{
	ExpiryMonth = "06",
	ExpiryYear = "2018",
	Cvv = "100",
	Number = "4242424242424242",
	Name = "Miss Matt Quigley",
	BillingDetails = new Address()
	{
		AddressLine1 = "Flat 1",
		AddressLine2 = "Glading Fields",
		Postcode = "N16 2BR",
		City = "London",
		State = "Hackney",
		Country = "GB",
		Phone = new Phone()
		{
			CountryCode = "44",
			Number = "203 583 44 55"
		}
	}, 
	DefaultCard=true
};

try
{
	// Submit your request and receive an apiResponse
	HttpResponse<Card> apiResponse = CheckoutClient.CardService.CreateCard("cust_9DECF6A8-DBF7-46F3-927D-BA6C3CE1F501", cardCreateRequest);

	if (!apiResponse.HasError)
	{
		// Access the response object retrieved from the api
		var card = apiResponse.Model;
	}
	else
	{
		// Api has returned an error object. You can access the details in the error property of the apiResponse.
		// apiResponse.error
	}
}
catch (Exception e)
{
	//... Handle exception
}
```

#### Tokens
##### Create payment token example

```csharp
// Create payload
var paymentTokenRequest = new PaymentTokenCreate()
  {
	  Currency = "usd",
	  Value = "100",
	  AutoCapTime = 1,
	  AutoCapture = "N",
	  ChargeMode = 1,
	  Email = "myEmail1@hotmail.com",
	  CustomerIp = "82.23.168.254",
	  TrackId = "TRK12345", 
	  Description = "new payment token",
	  Products = new List<Product>(){
		new Product{ 
			Name="ipad 3", 
			Price=100, 
			Quantity=1, 
			ShippingCost=10.5M, 
			Description="Gold edition", 
			Image="http://goofle.com/?id=12345", 
			Sku="TR12345", TrackingUrl="http://tracket.com?id=123456"
		}
	},
	  ShippingDetails = new Address()
	  {
		  AddressLine1 = "Flat 1",
		  AddressLine2 = "Glading Fields",
		  Postcode = "N16 2BR",
		  City = "London",
		  State = "Hackney",
		  Country = "GB",
		  Phone = new Phone()
		  {
			  CountryCode = "44",
			  Number = "203 583 44 55"
		  }
	  },
	  Metadata = new Dictionary<string, string>() { { "extraInformation", "EBS travel" } },
	  Udf1 = "udf1 string",
	  Udf2 = "udf2 string",
	  Udf3 = "udf3 string",
	  Udf4 = "udf4 string",
	  Udf5 = "udf5 string"
  };

try
{
	// Submit your request and receive an apiResponse
	HttpResponse<PaymentToken> apiResponse = CheckoutClient.TokenService.CreatePaymentToken(paymentTokenRequest);

	if (!apiResponse.HasError)
	{
		// Access the response object retrieved from the api
		var paymentToken = apiResponse.Model;
	}
	else
	{
		// Api has returned an error object. You can access the details in the error property of the apiResponse.
		// apiResponse.error
	}
}
catch (Exception e)
{
	//... Handle exception
}
```

##### Verify charge example

```csharp
// Create payload
string paymentToken = "pay_tok_e6ef69d3-11b2-473d-bdc0-6b03c8713454";

try
{
	// Submit your request and receive an apiResponse
	HttpResponse<Charge> apiResponse = CheckoutClient.ChargeService.VerifyCharge(paymentToken);

	if (!apiResponse.HasError)
	{
		// Access the response object retrieved from the api
		var charge = apiResponse.Model;
	}
	else
	{
		// Api has returned an error object. You can access the details in the error property of the apiResponse.
		// apiResponse.error
	}

}
catch (Exception e)
{
	//... Handle exception
}
```
## Debug Mode

If you enable the debug mode the HttpRequests and HttpResponses will be logged to console. Set this option to `false` when going live. Default is `false`.

## Build

To build the library from source, .NET Framework 4.6.1 or later is required. 

## Tests

All the tests are written with NUnit and reside in the `*.Tests` projects.

## Going Live

- In the _Account Keys_ section of the configuration options, place your **live** keys ([where to find them](https://docs.checkout.com/docs/business-level-administration#section-view-api-keys))
- In the _Basic_ section of the configuration options, switch the _Environment_ to **live**
- Ensure that you have correctly configured the Redirection URLs and Webhooks in your **live** Checkout.com HUB


## Reference 

You can find our complete Documentation [here](http://docs.checkout.com/ "here").  
If you would like to get an account manager, please contact us at sales@checkout.com  
For help during the integration process you can contact us at integration@checkout.com  
For support, you can contact us at support@checkout.com

_Checkout.com is authorised and regulated as a Payment institution by the UK Financial Conduct Authority._
