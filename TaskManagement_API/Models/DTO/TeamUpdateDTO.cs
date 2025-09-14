using System.ComponentModel.DataAnnotations;

namespace TaskManagement_API.Models.DTO
{
    public class TeamUpdateDTO
    {
        public int TeamID { get; set; }
        [Required]
        [MaxLength(50)]
        public string TeamName { get; set; }
        public long ModifiedID { get; set; }
    }
}
