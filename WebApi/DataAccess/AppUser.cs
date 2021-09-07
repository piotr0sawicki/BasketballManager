using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.DataAccess
{
    public class AppUser : IdentityUser
    {
        public string FirstName { get; set; }
    }
}
