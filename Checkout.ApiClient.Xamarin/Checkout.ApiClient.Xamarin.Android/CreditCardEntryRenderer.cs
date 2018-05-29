using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using CustomRenderer.Android;
using Checkout.ApiClient.Xamarin;
using Android.Content;

[assembly: ExportRenderer(typeof(CreditCardEntry), typeof(CreditCardEntryRenderer))]
namespace CustomRenderer.Android
{
    class CreditCardEntryRenderer : EntryRenderer
    {
        public CreditCardEntryRenderer(Context context) : base(context)
        {
        }

        protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
        {
            base.OnElementChanged(e);

            if (Control != null)
            {
                //Control.SetBackgroundColor(global::Android.Graphics.Color.OrangeRed);

                Control.SetBackground(null);
            }
        }
    }
}