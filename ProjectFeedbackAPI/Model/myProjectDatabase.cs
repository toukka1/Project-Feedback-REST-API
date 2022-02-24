using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;


namespace ProjectFeedbackAPI.Model
{
    public partial class myProjectDatabase : DbContext
    {
        public myProjectDatabase()
        {
        }

        public myProjectDatabase(DbContextOptions<myProjectDatabase> options)
            : base(options)
        {
        }

        public virtual DbSet<Project> Projects { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Project>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
