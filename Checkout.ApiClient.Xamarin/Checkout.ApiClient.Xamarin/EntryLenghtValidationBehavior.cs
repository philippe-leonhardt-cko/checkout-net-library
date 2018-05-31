using Xamarin.Forms;

namespace Checkout.ApiClient.Xamarin
{
    public class EntryLengtheValidationBehavior : Behavior<Entry>
    {
        public int MaxLength { private get; set; }

        protected override void OnAttachedTo(Entry entry)
        {
            entry.TextChanged += OnEntryTextChanged;
            base.OnAttachedTo(entry);
        }

        protected override void OnDetachingFrom(Entry entry)
        {
            entry.TextChanged -= OnEntryTextChanged;
            base.OnDetachingFrom(entry);
        }

        void OnEntryTextChanged(object sender, TextChangedEventArgs args)
        {
            Entry entry = (Entry)sender;
            string entryText = entry.Text;
            bool isLonger = entryText.Length > this.MaxLength;
            entry.Text = isLonger ? entryText.Remove(entryText.Length - 1) : entryText;
        }
    }
}
