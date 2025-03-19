using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using OptraxDAL.Models;
using OptraxDAL.Models.Admin;
using OptraxDAL.Models.Grow;
using OptraxDAL.Models.Inventory;
using OptraxDAL.Models.Map;
using OptraxDAL.Models.Products;


namespace OptraxDAL
{
    public class OptraxContext(DbContextOptions<OptraxContext> options, IMemoryCache cache, ICurrentUserService userService) : IdentityDbContext<AppUser>(options)
    {
        private readonly IMemoryCache _Cache = cache;
        private readonly ICurrentUserService _userService = userService;

        #region Admin
        public DbSet<AppUser> AppUsers { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Business> Businesses { get; set; }

        public DbSet<UoM> UoMs { get; set; }
        public DbSet<Input> Inputs { get; set; }
        public DbSet<ContainerType> ContainerTypes { get; set; }

        public DbSet<Icon> Icons { get; set; }
        public DbSet<IconCollection> IconCollections { get; set; }


        public DbSet<Location> Locations { get; set; }
        public DbSet<SiteLocation> SiteLocations { get; set; }
        public DbSet<FieldLocation> FieldLocations { get; set; }
        public DbSet<RowLocation> RowLocations { get; set; }
        public DbSet<BedLocation> BedLocations { get; set; }
        public DbSet<PlotLocation> PlotLocations { get; set; }
        public DbSet<GreenhouseLocation> GreenhouseLocations { get; set; }
        public DbSet<BuildingLocation> BuildingLocations { get; set; }
        public DbSet<RoomLocation> RoomLocations { get; set; }
        public DbSet<VehicleLocation> VehicleLocation { get; set; }
        public DbSet<OffsiteLocation> OffsiteLocations { get; set; }
        #endregion


        #region Grow
        public DbSet<Species> Species { get; set; }
        public DbSet<Variety> Varieties { get; set; }
        public DbSet<Cultivar> Cultivars { get; set; }

        public DbSet<Crop> Crops { get; set; }
        public DbSet<Batch> Batches { get; set; }
        public DbSet<Planting> Plantings { get; set; }

        public DbSet<Strain> Strains { get; set; }
        public DbSet<StrainRelationship> StrainRelationships { get; set; }

        public DbSet<PlantEvent> PlantEvents { get; set; }
        public DbSet<PruneEvent> PruneEvents { get; set; }
        public DbSet<GrowthEvent> GrowthEvents { get; set; }
        public DbSet<TransferEvent> TransferEvents { get; set; }
        public DbSet<TreatmentEvent> TreatmentEvents { get; set; }
        public DbSet<TransplantEvent> TransplantEvents { get; set; }
        #endregion


        #region Inventory
        public DbSet<Resource> Resources { get; set; }
        public DbSet<Category> Categories { get; set; }

        public DbSet<StockItem> StockItems { get; set; }
        public DbSet<Plant> Plants { get; set; }
        public DbSet<Light> Lights { get; set; }
        public DbSet<Durable> Durables { get; set; }
        public DbSet<Consumable> Consumables { get; set; }

        public DbSet<InventoryTransfer> Transfers { get; set; }
        public DbSet<TransferApproval> TransferApprovals { get; set; }

        public DbSet<SalesOrder> SalesOrders { get; set; }
        #endregion


        #region Map
        public DbSet<MapObject> MapObjects { get; set; }
        public DbSet<MapObjectPoint> MapObjectPoints { get; set; }
        public DbSet<MapPoint> MapPoints { get; set; }
        public DbSet<MapLine> MapLines { get; set; }
        public DbSet<MapPolygon> MapPolygons { get; set; }
        #endregion


        #region Product
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductItem> ProductItems { get; set; }
        public DbSet<ProductBatch> ProductBatches { get; set; }
        public DbSet<PurchaseOrder> PurchaseOrders { get; set; }
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

            builder.Entity<Business>().HasIndex(x => x.Name).IsUnique();
            builder.Entity<Input>().HasIndex(x => x.InputName).IsUnique();
            builder.Entity<UoM>().Property(x => x.PerQuantity).HasPrecision(6, 2);
            #endregion

            #region Inventory
            builder.Entity<Category>().HasIndex(x => x.Name).IsUnique();

            builder.Entity<Resource>().HasIndex(x => x.SKU).IsUnique();
            builder.Entity<Resource>().HasIndex(x => x.Name).IsUnique();
            builder.Entity<Resource>().Property(x => x.Active).HasDefaultValue(true);

            builder.Entity<ContainerType>().Property(x => x.Capacity).HasPrecision(8, 2);
            builder.Entity<ContainerType>().Property(x => x.Active).HasDefaultValue(true);

            #region Stock Items TPT
            builder.Entity<Plant>().ToTable("Plants", "Inventory");
            builder.Entity<Light>().ToTable("Lights", "Inventory");
            builder.Entity<Durable>().ToTable("Durables", "Inventory");
            builder.Entity<Consumable>().ToTable("Consumables", "Inventory");

            builder.Entity<Plant>().HasBaseType<StockItem>();
            builder.Entity<Light>().HasBaseType<StockItem>();
            builder.Entity<Durable>().HasBaseType<StockItem>();
            builder.Entity<Consumable>().HasBaseType<StockItem>();

            builder.Entity<StockItem>().Property(x => x.PurchasePrice).HasPrecision(8, 2);
            builder.Entity<Consumable>().Property(x => x.UnitCount).HasPrecision(8, 2);
            #endregion


            #region Locations TPH
            builder.Entity<Location>().HasIndex(x => x.Name).IsUnique();
            builder.Entity<Location>().Property(x => x.Active).HasDefaultValue(true);

            builder.Entity<Location>().HasDiscriminator<string>("LocationType")
                                               .HasValue<SiteLocation>("Site")
                                               .HasValue<FieldLocation>("Field")
                                               .HasValue<RowLocation>("Row")
                                               .HasValue<BedLocation>("Bed")
                                               .HasValue<PlotLocation>("Plot")
                                               .HasValue<GreenhouseLocation>("Greenhouse")
                                               .HasValue<BuildingLocation>("Building")
                                               .HasValue<RoomLocation>("Room")
                                               .HasValue<OffsiteLocation>("Offsite")
                                               .HasValue<VehicleLocation>("Vehicle");

            builder.Entity<BuildingLocation>().HasOne(bl => bl.Address)
                                              .WithOne(a => a.Building)
                                              .HasForeignKey<BuildingLocation>(bl => bl.AddressID)
                                              .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<SiteLocation>().HasOne(sl => sl.Business)
                                          .WithMany(b => b.Sites)
                                          .HasForeignKey(sl => sl.BusinessID)
                                          .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<BuildingLocation>().HasOne(bl => bl.Business)
                                              .WithMany(b => b.Buildings)
                                              .HasForeignKey(bl => bl.BusinessID)
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

            #region Map
            builder.Entity<MapPoint>().ToTable("Points", "Map");
            builder.Entity<MapLine>().ToTable("Lines", "Map");
            builder.Entity<MapPolygon>().ToTable("Polygons", "Map");

            builder.Entity<MapPoint>().HasBaseType<MapObject>();
            builder.Entity<MapLine>().HasBaseType<MapObject>();
            builder.Entity<MapPolygon>().HasBaseType<MapObject>();

            builder.Entity<MapLine>().Property(l => l.LineGeometry).HasColumnType("geometry");
            builder.Entity<MapPolygon>().Property(l => l.PolyGeometry).HasColumnType("geometry");
            builder.Entity<MapPoint>().Property(x => x.Latitude).HasPrecision(12, 8);
            builder.Entity<MapPoint>().Property(x => x.Longitude).HasPrecision(12, 8);
            builder.Entity<MapPoint>().Property(x => x.Elevation).HasPrecision(12, 8);

            builder.Entity<MapObjectPoint>().Property(x => x.Latitude).HasPrecision(12, 8);
            builder.Entity<MapObjectPoint>().Property(x => x.Longitude).HasPrecision(12, 8);
            builder.Entity<MapObjectPoint>().Property(x => x.Elevation).HasPrecision(12, 8);
            #endregion


            #region Grow
            builder.Entity<Species>().HasIndex(x => x.SpeciesName).IsUnique();
            builder.Entity<Species>().Property(x => x.WaterNeedsQty).HasPrecision(8, 2);

            builder.Entity<Crop>().HasIndex(x => x.Name).IsUnique();
            builder.Entity<Batch>().HasIndex(x => x.BatchName).IsUnique();
            builder.Entity<Planting>().Property(x => x.WasteQuantity).HasPrecision(10, 2);

            builder.Entity<Batch>().HasOne(c => c.Crop)
                                  .WithMany(s => s.Batches)
                                  .HasForeignKey(c => c.CropID)
                                  .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Strain>().HasIndex(x => x.Name).IsUnique();

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

            #region Products
            builder.Entity<Product>().HasIndex(x => x.ProductName).IsUnique();
            builder.Entity<ProductItem>().HasIndex(x => x.Barcode).IsUnique();
            #endregion
        }

        public override int SaveChanges()
        {
            var hasCategoryChanges = ChangeTracker.Entries<Category>().Any(e => e.State == EntityState.Added ||
                                                                                e.State == EntityState.Modified ||
                                                                                e.State == EntityState.Deleted);

            var result = base.SaveChanges();

            if (hasCategoryChanges)
            {
                _Cache.Remove("CategoriesSelect");
            }

            return result;
        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            var userID = _userService?.UserID;

            foreach (var entry in ChangeTracker.Entries<TrackingBase>())
            {
                if (entry.State == EntityState.Added)
                {
                    entry.Entity.DateCreated = DateTime.Now;
                    entry.Entity.CreatedUserID = userID;
                }
                else if (entry.State == EntityState.Modified)
                {
                    entry.Entity.DateLastModified = DateTime.Now;
                    entry.Entity.LastModifiedUserID = userID;
                }
            }

            return await base.SaveChangesAsync(cancellationToken);

            //var hasCategoryChanges = ChangeTracker.Entries<Category>()
            //                          .Any(e => e.State == EntityState.Added ||
            //                                    e.State == EntityState.Modified ||
            //                                    e.State == EntityState.Deleted);


            //if (hasCategoryChanges)
            //{
            //    _cache.Remove("CategoriesSelect");
            //}
        }
    }
}
