using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace BigSchool.Models
{
    public partial class BigSchoolContext : DbContext
    {
        public BigSchoolContext()
            : base("name=BigSchoolContext")
        {
        }

        public virtual DbSet<AspNetUser> AspNetUsers { get; set; }
        public virtual DbSet<Category1> Category1 { get; set; }
        public virtual DbSet<Course> Courses { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AspNetUser>()
                .HasMany(e => e.Courses)
                .WithRequired(e => e.AspNetUser)
                .HasForeignKey(e => e.LecturerId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Category1>()
                .HasMany(e => e.Courses)
                .WithRequired(e => e.Category1)
                .HasForeignKey(e => e.CategoryId)
                .WillCascadeOnDelete(false);
        }
    }
}
