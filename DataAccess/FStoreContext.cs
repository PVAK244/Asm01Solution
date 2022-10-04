using System;
using Microsoft.EntityFrameworkCore;
using BusinessObject;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace DataAccess
{
    public partial class FStoreContext : DbContext
    {
        public FStoreContext()
        {
        }

        public FStoreContext(DbContextOptions<FStoreContext> options)
            : base(options)
        {
        }

        public virtual DbSet<CategoryObject> Categories { get; set; }
        public virtual DbSet<MemberObject> Members { get; set; }
        public virtual DbSet<OrderObject> Orders { get; set; }
        public virtual DbSet<OrderDetailObject> OrderDetails { get; set; }
        public virtual DbSet<ProductObject> Products { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("server =(local); database = FStore;uid=sa;pwd=123456;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Vietnamese_CI_AS");

            modelBuilder.Entity<CategoryObject>(entity =>
            {
                entity.ToTable("Category");

                entity.HasIndex(e => e.CategoryName, "CategoryName")
                    .IsUnique();

                entity.HasIndex(e => e.CategoryId, "PrimaryKey")
                    .IsUnique();

                entity.Property(e => e.CategoryName)
                    .IsRequired()
                    .HasMaxLength(15)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<MemberObject>(entity =>
            {
                entity.ToTable("Member");

                entity.HasIndex(e => e.Email, "MemberEmailIdx")
                    .IsUnique();

                entity.HasIndex(e => e.MemberId, "PrimaryKey")
                    .IsUnique();

                entity.Property(e => e.City)
                    .IsRequired()
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.CompanyName)
                    .IsRequired()
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.Country)
                    .IsRequired()
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<OrderObject>(entity =>
            {
                entity.ToTable("Order");

                entity.HasIndex(e => e.MemberId, "OrderMemberIdx");

                entity.HasIndex(e => e.OrderId, "PrimaryKey")
                    .IsUnique();

                entity.Property(e => e.Freight).HasColumnType("money");

                entity.Property(e => e.OrderDate).HasColumnType("datetime");

                entity.Property(e => e.RequiredDate).HasColumnType("datetime");

                entity.Property(e => e.ShippedDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<OrderDetailObject>(entity =>
            {
                entity.HasKey(e => new { e.OrderId, e.ProductId })
                    .HasName("PK_ORDERDETAIL");

                entity.ToTable("OrderDetail");

                entity.HasIndex(e => e.OrderId, "OrderID");

                entity.HasIndex(e => new { e.OrderId, e.ProductId }, "PrimaryKey")
                    .IsUnique();

                entity.HasIndex(e => e.ProductId, "ProductsOrder Details");

                entity.Property(e => e.UnitPrice).HasColumnType("money");

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.OrderDetails)
                    .HasForeignKey(d => d.OrderId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ORDERDET_REFERENCE_ORDER");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.OrderDetails)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ORDERDET_REFERENCE_PRODUCT");
            });

            modelBuilder.Entity<ProductObject>(entity =>
            {
                entity.ToTable("Product");

                entity.HasIndex(e => e.CategoryId, "CategoriesProducts");

                entity.HasIndex(e => e.CategoryId, "CategoryID");

                entity.HasIndex(e => e.ProductId, "PrimaryKey")
                    .IsUnique();

                entity.HasIndex(e => e.ProductName, "ProductName");

                entity.Property(e => e.ProductName)
                    .IsRequired()
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.UnitPrice).HasColumnType("money");

                entity.Property(e => e.Weight)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.CategoryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PRODUCT_REFERENCE_CATEGORY");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
