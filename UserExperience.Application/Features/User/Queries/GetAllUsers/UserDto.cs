﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserExperience.Application.Features.User.Queries.GetAllUsers
{
    public class UserDto
    {

        public int Id { get; set; }
        public string UserName { get; set; }

        public string Email { get; set; }

        public string Web { get; set; }

        public string Direccion { get; set; }
    }
}
