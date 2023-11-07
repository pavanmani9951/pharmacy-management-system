using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Authorization_Microservice.Security
{
   public interface IJwtAuthenticationManager
    {
        string Authenticate(string email, string password);
    }
}
