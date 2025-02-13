﻿// <auto-generated />
using System;
using GrowFlowMVC;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace GrowFlowMVC.Migrations
{
    [DbContext(typeof(GrowFlowContext))]
    partial class GrowFlowContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("GrowFlow.Models.Grow.Container", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<decimal>("Capacity")
                        .HasPrecision(8, 2)
                        .HasColumnType("decimal(8,2)");

                    b.Property<string>("CapacityUnit")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Containers");
                });

            modelBuilder.Entity("GrowFlow.Models.Grow.Light", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<bool>("Active")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(true);

                    b.Property<string>("BulbType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ColorSpectrum")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<decimal?>("CoverageArea")
                        .HasPrecision(6, 2)
                        .HasColumnType("decimal(6,2)");

                    b.Property<int?>("LifespanHours")
                        .HasColumnType("int");

                    b.Property<string>("Manufacturer")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<decimal?>("PPF")
                        .HasPrecision(6, 2)
                        .HasColumnType("decimal(6,2)");

                    b.Property<decimal?>("PPFD")
                        .HasPrecision(6, 2)
                        .HasColumnType("decimal(6,2)");

                    b.Property<decimal?>("Price")
                        .HasPrecision(8, 2)
                        .HasColumnType("decimal(8,2)");

                    b.Property<int?>("RoomID")
                        .HasColumnType("int");

                    b.Property<int?>("Voltage")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("RoomID");

                    b.ToTable("Lights", "Grow");
                });

            modelBuilder.Entity("GrowFlow.Models.Grow.Plant", b =>
                {
                    b.Property<int>("PlantID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PlantID"));

                    b.Property<int?>("ContainerID")
                        .HasColumnType("int");

                    b.Property<string>("GrowthPhase")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("LightID")
                        .HasColumnType("int");

                    b.Property<int?>("RoomID")
                        .HasColumnType("int");

                    b.Property<int>("StrainID")
                        .HasColumnType("int");

                    b.HasKey("PlantID");

                    b.HasIndex("ContainerID");

                    b.HasIndex("LightID");

                    b.HasIndex("RoomID");

                    b.HasIndex("StrainID");

                    b.ToTable("Plants", "Grow");
                });

            modelBuilder.Entity("GrowFlow.Models.Grow.PlantTransfer", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<DateTimeOffset>("Date")
                        .HasColumnType("datetimeoffset");

                    b.Property<int>("DestinationID")
                        .HasColumnType("int")
                        .HasColumnName("DestinationID");

                    b.Property<string>("Notes")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("OriginID")
                        .HasColumnType("int")
                        .HasColumnName("OriginID");

                    b.Property<int>("PlantID")
                        .HasColumnType("int");

                    b.Property<string>("TransferType")
                        .IsRequired()
                        .HasMaxLength(13)
                        .HasColumnType("nvarchar(13)");

                    b.Property<int>("UserID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("PlantID");

                    b.ToTable("PlantTransfers", "Grow");

                    b.HasDiscriminator<string>("TransferType").HasValue("PlantTransfer");

                    b.UseTphMappingStrategy();
                });

            modelBuilder.Entity("GrowFlow.Models.Grow.Room", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<bool>("Active")
                        .HasColumnType("bit");

                    b.Property<string>("Description")
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<int?>("LocationID")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("ID");

                    b.HasIndex("LocationID");

                    b.ToTable("Rooms", "Grow");
                });

            modelBuilder.Entity("GrowFlow.Models.Grow.Strain", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("StrainType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Strains", "Grow");
                });

            modelBuilder.Entity("GrowFlow.Models.Grow.StrainRelationship", b =>
                {
                    b.Property<int>("ParentID")
                        .HasColumnType("int");

                    b.Property<int>("ChildID")
                        .HasColumnType("int");

                    b.HasKey("ParentID", "ChildID");

                    b.HasIndex("ChildID");

                    b.ToTable("StrainRelationships", "Grow");
                });

            modelBuilder.Entity("GrowFlow.Models.Location", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<bool>("Active")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(true);

                    b.Property<string>("Address1")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Address2")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("City")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LocationType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("State")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ZipCode")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Locations");
                });

            modelBuilder.Entity("GrowFlow.Models.Grow.ContainerTransfer", b =>
                {
                    b.HasBaseType("GrowFlow.Models.Grow.PlantTransfer");

                    b.HasIndex("DestinationID");

                    b.HasIndex("OriginID");

                    b.ToTable("PlantTransfers", "Grow");

                    b.HasDiscriminator().HasValue("Container");
                });

            modelBuilder.Entity("GrowFlow.Models.Grow.RoomTransfer", b =>
                {
                    b.HasBaseType("GrowFlow.Models.Grow.PlantTransfer");

                    b.HasIndex("DestinationID");

                    b.HasIndex("OriginID");

                    b.ToTable("PlantTransfers", "Grow");

                    b.HasDiscriminator().HasValue("Room");
                });

            modelBuilder.Entity("GrowFlow.Models.Grow.Light", b =>
                {
                    b.HasOne("GrowFlow.Models.Grow.Room", "Room")
                        .WithMany()
                        .HasForeignKey("RoomID");

                    b.Navigation("Room");
                });

            modelBuilder.Entity("GrowFlow.Models.Grow.Plant", b =>
                {
                    b.HasOne("GrowFlow.Models.Grow.Container", "CurrentContainer")
                        .WithMany("Plants")
                        .HasForeignKey("ContainerID");

                    b.HasOne("GrowFlow.Models.Grow.Light", "CurrentLight")
                        .WithMany("Plants")
                        .HasForeignKey("LightID");

                    b.HasOne("GrowFlow.Models.Grow.Room", "CurrentRoom")
                        .WithMany("Plants")
                        .HasForeignKey("RoomID");

                    b.HasOne("GrowFlow.Models.Grow.Strain", "Strain")
                        .WithMany("Plants")
                        .HasForeignKey("StrainID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CurrentContainer");

                    b.Navigation("CurrentLight");

                    b.Navigation("CurrentRoom");

                    b.Navigation("Strain");
                });

            modelBuilder.Entity("GrowFlow.Models.Grow.PlantTransfer", b =>
                {
                    b.HasOne("GrowFlow.Models.Grow.Plant", "Plant")
                        .WithMany("Transfers")
                        .HasForeignKey("PlantID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Plant");
                });

            modelBuilder.Entity("GrowFlow.Models.Grow.Room", b =>
                {
                    b.HasOne("GrowFlow.Models.Location", "Location")
                        .WithMany("Rooms")
                        .HasForeignKey("LocationID");

                    b.Navigation("Location");
                });

            modelBuilder.Entity("GrowFlow.Models.Grow.StrainRelationship", b =>
                {
                    b.HasOne("GrowFlow.Models.Grow.Strain", "ChildStrain")
                        .WithMany("Parents")
                        .HasForeignKey("ChildID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("GrowFlow.Models.Grow.Strain", "ParentStrain")
                        .WithMany("Children")
                        .HasForeignKey("ParentID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("ChildStrain");

                    b.Navigation("ParentStrain");
                });

            modelBuilder.Entity("GrowFlow.Models.Grow.ContainerTransfer", b =>
                {
                    b.HasOne("GrowFlow.Models.Grow.Container", "ToContainer")
                        .WithMany("TransfersIn")
                        .HasForeignKey("DestinationID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("GrowFlow.Models.Grow.Container", "FromContainer")
                        .WithMany("TransfersOut")
                        .HasForeignKey("OriginID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("FromContainer");

                    b.Navigation("ToContainer");
                });

            modelBuilder.Entity("GrowFlow.Models.Grow.RoomTransfer", b =>
                {
                    b.HasOne("GrowFlow.Models.Grow.Room", "ToRoom")
                        .WithMany("TransfersIn")
                        .HasForeignKey("DestinationID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("GrowFlow.Models.Grow.Room", "FromRoom")
                        .WithMany("TransfersOut")
                        .HasForeignKey("OriginID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("FromRoom");

                    b.Navigation("ToRoom");
                });

            modelBuilder.Entity("GrowFlow.Models.Grow.Container", b =>
                {
                    b.Navigation("Plants");

                    b.Navigation("TransfersIn");

                    b.Navigation("TransfersOut");
                });

            modelBuilder.Entity("GrowFlow.Models.Grow.Light", b =>
                {
                    b.Navigation("Plants");
                });

            modelBuilder.Entity("GrowFlow.Models.Grow.Plant", b =>
                {
                    b.Navigation("Transfers");
                });

            modelBuilder.Entity("GrowFlow.Models.Grow.Room", b =>
                {
                    b.Navigation("Plants");

                    b.Navigation("TransfersIn");

                    b.Navigation("TransfersOut");
                });

            modelBuilder.Entity("GrowFlow.Models.Grow.Strain", b =>
                {
                    b.Navigation("Children");

                    b.Navigation("Parents");

                    b.Navigation("Plants");
                });

            modelBuilder.Entity("GrowFlow.Models.Location", b =>
                {
                    b.Navigation("Rooms");
                });
#pragma warning restore 612, 618
        }
    }
}
