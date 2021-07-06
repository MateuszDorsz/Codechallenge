using Newtonsoft.Json;

namespace CodeChallenge.Data.Serialization
{
    public class ShapeProperties
    {
        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("a")]
        public string A { get; set; }

        [JsonProperty("b")]
        public string B { get; set; }

        [JsonProperty("color")]
        public string Color { get; set; }

        [JsonProperty("center")]
        public string Center { get; set; }

        [JsonProperty("radius")]
        public double? Radius { get; set; }

        [JsonProperty("filled")]
        public bool? Filled { get; set; }

        [JsonProperty("c")]
        public string C { get; set; }
    }
}
