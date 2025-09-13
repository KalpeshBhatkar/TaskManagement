using System.ComponentModel.DataAnnotations;

namespace TaskManagement_API.Models
{
    public class TaskComment
    {
        [Key]
        public long TaskCommentID { get; set; }
        public long TaskID { get; set; }
        [Required]
        public string Comment { get; set; }
        public long CreatedID { get; set; }
        public DateTime CreatedDate { get; set; }
        public long? ModifiedID { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public long? DeletedID { get; set; }
        public DateTime? DeletedDate { get; set; }
        public bool IsDeleted { get; set; }
    }
}
