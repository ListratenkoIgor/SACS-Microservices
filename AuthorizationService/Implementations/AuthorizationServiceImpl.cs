using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Interfaces;

namespace AuthorizationService.Implementations
{
    public class AuthorizationServiceImpl: IAuthorizationService
    {
        public bool Login() { return true; }
        public bool Register() { return true; }
    }
}
