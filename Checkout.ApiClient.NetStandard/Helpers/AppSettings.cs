using Checkout.Utilities;
using System;
using System.Collections.Generic;
using CheckoutEnvironment = Checkout.Helpers.Environment;

namespace Checkout
{
    /// <summary>
    /// Holds application settings that is read from the App.Debug.config or App.Release.config
    /// </summary>

#if NETSTANDARD
    public class AppSettings
    {
        private const string _liveUrl = "https://api2.checkout.com/v2";
        private const string _sandboxUrl = "https://sandbox.checkout.com/api2/v2";
        public const string ClientUserAgentName = "Checkout-DotNetLibraryClient/v1.0";
        public const string DefaultContentType = "application/json";
    
    
        public ApiUrls ApiUrls { get; private set; }
        public string SecretKey { get; set; }
        public string PublicKey { get; set; }
        public string BaseApiUri { get; private set; }
        public int MaxResponseContentBufferSize { get; set; } = 10240;
        public int RequestTimeout { get; set; } = 60;
        public bool DebugMode { get; set; } = false;

        private CheckoutEnvironment _environment;
        public CheckoutEnvironment Environment
        {
            get
            {
                return _environment;
            }

            set
            {
                switch (value)
                {
                    case CheckoutEnvironment.Live:
                        BaseApiUri = _liveUrl;
                        break;
                    case CheckoutEnvironment.Sandbox:
                        BaseApiUri = _sandboxUrl;
                        break;
                };
                _environment = value;
                ApiUrls = new ApiUrls(this);
            }
        }

        public AppSettings()
        {
            ApiUrls = new ApiUrls(this);
        }
    }

#else

  using System.Configuration;
  public class AppSettings
    {
    #region AppConfiguration properties
        private CheckoutEnvironment _environment = CheckoutEnvironment.Undefined;
        private ApiUrls _apiUrls;
        private string _secretKey;
        private string _publicKey;
        private string _baseApiUri;
        private int? _maxResponseContentBufferSize;
        private int? _requestTimeout;
        private bool? _debugMode;
        private const string _liveUrl = "https://api2.checkout.com/v2";
        private const string _sandboxUrl = "https://sandbox.checkout.com/api2/v2";
        public const string ClientUserAgentName = "Checkout-DotNetLibraryClient/v1.0";
        public const string DefaultContentType = "application/json";
    #endregion

        public AppSettings LoadFromConfig()
        {
            return this;
        }

        public ApiUrls ApiUrls
        {
            get { return _apiUrls ?? (_apiUrls = new ApiUrls(this)); }
            set { _apiUrls = value; }
        }

        public string SecretKey
        {
            get { return _secretKey ?? (_secretKey = ReadConfig("Checkout.SecretKey", true)); }
            set { _secretKey = value; }
        }

        public string PublicKey
        {
            get { return _publicKey ?? (_publicKey = ReadConfig("Checkout.PublicKey", true)); }
            set { _publicKey = value; }
        }

        public string BaseApiUri
        {
            get { return _baseApiUri; }
            set { _baseApiUri = value; }
        }

        public int MaxResponseContentBufferSize
        {
            get
            {

                if (_maxResponseContentBufferSize == null)
                {
                    var value = ReadConfig("Checkout.MaxResponseContentBufferSize");
                    _maxResponseContentBufferSize = (!string.IsNullOrEmpty(value) ? int.Parse(value) : 1000000);
                }

                return _maxResponseContentBufferSize.Value;
            }

            set { _maxResponseContentBufferSize = value; }
        }

        public int RequestTimeout
        {
            get
            {
                if (_requestTimeout == null)
                {
                    var value = ReadConfig("Checkout.RequestTimeout");
                    _requestTimeout = (!string.IsNullOrEmpty(value) ? int.Parse(value) : 60);
                }

                return _requestTimeout.Value;
            }
            set { _requestTimeout = value; }
        }

        public bool DebugMode
        {
            get
            {
                if (_debugMode == null)
                {
                    var value = ReadConfig("Checkout.DebugMode");
                    _debugMode = (!string.IsNullOrEmpty(value) ? bool.Parse(value) : false);
                }

                return _debugMode.Value;
            }
            set { _debugMode = value; }
        }

        public CheckoutEnvironment Environment
        {
            get
            {
                return _environment;
            }

            set
            {
                switch (value)
                {
                    case CheckoutEnvironment.Live:
                        _baseApiUri = _liveUrl;
                        break;
                    case CheckoutEnvironment.Sandbox:
                        _baseApiUri = _sandboxUrl;
                        break;
                };
                _environment = value;
                _apiUrls = new ApiUrls(this);
            }
        }

        public void SetEnvironmentFromConfig()
        {
            if (Enum.TryParse<CheckoutEnvironment>(ReadConfig("Checkout.Environment", true), out CheckoutEnvironment selectedEnvironment) && Enum.IsDefined(typeof(CheckoutEnvironment), selectedEnvironment))
            {
                Environment = selectedEnvironment;
            }
            else
            {
                throw new KeyNotFoundException("Config value is invalid for: Environment");
            }
        }

        private string ReadConfig(string key, bool throwIfnotExist = false)
        {
            try
            {
                return ConfigurationManager.AppSettings[key].ToString();
            }
            catch (Exception)
            {
                if (throwIfnotExist)
                {
                    throw new KeyNotFoundException("App settings Key not found for: " + key);
                }

                return null;
            }
        }
    }
#endif
}