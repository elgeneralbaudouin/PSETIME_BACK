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
    [Migration("20211004113626_Migration03_createrevendpermsmodule")]
    partial class Migration03_createrevendpermsmodule
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
                            CreatedAt = new DateTime(2021, 10, 4, 12, 36, 25, 718, DateTimeKind.Local).AddTicks(4768),
                            CreatedBy = "1",
                            Description = "CONFIGURATION GLOABLE 1",
                            EndDate = new DateTime(2021, 1, 1, 18, 0, 0, 0, DateTimeKind.Unspecified),
                            IsActive = true,
                            Name = "CONFIGURATION GLOABLE 1",
                            StartDate = new DateTime(2021, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified),
                            UpdatedAt = new DateTime(2021, 10, 4, 12, 36, 25, 719, DateTimeKind.Local).AddTicks(4457),
                            UpdatedBy = "1"
                        },
                        new
                        {
                            Id = 2,
                            Code = "GC2",
                            CreatedAt = new DateTime(2021, 10, 4, 12, 36, 25, 719, DateTimeKind.Local).AddTicks(5371),
                            CreatedBy = "1",
                            Description = "CONFIGURATION GLOABLE 2",
                            EndDate = new DateTime(2021, 1, 1, 18, 0, 0, 0, DateTimeKind.Unspecified),
                            IsActive = true,
                            Name = "CONFIGURATION GLOABLE 2",
                            StartDate = new DateTime(2021, 1, 1, 8, 0, 0, 0, DateTimeKind.Unspecified),
                            UpdatedAt = new DateTime(2021, 10, 4, 12, 36, 25, 719, DateTimeKind.Local).AddTicks(5381),
                            UpdatedBy = "1"
                        },
                        new
                        {
                            Id = 3,
                            Code = "GC3",
                            CreatedAt = new DateTime(2021, 10, 4, 12, 36, 25, 719, DateTimeKind.Local).AddTicks(5412),
                            CreatedBy = "1",
                            Description = "CONFIGURATION GLOABLE 3",
                            EndDate = new DateTime(2021, 1, 1, 18, 0, 0, 0, DateTimeKind.Unspecified),
                            IsActive = true,
                            Name = "CONFIGURATION GLOABLE 3",
                            StartDate = new DateTime(2021, 1, 1, 7, 30, 0, 0, DateTimeKind.Unspecified),
                            UpdatedAt = new DateTime(2021, 10, 4, 12, 36, 25, 719, DateTimeKind.Local).AddTicks(5413),
                            UpdatedBy = "1"
                        });
                });

            modelBuilder.Entity("PSETIME_BACK.DAL.Models.Entities.RevendPerms.PermissionUser", b =>
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

                    b.Property<bool>("IsActive")
                        .HasColumnType("boolean");

                    b.Property<string>("Name")
                        .HasColumnType("character varying(100)")
                        .HasMaxLength(100);

                    b.Property<int>("PermissionsStatusId")
                        .HasColumnName("perm_status_id")
                        .HasColumnType("integer");

                    b.Property<DateTime>("RequestDate")
                        .HasColumnName("date_demande")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Response")
                        .HasColumnName("reponse")
                        .HasColumnType("character varying(300)")
                        .HasMaxLength(300);

                    b.Property<DateTime>("ResponseDate")
                        .HasColumnName("date_reponse")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("UpdatedBy")
                        .HasColumnType("character varying(100)")
                        .HasMaxLength(100);

                    b.HasKey("Id");

                    b.HasIndex("PermissionsStatusId")
                        .IsUnique();

                    b.ToTable("adm_t_perm_user");
                });

            modelBuilder.Entity("PSETIME_BACK.DAL.Models.Entities.RevendPerms.PermissionsStatus", b =>
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

                    b.Property<bool>("IsActive")
                        .HasColumnType("boolean");

                    b.Property<string>("Name")
                        .HasColumnName("etat_permis")
                        .HasColumnType("character varying(100)")
                        .HasMaxLength(100);

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("UpdatedBy")
                        .HasColumnType("character varying(100)")
                        .HasMaxLength(100);

                    b.HasKey("Id");

                    b.ToTable("adm_t_permis_status");
                });

            modelBuilder.Entity("PSETIME_BACK.DAL.Models.Entities.RevendPerms.RevendicationStatus", b =>
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

                    b.Property<bool>("IsActive")
                        .HasColumnType("boolean");

                    b.Property<string>("Name")
                        .HasColumnName("etat_reven")
                        .HasColumnType("character varying(100)")
                        .HasMaxLength(100);

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("UpdatedBy")
                        .HasColumnType("character varying(100)")
                        .HasMaxLength(100);

                    b.HasKey("Id");

                    b.ToTable("adm_t_reven_atatut");
                });

            modelBuilder.Entity("PSETIME_BACK.DAL.Models.Entities.RevendPerms.RevendicationUser", b =>
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
                        .HasColumnName("objet")
                        .HasColumnType("character varying(100)")
                        .HasMaxLength(100);

                    b.Property<string>("Enclosed")
                        .HasColumnName("piece_jointe")
                        .HasColumnType("text");

                    b.Property<bool>("IsActive")
                        .HasColumnType("boolean");

                    b.Property<string>("Name")
                        .HasColumnType("character varying(100)")
                        .HasMaxLength(100);

                    b.Property<int>("RevendicationStatusId")
                        .HasColumnName("revenUser_id")
                        .HasColumnType("integer");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("UpdatedBy")
                        .HasColumnType("character varying(100)")
                        .HasMaxLength(100);

                    b.HasKey("Id");

                    b.HasIndex("RevendicationStatusId")
                        .IsUnique();

                    b.ToTable("adm_t_reven_user");
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

            modelBuilder.Entity("PSETIME_BACK.DAL.Models.Entities.RevendPerms.PermissionUser", b =>
                {
                    b.HasOne("PSETIME_BACK.DAL.Models.Entities.RevendPerms.PermissionsStatus", "PermissionsStatus")
                        .WithOne("PermissionUser")
                        .HasForeignKey("PSETIME_BACK.DAL.Models.Entities.RevendPerms.PermissionUser", "PermissionsStatusId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("PSETIME_BACK.DAL.Models.Entities.RevendPerms.RevendicationUser", b =>
                {
                    b.HasOne("PSETIME_BACK.DAL.Models.Entities.RevendPerms.RevendicationStatus", "RevendicationStatus")
                        .WithOne("RenvendicationUser")
                        .HasForeignKey("PSETIME_BACK.DAL.Models.Entities.RevendPerms.RevendicationUser", "RevendicationStatusId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
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