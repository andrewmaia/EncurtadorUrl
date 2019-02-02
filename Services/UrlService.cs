using System;
using System.Collections.Generic;
using System.Linq;
using EncurtadorUrl.Models;
using System.Text;

namespace EncurtadorUrl.Services
{
    public interface IUrlService
    {
        Url GetByID(int id);
        bool Delete (int id);
    }
 
    public class UrlService : IUrlService
    {
        private readonly EncurtadorUrlContext _context;
        public UrlService(EncurtadorUrlContext context)
        {
             _context = context;
        }        

        public Url GetByID(int id)
        {
            return _context.Urls.FirstOrDefault(x=>x.ID==id);
        }

        public bool Delete(int id)
        {
            Url url =_context.Urls.FirstOrDefault(x=>x.ID==id);
            if(url==null)
                return false;
            
            _context.Urls.Remove(url);
            _context.SaveChanges();
            return true;
        }

    }
}