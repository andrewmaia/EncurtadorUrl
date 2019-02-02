using System.Collections.Generic;

namespace EncurtadorUrl.DTOS
{
    public class SystemStatsDTO
    {
        public int Hits { get; set; }   
        public int UrlCount { get; set; } 
        public IList<StatsDTO> TopUrls { get; set; }                
    }
}
