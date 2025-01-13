using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace MyEfProject.Models
{
    public partial class PEContext : DbContext
    {
        public PEContext()
        {
        }

        public PEContext(DbContextOptions<PEContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Group> Groups { get; set; }
        public virtual DbSet<Gym> Gyms { get; set; }
        public virtual DbSet<Norm> Norms { get; set; }
        public virtual DbSet<Result> Results { get; set; }
        public virtual DbSet<Student> Students { get; set; }
        public virtual DbSet<Trainer> Trainers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=localhost;Database=PE;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Cyrillic_General_CI_AS");

            modelBuilder.Entity<Group>(entity =>
            {
                entity.HasKey(e => e.IdGroup)
                    .HasName("PK__group__8BE8BA1BEC3D4B0E");

                entity.ToTable("group");

                entity.Property(e => e.IdGroup)
                    .ValueGeneratedNever()
                    .HasColumnName("id_group");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("name");
            });

            modelBuilder.Entity<Gym>(entity =>
            {
                entity.HasKey(e => e.IdGym)
                    .HasName("PK__gym__D796D3E533E07AB1");

                entity.ToTable("gym");

                entity.Property(e => e.IdGym)
                    .ValueGeneratedNever()
                    .HasColumnName("id_gym");

                entity.Property(e => e.Address)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("address");

                entity.Property(e => e.ClosingHours).HasColumnName("closing_hours");

                entity.Property(e => e.OpeningHours).HasColumnName("opening_hours");
            });

            modelBuilder.Entity<Norm>(entity =>
            {
                entity.HasKey(e => e.IdNorm)
                    .HasName("PK__norm__2699EABDAA39BF12");

                entity.ToTable("norm");

                entity.Property(e => e.IdNorm)
                    .ValueGeneratedNever()
                    .HasColumnName("id_norm");

                entity.Property(e => e.Description)
                    .HasColumnType("text")
                    .HasColumnName("description");

                entity.Property(e => e.IdResult).HasColumnName("id_result");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("name");

                entity.Property(e => e.NormType)
                    .IsRequired()
                    .HasMaxLength(45)
                    .IsUnicode(false)
                    .HasColumnName("norm_type");

                entity.Property(e => e.Type)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("type");

                entity.HasOne(d => d.IdResultNavigation)
                    .WithMany(p => p.Norms)
                    .HasForeignKey(d => d.IdResult)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_norm_result");
            });

            modelBuilder.Entity<Result>(entity =>
            {
                entity.HasKey(e => e.IdResult)
                    .HasName("PK__result__12EEC0B801825BF8");

                entity.ToTable("result");

                entity.Property(e => e.IdResult)
                    .ValueGeneratedNever()
                    .HasColumnName("id_result");

                entity.Property(e => e.DateOfCompletion)
                    .HasColumnType("date")
                    .HasColumnName("date_of_completion");

                entity.Property(e => e.Mark).HasColumnName("mark");
            });

            modelBuilder.Entity<Student>(entity =>
            {
                entity.HasKey(e => e.IdStudent)
                    .HasName("PK__student__2BE2EBB696B5B5D3");

                entity.ToTable("student");

                entity.Property(e => e.IdStudent)
                    .ValueGeneratedNever()
                    .HasColumnName("id_student");

                entity.Property(e => e.Gender)
                    .IsRequired()
                    .HasMaxLength(45)
                    .IsUnicode(false)
                    .HasColumnName("gender");

                entity.Property(e => e.IdGroup).HasColumnName("id_group");

                entity.Property(e => e.IdGym).HasColumnName("id_gym");

                entity.Property(e => e.IdNorm).HasColumnName("id_norm");

                entity.Property(e => e.IdTrainer).HasColumnName("id_trainer");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(45)
                    .IsUnicode(false)
                    .HasColumnName("name");

                entity.HasOne(d => d.IdGroupNavigation)
                    .WithMany(p => p.Students)
                    .HasForeignKey(d => d.IdGroup)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_student_group");

                entity.HasOne(d => d.IdGymNavigation)
                    .WithMany(p => p.Students)
                    .HasForeignKey(d => d.IdGym)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_student_gym");

                entity.HasOne(d => d.IdNormNavigation)
                    .WithMany(p => p.Students)
                    .HasForeignKey(d => d.IdNorm)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_student_norm");

                entity.HasOne(d => d.IdTrainerNavigation)
                    .WithMany(p => p.Students)
                    .HasForeignKey(d => d.IdTrainer)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_student_trainer");
            });

            modelBuilder.Entity<Trainer>(entity =>
            {
                entity.HasKey(e => e.IdTrainer)
                    .HasName("PK__trainer__9104E81782116E03");

                entity.ToTable("trainer");

                entity.Property(e => e.IdTrainer)
                    .ValueGeneratedNever()
                    .HasColumnName("id_trainer");

                entity.Property(e => e.Education)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("education");

                entity.Property(e => e.Experience)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("experience");

                entity.Property(e => e.IdGym).HasColumnName("id_gym");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("name");

                entity.Property(e => e.Specialization)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("specialization");

                entity.HasOne(d => d.IdGymNavigation)
                    .WithMany(p => p.Trainers)
                    .HasForeignKey(d => d.IdGym)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_trainer_gym");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
