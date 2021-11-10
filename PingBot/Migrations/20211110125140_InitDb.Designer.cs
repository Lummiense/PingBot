﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using PingBot.Data;

namespace PingBot.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20211110125140_InitDb")]
    partial class InitDb
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("ProductVersion", "5.0.11")
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            modelBuilder.Entity("PingBot.Contracts.Entities.CamEntity", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.None);

                    b.Property<long?>("ContractEntityId")
                        .HasColumnType("bigint");

                    b.Property<string>("Coordinates")
                        .HasColumnType("text");

                    b.Property<string>("IP")
                        .HasColumnType("text");

                    b.Property<string>("InstallationAddress")
                        .HasColumnType("text");

                    b.Property<string>("InstallationPlacePhoto")
                        .HasColumnType("text");

                    b.Property<bool>("IsActive")
                        .HasColumnType("boolean");

                    b.Property<DateTime>("UpdateDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("ViewDescription")
                        .HasColumnType("text");

                    b.Property<string>("ViewPhoto")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("ContractEntityId");

                    b.ToTable("Camers");
                });

            modelBuilder.Entity("PingBot.Contracts.Entities.CamTypeEntity", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.None);

                    b.Property<string>("CamType")
                        .HasColumnType("text");

                    b.Property<bool>("IsActive")
                        .HasColumnType("boolean");

                    b.Property<DateTime>("UpdateDate")
                        .HasColumnType("timestamp without time zone");

                    b.HasKey("Id");

                    b.ToTable("CamTypes");
                });

            modelBuilder.Entity("PingBot.Contracts.Entities.ContractEntity", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.None);

                    b.Property<string>("ContractTitle")
                        .HasColumnType("text");

                    b.Property<bool>("IsActive")
                        .HasColumnType("boolean");

                    b.Property<DateTime>("UpdateDate")
                        .HasColumnType("timestamp without time zone");

                    b.HasKey("Id");

                    b.ToTable("Contract");
                });

            modelBuilder.Entity("PingBot.Contracts.Entities.CamEntity", b =>
                {
                    b.HasOne("PingBot.Contracts.Entities.ContractEntity", null)
                        .WithMany("Cams")
                        .HasForeignKey("ContractEntityId");
                });

            modelBuilder.Entity("PingBot.Contracts.Entities.ContractEntity", b =>
                {
                    b.Navigation("Cams");
                });
#pragma warning restore 612, 618
        }
    }
}
