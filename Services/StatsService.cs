using System;
using System.Collections.Generic;
using System.Linq;
using EncurtadorUrl.Models;
using EncurtadorUrl.DTOS;
using System.Text;
using AutoMapper;

namespace EncurtadorUrl.Services
{
    public interface IStatsService
    {
        StatsDTO GetByID(int id);
        SystemStatsDTO GetSystemStats();
        StatsDTO Get(Url url);


    }
 
    public class StatsService : IStatsService
    {
        private readonly EncurtadorUrlContext _context;
        private readonly IUrlService _urlService;      
        private readonly IMapper _mapper;           
        public StatsService(EncurtadorUrlContext context,IUrlService urlService,IMapper mapper)
        {
             _context = context;
             _urlService = urlService;
             _mapper = mapper;
        }        

        public StatsDTO GetByID(int id)
        {
            Url url = _urlService.GetByID(id);
            if(url==null)
                return null; 

            return this.Get(url);
        }

        public StatsDTO Get(Url url)
        {
            return _mapper.Map<StatsDTO>(url);
        }        

        public SystemStatsDTO GetSystemStats()
        {
            SystemStatsDTO ss = new SystemStatsDTO();
            ss.UrlCount = _context.Urls.Count();
            ss.Hits = _context.Urls.Sum(x=>x.Hits);
            ss.TopUrls =  this.GetTopUrls();
            return ss;
        }

        private IList<StatsDTO> GetTopUrls()
        {
            IList<Url> urlList = _context.Urls.OrderByDescending(x=>x.Hits).Take(3).ToList();
            IList<StatsDTO> statsList = new List<StatsDTO>();
            foreach(Url url in urlList){
                statsList.Add(Get(url));
            }
            return statsList;
        }
    }
}