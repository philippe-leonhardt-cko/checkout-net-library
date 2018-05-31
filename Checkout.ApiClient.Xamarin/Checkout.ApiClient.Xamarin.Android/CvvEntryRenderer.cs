using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using CustomRenderer.Android;
using Checkout.ApiClient.Xamarin;
using Android.Content;

[assembly: ExportRenderer(typeof(CvvEntry), typeof(CvvEntryRenderer))]
namespace CustomRenderer.Android
{
    class CvvEntryRenderer : EntryRenderer
    {
        public CvvEntryRenderer(Context context) : base(context)
        {
        }

        protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
        {
            base.OnElementChanged(e);

            if (Control != null)
            {
                Control.SetBackground(null);
            }
        }
    }
}