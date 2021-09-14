using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.Core.Models
{
    public class AuthenticatedUserModel
    {
        public string Token { get; set; }
        public string UserName { get; set; }
    }
}
