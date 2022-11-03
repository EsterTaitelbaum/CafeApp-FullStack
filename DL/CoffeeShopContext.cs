using System;
using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace DL
{
    public partial class CoffeeShopContext : DbContext
    {
        public CoffeeShopContext()
        {
        }

        public CoffeeShopContext(DbContextOptions<CoffeeShopContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Categories> Categories { get; set; }
        public virtual DbSet<Complaints> Complaints { get; set; }
        public virtual DbSet<Incomes> Incomes { get; set; }
        public virtual DbSet<OrderItem> OrderItem { get; set; }
        public virtual DbSet<Orders> Orders { get; set; }
        public virtual DbSet<Products> Products { get; set; }
        public virtual DbSet<Rating> Rating { get; set; }
        public virtual DbSet<UserType> UserType { get; set; }
        public virtual DbSet<Users> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=DESKTOP-0T014UV;Database=Coffee Shop;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Categories>(entity =>
            {
                entity.HasKey(e => e.CategoryId);

                entity.Property(e => e.CategoryId).HasColumnName("Category_id");

                entity.Property(e => e.CategoryName)
                    .IsRequired()
                    .HasColumnName("Category_name")
                    .HasMaxLength(50)
                    .IsFixedLength();
            });

            modelBuilder.Entity<Complaints>(entity =>
            {
                entity.ToTable("complaints");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.ClientCode)
                    .IsRequired()
                    .HasColumnName("Client_Code")
                    .HasMaxLength(650);

                entity.Property(e => e.ComplaintDesc)
                    .IsRequired()
                    .HasColumnName("Complaint_Desc");

                entity.Property(e => e.LetterDesc)
                    .HasColumnName("Letter_Desc")
                    .HasMaxLength(850);

                entity.Property(e => e.SubjectCode).HasColumnName("Subject_Code");

                entity.Property(e => e.SubjectName)
                    .IsRequired()
                    .HasColumnName("Subject_Name")
                    .HasMaxLength(500);

                entity.Property(e => e.Summary).HasMaxLength(1250);

                entity.Property(e => e.UpdateDate)
                    .HasColumnName("Update_Date")
                    .HasMaxLength(1150);
            });

            modelBuilder.Entity<Incomes>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("incomes");

                entity.Property(e => e.ClientCode).HasColumnName("Client_Code");

                entity.Property(e => e.DateT).HasColumnType("date");

                entity.Property(e => e.Ip).HasMaxLength(50);

                entity.Property(e => e.RecordDate).HasColumnName("Record_Date");
            });

            modelBuilder.Entity<OrderItem>(entity =>
            {
                entity.ToTable("Order_Item");

                entity.Property(e => e.OrderItemId).HasColumnName("Order_item_id");

                entity.Property(e => e.OrderId).HasColumnName("Order_id");

                entity.Property(e => e.ProductId).HasColumnName("Product_id");

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.OrderItem)
                    .HasForeignKey(d => d.OrderId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Order_Ite__Order__32E0915F");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.OrderItem)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Order_Ite__Produ__33D4B598");
            });

            modelBuilder.Entity<Orders>(entity =>
            {
                entity.HasKey(e => e.OrderId)
                    .HasName("PK_Oreders");

                entity.Property(e => e.OrderId).HasColumnName("Order_id");

                entity.Property(e => e.OrderSum).HasColumnName("Order_sum");

                entity.Property(e => e.OrederDate)
                    .HasColumnName("Oreder_date")
                    .HasColumnType("date");

                entity.Property(e => e.UserId).HasColumnName("User_id");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Orders__User_id__34C8D9D1");
            });

            modelBuilder.Entity<Products>(entity =>
            {
                entity.HasKey(e => e.ProductId);

                entity.Property(e => e.ProductId).HasColumnName("Product_id");

                entity.Property(e => e.CategoryId).HasColumnName("Category_id");

                entity.Property(e => e.Description).HasMaxLength(50);

                entity.Property(e => e.ImageName)
                    .HasColumnName("Image_name")
                    .HasMaxLength(50);

                entity.Property(e => e.ProductName)
                    .IsRequired()
                    .HasColumnName("Product_Name")
                    .HasMaxLength(30);

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.CategoryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Products__Catego__35BCFE0A");
            });

            modelBuilder.Entity<Rating>(entity =>
            {
                entity.ToTable("RATING");

                entity.Property(e => e.RatingId).HasColumnName("RATING_ID");

                entity.Property(e => e.Host)
                    .HasColumnName("HOST")
                    .HasMaxLength(50);

                entity.Property(e => e.Method)
                    .HasColumnName("METHOD")
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.Property(e => e.Path)
                    .HasColumnName("PATH")
                    .HasMaxLength(50);

                entity.Property(e => e.RecordDate)
                    .HasColumnName("Record_Date")
                    .HasColumnType("datetime");

                entity.Property(e => e.Referer)
                    .HasColumnName("REFERER")
                    .HasMaxLength(100);

                entity.Property(e => e.UserAgent).HasColumnName("USER_AGENT");
            });

            modelBuilder.Entity<UserType>(entity =>
            {
                entity.ToTable("user_type");

                entity.Property(e => e.UserTypeId)
                    .HasColumnName("user_type_id")
                    .ValueGeneratedNever();

                entity.Property(e => e.UserType1)
                    .IsRequired()
                    .HasColumnName("user_type")
                    .HasMaxLength(20)
                    .IsFixedLength();
            });

            modelBuilder.Entity<Users>(entity =>
            {
                entity.HasKey(e => e.UserId);

                entity.Property(e => e.UserId).HasColumnName("User_id");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.FirstName).HasMaxLength(50);

                entity.Property(e => e.LastName).HasMaxLength(50);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.UserType).HasDefaultValueSql("((2))");

                entity.HasOne(d => d.UserTypeNavigation)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.UserType)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Users__UserType__36B12243");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
