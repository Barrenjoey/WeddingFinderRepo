using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using WeddingFinder.Models;

namespace WeddingFinder.Context
{
    public partial class WeddingFinderContext : DbContext
    {
        public WeddingFinderContext()
        {
        }

        public WeddingFinderContext(DbContextOptions<WeddingFinderContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Address> Address { get; set; }
        public virtual DbSet<Business> Business { get; set; }
        public virtual DbSet<Category> Category { get; set; }
        public virtual DbSet<Contact> Contact { get; set; }
        public virtual DbSet<Content> Content { get; set; }
        public virtual DbSet<Region> Region { get; set; }
        public virtual DbSet<Review> Review { get; set; }
        public virtual DbSet<State> State { get; set; }
        public virtual DbSet<Subscription> Subscription { get; set; }
        public virtual DbSet<SubscriptionType> SubscriptionType { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseNpgsql("Host=weddingfinderdb.cdvky3cxezm7.ap-southeast-2.rds.amazonaws.com;Database=WeddingFinder;Username=vanduse;Password=#Movement1");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Address>(entity =>
            {
                entity.Property(e => e.AddressId)
                    .HasColumnName("AddressID")
                    .UseIdentityAlwaysColumn();

                entity.Property(e => e.Country).HasMaxLength(50);

                entity.Property(e => e.Postcode).HasMaxLength(4);

                entity.Property(e => e.RegionId).HasColumnName("RegionID");

                entity.Property(e => e.StateId).HasColumnName("StateID");

                entity.Property(e => e.SteetNumber).HasMaxLength(50);

                entity.Property(e => e.Street).HasMaxLength(50);

                entity.Property(e => e.Suburb).HasMaxLength(50);

                entity.HasOne(d => d.Region)
                    .WithMany(p => p.Address)
                    .HasForeignKey(d => d.RegionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Address_RegionID_fkey");

                entity.HasOne(d => d.State)
                    .WithMany(p => p.Address)
                    .HasForeignKey(d => d.StateId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Address_StateID_fkey");
            });

            modelBuilder.Entity<Business>(entity =>
            {
                entity.HasKey(e => e.WedFinId)
                    .HasName("Business_pkey");

                entity.Property(e => e.WedFinId)
                    .HasColumnName("WedFinID")
                    .UseIdentityAlwaysColumn();

                entity.Property(e => e.AddressId).HasColumnName("AddressID");

                entity.Property(e => e.BusinessName).HasMaxLength(100);

                entity.Property(e => e.CategoryId).HasColumnName("CategoryID");

                entity.Property(e => e.ContactId).HasColumnName("ContactID");

                entity.Property(e => e.ContentId).HasColumnName("ContentID");

                entity.Property(e => e.Created).HasColumnType("date");

                entity.Property(e => e.ReviewRating).HasColumnType("numeric(1,1)");

                entity.Property(e => e.ServiceRegions).HasMaxLength(100);

                entity.Property(e => e.Website).HasMaxLength(100);

                entity.HasOne(d => d.Address)
                    .WithMany(p => p.Business)
                    .HasForeignKey(d => d.AddressId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Business_AddressID_fkey");

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.Business)
                    .HasForeignKey(d => d.CategoryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Business_CategoryID_fkey");

                entity.HasOne(d => d.Contact)
                    .WithMany(p => p.Business)
                    .HasForeignKey(d => d.ContactId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Business_ContactID_fkey");

                entity.HasOne(d => d.Content)
                    .WithMany(p => p.Business)
                    .HasForeignKey(d => d.ContentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Business_ContentID_fkey");
            });

            modelBuilder.Entity<Category>(entity =>
            {
                entity.Property(e => e.CategoryId)
                    .HasColumnName("CategoryID")
                    .UseIdentityAlwaysColumn();

                entity.Property(e => e.CategoryName)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Contact>(entity =>
            {
                entity.Property(e => e.ContactId)
                    .HasColumnName("ContactID")
                    .UseIdentityAlwaysColumn();

                entity.Property(e => e.ContactNumber).HasMaxLength(10);

                entity.Property(e => e.Email).HasMaxLength(100);

                entity.Property(e => e.Mobile).HasMaxLength(10);
            });

            modelBuilder.Entity<Content>(entity =>
            {
                entity.Property(e => e.ContentId)
                    .HasColumnName("ContentID")
                    .UseIdentityAlwaysColumn();

                entity.Property(e => e.Body1).HasMaxLength(255);

                entity.Property(e => e.Body2).HasMaxLength(255);

                entity.Property(e => e.Body3).HasMaxLength(255);

                entity.Property(e => e.Img2).HasMaxLength(255);

                entity.Property(e => e.Img3).HasMaxLength(255);

                entity.Property(e => e.Img4).HasMaxLength(255);

                entity.Property(e => e.ImgProfile).HasMaxLength(255);

                entity.Property(e => e.ShortBlurb).HasMaxLength(50);
            });

            modelBuilder.Entity<Region>(entity =>
            {
                entity.Property(e => e.RegionId)
                    .HasColumnName("RegionID")
                    .UseIdentityAlwaysColumn();

                entity.Property(e => e.RegionName)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.StateId).HasColumnName("StateID");

                entity.HasOne(d => d.State)
                    .WithMany(p => p.Region)
                    .HasForeignKey(d => d.StateId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Region_StateID_fkey");
            });

            modelBuilder.Entity<Review>(entity =>
            {
                entity.Property(e => e.ReviewId)
                    .HasColumnName("ReviewID")
                    .UseIdentityAlwaysColumn();

                entity.Property(e => e.Content)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.ReviewDate).HasColumnType("date");

                entity.Property(e => e.ReviewerName).HasMaxLength(50);

                entity.Property(e => e.WedFinId).HasColumnName("WedFinID");

                entity.HasOne(d => d.WedFin)
                    .WithMany(p => p.Review)
                    .HasForeignKey(d => d.WedFinId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Review_WedFinID_fkey");
            });

            modelBuilder.Entity<State>(entity =>
            {
                entity.Property(e => e.StateId)
                    .HasColumnName("StateID")
                    .UseIdentityAlwaysColumn();

                entity.Property(e => e.StateDisplayName).HasMaxLength(100);

                entity.Property(e => e.StateName)
                    .IsRequired()
                    .HasMaxLength(3);
            });

            modelBuilder.Entity<Subscription>(entity =>
            {
                entity.Property(e => e.SubscriptionId)
                    .HasColumnName("SubscriptionID")
                    .UseIdentityAlwaysColumn();

                entity.Property(e => e.LastBilling).HasColumnType("date");

                entity.Property(e => e.SubExpire).HasColumnType("date");

                entity.Property(e => e.SubStart).HasColumnType("date");

                entity.Property(e => e.SubTypeId).HasColumnName("SubTypeID");

                entity.Property(e => e.WedFinId).HasColumnName("WedFinID");

                entity.HasOne(d => d.SubType)
                    .WithMany(p => p.Subscription)
                    .HasForeignKey(d => d.SubTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Subscription_SubTypeID_fkey");

                entity.HasOne(d => d.WedFin)
                    .WithMany(p => p.Subscription)
                    .HasForeignKey(d => d.WedFinId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Subscription_WedFinID_fkey");
            });

            modelBuilder.Entity<SubscriptionType>(entity =>
            {
                entity.HasKey(e => e.SubTypeId)
                    .HasName("SubscriptionType_pkey");

                entity.Property(e => e.SubTypeId)
                    .HasColumnName("SubTypeID")
                    .UseIdentityAlwaysColumn();

                entity.Property(e => e.MonthlyCost).HasColumnType("money");

                entity.Property(e => e.SubscriptionName).HasMaxLength(255);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
