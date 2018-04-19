using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Checkout.ApiServices.RecurringPayments.ResponseModels
{
    public class BaseResponseRecurringPlan
    {
        public string Name { get; set; }
        public string PlanTrackId { get; set; }
        public decimal? AutoCapTime { get; set; }

        [JsonIgnore]
        public int Value
        {
            get { return (int) _privateValue; }
            set { _privateValue = value; }
        }

        // TODO: Explain reason
        [JsonProperty(PropertyName = "value")]
        [Obsolete]
        public decimal _privateValue { get; set; }

        public string Cycle { get; set; }
        public int? RecurringCount { get; set; }
    }
}
