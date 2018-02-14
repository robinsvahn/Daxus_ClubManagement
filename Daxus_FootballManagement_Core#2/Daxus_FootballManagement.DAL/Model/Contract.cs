using System;
using System.ComponentModel.DataAnnotations;
using Daxus_FootballManagement.DAL.Model.Interfaces;

namespace Daxus_FootballManagement.DAL.Model
{
    public class Contract : IEntity
    {
        public Contract()
        {
            CreatedOn = DateTime.UtcNow;
        }

        [Key]
        public int Id { get; set; }
        [Required]
        public DateTime ValidFrom { get; set; }
        [Required]
        public DateTime ValidTo { get; set; }
        [Required]
        public double Salary { get; set; }
        [Required]
        public DateTime CreatedOn { get; }

        public Player PlayerFk { get; set; }
        public Team TeamFk { get; set; }
    }
}