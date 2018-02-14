using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Daxus_FootballManagement.DAL.Model.Interfaces;

namespace Daxus_FootballManagement.DAL.Model
{
    public class Team : IEntity
    {
        public Team()
        {
            CreatedOn = DateTime.UtcNow;
        }

        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public DateTime CreatedOn { get; }

        public ICollection<Contract> Contracts { get; set; }
    }
}