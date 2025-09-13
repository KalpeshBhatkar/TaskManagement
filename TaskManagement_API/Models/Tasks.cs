using System;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace TaskManagement_API.Models
{
    public class Tasks
    {
        [Key]
        public long TaskID { get; set; }
        public long ParentTaskID { get; set; }
        public int TaskNo { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int Progress { get; set; }
        public int TaskTypeID { get; set; }
        public int TeamID { get; set; }
        public int ProjectID { get; set; }
        public int Complexity { get; set; }
        public int PriorityID { get; set; }
        public int TaskStatusID { get; set; }
        public int Duration_Hours { get; set; }
        public int Duration_Minutes { get; set; }
        public long AssignedToID { get; set; }
        public long RequestedByID { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? DueDate { get; set; }
        public long CreatedID { get; set; }
        public DateTime CreatedDate { get; set; }
        public long? ModifiedID { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public long? DeletedID { get; set; }
        public DateTime? DeletedDate { get; set; }
        public bool IsDeleted { get; set; }

    }
}
