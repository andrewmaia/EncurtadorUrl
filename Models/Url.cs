using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace EncurtadorUrl.Models
{
    public class Url
    {
        public int ID { get; set; }
        public int Hits { get; set; }        
        public string FullUrl { get; set; }        
        public string ShortUrl { get; set; }
    }
}
