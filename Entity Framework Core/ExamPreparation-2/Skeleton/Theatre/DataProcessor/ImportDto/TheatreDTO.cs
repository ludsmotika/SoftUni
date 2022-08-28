using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Theatre.DataProcessor.ImportDto
{
    [JsonObject("Theatre")]
    public class TheatreDTO
    {
        [JsonProperty("Name")]
        [Required]
        [MaxLength(30)]
        [MinLength(4)]
        public string Name { get; set; }


        [JsonProperty("NumberOfHalls")]
        [Range(typeof(sbyte),"1","10")]
        [Required]
        public sbyte NumberOfHalls{ get; set; }


        [JsonProperty("Director")]
        [Required]
        [MaxLength(30)]
        [MinLength(4)]
        public string Director{ get; set; }


        [JsonProperty("Tickets")]
        public List<TicketDTO> Tickets { get; set; }
    }
}
