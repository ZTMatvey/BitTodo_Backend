﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitTodo.Domain.DTOs.Request
{
    public sealed class UserLoginDTO
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
