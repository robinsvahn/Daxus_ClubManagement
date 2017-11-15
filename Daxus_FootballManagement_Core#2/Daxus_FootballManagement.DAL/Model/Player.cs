using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Daxus_FootballManagement.DAL.Model
{
    public class Player
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
        public IEnumerable<Contract> Contracts { get; set; }
        public IEnumerable<GuestSlot> GuestSlots { get; set; }
    }
}
