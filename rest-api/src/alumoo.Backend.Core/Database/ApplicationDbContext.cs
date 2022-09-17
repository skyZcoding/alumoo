using alumoo.Backend.Core.Database.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace alumoo.Backend.Core.Database
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<UserEntity> Users { get; set; }
        public DbSet<TaskEntity> Tasks { get; set; }
        public DbSet<VolunteerEntity> Volunteers { get; set; }
        public DbSet<ProjectEntity> Projects { get; set; }
        public DbSet<ImpressionEntity> Impressions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // UserEntity
            modelBuilder.Entity<UserEntity>()
                .HasKey(u => new { u.UserId });

            modelBuilder.Entity<UserEntity>()
                .HasMany(u => u.Projects)
                .WithOne(w => w.Owner);

            // VolunteerEntity

            modelBuilder.Entity<VolunteerEntity>()
                .HasKey(u => new { u.VolunteerId });

            modelBuilder.Entity<VolunteerEntity>()
                .HasMany(v => v.Tasks)
                .WithMany(t => t.Volunteers);

            modelBuilder.Entity<VolunteerEntity>()
                .HasMany(v => v.Applications)
                .WithMany(t => t.Applicants);

            modelBuilder.Entity<VolunteerEntity>()
                .HasMany(v => v.Impressions)
                .WithOne(t => t.Volunteer);

            modelBuilder.Entity<VolunteerEntity>()
                .HasOne(v => v.User);

            modelBuilder.Entity<VolunteerEntity>()
                .HasMany(v => v.FavoritProjects)
                .WithMany(p => p.Followers);

            modelBuilder.Entity<VolunteerEntity>()
                .HasMany(v => v.FavoritTasks)
                .WithMany(t => t.Followers);

            // TaskEntity

            modelBuilder.Entity<TaskEntity>()
                .HasKey(u => new { u.TaskId });

            modelBuilder.Entity<TaskEntity>()
                .HasMany(t => t.Applicants)
                .WithMany(v => v.Applications);

            modelBuilder.Entity<TaskEntity>()
                .HasMany(t => t.Volunteers)
                .WithMany(v => v.Tasks);

            modelBuilder.Entity<TaskEntity>()
                .HasOne(t => t.Project)
                .WithMany(p => p.Tasks);

            modelBuilder.Entity<TaskEntity>()
                .HasMany(t => t.Followers)
                .WithMany(v => v.FavoritTasks);

            // ProjectEntity

            modelBuilder.Entity<ProjectEntity>()
                .HasKey(u => new { u.ProjectId });

            modelBuilder.Entity<ProjectEntity>()
                .HasMany(p => p.Tasks)
                .WithOne(t => t.Project);

            modelBuilder.Entity<ProjectEntity>()
                .HasOne(p => p.Owner)
                .WithMany(u => u.Projects);

            modelBuilder.Entity<ProjectEntity>()
                .HasMany(p => p.Followers)
                .WithMany(v => v.FavoritProjects);

            // ImpressionEntity

            modelBuilder.Entity<ImpressionEntity>()
                .HasKey(u => new { u.ImpressionId });

            modelBuilder.Entity<ImpressionEntity>()
                .HasOne(i => i.Volunteer)
                .WithMany(v => v.Impressions);

            modelBuilder.Entity<ImpressionEntity>()
                .HasOne(i => i.Task)
                .WithMany(t => t.Impressions);
        }
    }
}
