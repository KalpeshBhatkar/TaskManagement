using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using TaskManagement_API.Models;

namespace TaskManagement_API.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<Project> Projects { get; set; }
        public DbSet<TaskAttachment> TaskAttachments { get; set; }
        public DbSet<TaskComment> TaskComments { get; set; }
        public DbSet<TaskMember> TaskMembers { get; set; }
        public DbSet<Tasks> Tasks { get; set; }
        public DbSet<TaskManagement_API.Models.TaskStatus> TaskStatus { get; set; }
        public DbSet<TaskTypes> TaskTypes { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<User> Users { get; set; }

    }
}
