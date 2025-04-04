using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Microsoft.Extensions.Caching.Memory;
using OptraxDAL.Models;
using OptraxDAL.Models.Admin;
using OptraxDAL.Models.BaseClasses;
using OptraxDAL.Models.Grow;
using OptraxDAL.Models.Inventory;
using OptraxDAL.Models.Maps;
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
        public DbSet<Site> Sites { get; set; }
        public DbSet<Field> Fields { get; set; }
        public DbSet<Greenhouse> Greenhouses { get; set; }
        public DbSet<Building> Buildings { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Vehicle> Vehicles { get; set; }
        public DbSet<OffsiteLocation> OffsiteLocations { get; set; }
        //public DbSet<RowLocation> RowLocations { get; set; }
        //public DbSet<BedLocation> BedLocations { get; set; }
        //public DbSet<PlotLocation> PlotLocations { get; set; }
        #endregion


        #region Grow
        public DbSet<Plant> Plants { get; set; }
        public DbSet<PlantTrait> PlantTraits { get; set; }
        public DbSet<PlantProfile> PlantProfiles { get; set; }
        public DbSet<TraitDefinition> TraitDefinitions { get; set; }


        public DbSet<Crop> Crops { get; set; }
        public DbSet<CropBatch> CropBatches { get; set; }

        public DbSet<Planting> Plantings { get; set; }
        public DbSet<PlantingSection> Sections { get; set; }
        public DbSet<PlantingPattern> Patterns { get; set; }

        //public DbSet<Strain> Strains { get; set; }
        //public DbSet<StrainRelationship> StrainRelationships { get; set; }

        //public DbSet<PlantEvent> PlantEvents { get; set; }
        //public DbSet<PruneEvent> PruneEvents { get; set; }
        //public DbSet<GrowthEvent> GrowthEvents { get; set; }
        //public DbSet<TransferEvent> TransferEvents { get; set; }
        //public DbSet<TreatmentEvent> TreatmentEvents { get; set; }
        //public DbSet<TransplantEvent> TransplantEvents { get; set; }
        #endregion


        #region Inventory
        public DbSet<Resource> Resources { get; set; }
        public DbSet<Category> Categories { get; set; }

        public DbSet<StockItem> StockItems { get; set; }
        public DbSet<Durable> Durables { get; set; }
        public DbSet<Consumable> Consumables { get; set; }

        public DbSet<InventoryTransfer> Transfers { get; set; }
        public DbSet<TransferApproval> TransferApprovals { get; set; }

        public DbSet<SalesOrder> SalesOrders { get; set; }
        #endregion


        #region Map
        public DbSet<Map> Maps { get; set; }
        public DbSet<MapObject> MapObjects { get; set; }
        public DbSet<MapPoint> MapPoints { get; set; }
        public DbSet<MapLine> MapLines { get; set; }
        public DbSet<MapCircle> MapCircles { get; set; }
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

            var rgbaConverter = new ValueConverter<ColorRgba, byte[]>(v => v.ToBytes(), v => ColorRgba.FromBytes(v));

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

            builder.Entity<ContainerType>(e =>
            {
                e.Property(x => x.Capacity).HasPrecision(8, 2);
                e.Property(x => x.Active).HasDefaultValue(true);
            });
            #endregion

            #region Locations TPH
            builder.Entity<Location>(e =>
            {
                e.Property(x => x.Active).HasDefaultValue(true);

                e.HasOne(x => x.MapObject).WithOne(b => b.Location)
                                          .HasForeignKey<Location>(x => x.MapObjectId)
                                          .OnDelete(DeleteBehavior.Cascade);

                e.HasDiscriminator<string>("LocationType").HasValue<Site>("Site")
                                                          .HasValue<Field>("Field")
                                                          .HasValue<Greenhouse>("Greenhouse")
                                                          .HasValue<Building>("Building")
                                                          .HasValue<Room>("Room")
                                                          .HasValue<OffsiteLocation>("Offsite")
                                                          .HasValue<Vehicle>("Vehicle");
            });

            builder.Entity<Site>(e =>
            {
                e.HasOne(sl => sl.Business).WithMany(b => b.Sites)
                                           .HasForeignKey(sl => sl.BusinessId)
                                           .OnDelete(DeleteBehavior.Restrict);
            });

            builder.Entity<Field>(e =>
            {
                e.Property(x => x.Width).HasPrecision(18, 4);
                e.Property(x => x.Length).HasPrecision(18, 4);
                e.Property(x => x.Radius).HasPrecision(18, 4);
            });

            builder.Entity<Greenhouse>(e =>
            {
                e.Property(x => x.Width).HasPrecision(18, 4);
                e.Property(x => x.Length).HasPrecision(18, 4);
                e.Property(x => x.Radius).HasPrecision(18, 4);
            });

            builder.Entity<Building>(e =>
            {
                e.HasOne(bl => bl.Address).WithOne(a => a.Building)
                                          .HasForeignKey<Building>(bl => bl.AddressId)
                                          .OnDelete(DeleteBehavior.Restrict);

                e.HasOne(bl => bl.Business).WithMany(b => b.Buildings)
                                           .HasForeignKey(bl => bl.BusinessId)
                                           .OnDelete(DeleteBehavior.Restrict);
            });

            builder.Entity<InventoryTransfer>(e =>
            {
                e.Property(x => x.UnitCount).HasPrecision(8, 2);

                e.HasOne(it => it.Origin).WithMany(o => o.TransfersOut)
                                         .HasForeignKey(it => it.OriginId)
                                         .OnDelete(DeleteBehavior.Restrict);

                e.HasOne(it => it.Destination).WithMany(o => o.TransfersIn)
                                              .HasForeignKey(it => it.DestinationId)
                                              .OnDelete(DeleteBehavior.Restrict);
            });
            #endregion

            #region Inventory
            builder.Entity<Category>(e =>
            {
                e.HasIndex(x => x.Name).IsUnique();
                e.Property(x => x.Active).HasDefaultValue(true);
            });

            builder.Entity<Resource>(e =>
            {
                e.HasIndex(x => x.SKU).IsUnique();
                e.HasIndex(x => x.Name).IsUnique();
                e.Property(x => x.Active).HasDefaultValue(true);
            });

            #region Stock Items TPT
            builder.Entity<Durable>(e =>
            {
                e.HasBaseType<StockItem>();
                e.ToTable("Durables", "Inventory");
            });
            builder.Entity<Consumable>(e =>
            {
                e.HasBaseType<StockItem>();
                e.ToTable("Consumables", "Inventory");
                e.Property(x => x.UnitCount).HasPrecision(8, 2);
            });

            builder.Entity<StockItem>().Property(x => x.PurchasePrice).HasPrecision(8, 2);
            #endregion

            #endregion

            #region Map
            builder.Entity<MapPoint>(e =>
            {
                e.HasBaseType<MapObject>();
                e.ToTable("Points", "Map");
                e.Property(x => x.Latitude).HasPrecision(12, 8);
                e.Property(x => x.Longitude).HasPrecision(12, 8);
                e.Property(x => x.Elevation).HasPrecision(12, 8);
            });

            builder.Entity<MapLine>(e =>
            {
                e.HasBaseType<MapObject>();
                e.ToTable("Lines", "Map");
                e.Property(x => x.LineGeometry).HasColumnType("geometry");
                e.Property(e => e.ColorBytes).HasConversion(rgbaConverter).HasColumnType("varbinary(4)");
                e.Property(e => e.FillColorBytes).HasConversion(rgbaConverter).HasColumnType("varbinary(4)");
            });

            builder.Entity<MapCircle>(e =>
            {
                e.HasBaseType<MapObject>();
                e.ToTable("Circles", "Map");
                e.Property(x => x.Radius).HasPrecision(12, 8);
                e.Property(x => x.Area).HasColumnType("geometry");
                e.Property(e => e.ColorBytes).HasConversion(rgbaConverter).HasColumnType("varbinary(4)");
                e.Property(e => e.FillColorBytes).HasConversion(rgbaConverter).HasColumnType("varbinary(4)");
            });

            builder.Entity<MapPolygon>(e =>
            {
                e.HasBaseType<MapObject>();
                e.ToTable("Polygons", "Map");
                e.Property(l => l.PolyGeometry).HasColumnType("geometry");
                e.Property(e => e.ColorBytes).HasConversion(rgbaConverter).HasColumnType("varbinary(4)");
                e.Property(e => e.FillColorBytes).HasConversion(rgbaConverter).HasColumnType("varbinary(4)");
            });
            #endregion

            #region Grow
            builder.Entity<Plant>(e =>
            {
                e.HasOne(p => p.Parent1).WithMany(p => p.ChildrenP1)
                                        .HasForeignKey(p => p.Parent1Id)
                                        .OnDelete(DeleteBehavior.Restrict);

                e.HasOne(p => p.Parent2).WithMany(p => p.ChildrenP2)
                                        .HasForeignKey(p => p.Parent2Id)
                                        .OnDelete(DeleteBehavior.Restrict);

                e.HasOne(p => p.Profile).WithMany(p => p.Plants)
                                        .HasForeignKey(p => p.ProfileId)
                                        .OnDelete(DeleteBehavior.Restrict);
            });

            builder.Entity<PlantTrait>(e =>
            {
                e.HasOne(p => p.Definition).WithMany(p => p.Traits)
                                           .HasForeignKey(p => p.DefinitionId)
                                           .OnDelete(DeleteBehavior.Restrict);
            });

            builder.Entity<Crop>(e =>
            {
                e.HasIndex(x => x.Name).IsUnique();

                e.HasOne(x => x.Plant).WithMany(c => c.Crops)
                                      .HasForeignKey(x => x.PlantId)
                                      .OnDelete(DeleteBehavior.Restrict);
            });

            builder.Entity<CropBatch>(e =>
            {
                e.HasIndex(x => x.Name).IsUnique();

                e.HasOne(c => c.Crop).WithMany(s => s.Batches)
                                     .HasForeignKey(c => c.CropId)
                                     .OnDelete(DeleteBehavior.Restrict);
            });

            builder.Entity<Planting>(e =>
            {
                e.Property(x => x.WasteQuantity).HasPrecision(10, 2);

                e.HasOne(x => x.Crop).WithMany(c => c.Plantings)
                                     .HasForeignKey(x => x.CropId)
                                     .OnDelete(DeleteBehavior.Restrict);

                e.HasOne(x => x.Batch).WithMany(b => b.Plantings)
                                      .HasForeignKey(x => x.BatchId)
                                      .OnDelete(DeleteBehavior.Restrict);

                e.HasOne(x => x.Location).WithMany(b => b.Plantings)
                                         .HasForeignKey(x => x.LocationId)
                                         .OnDelete(DeleteBehavior.Restrict);
            });

            builder.Entity<PlantingPattern>(e =>
            {
                e.Property(x => x.Width).HasPrecision(18, 4);
                e.Property(x => x.Length).HasPrecision(18, 4);
                e.Property(x => x.Radius).HasPrecision(18, 4);
                e.Property(x => x.SpaceLeft).HasPrecision(18, 4);
                e.Property(x => x.SpaceRight).HasPrecision(18, 4);
                e.Property(x => x.PlantSpacing).HasPrecision(18, 4);
                e.Property(x => x.Direction).HasMaxLength(10);
            });

            builder.Entity<PlantingSection>(e =>
            {
                e.Property(x => x.SectionType).HasMaxLength(20);

                e.HasOne(x => x.Planting).WithMany(b => b.Sections)
                                         .HasForeignKey(x => x.PlantingId)
                                         .OnDelete(DeleteBehavior.Restrict);

                e.HasOne(x => x.Parent).WithMany(b => b.Children)
                                       .HasForeignKey(x => x.ParentId)
                                       .OnDelete(DeleteBehavior.Restrict);

                e.HasOne(x => x.Pattern).WithMany(b => b.Sections)
                                        .HasForeignKey(x => x.PatternId)
                                        .OnDelete(DeleteBehavior.Restrict);

                e.HasOne(x => x.MapObject).WithOne(b => b.Section)
                                          .HasForeignKey<PlantingSection>(x => x.MapObjectId)
                                          .OnDelete(DeleteBehavior.Cascade);
            });

            // Genetics Relationships
            //builder.Entity<Strain>().HasIndex(x => x.Name).IsUnique();

            //builder.Entity<StrainRelationship>(e =>
            //{
            //    e.HasKey(x => new { x.ParentId, x.ChildId }); // Composite Key

            //    e.HasOne(x => x.ParentStrain).WithMany(s => s.Children)
            //                                 .HasForeignKey(x => x.ParentId)
            //                                 .OnDelete(DeleteBehavior.Restrict);

            //    e.HasOne(x => x.ChildStrain).WithMany(s => s.Parents)
            //                                .HasForeignKey(x => x.ChildId)
            //                                .OnDelete(DeleteBehavior.Restrict);
            //});

            #region Plant Events 

            //builder.Entity<PruneEvent>().Property(x => x.WasteQuantity).HasPrecision(10, 2);
            //builder.Entity<TreatmentEvent>().Property(x => x.QuantityApplied).HasPrecision(8, 2);

            //// TPH
            //builder.Entity<PlantEvent>(e =>
            //{
            //    e.HasDiscriminator<string>("EventType").HasValue<PruneEvent>("Prune")
            //                                           .HasValue<GrowthEvent>("Growth")
            //                                           .HasValue<TransferEvent>("Transfer")
            //                                           .HasValue<TreatmentEvent>("Treatment")
            //                                           .HasValue<TransplantEvent>("Transplant");

            //    e.HasOne(pe => pe.Plant).WithMany(p => p.PlantEvents)
            //                            .OnDelete(DeleteBehavior.Restrict);
            //});

            //builder.Entity<TransferEvent>().HasOne(ta => ta.Transfer)
            //                               .WithOne(pt => pt.PlantTransfer)
            //                               .HasForeignKey<TransferEvent>(ta => ta.TransferId)
            //                               .OnDelete(DeleteBehavior.Restrict);


            //builder.Entity<TreatmentEvent>().HasOne(te => te.Product)
            //                                .WithMany(p => p.PlantTreatments)
            //                                .HasForeignKey(te => te.ProductId)
            //                                .HasPrincipalKey(p => p.Id)
            //                                .OnDelete(DeleteBehavior.Restrict);
            #endregion
            #endregion

            #region Products
            builder.Entity<Product>().HasIndex(x => x.Name).IsUnique();
            builder.Entity<ProductItem>().HasIndex(x => x.Barcode).IsUnique();
            #endregion
        }

        public override int SaveChanges()
        {
            SetTracking();

            return base.SaveChanges();
        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            SetTracking();

            return await base.SaveChangesAsync(cancellationToken);

        }

        private void SetTracking()
        {
            var userId = _userService?.UserId;

            foreach (var entry in ChangeTracker.Entries<TrackingBase>())
            {
                if (entry.State == EntityState.Added)
                {
                    entry.Entity.UserId = userId;
                    entry.Entity.DateCreated = DateTime.Now;
                }
                else if (entry.State == EntityState.Modified)
                {
                    entry.Entity.DateLastModified = DateTime.Now;
                }
            }
        }
    }
}
