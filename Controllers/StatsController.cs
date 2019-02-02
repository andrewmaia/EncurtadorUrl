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
using EncurtadorUrl.DTOS;

namespace EncurtadorUrl.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
      public class StatsController : ControllerBase
    {
        private readonly IStatsService _statsService;

        public StatsController(IStatsService statsService)
        {
            _statsService = statsService;
        }


        [HttpGet("{id}")]
         public ActionResult<StatsDTO> GetById(int id)
        {
            StatsDTO s =  _statsService.GetByID(id);
            if (s==null)
                return NotFound();
            
            return s;

        }


    }
}
