using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SoftJail.DataProcessor.ImportDto
{
    [JsonObject]
    public class DepartmentDTO
    {
        [MinLength(3)]
        [MaxLength(25)]
        [JsonProperty("Name")]
        public string Name { get; set; }

        [JsonProperty("Cells")]
        public List<CellDTO> Cells{ get; set; }
    }
}
