using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace ProductShop.Dtos.Export
{
    [XmlType("SoldProducts")]
    public class SoldProductsDTO
    {
        [XmlElement("count")]
        public int count{ get; set; }


        [XmlElement("products")]
        public ProdBefDTO SoldProducts { get; set; }
    }
}
