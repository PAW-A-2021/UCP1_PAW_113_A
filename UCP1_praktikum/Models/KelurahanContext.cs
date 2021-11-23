using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace UCP1_praktikum.Models
{
    public partial class KelurahanContext : DbContext
    {
        public KelurahanContext()
        {
        }

        public KelurahanContext(DbContextOptions<KelurahanContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Gender> Gender { get; set; }
        public virtual DbSet<Penduduk> Penduduk { get; set; }
        public virtual DbSet<Status> Status { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Gender>(entity =>
            {
                entity.HasKey(e => e.IdGender);

                entity.Property(e => e.IdGender)
                    .HasColumnName("id_gender")
                    .ValueGeneratedNever();

                entity.Property(e => e.NamaGender)
                    .HasColumnName("nama_gender")
                    .HasMaxLength(1)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Penduduk>(entity =>
            {
                entity.HasKey(e => e.IdData);

                entity.Property(e => e.IdData)
                    .HasColumnName("id_data")
                    .ValueGeneratedNever();

                entity.Property(e => e.Alamat)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.IdGender).HasColumnName("id_gender");

                entity.Property(e => e.IdStatus).HasColumnName("id_status");

                entity.Property(e => e.Nama)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.NamaDusun)
                    .HasColumnName("Nama_dusun")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.NoKk).HasColumnName("No_kk");

                entity.HasOne(d => d.IdGenderNavigation)
                    .WithMany(p => p.Penduduk)
                    .HasForeignKey(d => d.IdGender)
                    .HasConstraintName("FK_Penduduk_Gender");

                entity.HasOne(d => d.IdStatusNavigation)
                    .WithMany(p => p.Penduduk)
                    .HasForeignKey(d => d.IdStatus)
                    .HasConstraintName("FK_Penduduk_Status");
            });

            modelBuilder.Entity<Status>(entity =>
            {
                entity.HasKey(e => e.IdStatus);

                entity.Property(e => e.IdStatus)
                    .HasColumnName("id_status")
                    .ValueGeneratedNever();

                entity.Property(e => e.Status1)
                    .HasColumnName("status")
                    .HasMaxLength(10)
                    .IsUnicode(false);
            });
        }
    }
}
