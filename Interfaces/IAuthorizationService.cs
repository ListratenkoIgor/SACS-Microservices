using Shed.CoreKit.WebApi;
using System;
using System.Collections.Generic;

namespace Interfaces
{
    public interface IAuthorizationService
    {
        
        [HttpPost,Route("login/")]
        public void Login(string Email,string Password,bool RememberMe=true);

        [HttpPost, Route("register/")]
        public void Register(string Email, string Password);
    }
}
