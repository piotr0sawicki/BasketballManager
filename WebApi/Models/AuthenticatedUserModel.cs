using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Models
{
    public class AuthenticatedUserModel
    {
        public string Token { get; set; }
        public string UserName { get; set; }
    }
}
