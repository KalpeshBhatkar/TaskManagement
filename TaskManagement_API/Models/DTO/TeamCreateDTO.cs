using System.ComponentModel.DataAnnotations;

namespace TaskManagement_API.Models.DTO
{
    public class TeamCreateDTO
    {
        [Required]
        [MaxLength(50)]
        public string TeamName { get; set; }
        public long CreatedID { get; set; }
    }
}
