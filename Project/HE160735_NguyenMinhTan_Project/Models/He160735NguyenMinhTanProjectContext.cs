using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace HE160735_NguyenMinhTan_Project.Models;

public partial class He160735NguyenMinhTanProjectContext : DbContext
{
    public He160735NguyenMinhTanProjectContext()
    {
    }

    public He160735NguyenMinhTanProjectContext(DbContextOptions<He160735NguyenMinhTanProjectContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Book> Books { get; set; }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<Food> Foods { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseSqlServer(new ConfigurationBuilder().AddJsonFile("appsettings.json").Build().GetConnectionString("DbConnect"));
        }
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Book>(entity =>
        {
            entity.ToTable("Book");

            entity.Property(e => e.BookId).HasColumnName("Book_id");
            entity.Property(e => e.BookDate)
                .HasColumnType("date")
                .HasColumnName("Book_date");
            entity.Property(e => e.BookTime)
                .IsRequired()
                .HasMaxLength(150)
                .HasColumnName("Book_time");
            entity.Property(e => e.Email)
                .IsRequired()
                .HasMaxLength(150);
            entity.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(150);
            entity.Property(e => e.Note).HasMaxLength(150);
            entity.Property(e => e.NumberOfPeople).HasColumnName("Number_of_people");
            entity.Property(e => e.Phone)
                .IsRequired()
                .HasMaxLength(150);
            entity.Property(e => e.UserId).HasColumnName("User_id");
        });

        modelBuilder.Entity<Category>(entity =>
        {
            entity.ToTable("Category");

            entity.Property(e => e.CategoryId).HasColumnName("Category_id");
            entity.Property(e => e.CategoryName)
                .HasMaxLength(150)
                .HasColumnName("Category_name");
        });

        modelBuilder.Entity<Food>(entity =>
        {
            entity.ToTable("Food");

            entity.Property(e => e.FoodId).HasColumnName("Food_id");
            entity.Property(e => e.FoodCategory).HasColumnName("Food_category");
            entity.Property(e => e.FoodDescription)
                .IsRequired()
                .HasMaxLength(150)
                .HasColumnName("Food_description");
            entity.Property(e => e.FoodImage)
                .IsRequired()
                .HasMaxLength(150)
                .HasColumnName("Food_image");
            entity.Property(e => e.FoodName)
                .IsRequired()
                .HasMaxLength(150)
                .HasColumnName("Food_name");
            entity.Property(e => e.FoodPrice).HasColumnName("Food_price");

            entity.HasOne(d => d.FoodCategoryNavigation).WithMany(p => p.Foods)
                .HasForeignKey(d => d.FoodCategory)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Food_Category");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.ToTable("User");

            entity.Property(e => e.UserId).HasColumnName("User_id");
            entity.Property(e => e.Email)
                .IsRequired()
                .HasMaxLength(150);
            entity.Property(e => e.Password)
                .IsRequired()
                .HasMaxLength(150);
            entity.Property(e => e.Phone).HasMaxLength(150);
            entity.Property(e => e.Username)
                .IsRequired()
                .HasMaxLength(150);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
