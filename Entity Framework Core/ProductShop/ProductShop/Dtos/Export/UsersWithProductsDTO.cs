using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace ProductShop.Dtos.Export
{
    [XmlType("Users")]
    public class UsersWithProductsDTO
    {
        [XmlElement("count")]
        public int count{ get; set; }
        [XmlElement("users")]
        public UserProdDTO[] users{ get; set; }
    }
}
