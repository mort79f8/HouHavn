using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace HouHavn.Web.Model
{
    public partial class HouhavnContext : DbContext
    {
        public HouhavnContext()
        {
        }

        public HouhavnContext(DbContextOptions<HouhavnContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Berth> Berths { get; set; }
        public virtual DbSet<Boat> Boats { get; set; }
        public virtual DbSet<Person> Persons { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.0-rtm-35687");

            modelBuilder.Entity<Berth>(entity =>
            {
                entity.Property(e => e.BerthId).ValueGeneratedNever();
            });

            modelBuilder.Entity<Boat>(entity =>
            {
                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.PropulsionType)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Type)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.BerthNavigation)
                    .WithMany(p => p.Boats)
                    .HasForeignKey(d => d.Berth)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Boats_Berths");

                entity.HasOne(d => d.PersonNavigation)
                    .WithMany(p => p.Boats)
                    .HasForeignKey(d => d.Person)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Boats_Persons");
            });

            modelBuilder.Entity<Person>(entity =>
            {
                entity.Property(e => e.Address).IsRequired();

                entity.Property(e => e.City)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Country)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.FirstName).IsRequired();

                entity.Property(e => e.LastName).IsRequired();

                entity.Property(e => e.PhoneNumber)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.PostalCode)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}