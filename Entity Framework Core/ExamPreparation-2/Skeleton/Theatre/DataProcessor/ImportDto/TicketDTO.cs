using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Theatre.DataProcessor.ImportDto
{
    [JsonObject("Ticket")]
    public class TicketDTO
    {
        [Required]
        [JsonProperty("Price")]
        [Range(typeof(decimal), "1", "100")]
        public decimal Price { get; set; }


        [Required]
        [JsonProperty("RowNumber")]
        [Range(typeof(sbyte), "1", "10")]
        public sbyte RowNumber { get; set; }

        [Required]
        [JsonProperty("PlayId")]
        public int PlayId { get; set; }
    }
}
