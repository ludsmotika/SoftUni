using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SoftJail.DataProcessor.ImportDto
{
    public class PrisonerDTO
    {
        [Required]
        [JsonProperty(nameof(FullName))]
        [MinLength(3)]
        [MaxLength(20)]
        public string FullName { get; set; }


        [Required]
        [RegularExpression(@"The [A-Z][a-z]*")]
        public string Nickname { get; set; }



        [Range(18,65)]
        [JsonProperty(nameof(Age))]
        public int Age { get; set; }


        [Required]
        [JsonProperty(nameof(IncarcerationDate))]
        public string IncarcerationDate { get; set; }

        [JsonProperty(nameof(ReleaseDate))]
        public string ReleaseDate { get; set; }


        [JsonProperty(nameof(Bail))]
        [Range(typeof(decimal),"0", "79228162514264337593543950335")]
        public decimal? Bail { get; set; }


        public int? CellId { get; set; }
        public List<MailDTO> Mails { get; set; }
    }
}
