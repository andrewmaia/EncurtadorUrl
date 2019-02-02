using System;
using System.Collections.Generic;
using System.Linq;
using EncurtadorUrl.Models;
//using Innovativo;
using System.Text;

namespace EncurtadorUrl.Services
{
    public interface IUrlService
    {
        Url ObterPorID(int id);    
    }
 
    public class UrlService : IUrlService
    {
        private readonly EncurtadorUrlContext _context;
        public UrlService(EncurtadorUrlContext context)
        {
             _context = context;
        }        

        public Url ObterPorID(int id)
        {
            return _context.Urls.FirstOrDefault(x=>x.ID==id);
        }



    }
}