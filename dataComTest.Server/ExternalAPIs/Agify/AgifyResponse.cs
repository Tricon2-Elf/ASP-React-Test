﻿using System.Text.Json.Serialization;

namespace dataComTest.Server.ExternalAPIs.Agify
{
    public class AgifyResponse
    {
        [JsonPropertyName("name")]
        public string? Name { get; set; }

        [JsonPropertyName("age")]
        public int Age { get; set; }

        [JsonPropertyName("count")]
        public int Count { get; set; }
    }
}
