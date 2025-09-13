using System.ComponentModel.DataAnnotations;

namespace TaskManagement_API.Models
{
    public class TaskTypes
    {
        [Key]
        public int TaskTypeID { get; set; }
        [Required, MaxLength(250)]
        public string TaskTypeName { get; set; }
        public int OrderBy { get; set; }
        public long CreatedID { get; set; }
        public DateTime CreatedDate { get; set; }
        public long? ModifiedID { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public long? DeletedID { get; set; }
        public DateTime? DeletedDate { get; set; }
        public bool IsDeleted { get; set; }
    }
}
