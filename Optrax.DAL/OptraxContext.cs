using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using OptraxDAL.Models.Admin;
using OptraxDAL.Models.Grow;
using OptraxDAL.Models.Inventory;
using OptraxDAL.Models.Products;


namespace OptraxDAL
{
    public class OptraxContext(DbContextOptions<OptraxContext> options) : IdentityDbContext<AppUser>(options)
    {
        #region Admin
        public DbSet<AppUser> AppUsers { get; set; }

        #endregion

        #region Grow
        public DbSet<ContainerType> ContainerTypes { get; set; }
        public DbSet<Crop> Crops { get; set; }
        public DbSet<Light> Lights { get; set;}
        public DbSet<Plant> Plants { get; set; }
        public DbSet<Room> Rooms { get; set; }

        public DbSet<Strain> Strains { get; set; }
        public DbSet<StrainRelationship> StrainRelationships { get; set; }

        public DbSet<PlantAction> PlantActions { get; set; }
        public DbSet<PruneAction> PruneActions { get; set; }
        public DbSet<TransferAction> TransferActions { get; set; }
        public DbSet<TreatmentAction> TreatmentActions { get; set; }

        public DbSet<PlantTransfer> PlantTransfers { get; set; }
        public DbSet<ContainerTransfer> ContainerTransfers { get; set; }
        public DbSet<LightTransfer> LightTransfers { get; set; }
        public DbSet<RoomTransfer> RoomTransfers { get; set; }
        #endregion

        #region Inventory
        public DbSet<InventoryCategory> InventoryCategories { get; set; }
        public DbSet<InventoryItem> InventoryItems { get; set; }
        public DbSet<InventoryLocation> InventoryLocations { get; set; }
        public DbSet<InventoryStockItem> InventoryStockItems { get; set; }
        #endregion

        #region Products
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductBatch> ProductBatches { get; set; }
        public DbSet<ProductItem> ProductItems { get; set; }
        #endregion

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<AppUser>().ToTable("AspNetUsers", "Identity");
            builder.Entity<IdentityRole>().ToTable("AspNetRoles", "Identity");
            builder.Entity<IdentityUserRole<string>>().ToTable("AspNetUserRoles", "Identity");
            builder.Entity<IdentityRoleClaim<string>>().ToTable("AspNetRoleClaims", "Identity");
            builder.Entity<IdentityUserClaim<string>>().ToTable("AspNetUserClaims", "Identity");
            builder.Entity<IdentityUserLogin<string>>().ToTable("AspNetUserLogins", "Identity");
            builder.Entity<IdentityUserToken<string>>().ToTable("AspNetUserTokens", "Identity");

            builder.Entity<ContainerType>().Property(x => x.Capacity).HasPrecision(8, 2);
            builder.Entity<ContainerType>().Property(x => x.Active).HasDefaultValue(true);

            builder.Entity<Crop>().Property(x => x.WasteQuantity).HasPrecision(10, 2);
            builder.Entity<Crop>().Property(x => x.ProductQuantity).HasPrecision(10, 2);

            builder.Entity<Light>().Property(x => x.PPF).HasPrecision(6, 2);
            builder.Entity<Light>().Property(x => x.PPFD).HasPrecision(6, 2);
            builder.Entity<Light>().Property(x => x.Active).HasDefaultValue(true);
            builder.Entity<Light>().Property(x => x.ColorSpectrum).HasMaxLength(50);
            builder.Entity<Light>().Property(x => x.CoverageAreaSF).HasPrecision(6, 2);

            builder.Entity<InventoryItem>().Property(x => x.Active).HasDefaultValue(true);
            builder.Entity<InventoryItem>().Property(x => x.StockCount).HasPrecision(10, 2);
            builder.Entity<InventoryLocation>().Property(x => x.Active).HasDefaultValue(true);

            builder.Entity<ProductItem>().HasIndex(p => p.Barcode).IsUnique();

            builder.Entity<Room>().Property(x => x.Active).HasDefaultValue(true);

            builder.Entity<TreatmentAction>().Property(x => x.QuantityApplied).HasPrecision(8, 2);


            #region Handle Plant Actions TPH
            builder.Entity<PlantAction>().HasDiscriminator<string>("TransferType")
                                         .HasValue<PruneAction>("Prune")
                                         .HasValue<TransferAction>("Transfer")
                                         .HasValue<TreatmentAction>("Treatment");

            builder.Entity<TransferAction>().HasOne(ta => ta.Transfer)
                                            .WithOne(pt => pt.PlantAction)
                                            .HasForeignKey<TransferAction>(ta => ta.TransferID)
                                            .OnDelete(DeleteBehavior.Restrict); 
            #endregion

            #region Handle Transfers TPH
            builder.Entity<PlantTransfer>().HasOne(pt => pt.Plant)
                                           .WithMany(p => p.Transfers)
                                           .HasForeignKey(pt => pt.PlantID)
                                           .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<PlantTransfer>().HasDiscriminator<string>("TransferType")
                                           .HasValue<RoomTransfer>("Room")
                                           .HasValue<LightTransfer>("Light")
                                           .HasValue<ContainerTransfer>("Container");


            builder.Entity<ContainerTransfer>().HasOne(ct => ct.FromContainer)
                                               .WithMany(c => c.TransfersOut)
                                               .HasForeignKey(ct => ct.OriginID)
                                               .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<ContainerTransfer>().HasOne(ct => ct.ToContainer)
                                               .WithMany(c => c.TransfersIn)
                                               .HasForeignKey(ct => ct.DestinationID)
                                               .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<ContainerTransfer>().Property(ct => ct.OriginID).HasColumnName("OriginID");
            builder.Entity<ContainerTransfer>().Property(ct => ct.DestinationID).HasColumnName("DestinationID");

            builder.Entity<RoomTransfer>().HasOne(rt => rt.FromRoom)
                                          .WithMany(r => r.TransfersOut)
                                          .HasForeignKey(rt => rt.OriginID)
                                          .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<RoomTransfer>().HasOne(rt => rt.ToRoom)
                                          .WithMany(r => r.TransfersIn)
                                          .HasForeignKey(rt => rt.DestinationID)
                                          .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<RoomTransfer>().Property(rt => rt.OriginID).HasColumnName("OriginID");
            builder.Entity<RoomTransfer>().Property(rt => rt.DestinationID).HasColumnName("DestinationID");

            builder.Entity<LightTransfer>().HasOne(rt => rt.FromLight)
                                           .WithMany(r => r.TransfersOut)
                                           .HasForeignKey(rt => rt.OriginID)
                                           .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<LightTransfer>().HasOne(rt => rt.ToLight)
                                           .WithMany(r => r.TransfersIn)
                                           .HasForeignKey(rt => rt.DestinationID)
                                           .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<LightTransfer>().Property(rt => rt.OriginID).HasColumnName("OriginID");
            builder.Entity<LightTransfer>().Property(rt => rt.DestinationID).HasColumnName("DestinationID");
            #endregion

            #region Genetics Relationships
            builder.Entity<StrainRelationship>().HasKey(x => new { x.ParentID, x.ChildID }); // Composite Key

            builder.Entity<StrainRelationship>().HasOne(x => x.ParentStrain)
                                                .WithMany(s => s.Children)
                                                .HasForeignKey(x => x.ParentID)
                                                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<StrainRelationship>().HasOne(x => x.ChildStrain)
                                                .WithMany(s => s.Parents)
                                                .HasForeignKey(x => x.ChildID)
                                                .OnDelete(DeleteBehavior.Restrict);
            #endregion
        }
    }
}
