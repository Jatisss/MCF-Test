﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using bpkp_be.Database;

#nullable disable

namespace bpkp_be.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.31")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("bpkp_be.Controllers.Models.MsStorageLocation", b =>
                {
                    b.Property<string>("LocationId")
                        .HasColumnType("nvarchar(10)");

                    b.Property<string>("LocationName")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("LocationId");

                    b.ToTable("ms_storage_location");
                });

            modelBuilder.Entity("bpkp_be.Controllers.Models.MsUser", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UserId"), 1L, 1);

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("UserId");

                    b.ToTable("ms_user");
                });

            modelBuilder.Entity("bpkp_be.Controllers.Models.TrBpkb", b =>
                {
                    b.Property<string>("AgreementNumber")
                        .HasColumnType("nvarchar(100)");

                    b.Property<DateTime>("BpkbDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("BpkbDateIn")
                        .HasColumnType("datetime2");

                    b.Property<string>("BpkbNo")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("BranchId")
                        .IsRequired()
                        .HasColumnType("nvarchar(10)");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasColumnType("nvarchar(20)");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("FakturDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("FakturNo")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("LastUpdatedBy")
                        .IsRequired()
                        .HasColumnType("nvarchar(20)");

                    b.Property<DateTime>("LastUpdatedOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("LocationId")
                        .IsRequired()
                        .HasColumnType("nvarchar(10)");

                    b.Property<string>("PoliceNo")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("AgreementNumber");

                    b.ToTable("tr_bpkp");
                });
#pragma warning restore 612, 618
        }
    }
}
