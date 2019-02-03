using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Cors;
using Microsoft.Extensions.Primitives;
using System.Data;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.AspNetCore.Authorization;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using System;
using Microsoft.Extensions.Options;
using EncurtadorUrl.Services;
using EncurtadorUrl.Models;
using EncurtadorUrl.DTOS;

namespace EncurtadorUrl.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
      public class UsersController : ControllerBase
    {
        private readonly IUsersService _usersService;
        private readonly IStatsService _statsService;        

        public UsersController(IUsersService usersService,IStatsService statsService )
        {
            _usersService = usersService;
            _statsService = statsService;
        }


        [HttpGet("{userid}/stats")]
        public ActionResult<SystemStatsDTO> Get(int userid)        
        {
            SystemStatsDTO s = _statsService.GetStatsByUser(userid);
            if (s==null)
                return NotFound();
            
            return s;
        }   


        [HttpPost("{userid}/urls")]
        public IActionResult PostUrl(UrlInputDTO urlInputDTO,int userid)        
        {
            StatsDTO s = _usersService.CreateUrl(urlInputDTO,userid);
            if (s==null)
                return BadRequest();

            return Created("api/stats/" + s.ID.ToString(),s);

        }

        [HttpPost]
        public IActionResult Post(UserInputDTO urlInputDTO)        
        {
            User u = _usersService.CreateUser(urlInputDTO.ID);
            if (u==null)
                return Conflict();
   
            return Created("api/users/" + u.ID + "/stats",u);

        }            

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (_usersService.Delete(id))
                return NoContent();
            else
                return NotFound(); 
        }
    
    }
}
