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

    public virtual DbSet<ContactInquiry> ContactInquiries { get; set; }

    public virtual DbSet<ContactU> ContactUs { get; set; }

    public virtual DbSet<FoodAvailable> FoodAvailables { get; set; }

    public virtual DbSet<FoodCollectionRequest> FoodCollectionRequests { get; set; }

    public virtual DbSet<FoodDistributionRequest> FoodDistributionRequests { get; set; }

    public virtual DbSet<FoodDonation> FoodDonations { get; set; }

    public virtual DbSet<MoneyDonation> MoneyDonations { get; set; }

    public virtual DbSet<NewsPost> NewsPosts { get; set; }

    public virtual DbSet<Order> Orders { get; set; }

    public virtual DbSet<Partner> Partners { get; set; }

    public virtual DbSet<PartnershipRequest> PartnershipRequests { get; set; }

    public virtual DbSet<Restaurant> Restaurants { get; set; }

    public virtual DbSet<RestaurantDonation> RestaurantDonations { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=DESKTOP-AFFT1QQ;Database=Faid;Trusted_Connection=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ContactInquiry>(entity =>
        {
            entity.HasKey(e => e.InquiryId).HasName("PK__ContactI__05E6E7EF0B7F93CF");

            entity.Property(e => e.InquiryId).HasColumnName("InquiryID");
            entity.Property(e => e.Email)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.FullName)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.MessageContent).HasColumnType("text");
            entity.Property(e => e.Subject)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.SubmissionDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
        });

        modelBuilder.Entity<ContactU>(entity =>
        {
            entity.HasKey(e => e.ContactId).HasName("PK__ContactU__5C6625BBB55AED50");

            entity.Property(e => e.ContactId).HasColumnName("ContactID");
            entity.Property(e => e.Email).HasMaxLength(100);
            entity.Property(e => e.Name).HasMaxLength(100);
            entity.Property(e => e.Subject).HasMaxLength(200);
            entity.Property(e => e.SubmittedOn)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.UserId).HasColumnName("UserID");

            entity.HasOne(d => d.User).WithMany(p => p.ContactUs)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__ContactUs__UserI__73BA3083");
        });

        modelBuilder.Entity<FoodAvailable>(entity =>
        {
            entity.HasKey(e => e.FoodId).HasName("PK__FoodAvai__856DB3CB61CECA5D");

            entity.ToTable("FoodAvailable");

            entity.Property(e => e.FoodId).HasColumnName("FoodID");
            entity.Property(e => e.AvailableUntil).HasColumnType("datetime");
            entity.Property(e => e.FoodName).HasMaxLength(100);
            entity.Property(e => e.Image).IsUnicode(false);
            entity.Property(e => e.Price).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.RestaurantId).HasColumnName("RestaurantID");

            entity.HasOne(d => d.Restaurant).WithMany(p => p.FoodAvailables)
                .HasForeignKey(d => d.RestaurantId)
                .HasConstraintName("FK__FoodAvail__Resta__76969D2E");
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

        modelBuilder.Entity<FoodDonation>(entity =>
        {
            entity.HasKey(e => e.DonationId).HasName("PK__FoodDona__C5082EDBB6E4A881");

            entity.Property(e => e.DonationId).HasColumnName("DonationID");
            entity.Property(e => e.ContactInfo).HasMaxLength(255);
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.FoodType).HasMaxLength(255);
            entity.Property(e => e.PickupArrangements).HasMaxLength(500);
        });

        modelBuilder.Entity<MoneyDonation>(entity =>
        {
            entity.HasKey(e => e.DonationId).HasName("PK__MoneyDon__C5082EDBB83705C1");

            entity.Property(e => e.DonationId).HasColumnName("DonationID");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.DonationAmount).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.DonationFrequency).HasMaxLength(50);
            entity.Property(e => e.FundUsage).HasMaxLength(500);
        });

        modelBuilder.Entity<NewsPost>(entity =>
        {
            entity.HasKey(e => e.PostId).HasName("PK__NewsPost__AA1260381169C0E2");

            entity.Property(e => e.PostId).HasColumnName("PostID");
            entity.Property(e => e.Image).IsUnicode(false);
            entity.Property(e => e.PublishedDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Title).HasMaxLength(255);
        });

        modelBuilder.Entity<Order>(entity =>
        {
            entity.HasKey(e => e.OrderId).HasName("PK__Orders__C3905BAF6DEC05C5");

            entity.Property(e => e.OrderId).HasColumnName("OrderID");
            entity.Property(e => e.FoodId).HasColumnName("FoodID");
            entity.Property(e => e.OrderDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.TotalPrice).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.UserId).HasColumnName("UserID");

            entity.HasOne(d => d.Food).WithMany(p => p.Orders)
                .HasForeignKey(d => d.FoodId)
                .HasConstraintName("FK__Orders__FoodID__7A672E12");

            entity.HasOne(d => d.User).WithMany(p => p.Orders)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__Orders__UserID__797309D9");
        });

        modelBuilder.Entity<Partner>(entity =>
        {
            entity.HasKey(e => e.PartnerId).HasName("PK__Partners__39FD633293CBB97A");

            entity.Property(e => e.PartnerId).HasColumnName("PartnerID");
            entity.Property(e => e.ContactInfo).HasMaxLength(255);
            entity.Property(e => e.Image).IsUnicode(false);
            entity.Property(e => e.PartnerName).HasMaxLength(100);
            entity.Property(e => e.PartnerType).HasMaxLength(100);
        });

        modelBuilder.Entity<PartnershipRequest>(entity =>
        {
            entity.HasKey(e => e.RequestId).HasName("PK__Partners__33A8519AEB6D5CF3");

            entity.Property(e => e.RequestId).HasColumnName("RequestID");
            entity.Property(e => e.ContactPerson).HasMaxLength(100);
            entity.Property(e => e.ContactPhoneNumber)
                .HasMaxLength(15)
                .IsUnicode(false);
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
            entity.Property(e => e.Email).HasMaxLength(255);
            entity.Property(e => e.FoodType).HasMaxLength(100);
            entity.Property(e => e.Image).IsUnicode(false);
            entity.Property(e => e.Name).HasMaxLength(100);
            entity.Property(e => e.OwnerName).HasMaxLength(100);
            entity.Property(e => e.Password).HasMaxLength(255);
            entity.Property(e => e.PhoneNo).HasMaxLength(20);
        });

        modelBuilder.Entity<RestaurantDonation>(entity =>
        {
            entity.HasKey(e => e.DonationId).HasName("PK__Restaura__C5082EDBCD5481E7");

            entity.Property(e => e.DonationId).HasColumnName("DonationID");
            entity.Property(e => e.ContactDetails).HasMaxLength(255);
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.FoodDonated).HasMaxLength(500);
            entity.Property(e => e.PickupDetails).HasMaxLength(500);
            entity.Property(e => e.RestaurantName).HasMaxLength(255);
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
            entity.Property(e => e.Phone).HasMaxLength(20);
            entity.Property(e => e.UserName).HasMaxLength(100);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
