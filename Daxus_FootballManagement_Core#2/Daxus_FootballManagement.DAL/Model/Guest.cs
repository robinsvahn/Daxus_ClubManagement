using System;
using System.ComponentModel.DataAnnotations;
using Daxus_FootballManagement.DAL.Model.Interfaces;

namespace Daxus_FootballManagement.DAL.Model
{
    public class Guest : IEntity
    {
        public Guest()
        {
            CreatedOn = DateTime.UtcNow;
        }

        [Key]
        public int Id { get; set; }
        [Required]
        public string Firstname { get; set; }
        [Required]
        public string Lastname { get; set; }
        [Required]
        public DateTime CreatedOn { get; set; }
        public DateTime Birthdate { get; set; }
        public string FakeChange { get; set; }
    }
}
