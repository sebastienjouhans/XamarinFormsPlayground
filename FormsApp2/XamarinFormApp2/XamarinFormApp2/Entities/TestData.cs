﻿namespace XamarinFormApp2.Entities
{
    using System.Collections.Generic;

    using Newtonsoft.Json;

    public class TestData
    {

        [JsonProperty(PropertyName = "users")]
        public List<User> Users { get; set; }

        [JsonProperty(PropertyName = "Countries")]
        public List<Country> Countries { get; set; }
    }
}
