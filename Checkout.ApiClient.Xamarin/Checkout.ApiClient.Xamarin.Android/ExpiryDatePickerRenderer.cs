using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using CustomRenderer.Android;
using Checkout.ApiClient.Xamarin;
using Android.Content;

[assembly: ExportRenderer(typeof(ExpiryDatePicker), typeof(ExpiryDatePickerRenderer))]
namespace CustomRenderer.Android
{
    class ExpiryDatePickerRenderer : DatePickerRenderer
    {
        public ExpiryDatePickerRenderer(Context context) : base(context)
        {
        }

        protected override void OnElementChanged(ElementChangedEventArgs<DatePicker> e)
        {
            base.OnElementChanged(e);

            if (Control != null)
            {
                Control.SetBackground(null);   
            }
        }
    }
}