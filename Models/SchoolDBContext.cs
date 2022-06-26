using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace SchoolManagement.Models
{
    public partial class SchoolDBContext : DbContext
    {
        public SchoolDBContext()
        {
        }

        public SchoolDBContext(DbContextOptions<SchoolDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Student> Student { get; set; }
        public virtual DbSet<StudentTeacher> StudentTeacher { get; set; }
        public virtual DbSet<Teacher> Teacher { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source=MUZZ-PC\\SQLEXPRESS;Initial Catalog=SchoolDB;Integrated Security=True;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>(entity =>
            {
                entity.Property(e => e.StudentId)
                    .HasColumnName("studentId")
                    .ValueGeneratedNever();

                entity.Property(e => e.Age).HasColumnName("age");

                entity.Property(e => e.Contact)
                    .HasColumnName("contact")
                    .IsUnicode(false);

                entity.Property(e => e.Gender)
                    .HasColumnName("gender")
                    .IsUnicode(false);

                entity.Property(e => e.StudentName)
                    .HasColumnName("studentName")
                    .IsUnicode(false);
            });

            modelBuilder.Entity<StudentTeacher>(entity =>
            {
                entity.HasKey(e => new { e.TeacherId, e.StudentId });

                entity.Property(e => e.TeacherId).HasColumnName("teacherId");

                entity.Property(e => e.StudentId).HasColumnName("studentId");

                entity.HasOne(d => d.Student)
                    .WithMany(p => p.StudentTeacher)
                    .HasForeignKey(d => d.StudentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_StudentTeacher_Student");

                entity.HasOne(d => d.Teacher)
                    .WithMany(p => p.StudentTeacher)
                    .HasForeignKey(d => d.TeacherId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_StudentTeacher_Teacher");
            });

            modelBuilder.Entity<Teacher>(entity =>
            {
                entity.Property(e => e.TeacherId)
                    .HasColumnName("teacherId")
                    .ValueGeneratedNever();

                entity.Property(e => e.Contact)
                    .HasColumnName("contact")
                    .IsUnicode(false);

                entity.Property(e => e.Departement)
                    .HasColumnName("departement")
                    .IsUnicode(false);

                entity.Property(e => e.TeacherName)
                    .HasColumnName("teacherName")
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
