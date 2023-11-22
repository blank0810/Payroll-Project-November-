using Newtonsoft.Json;
using System.Collections.Generic;

namespace Payroll_Project2.API_Used
{
    public class AutoCompleteResponse
    {
        public IList<Prediction> Predictions { get; set; }
    }

    public class Prediction
    {
        public string Description { get; set; }

        [JsonProperty(PropertyName = "place_id")]

        public string PlaceId { get; set; }
    }
}
