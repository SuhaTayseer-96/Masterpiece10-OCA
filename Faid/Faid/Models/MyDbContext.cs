using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Faid.Models;

public partial class MyDbContext : DbContext
{
    public MyDbContext()
    {
    }

    public MyDbContext(DbContextOptions<MyDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Donation> Donations { get; set; }

    public virtual DbSet<FoodAvailable> FoodAvailables { get; set; }

    public virtual DbSet<FoodCollectionRequest> FoodCollectionRequests { get; set; }

    public virtual DbSet<FoodDistributionRequest> FoodDistributionRequests { get; set; }

    public virtual DbSet<Order> Orders { get; set; }

    public virtual DbSet<Partner> Partners { get; set; }

    public virtual DbSet<PartnershipRequest> PartnershipRequests { get; set; }

    public virtual DbSet<Restaurant> Restaurants { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=DESKTOP-AFFT1QQ;Database=Faid;Trusted_Connection=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Donation>(entity =>
        {
            entity.HasKey(e => e.DonationId).HasName("PK__Donation__C5082EDB04CCCE7A");

            entity.Property(e => e.DonationId).HasColumnName("DonationID");
            entity.Property(e => e.DonationAmount).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.DonationDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.DonationDetails).HasMaxLength(255);
            entity.Property(e => e.DonationType).HasMaxLength(100);
            entity.Property(e => e.UserId).HasColumnName("UserID");

            entity.HasOne(d => d.User).WithMany(p => p.Donations)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__Donations__UserI__44FF419A");
        });

        modelBuilder.Entity<FoodAvailable>(entity =>
        {
            entity.HasKey(e => e.FoodId).HasName("PK__FoodAvai__856DB3CB9A92967E");

            entity.ToTable("FoodAvailable");

            entity.Property(e => e.FoodId).HasColumnName("FoodID");
            entity.Property(e => e.AvailableUntil).HasColumnType("datetime");
            entity.Property(e => e.FoodName).HasMaxLength(100);
            entity.Property(e => e.Price).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.RestaurantId).HasColumnName("RestaurantID");

            entity.HasOne(d => d.Restaurant).WithMany(p => p.FoodAvailables)
                .HasForeignKey(d => d.RestaurantId)
                .HasConstraintName("FK__FoodAvail__Resta__3D5E1FD2");
        });

        modelBuilder.Entity<FoodCollectionRequest>(entity =>
        {
            entity.HasKey(e => e.RequestId).HasName("PK__FoodColl__33A8519AA805BDAB");

            entity.Property(e => e.RequestId).HasColumnName("RequestID");
            entity.Property(e => e.Email).HasMaxLength(100);
            entity.Property(e => e.FoodType).HasMaxLength(100);
            entity.Property(e => e.Name).HasMaxLength(100);
            entity.Property(e => e.Phone).HasMaxLength(20);
            entity.Property(e => e.PickupAddress).HasMaxLength(255);
            entity.Property(e => e.UserId).HasColumnName("UserID");

            entity.HasOne(d => d.User).WithMany(p => p.FoodCollectionRequests)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__FoodColle__UserI__48CFD27E");
        });

        modelBuilder.Entity<FoodDistributionRequest>(entity =>
        {
            entity.HasKey(e => e.RequestId).HasName("PK__FoodDist__33A8519AF259D036");

            entity.Property(e => e.RequestId).HasColumnName("RequestID");
            entity.Property(e => e.CharityName).HasMaxLength(100);
            entity.Property(e => e.ContactPerson).HasMaxLength(100);
            entity.Property(e => e.Email).HasMaxLength(100);
            entity.Property(e => e.FoodTypeNeeded).HasMaxLength(100);
            entity.Property(e => e.Phone).HasMaxLength(20);
            entity.Property(e => e.PickupAddress).HasMaxLength(255);
        });

        modelBuilder.Entity<Order>(entity =>
        {
            entity.HasKey(e => e.OrderId).HasName("PK__Orders__C3905BAF57813080");

            entity.Property(e => e.OrderId).HasColumnName("OrderID");
            entity.Property(e => e.FoodId).HasColumnName("FoodID");
            entity.Property(e => e.OrderDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.TotalPrice).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.UserId).HasColumnName("UserID");

            entity.HasOne(d => d.Food).WithMany(p => p.Orders)
                .HasForeignKey(d => d.FoodId)
                .HasConstraintName("FK__Orders__FoodID__412EB0B6");

            entity.HasOne(d => d.User).WithMany(p => p.Orders)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__Orders__UserID__403A8C7D");
        });

        modelBuilder.Entity<Partner>(entity =>
        {
            entity.HasKey(e => e.PartnerId).HasName("PK__Partners__39FD633293CBB97A");

            entity.Property(e => e.PartnerId).HasColumnName("PartnerID");
            entity.Property(e => e.ContactInfo).HasMaxLength(255);
            entity.Property(e => e.PartnerName).HasMaxLength(100);
            entity.Property(e => e.PartnerType).HasMaxLength(100);
        });

        modelBuilder.Entity<PartnershipRequest>(entity =>
        {
            entity.HasKey(e => e.RequestId).HasName("PK__Partners__33A8519AEB6D5CF3");

            entity.Property(e => e.RequestId).HasColumnName("RequestID");
            entity.Property(e => e.ContactPerson).HasMaxLength(100);
            entity.Property(e => e.Email).HasMaxLength(100);
            entity.Property(e => e.OrganizationName).HasMaxLength(100);
            entity.Property(e => e.OrganizationType).HasMaxLength(100);
            entity.Property(e => e.PartnershipGoals).HasMaxLength(255);
        });

        modelBuilder.Entity<Restaurant>(entity =>
        {
            entity.HasKey(e => e.RestaurantId).HasName("PK__Restaura__87454CB539C6D36C");

            entity.Property(e => e.RestaurantId).HasColumnName("RestaurantID");
            entity.Property(e => e.Address).HasMaxLength(255);
            entity.Property(e => e.ContactInfo).HasMaxLength(100);
            entity.Property(e => e.FoodType).HasMaxLength(100);
            entity.Property(e => e.Name).HasMaxLength(100);
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PK__Users__1788CCAC63DF5EED");

            entity.HasIndex(e => e.Email, "UQ__Users__A9D10534F660B2BC").IsUnique();

            entity.Property(e => e.UserId).HasColumnName("UserID");
            entity.Property(e => e.Address).HasMaxLength(255);
            entity.Property(e => e.DateJoined)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Email).HasMaxLength(100);
            entity.Property(e => e.Name).HasMaxLength(100);
            entity.Property(e => e.PasswordHash).HasMaxLength(255);
            entity.Property(e => e.Phone).HasMaxLength(20);
            entity.Property(e => e.UserType).HasMaxLength(50);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
