using System;
using System.Collections.Generic;
using System.Linq;
using EncurtadorUrl.Models;
using EncurtadorUrl.DTOS;
using System.Text;

namespace EncurtadorUrl.Services
{
    public interface IUsersService
    {
        StatsDTO CreateUrl(UrlInputDTO urlInputDTO, int userid);
        User CreateUser(string name);        
        bool Delete (int id);        
    }
 
    public class UsersService : IUsersService
    {
        private readonly EncurtadorUrlContext _context;
        private readonly IUrlService _urlService; 

        private readonly IStatsService _statsService;              
        public UsersService(EncurtadorUrlContext context,IUrlService urlService,IStatsService statsService)
        {
             _context = context;
             _urlService = urlService;
             _statsService = statsService;
        }        

        public User GetByID(int id)
        {
            return _context.Users.FirstOrDefault(x=>x.ID==id);
        }

        public StatsDTO CreateUrl(UrlInputDTO urlInputDTO, int userid)
        {
            User user = this.GetByID(userid);
            if (user==null)
                return null;

            Url url = _urlService.Create(urlInputDTO.Url, user);
            return _statsService.Get(url);
        }

        public bool Delete (int id)
        {
            User user =_context.Users.FirstOrDefault(x=>x.ID==id);
            if(user==null)
                return false;

            foreach(Url url in user.UrlList)
                _context.Urls.Remove(url);
            
            _context.Users.Remove(user);
            _context.SaveChanges();
            return true;            
        }

        public User CreateUser(string name)
        {
            if(_context.Users.Any(x=>x.Name.ToLower()==name.ToLower()))
                return null;

            User user = new User();
            user.Name=name.ToLower();
            _context.Users.Add(user);
            _context.SaveChanges();
            return user;
        }
    }
}