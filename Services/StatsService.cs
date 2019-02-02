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

            return _mapper.Map<StatsDTO>(url);                 
        }
    }
}