using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace TVTOWebsite.Models
{
    public partial class tvtoDBContext : DbContext
    {
        public tvtoDBContext()
        {
        }

        public tvtoDBContext(DbContextOptions<tvtoDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Content> Contents { get; set; }
        public virtual DbSet<Multimedium> Multimedia { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=(LocalDb)\\MSSQLLocalDB;Initial Catalog=tvtoDB;Integrated Security=True;Pooling=False");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Content>(entity =>
            {
                entity.ToTable("Content");

                entity.Property(e => e.Abstract).HasMaxLength(1000);

                entity.Property(e => e.Content1)
                    .HasColumnType("ntext")
                    .HasColumnName("Content");

                entity.Property(e => e.Date).HasColumnType("datetime");

                entity.Property(e => e.Picture).HasMaxLength(50);

                entity.Property(e => e.Title).HasMaxLength(500);
            });

            modelBuilder.Entity<Multimedium>(entity =>
            {
                entity.Property(e => e.Movie).HasMaxLength(50);

                entity.Property(e => e.Music).HasMaxLength(50);

                entity.Property(e => e.Picture).HasMaxLength(50);

                entity.Property(e => e.Text).HasMaxLength(500);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
