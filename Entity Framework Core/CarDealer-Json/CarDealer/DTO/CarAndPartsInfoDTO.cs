using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarDealer.DTO
{
    public class CarAndPartsInfoDTO
    {
        [JsonProperty("cars")]
        public CarDTO Car { get; set; }



        [JsonProperty("parts")]
        public  List<PartsInfoDTO> Parts{ get; set; }
    }
}
