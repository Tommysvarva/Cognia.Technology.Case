using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace Vegvesen.ParkeringsService.Models
{
    public partial class cognia_technology_caseContext : DbContext
    {
        public cognia_technology_caseContext()
        {
        }

        public cognia_technology_caseContext(DbContextOptions<cognia_technology_caseContext> options)
            : base(options)
        {
        }

        public virtual DbSet<ParkingFacility> ParkingFacilities { get; set; }
        public virtual DbSet<ParkingProvider> ParkingProviders { get; set; }
        public virtual DbSet<ParkingProviderSpot> ParkingProviderSpots { get; set; }
        public virtual DbSet<ParkingSpot> ParkingSpots { get; set; }
        public virtual DbSet<ParkingSpotFacility> ParkingSpotFacilities { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=DESKTOP-UO923US;Database=cognia_technology_case;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Danish_Norwegian_CI_AS");

            modelBuilder.Entity<ParkingFacility>(entity =>
            {
                entity.ToTable("parking_facility");

                entity.Property(e => e.Description).HasMaxLength(255);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<ParkingProvider>(entity =>
            {
                entity.ToTable("parking_provider");

                entity.Property(e => e.Id).ValueGeneratedNever();
            });

            modelBuilder.Entity<ParkingProviderSpot>(entity =>
            {
                entity.ToTable("parking_provider_spot");

                entity.HasOne(d => d.Provider)
                    .WithMany(p => p.ParkingProviderSpots)
                    .HasForeignKey(d => d.ProviderId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_parking_provider_spot_parking_provider");

                entity.HasOne(d => d.Spot)
                    .WithMany(p => p.ParkingProviderSpots)
                    .HasForeignKey(d => d.SpotId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_parking_provider_spot_parking_spot");
            });

            modelBuilder.Entity<ParkingSpot>(entity =>
            {
                entity.ToTable("parking_spot");

                entity.Property(e => e.Id).ValueGeneratedNever();
            });

            modelBuilder.Entity<ParkingSpotFacility>(entity =>
            {
                entity.ToTable("parking_spot_facility");

                entity.HasOne(d => d.Facility)
                    .WithMany(p => p.ParkingSpotFacilities)
                    .HasForeignKey(d => d.FacilityId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_parking_spot_facility_parking_facility");

                entity.HasOne(d => d.Spot)
                    .WithMany(p => p.ParkingSpotFacilities)
                    .HasForeignKey(d => d.SpotId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_parking_spot_facility_parking_spot");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
