using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Dal.models;

public partial class ToysShopContext : DbContext
{
    public ToysShopContext()
    {
    }

    public ToysShopContext(DbContextOptions<ToysShopContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<Company> Companies { get; set; }

    public virtual DbSet<Customer> Customers { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<Purchase> Purchases { get; set; }

    public virtual DbSet<PurchaseDetail> PurchaseDetails { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server= wertzberger;Database=toys_shop;Trusted_Connection=True;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.UseCollation("Hebrew_100_CI_AS");

        modelBuilder.Entity<Category>(entity =>
        {
            entity.HasKey(e => e.CategoryId).HasName("PK__category__23CAF1D8DDD5DE26");

            entity.ToTable("category");

            entity.Property(e => e.CategoryId).HasColumnName("categoryId");
            entity.Property(e => e.CategoryName)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("categoryName");
        });

        modelBuilder.Entity<Company>(entity =>
        {
            entity.HasKey(e => e.CompanyId).HasName("PK__company__AD54599049C84535");

            entity.ToTable("company");

            entity.Property(e => e.CompanyId).HasColumnName("companyId");
            entity.Property(e => e.CompanyName)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("companyName");
        });

        modelBuilder.Entity<Customer>(entity =>
        {
            entity.HasKey(e => e.CustomerId).HasName("PK__customer__B611CB7D043C05EE");

            entity.ToTable("customers");

            entity.Property(e => e.CustomerId).HasColumnName("customerId");
            entity.Property(e => e.CustomerDateOfBirth).HasColumnName("customerDateOfBirth");
            entity.Property(e => e.CustomerEmail)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("customerEmail");
            entity.Property(e => e.CustomerFirstName)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("customerFirstName");
            entity.Property(e => e.CustomerLastName)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("customerLastName");
            entity.Property(e => e.CustomerPhone)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("customerPhone");
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.ProductId).HasName("PK__products__2D10D16A19338304");

            entity.ToTable("products");

            entity.Property(e => e.ProductId).HasColumnName("productId");
            entity.Property(e => e.ProductCategoryId).HasColumnName("productCategoryId");
            entity.Property(e => e.ProductCompanyId).HasColumnName("productCompanyId");
            entity.Property(e => e.ProductDescription)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("productDescription");
            entity.Property(e => e.ProductImage)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasColumnName("productImage");
            entity.Property(e => e.ProductLastUpdate).HasColumnName("productLastUpdate");
            entity.Property(e => e.ProductName)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("productName");
            entity.Property(e => e.ProductPrice).HasColumnName("productPrice");

            entity.HasOne(d => d.ProductCategory).WithMany(p => p.Products)
                .HasForeignKey(d => d.ProductCategoryId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_products_category");

            entity.HasOne(d => d.ProductCompany).WithMany(p => p.Products)
                .HasForeignKey(d => d.ProductCompanyId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_products_company");
        });

        modelBuilder.Entity<Purchase>(entity =>
        {
            entity.HasKey(e => e.PurchaseId).HasName("PK__purchase__0261226C49C028AA");

            entity.ToTable("purchases");

            entity.Property(e => e.PurchaseId).HasColumnName("purchaseId");
            entity.Property(e => e.PurchaseAmountToPay).HasColumnName("purchaseAmountToPay");
            entity.Property(e => e.PurchaseCustomerId).HasColumnName("purchaseCustomerId");
            entity.Property(e => e.PurchaseDate).HasColumnName("purchaseDate");
            entity.Property(e => e.PurchaseMention)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasColumnName("purchaseMention");

            entity.HasOne(d => d.PurchaseCustomer).WithMany(p => p.Purchases)
                .HasForeignKey(d => d.PurchaseCustomerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_purchases_customer");
        });

        modelBuilder.Entity<PurchaseDetail>(entity =>
        {
            entity.HasKey(e => e.PurchaseDetailsId).HasName("PK__purchase__67AF052932C2B79E");

            entity.ToTable("purchaseDetails");

            entity.Property(e => e.PurchaseDetailsId).HasColumnName("purchaseDetailsId");
            entity.Property(e => e.PurchaseDetailsAmount).HasColumnName("purchaseDetailsAmount");
            entity.Property(e => e.PurchaseDetailsProductsId).HasColumnName("purchaseDetailsProductsId");
            entity.Property(e => e.PurchaseDetailsPurchaseId).HasColumnName("purchaseDetailsPurchaseId");

            entity.HasOne(d => d.PurchaseDetailsProducts).WithMany(p => p.PurchaseDetails)
                .HasForeignKey(d => d.PurchaseDetailsProductsId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_purchase_details_products");

            entity.HasOne(d => d.PurchaseDetailsPurchase).WithMany(p => p.PurchaseDetails)
                .HasForeignKey(d => d.PurchaseDetailsPurchaseId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_purchase_details_purchases");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
