using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace ProductShop.Dtos.Export
{
    public class UserAndProductsDTO
    {
        [XmlElement("count")]
        public int count { get { return this.Users.Length; } }

        [XmlElement("users")]
        public UserProdDTO[] Users { get; set; }

    }
}
