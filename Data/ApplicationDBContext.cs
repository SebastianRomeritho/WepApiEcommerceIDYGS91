using Microsoft.EntityFrameworkCore;
using WepApiEcommerceIDYGS91.Models;

namespace WepApiEcommerceIDYGS91.Data
{
    public partial class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Rol> Rols { get; set; }
        public virtual DbSet<Category> Category { get; set; }

        public virtual DbSet<Product> Products { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>(entity =>
            {
                entity.HasKey(e => e.IdCategory).HasName("PK__Category__79D361B69AF4766D");

                entity.ToTable("Category");

                entity.Property(e => e.IdCategory).HasColumnName("idCategory");
                entity.Property(e => e.DescriptionCategory)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("descriptionCategory");
                entity.Property(e => e.NameCategory)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("nameCategory");
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.HasKey(e => e.IdProduct).HasName("PK__Product__5EEC79D16B119D94");

                entity.ToTable("Product");

                entity.Property(e => e.IdProduct).HasColumnName("idProduct");
                entity.Property(e => e.DescriptionProduct)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("descriptionProduct");
                entity.Property(e => e.ImageProduct)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("imageProduct");
                entity.Property(e => e.IsActive).HasColumnName("isActive");
                entity.Property(e => e.NameProduct)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("nameProduct");
                entity.Property(e => e.Price)
                    .HasColumnType("decimal(10, 2)")
                    .HasColumnName("price");
                entity.Property(e => e.Stock).HasColumnName("stock");

                entity.HasOne(d => d.oCategory).WithMany(p => p.Products)
                    .HasForeignKey(d => d.IdCategory)
                    .HasConstraintName("FK__Product__IdCateg__398D8EEE");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}