using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace EncurtadorUrl.Models
{
    public class User
    {
        public int ID { get; set; }
        public string Name { get; set; }  
        public virtual List<Url> UrlList { get; set; }              
    }
}
