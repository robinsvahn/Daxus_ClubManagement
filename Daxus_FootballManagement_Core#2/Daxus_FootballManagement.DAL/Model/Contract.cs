using System;
using System.ComponentModel.DataAnnotations;
using Daxus_FootballManagement.DAL.Model.Interfaces;

namespace Daxus_FootballManagement.DAL.Model
{
    public class Contract : IEntity
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public DateTime ValidFrom { get; set; }
        public DateTime ValidTo { get; set; }
        public double Salary { get; set; }

        public Player Player { get; set; }
        public Team Team { get; set; }
    }
}