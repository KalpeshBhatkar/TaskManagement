using System.ComponentModel.DataAnnotations;

namespace TaskManagement_API.Models.DTO
{
    public class TeamDTO
    {
        public int TeamID { get; set; }
        [Required]
        [MaxLength(50)]
        public string TeamName { get; set; }
    }
}
