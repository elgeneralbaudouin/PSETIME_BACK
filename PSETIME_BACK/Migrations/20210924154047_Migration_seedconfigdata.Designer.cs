﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using PSETIME_BACK.DAL.Models;

namespace PSETIME_BACK.Migrations
{
    [DbContext(typeof(ApplicationDBContext))]
    [Migration("20210924154047_Migration_seedconfigdata")]
    partial class Migration_seedconfigdata
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .HasAnnotation("ProductVersion", "3.1.19")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("PSETIME_BACK.DAL.Models.Entities.GlobalConfigs.GlobalConfig", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Code")
                        .HasColumnType("character varying(100)")
                        .HasMaxLength(100);

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("character varying(100)")
                        .HasMaxLength(100);

                    b.Property<string>("Description")
                        .HasColumnType("character varying(100)")
                        .HasMaxLength(100);

                    b.Property<DateTime>("EndDate")
                        .HasColumnName("date_fin")
                        .HasColumnType("timestamp without time zone");

                    b.Property<bool>("IsActive")
                        .HasColumnType("boolean");

                    b.Property<string>("Name")
                        .HasColumnType("character varying(100)")
                        .HasMaxLength(100);

                    b.Property<DateTime>("StartDate")
                        .HasColumnName("date_debut")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("UpdatedBy")
                        .HasColumnType("character varying(100)")
                        .HasMaxLength(100);

                    b.HasKey("Id");

                    b.ToTable("config_t_global_config");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Code = "GC1",
                            CreatedAt = new DateTime(2021, 9, 24, 16, 40, 46, 696, DateTimeKind.Local).AddTicks(2498),
                            CreatedBy = "1",
                            Description = "CONFIGURATION GLOABLE 1",
                            EndDate = new DateTime(2021, 1, 1, 18, 0, 0, 0, DateTimeKind.Unspecified),
                            IsActive = true,
                            Name = "CONFIGURATION GLOABLE 1",
                            StartDate = new DateTime(2021, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified),
                            UpdatedAt = new DateTime(2021, 9, 24, 16, 40, 46, 697, DateTimeKind.Local).AddTicks(1360),
                            UpdatedBy = "1"
                        },
                        new
                        {
                            Id = 2,
                            Code = "GC2",
                            CreatedAt = new DateTime(2021, 9, 24, 16, 40, 46, 697, DateTimeKind.Local).AddTicks(2409),
                            CreatedBy = "1",
                            Description = "CONFIGURATION GLOABLE 2",
                            EndDate = new DateTime(2021, 1, 1, 18, 0, 0, 0, DateTimeKind.Unspecified),
                            IsActive = true,
                            Name = "CONFIGURATION GLOABLE 2",
                            StartDate = new DateTime(2021, 1, 1, 8, 0, 0, 0, DateTimeKind.Unspecified),
                            UpdatedAt = new DateTime(2021, 9, 24, 16, 40, 46, 697, DateTimeKind.Local).AddTicks(2418),
                            UpdatedBy = "1"
                        },
                        new
                        {
                            Id = 3,
                            Code = "GC3",
                            CreatedAt = new DateTime(2021, 9, 24, 16, 40, 46, 697, DateTimeKind.Local).AddTicks(2451),
                            CreatedBy = "1",
                            Description = "CONFIGURATION GLOABLE 3",
                            EndDate = new DateTime(2021, 1, 1, 18, 0, 0, 0, DateTimeKind.Unspecified),
                            IsActive = true,
                            Name = "CONFIGURATION GLOABLE 3",
                            StartDate = new DateTime(2021, 1, 1, 7, 30, 0, 0, DateTimeKind.Unspecified),
                            UpdatedAt = new DateTime(2021, 9, 24, 16, 40, 46, 697, DateTimeKind.Local).AddTicks(2453),
                            UpdatedBy = "1"
                        });
                });

            modelBuilder.Entity("PSETIME_BACK.DAL.Models.Entities.UserManager.UserGroups", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Code")
                        .HasColumnType("character varying(100)")
                        .HasMaxLength(100);

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("character varying(100)")
                        .HasMaxLength(100);

                    b.Property<string>("Description")
                        .HasColumnType("character varying(100)")
                        .HasMaxLength(100);

                    b.Property<int>("GlobalConfigId")
                        .HasColumnName("config_id")
                        .HasColumnType("integer");

                    b.Property<bool>("IsActive")
                        .HasColumnType("boolean");

                    b.Property<string>("Name")
                        .HasColumnType("character varying(100)")
                        .HasMaxLength(100);

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("UpdatedBy")
                        .HasColumnType("character varying(100)")
                        .HasMaxLength(100);

                    b.HasKey("Id");

                    b.HasIndex("GlobalConfigId")
                        .IsUnique();

                    b.ToTable("adm_t_group_user");
                });

            modelBuilder.Entity("PSETIME_BACK.DAL.Models.Entities.UserManager.UserGroups", b =>
                {
                    b.HasOne("PSETIME_BACK.DAL.Models.Entities.GlobalConfigs.GlobalConfig", "GlobalConfig")
                        .WithOne("UserGroups")
                        .HasForeignKey("PSETIME_BACK.DAL.Models.Entities.UserManager.UserGroups", "GlobalConfigId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}