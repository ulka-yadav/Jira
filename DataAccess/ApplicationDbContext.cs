using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Models.Models;
using Task = Models.Models.Task;

namespace DataAccess
{
    public class ApplicationDbContext:IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { 
        
        }
        public DbSet<ApplicationUser> applicationUser { get; set; }
        public DbSet<ApplicationRole> applicationRole { get; set; }
        public DbSet<Epic> epic { get; set; }
        public DbSet<Project> project { get; set; }
        public DbSet<Status> status { get; set; }
        public DbSet<SubTask> subTask { get; set; }
        public DbSet<Task> task { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

          // Project → User (CreatedBy / ModifiedBy)
                builder.Entity<Project>()
                .HasOne(p => p.CreatedByUser)
                .WithMany()
                .HasForeignKey(p => p.CreatedByUserId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.Entity<Project>()
                .HasOne(p => p.ModifiedByUser)
                .WithMany()
                .HasForeignKey(p => p.ModifiedByUserId)
                .OnDelete(DeleteBehavior.NoAction);
          // Epic → Project

            builder.Entity<Epic>()
                .HasOne(e => e.Project)
                .WithMany()
                .HasForeignKey(e => e.ProjectId)
                .OnDelete(DeleteBehavior.NoAction);
          // Epic → User (CreatedBy / ModifiedBy)
            

            builder.Entity<Epic>()
                .HasOne(e => e.CreatedByUser)
                .WithMany()
                .HasForeignKey(e => e.CreatedByUserId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.Entity<Epic>()
                .HasOne(e => e.ModifiedByUser)
                .WithMany()
                .HasForeignKey(e => e.ModifiedByUserId)
                .OnDelete(DeleteBehavior.NoAction);
            // Task → Epic

            builder.Entity<Task>()
                .HasOne(t => t.Epic)
                .WithMany()
                .HasForeignKey(t => t.EpicId)
                .OnDelete(DeleteBehavior.NoAction);
           // Task → Status

            builder.Entity<Task>()
                .HasOne(t => t.Status)
                .WithMany()
                .HasForeignKey(t => t.statusId)
                .OnDelete(DeleteBehavior.NoAction);
          // Task → User (Assigned / CreatedBy / ModifiedBy)
            

            builder.Entity<Task>()
                .HasOne(t => t.User)
                .WithMany()
                .HasForeignKey(t => t.UserId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.Entity<Task>()
                .HasOne(t => t.CreatedByUser)
                .WithMany()
                .HasForeignKey(t => t.CreatedByUserId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.Entity<Task>()
                .HasOne(t => t.ModifiedByUser)
                .WithMany()
                .HasForeignKey(t => t.ModifiedByUserId)
                .OnDelete(DeleteBehavior.NoAction);
            // SubTask → Task

            builder.Entity<SubTask>()
                .HasOne(st => st.Task)
                .WithMany()
                .HasForeignKey(st => st.TaskId)
                .OnDelete(DeleteBehavior.NoAction);
                // SubTask → Status

            builder.Entity<SubTask>()
                .HasOne(st => st.Status)
                .WithMany()
                .HasForeignKey(st => st.statusId)
                .OnDelete(DeleteBehavior.NoAction);
             // SubTask → User (CreatedBy / ModifiedBy)

            builder.Entity<SubTask>()
                .HasOne(st => st.CreatedByUser)
                .WithMany()
                .HasForeignKey(st => st.CreatedByUserId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.Entity<SubTask>()
                .HasOne(st => st.ModifiedByUser)
                .WithMany()
                .HasForeignKey(st => st.ModifiedByUserId)
                .OnDelete(DeleteBehavior.NoAction);
        }





    }
}
