using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarDealer.DTO
{

    [JsonObject]
    public class CustomerDTO
    {
        [JsonProperty("Name")]
        public string Name { get; set; }


        [JsonProperty("BirthDate")]
        public DateTime BirthDate { get; set; }


        [JsonProperty("IsYoungDriver")]
        public bool IsYoungDriver { get; set; }

    }
}
