using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using static Jsonproject.Books;

namespace Jsonproject
{
   public class Infodata
   {

          [JsonPropertyName("Books")]
        public List<Books> AllBooksJson { get; set; } = new List<Books>();
       

        [JsonPropertyName("Authors")]
        public List<Authors> AllAuthorsJson { get; set; } = new List<Authors>();



    }
}
