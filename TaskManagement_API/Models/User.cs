using System.ComponentModel.DataAnnotations;

namespace TaskManagement_API.Models
{
    public class User
    {
        [Key]
        public long UserID { get; set; }
        [Required, MaxLength(100)]
        public string FirstName { get; set; }
        [Required, MaxLength(100)]
        public string LastName { get; set; }
        [Required, MaxLength(50)]
        public string UserName { get; set; }
        [Required, MaxLength(150)]
        public string EmailID { get; set; }
        [Required, MaxLength(50)]
        public string Password { get; set; }
        [Required, MaxLength(100)]
        public string RoleName { get; set; }
        public bool IsActice { get; set; }

        public long CreatedID { get; set; }
        public DateTime CreatedDate { get; set; }
        public long? ModifiedID { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public long? DeletedID { get; set; }
        public DateTime? DeletedDate { get; set; }
        public bool IsDeleted { get; set; }
    }
}
