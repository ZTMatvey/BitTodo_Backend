using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BitTodo.Domain.Models
{
    public class AppUser : IdentityUser
    {
        public ICollection<Group> Groups { get; set; }
    }
}
