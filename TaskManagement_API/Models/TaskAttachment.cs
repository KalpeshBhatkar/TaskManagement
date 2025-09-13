using System.ComponentModel.DataAnnotations;

namespace TaskManagement_API.Models
{
    public class TaskAttachment
    {
        [Key]
        public long TaskAttachmentID { get; set; }
        public long TaskID { get; set; }
        [Required, MaxLength(250)]
        public string FileName { get; set; }
        [Required, MaxLength(500)]
        public string FilePath { get; set; }
        public long CreatedID { get; set; }
        public DateTime CreatedDate { get; set; }
        public long? ModifiedID { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public long? DeletedID { get; set; }
        public DateTime? DeletedDate { get; set; }
        public bool IsDeleted { get; set; }
    }
}
