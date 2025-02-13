using GrowFlow.Models;
using GrowFlow.Models.Grow;
using Microsoft.EntityFrameworkCore;

namespace GrowFlowMVC
{
    public class GrowFlowContext : DbContext
    {
        public GrowFlowContext(DbContextOptions<GrowFlowContext> options) : base(options) { }

        public DbSet<Container> Containers { get; set; }
        public DbSet<ContainerTransfer> ContainerTransfers { get; set; }
        public DbSet<Light> Lights { get; set; }       
        public DbSet<Location> Locations { get; set; }
        public DbSet<Plant> Plants { get; set; }
        public DbSet<PlantTransfer> PlantTransfers { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<RoomTransfer> RoomTransfers { get; set; }
        public DbSet<Strain> Strains { get; set; }
        public DbSet<StrainRelationship> StrainRelationships { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Container>().Property(x => x.Capacity).HasPrecision(8, 2);

            modelBuilder.Entity<Light>().Property(x => x.CoverageAreaSF).HasPrecision(6, 2);
            modelBuilder.Entity<Light>().Property(x => x.PPF).HasPrecision(6, 2);
            modelBuilder.Entity<Light>().Property(x => x.PPFD).HasPrecision(6, 2);
            modelBuilder.Entity<Light>().Property(x => x.Price).HasPrecision(8, 2);
            modelBuilder.Entity<Light>().Property(x => x.Active).HasDefaultValue(true);

            modelBuilder.Entity<Location>().Property(x => x.Active).HasDefaultValue(true);
            
            #region Handle Transfers TPH
            modelBuilder.Entity<PlantTransfer>().HasOne(pt => pt.Plant)
                                                .WithMany(p => p.Transfers)
                                                .HasForeignKey(pt => pt.PlantID);

            modelBuilder.Entity<PlantTransfer>().HasDiscriminator<string>("TransferType")
                                                .HasValue<ContainerTransfer>("Container")
                                                .HasValue<RoomTransfer>("Room");

            modelBuilder.Entity<ContainerTransfer>().HasOne(ct => ct.FromContainer)
                                                    .WithMany(c => c.TransfersOut)
                                                    .HasForeignKey(ct => ct.OriginID)
                                                    .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<ContainerTransfer>().HasOne(ct => ct.ToContainer)
                                                    .WithMany(c=> c.TransfersIn)
                                                    .HasForeignKey(ct => ct.DestinationID)
                                                    .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<ContainerTransfer>().Property(ct => ct.OriginID).HasColumnName("OriginID");
            modelBuilder.Entity<ContainerTransfer>().Property(ct => ct.DestinationID).HasColumnName("DestinationID");

            modelBuilder.Entity<RoomTransfer>().HasOne(rt => rt.FromRoom)
                                               .WithMany(r => r.TransfersOut)
                                               .HasForeignKey(rt => rt.OriginID)
                                               .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<RoomTransfer>().HasOne(rt => rt.ToRoom)
                                               .WithMany(r => r.TransfersIn)
                                               .HasForeignKey(rt => rt.DestinationID)
                                               .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<RoomTransfer>().Property(rt => rt.OriginID).HasColumnName("OriginID");
            modelBuilder.Entity<RoomTransfer>().Property(rt => rt.DestinationID).HasColumnName("DestinationID");
            #endregion

            #region Genetics Relationships
            modelBuilder.Entity<StrainRelationship>().HasKey(x => new { x.ParentID, x.ChildID }); // Composite Key

            modelBuilder.Entity<StrainRelationship>().HasOne(x => x.ParentStrain)
                                                     .WithMany(s => s.Children)
                                                     .HasForeignKey(x => x.ParentID)
                                                     .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<StrainRelationship>().HasOne(x => x.ChildStrain)
                                                     .WithMany(s => s.Parents)
                                                     .HasForeignKey(x => x.ChildID)
                                                     .OnDelete(DeleteBehavior.Restrict);
            #endregion

            base.OnModelCreating(modelBuilder);
        }
    }
}
