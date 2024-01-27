using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace SchoolDatabaseVS.Models
{
    public partial class SchoolDatabaseDbContext : DbContext
    {
        public SchoolDatabaseDbContext()
        {
        }

        public SchoolDatabaseDbContext(DbContextOptions<SchoolDatabaseDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Betyg> Betygs { get; set; } = null!;
        public virtual DbSet<Kurser> Kursers { get; set; } = null!;
        public virtual DbSet<Personal> Personals { get; set; } = null!;
        public virtual DbSet<Studenter> Studenters { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source = BIGHANZ; Initial Catalog = SchoolDatabase;Integrated Security = True;TrustServerCertificate = Yes");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Betyg>(entity =>
            {
                entity.ToTable("Betyg");

                entity.Property(e => e.BetygId).HasColumnName("BetygID");

                entity.Property(e => e.Betyg1)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("Betyg");

                entity.Property(e => e.Datum).HasColumnType("date");

                entity.Property(e => e.KursId).HasColumnName("KursID");

                entity.Property(e => e.PersonalId).HasColumnName("PersonalID");

                entity.Property(e => e.StudentId).HasColumnName("StudentID");

                entity.HasOne(d => d.Personal)
                    .WithMany(p => p.Betygs)
                    .HasForeignKey(d => d.PersonalId)
                    .HasConstraintName("FK__Betyg__PersonalI__3E52440B");
            });

            modelBuilder.Entity<Kurser>(entity =>
            {
                entity.HasKey(e => e.KursId)
                    .HasName("PK__Kurser__BCCFFF3B18EE3966");

                entity.ToTable("Kurser");

                entity.Property(e => e.KursId)
                    .ValueGeneratedNever()
                    .HasColumnName("KursID");

                entity.Property(e => e.KursNamn)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Personal>(entity =>
            {
                entity.ToTable("Personal");

                entity.Property(e => e.PersonalId)
                    .ValueGeneratedNever()
                    .HasColumnName("PersonalID");

                entity.Property(e => e.Namn)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.YrkesRoll)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Studenter>(entity =>
            {
                entity.HasKey(e => e.StudentId)
                    .HasName("PK__Studente__32C52A792A37F7C5");

                entity.ToTable("Studenter");

                entity.Property(e => e.StudentId)
                    .ValueGeneratedNever()
                    .HasColumnName("StudentID");

                entity.Property(e => e.Klass)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.PersonNummer)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Snamn)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("SNamn");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
