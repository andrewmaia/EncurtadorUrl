using System;
using System.Collections.Generic;
using System.Linq;
using EncurtadorUrl.Models;
using EncurtadorUrl.DTOS;
using System.Text;

namespace EncurtadorUrl.Services
{
    public interface IUrlService
    {
        Url GetByID(int id);
        bool Delete (int id);
        Url Create(string url, User user);

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

        public Url Create(string url, User user)
        {
            Url u = new Url();
            u.FullUrl = url;
            u.ShortUrl= string.Concat("http://", Guid.NewGuid().ToString().Substring(0,10));
            u.Hits =0;
            u.User=user;

            _context.Urls.Add(u);
            _context.SaveChanges();

            return u;
        }


    }
}