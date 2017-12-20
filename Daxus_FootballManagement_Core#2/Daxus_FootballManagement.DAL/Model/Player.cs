using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Daxus_FootballManagement.DAL.Model.Interfaces;

namespace Daxus_FootballManagement.DAL.Model
{
    public class Player : IEntity
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Firstname { get; set; }
        [Required]
        public string Lastname { get; set; }
        [Required]
        public DateTime Birthdate { get; set; }
        [Required]
        public DateTime Registered { get; set; }
        public ICollection<Contract> Contracts { get; set; }
        public ICollection<GuestSlot> GuestSlots { get; set; }
    }
}
