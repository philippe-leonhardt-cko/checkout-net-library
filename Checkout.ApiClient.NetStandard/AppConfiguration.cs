using System;
using System.Collections.Generic;
using System.Text;
using CheckoutEnvironment = Checkout.Helpers.Environment;

namespace Checkout
{
    public class AppConfiguration : AppSettings
    {
        private const string _liveUrl = "https://api2.checkout.com/v2";
        private const string _sandboxUrl = "https://sandbox.checkout.com/api2/v2";

        private AppConfiguration() { }

        private AppConfiguration(CheckoutEnvironment mode)
        {
            switch (mode)
            {
                // Configure this section for Sandbox
                case CheckoutEnvironment.Sandbox:
                    base.SecretKey = "sk_test_f952525d-b0eb-4320-a73f-58025ef59dad";
                    base.PublicKey = "pk_test_607415e3-3fe9-4940-a5d2-7f8be318596b";
                    base.BaseApiUri = _sandboxUrl;
                    base.MaxResponseContentBufferSize = 10240;
                    base.RequestTimeout = 60;
                    base.DebugMode = true;
                    base.Environment = CheckoutEnvironment.Sandbox;
                    break;
                // Configure this section for Live
                case CheckoutEnvironment.Live:
                    base.SecretKey = "";
                    base.PublicKey = "";
                    base.BaseApiUri = _liveUrl;
                    base.MaxResponseContentBufferSize = 10240;
                    base.RequestTimeout = 60;
                    base.DebugMode = false;
                    base.Environment = CheckoutEnvironment.Live;
                    break;
            }
        }

        public static AppConfiguration Sandbox()
        {
            return new AppConfiguration(CheckoutEnvironment.Sandbox);
        }

        public static AppConfiguration Live()
        {
            return new AppConfiguration(CheckoutEnvironment.Live);
        }
    }
}
