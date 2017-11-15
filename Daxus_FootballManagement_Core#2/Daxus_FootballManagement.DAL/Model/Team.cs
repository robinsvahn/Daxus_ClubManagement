using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Daxus_FootballManagement.DAL.Model
{
    public class Team
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public ICollection<Contract> Contracts { get; set; }
    }
}