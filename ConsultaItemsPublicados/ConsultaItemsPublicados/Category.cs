using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace ConsultaItemsPublicados
{
   public class Category
    {
        [JsonPropertyName("id")]
        public string id { get; set; }


        [JsonPropertyName("name")]
        public string name { get; set; }

    }
}
