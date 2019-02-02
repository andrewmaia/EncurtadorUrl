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

        public UsersController(IUsersService usersService)
        {
            _usersService = usersService;
        }



        [HttpPost("{userid}/urls")]
        public IActionResult Post(UrlInputDTO urlInputDTO,int userid)        
        {
            StatsDTO s = _usersService.CreateUrl(urlInputDTO,userid);
            if (s==null)
                return BadRequest();

            return Created("api/stats/" + s.ID.ToString(),s);

        }    

    
    }
}
