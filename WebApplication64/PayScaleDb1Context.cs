using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace WebApplication64
{
    public partial class PayScaleDb1Context : DbContext
    {
        public PayScaleDb1Context()
        {
        }

        public PayScaleDb1Context(DbContextOptions<PayScaleDb1Context> options)
            : base(options)
        {
        }

        public virtual DbSet<Scale> Scales { get; set; }
        public virtual DbSet<Scalee> Scalees { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=LAPTOP-1KL3BT26;Database=PayScaleDb1;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Scale>(entity =>
            {
                entity.HasKey(e => e.Payband)
                    .HasName("PK__Scale__7852CA5AFB457AD8");

                entity.ToTable("Scale");

                entity.Property(e => e.Payband)
                    .HasMaxLength(10)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Scalee>(entity =>
            {
                entity.HasKey(e => new { e.Payband, e.PaySalary })
                    .HasName("PK__Scalee__C48F01D7DE3F463C");

                entity.ToTable("Scalee");

                entity.Property(e => e.Payband)
                    .HasMaxLength(10)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
