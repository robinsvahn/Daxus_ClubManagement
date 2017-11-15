﻿using System;
using System.ComponentModel.DataAnnotations;

namespace Daxus_FootballManagement.DAL.Model
{
    public class Guest
    {
        [Key]
        public int Id { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public DateTime Birthdate { get; set; }
    }
}
