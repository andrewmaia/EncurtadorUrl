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
      public class UrlController : ControllerBase
    {
        private readonly IUrlService _urlService;

        public UrlController(IUrlService urlService)
        {
            _urlService = urlService;
        }


        [HttpGet("{id}")]
         public ActionResult GetById(int id)
        {
            Url url= _urlService.GetByID(id);
            if (url!=null)
                return Redirect(url.FullUrl);
            else
                return NotFound();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (_urlService.Delete(id))
                return NoContent();
            else
                return NotFound(); 
        }

    
    }
}
