using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using OptraxDAL.Models.Admin;
using OptraxDAL.Models.Grow;
using OptraxDAL.Models.Inventory;
using OptraxDAL.Models.Products;


namespace OptraxDAL
{
    public class OptraxContext(DbContextOptions<OptraxContext> options, IMemoryCache cache) : IdentityDbContext<AppUser>(options)
    {
        private readonly IMemoryCache _cache = cache;

        #region Admin
        public DbSet<AppUser> AppUsers { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Business> Businesses { get; set; }
        public DbSet<UOM> UOMs { get; set; }
        #endregion

        #region Inventory
        public DbSet<InventoryCategory> InventoryCategories { get; set; }
        public DbSet<InventoryItem> InventoryItems { get; set; }

        public DbSet<StockItem> StockItems { get; set; }
        public DbSet<Plant> Plants { get; set; }
        public DbSet<Light> Lights { get; set; }
        public DbSet<DurableItem> DurableItems { get; set; }
        public DbSet<ConsumableItem> ConsumableItems { get; set; }

        public DbSet<LightType> LightTypes { get; set; }
        public DbSet<ContainerType> ContainerTypes { get; set; }

        public DbSet<InventoryLocation> InventoryLocations { get; set; }
        public DbSet<ContainerLocation> ContainerLocations { get; set; }
        public DbSet<RoomLocation> RoomLocations { get; set; }
        public DbSet<BuildingLocation> BuildingLocations { get; set; }
        public DbSet<OffsiteLocation> OffsiteLocations { get; set; }
        public DbSet<InventoryTransfer> InventoryTransfers { get; set; }
        #endregion

        #region Grow
        public DbSet<Strain> Strains { get; set; }
        public DbSet<StrainRelationship> StrainRelationships { get; set; }

        public DbSet<Crop> Crops { get; set; }

        public DbSet<PlantEvent> PlantEvents { get; set; }
        public DbSet<PruneEvent> PruneEvents { get; set; }
        public DbSet<LightEvent> LightEvents { get; set; }
        public DbSet<GrowthEvent> GrowthEvents { get; set; }
        public DbSet<TransferEvent> TransferEvents { get; set; }
        public DbSet<TreatmentEvent> TreatmentEvents { get; set; }
        public DbSet<TransplantEvent> TransplantEvents { get; set; }
        #endregion

        #region Product
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductItem> ProductItems { get; set; }
        public DbSet<ProductBatch> ProductBatches { get; set; }
        #endregion

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            #region Admin
            builder.Entity<AppUser>().ToTable("AspNetUsers", "Identity");
            builder.Entity<IdentityRole>().ToTable("AspNetRoles", "Identity");
            builder.Entity<IdentityUserRole<string>>().ToTable("AspNetUserRoles", "Identity");
            builder.Entity<IdentityRoleClaim<string>>().ToTable("AspNetRoleClaims", "Identity");
            builder.Entity<IdentityUserClaim<string>>().ToTable("AspNetUserClaims", "Identity");
            builder.Entity<IdentityUserLogin<string>>().ToTable("AspNetUserLogins", "Identity");
            builder.Entity<IdentityUserToken<string>>().ToTable("AspNetUserTokens", "Identity");

            builder.Entity<UOM>().Property(x => x.PerQuantity).HasPrecision(6, 2);

            #endregion


            #region Inventory
            builder.Entity<InventoryCategory>().HasIndex(x => x.Name).IsUnique();

            builder.Entity<InventoryItem>().HasIndex(x => x.Name).IsUnique();
            builder.Entity<InventoryItem>().HasIndex(x => x.SKU).IsUnique();
            builder.Entity<InventoryItem>().Property(x => x.Active).HasDefaultValue(true);

            builder.Entity<InventoryItem>().HasOne(i => i.ContainerType)
                                           .WithMany(ct => ct.InventoryItems)
                                           .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<InventoryItem>().HasOne(i => i.LightType)
                                           .WithMany(lt => lt.InventoryItems)
                                           .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<LightType>().Property(x => x.PPF).HasPrecision(6, 2);
            builder.Entity<LightType>().Property(x => x.PPFD).HasPrecision(6, 2);
            builder.Entity<LightType>().Property(x => x.ColorSpectrum).HasMaxLength(50);
            builder.Entity<LightType>().Property(x => x.CoverageAreaSF).HasPrecision(6, 2);

            builder.Entity<ContainerType>().Property(x => x.Capacity).HasPrecision(8, 2);
            builder.Entity<ContainerType>().Property(x => x.Active).HasDefaultValue(true);

            // Stock Items TPT
            builder.Entity<Plant>().ToTable("Plants");
            builder.Entity<Light>().ToTable("Lights");
            builder.Entity<DurableItem>().ToTable("DurableItems");
            builder.Entity<ConsumableItem>().ToTable("Consumables");

            builder.Entity<Plant>().HasBaseType<StockItem>();
            builder.Entity<Light>().HasBaseType<StockItem>();
            builder.Entity<ConsumableItem>().HasBaseType<StockItem>();
            builder.Entity<DurableItem>().HasBaseType<StockItem>();

            builder.Entity<StockItem>().Property(x => x.PurchasePrice).HasPrecision(8, 2);
            builder.Entity<ConsumableItem>().Property(x => x.UnitCount).HasPrecision(8, 2);

            #region Locations TPH
            builder.Entity<InventoryLocation>().Property(x => x.Active).HasDefaultValue(true);

            builder.Entity<InventoryLocation>().HasDiscriminator<string>("LocationType")
                                               .HasValue<ContainerLocation>("Container")
                                               .HasValue<RoomLocation>("Room")
                                               .HasValue<BuildingLocation>("Building")
                                               .HasValue<OffsiteLocation>("Offsite");

            builder.Entity<BuildingLocation>().HasOne(bl => bl.Address)
                                              .WithOne(a => a.Building)
                                              .HasForeignKey<BuildingLocation>(bl => bl.AddressID)
                                              .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<ContainerLocation>().HasOne(cl => cl.ContainerType)
                                               .WithMany(ct => ct.ContainerLocations)
                                               .HasForeignKey(cl => cl.ContainerTypeID)
                                               .OnDelete(DeleteBehavior.Restrict);


            builder.Entity<InventoryTransfer>().Property(x => x.UnitCount).HasPrecision(8, 2);
            builder.Entity<InventoryTransfer>().HasOne(it => it.Origin)
                                               .WithMany(o => o.TransfersOut)
                                               .HasForeignKey(it => it.OriginID)
                                               .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<InventoryTransfer>().HasOne(it => it.Destination)
                                               .WithMany(o => o.TransfersIn)
                                               .HasForeignKey(it => it.DestinationID)
                                               .OnDelete(DeleteBehavior.Restrict);
            #endregion
            #endregion


            #region Grow
            builder.Entity<Crop>().Property(x => x.WasteQuantity).HasPrecision(10, 2);

            builder.Entity<Crop>().HasOne(c => c.Location)
                                  .WithMany(r => r.Crops)
                                  .HasForeignKey(c => c.LocationID)
                                  .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Crop>().HasOne(c => c.Strain)
                                  .WithMany(s => s.Crops)
                                  .HasForeignKey(c => c.StrainID)
                                  .OnDelete(DeleteBehavior.Restrict);

            // Genetics Relationships
            builder.Entity<StrainRelationship>().HasKey(x => new { x.ParentID, x.ChildID }); // Composite Key

            builder.Entity<StrainRelationship>().HasOne(x => x.ParentStrain)
                                                .WithMany(s => s.Children)
                                                .HasForeignKey(x => x.ParentID)
                                                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<StrainRelationship>().HasOne(x => x.ChildStrain)
                                                .WithMany(s => s.Parents)
                                                .HasForeignKey(x => x.ChildID)
                                                .OnDelete(DeleteBehavior.Restrict);

            #region Plant Events 

            builder.Entity<PruneEvent>().Property(x => x.WasteQuantity).HasPrecision(10, 2);
            builder.Entity<TreatmentEvent>().Property(x => x.QuantityApplied).HasPrecision(8, 2);

            // TPH
            builder.Entity<PlantEvent>().HasDiscriminator<string>("EventType")
                                        .HasValue<PruneEvent>("Prune")
                                        .HasValue<LightEvent>("Light")
                                        .HasValue<GrowthEvent>("Growth")
                                        .HasValue<TransferEvent>("Transfer")
                                        .HasValue<TreatmentEvent>("Treatment")
                                        .HasValue<TransplantEvent>("Transplant");

            builder.Entity<PlantEvent>().HasOne(pe => pe.Plant)
                                        .WithMany(p => p.PlantEvents)
                                        .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<TransferEvent>().HasOne(ta => ta.Transfer)
                                           .WithOne(pt => pt.PlantTransfer)
                                           .HasForeignKey<TransferEvent>(ta => ta.TransferID)
                                           .OnDelete(DeleteBehavior.Restrict);


            builder.Entity<TreatmentEvent>().HasOne(te => te.Product)
                                            .WithMany(p => p.PlantTreatments)
                                            .HasForeignKey(te => te.ProductID)
                                            .HasPrincipalKey(p => p.ID)
                                            .OnDelete(DeleteBehavior.Restrict);
            #endregion
            #endregion


            #region Product
            builder.Entity<ProductItem>().HasIndex(x => x.Barcode).IsUnique();
            #endregion
        }




        public override int SaveChanges()
        {
            var hasCategoryChanges = ChangeTracker.Entries<InventoryCategory>()
                                                  .Any(e => e.State == EntityState.Added ||
                                                            e.State == EntityState.Modified ||
                                                            e.State == EntityState.Deleted);

            var result = base.SaveChanges();

            if (hasCategoryChanges)
            {
                _cache.Remove("CategoriesSelect"); 
            }

            return result;
        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            var hasCategoryChanges = ChangeTracker.Entries<InventoryCategory>()
                                                  .Any(e => e.State == EntityState.Added ||
                                                            e.State == EntityState.Modified ||
                                                            e.State == EntityState.Deleted);

            var result = await base.SaveChangesAsync(cancellationToken);

            if (hasCategoryChanges)
            {
                _cache.Remove("CategoriesSelect"); 
            }

            return result;
        }
    }
}
