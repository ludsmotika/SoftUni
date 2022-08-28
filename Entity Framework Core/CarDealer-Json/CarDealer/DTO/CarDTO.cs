using CarDealer.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarDealer.DTO
{

    [JsonObject("car")]
    public class CarDTO
    {
        [JsonProperty("Id")]
        public int id { get; set; }


        [JsonProperty("Make")]
        public string Make{ get; set; }


        [JsonProperty("Model")]
        public string Model { get; set; }


        [JsonProperty("TravelledDistance")]
        public long TravelledDistance { get; set; }

    }
}
