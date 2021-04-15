using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace testAppication6.Models
{
    public partial class TestDB1Context : DbContext
    {   
        public TestDB1Context(DbContextOptions<TestDB1Context> options)
            : base(options)
        {
        }

        public virtual DbSet<Account> Accounts { get; set; }
        public virtual DbSet<Billing> Billings { get; set; }
        public virtual DbSet<Shippng> Shippngs { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#pragma warning disable CS1030 // #warning directive
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=BISTECNB081\\MSSQLSERVER2;Database=TestDB1;Trusted_Connection=True;");
#pragma warning restore CS1030 // #warning directive
            }
        }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Account>(entity =>
            {
                entity.HasKey(e => e.AccId)
                   .HasName("PK__Account__49ACB9A41B6D77AB");

                entity.ToTable("Account");

                entity.Property(e => e.AccId)
                   //.ValueGeneratedOnAdd()
                   .HasColumnName("Acc_ID");

                entity.Property(e => e.AccAddress1)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("Acc_Address1");

                entity.Property(e => e.AccAddress2)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("Acc_Address2");

                entity.Property(e => e.AccCity)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("Acc_City");

                entity.Property(e => e.AccDistrict)
                    .IsRequired()
                    .HasMaxLength(225)
                    .IsUnicode(false)
                    .HasColumnName("Acc_District");

                entity.Property(e => e.BName)
                    .HasMaxLength(225)
                    .IsUnicode(false)
                    .HasColumnName("B_Name");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.PhoneCode).HasColumnName("Phone_Code");

                entity.Property(e => e.PhoneNumber).HasColumnName("Phone_Number");

                entity.Property(e => e.StartDate)
                    .HasColumnType("date")
                    .HasColumnName("Start_Date");
            });

            modelBuilder.Entity<Billing>(entity =>
            {
                entity.HasKey(e => e.BillId);

                entity.ToTable("Billing");

                entity.Property(e => e.BillId)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("Bill_ID");

                entity.Property(e => e.AccId).HasColumnName("Acc_ID");

                entity.Property(e => e.BillAddress1)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("Bill_Address1");

                entity.Property(e => e.BillAddress2)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("Bill_Address2");

                entity.Property(e => e.BillCity)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("Bill_City");

                entity.HasOne(d => d.Acc)
                    .WithMany(p => p.Billings)
                    .HasForeignKey(d => d.AccId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Billing__Acc_ID__267ABA7A");
            });

            modelBuilder.Entity<Shippng>(entity =>
            {
                entity.HasKey(e => e.ShipId)
                    .HasName("PK__Shippng__58D0810B55EF0B5D");

                entity.ToTable("Shippng");

                entity.Property(e => e.ShipId)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("Ship_ID");

                entity.Property(e => e.AccId).HasColumnName("Acc_ID");

                entity.Property(e => e.EmailSub)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("Email_Sub");

                entity.Property(e => e.IsChecked).HasColumnName("is_checked");

                entity.Property(e => e.Request)
                    .IsRequired()
                    .HasMaxLength(225)
                    .IsUnicode(false);

                entity.Property(e => e.ShipAddress1)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("Ship_Address1");

                entity.Property(e => e.ShipAddress2)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("Ship_Address2");

                entity.Property(e => e.ShipCity)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("Ship_City");

                entity.HasOne(d => d.Acc)
                    .WithMany(p => p.Shippngs)
                    .HasForeignKey(d => d.AccId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Shippng__Acc_ID__29572725");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
