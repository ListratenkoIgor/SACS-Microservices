using Shed.CoreKit.WebApi;
using System;
using System.Collections.Generic;

namespace Interfaces
{
    public interface IAuthorizationService
    {
        [Route("login/")]
        public bool Login();

        [Route("register/")]
        public bool Register();
    }
}
