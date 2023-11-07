using Authorization_Microservice.Security;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Authorization_Microservice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {

        private readonly IJwtAuthenticationManager jwtAuthenticationManager;

        public AuthenticationController(IJwtAuthenticationManager jwtAuthenticationManager)
        {
            this.jwtAuthenticationManager = jwtAuthenticationManager;
        }
        // GET: api/<AuthenticationController>
        [EnableCors("AllowOrigin")]
        [HttpGet]
        public string Authenticate(string Username,string Password)
        {
            var tokenString = jwtAuthenticationManager.Authenticate(Username, Password);

            if (tokenString == null)
            {
                return null;
            }
            else
            {
                return tokenString;
            }

        }
    }
}
