using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace EncurtadorUrl.Models
{
    public class Url
    {
        public int ID { get; set; }
        public string MiniUrl { get; set; }        
        public string FullUrl { get; set; }
    }
}
