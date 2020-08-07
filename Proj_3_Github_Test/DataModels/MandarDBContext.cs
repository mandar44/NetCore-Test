using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Proj_3_Github_Test.datamodels
{
    public partial class MandarDBContext : DbContext
    {
        public MandarDBContext()
        {
        }

        public MandarDBContext(DbContextOptions<MandarDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Book_Master> Book_Master { get; set; }
        public virtual DbSet<Item_Master> Item_Master { get; set; }
        public virtual DbSet<Order_Item_Details> Order_Item_Details { get; set; }
        public virtual DbSet<Order_Master> Order_Master { get; set; }
        public virtual DbSet<User_Master> User_Master { get; set; }
        public virtual DbSet<User_Type_Master> User_Type_Master { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=MandarPC;Database=MandarDB;User Id=mandar;Password=pass@1234;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book_Master>(entity =>
            {
                entity.HasKey(e => e.Book_ID);

                entity.Property(e => e.Author)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Book_Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Created_Date).HasColumnType("datetime");

                entity.Property(e => e.Description)
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.Property(e => e.Price).HasColumnType("numeric(4, 2)");
            });

            modelBuilder.Entity<Item_Master>(entity =>
            {
                entity.HasKey(e => e.Item_ID);

                entity.Property(e => e.Created_Date).HasColumnType("datetime");

                entity.Property(e => e.Item_Name)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Rate).HasColumnType("decimal(10, 4)");

                entity.Property(e => e.Updated_Date).HasColumnType("datetime");
            });

            modelBuilder.Entity<Order_Item_Details>(entity =>
            {
                entity.HasKey(e => e.Order_Item_ID)
                    .HasName("PK_Order_Details");

                entity.Property(e => e.Created_Date).HasColumnType("datetime");

                entity.Property(e => e.Rate).HasColumnType("decimal(10, 2)");

                entity.HasOne(d => d.Item_)
                    .WithMany(p => p.Order_Item_Details)
                    .HasForeignKey(d => d.Item_ID)
                    .HasConstraintName("FK_Order_Details_Item_Master");

                entity.HasOne(d => d.Order_)
                    .WithMany(p => p.Order_Item_Details)
                    .HasForeignKey(d => d.Order_ID)
                    .HasConstraintName("FK_Order_Details_Order_Master");
            });

            modelBuilder.Entity<Order_Master>(entity =>
            {
                entity.HasKey(e => e.Order_ID);

                entity.Property(e => e.City)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Created_Date).HasColumnType("datetime");

                entity.Property(e => e.Email_ID)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Mobile)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Order_Date).HasColumnType("datetime");

                entity.Property(e => e.Phone)
                    .HasMaxLength(11)
                    .IsUnicode(false);

                entity.Property(e => e.Pincode)
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.Property(e => e.State)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.Created_ByNavigation)
                    .WithMany(p => p.Order_MasterCreated_ByNavigation)
                    .HasForeignKey(d => d.Created_By)
                    .HasConstraintName("FK_Order_Master_User_Master1");

                entity.HasOne(d => d.Customer_)
                    .WithMany(p => p.Order_MasterCustomer_)
                    .HasForeignKey(d => d.Customer_ID)
                    .HasConstraintName("FK_Order_Master_User_Master");
            });

            modelBuilder.Entity<User_Master>(entity =>
            {
                entity.HasKey(e => e.User_ID);

                entity.Property(e => e.Active).HasDefaultValueSql("((1))");

                entity.Property(e => e.Password)
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.User_Name)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.HasOne(d => d.User_Type_)
                    .WithMany(p => p.User_Master)
                    .HasForeignKey(d => d.User_Type_ID)
                    .HasConstraintName("FK_User_Master_User_Type_Master");
            });

            modelBuilder.Entity<User_Type_Master>(entity =>
            {
                entity.HasKey(e => e.User_Type_ID)
                    .HasName("PK_User_Type_Master_1");

                entity.Property(e => e.Active).HasDefaultValueSql("((1))");

                entity.Property(e => e.User_Type)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
