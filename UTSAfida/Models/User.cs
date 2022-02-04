﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace UTSAfida.Models
{
    public class User
    {
        [Key]
        public string Username { get; set; }
        public string Password { get; set; }
        public string Nama { get; set; }
        public string Email { get; set; }
        public Roles Roles { get; set; }

    }
}