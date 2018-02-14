using System;
using System.ComponentModel.DataAnnotations;
using Daxus_FootballManagement.DAL.Model.Interfaces;

namespace Daxus_FootballManagement.DAL.Model
{
    public class GuestSlot : IEntity
    {
        public GuestSlot()
        {
            CreatedOn = DateTime.UtcNow;
        }

        [Key]
        public int Id { get; set; }
        [Required]
        public Guest Guest { get; set; }
        [Required]
        public DateTime CreatedOn { get; }

        public Player PlayerFk { get; set; }
    }
}