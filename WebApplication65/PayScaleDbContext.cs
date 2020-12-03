using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace WebApplication65
{
    public partial class PayScaleDbContext : DbContext
    {
        public PayScaleDbContext()
        {
        }

        public PayScaleDbContext(DbContextOptions<PayScaleDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Scale> Scales { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=LAPTOP-1KL3BT26;Database=PayScaleDb;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Scale>(entity =>
            {
                entity.HasKey(e => e.Payband)
                    .HasName("PK__Scale__7852CA5A87C2B0A7");

                entity.ToTable("Scale");

                entity.Property(e => e.Payband)
                    .HasMaxLength(10)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
