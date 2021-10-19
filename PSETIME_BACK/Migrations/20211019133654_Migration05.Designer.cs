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
    [Migration("20211019133654_Migration05")]
    partial class Migration05
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .HasAnnotation("ProductVersion", "3.1.19")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("character varying(256)")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasColumnType("character varying(256)")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("text");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("text");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("text");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("text");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("text");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("text");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("text");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("text");

                    b.Property<string>("RoleId")
                        .HasColumnType("text");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("text");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<string>("Value")
                        .HasColumnType("text");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

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
                            CreatedAt = new DateTime(2021, 10, 19, 14, 36, 54, 266, DateTimeKind.Local).AddTicks(1448),
                            CreatedBy = "1",
                            Description = "CONFIGURATION GLOABLE 1",
                            EndDate = new DateTime(2021, 1, 1, 18, 0, 0, 0, DateTimeKind.Unspecified),
                            IsActive = true,
                            Name = "CONFIGURATION GLOABLE 1",
                            StartDate = new DateTime(2021, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified),
                            UpdatedAt = new DateTime(2021, 10, 19, 14, 36, 54, 267, DateTimeKind.Local).AddTicks(2477),
                            UpdatedBy = "1"
                        },
                        new
                        {
                            Id = 2,
                            Code = "GC2",
                            CreatedAt = new DateTime(2021, 10, 19, 14, 36, 54, 267, DateTimeKind.Local).AddTicks(3935),
                            CreatedBy = "1",
                            Description = "CONFIGURATION GLOABLE 2",
                            EndDate = new DateTime(2021, 1, 1, 18, 0, 0, 0, DateTimeKind.Unspecified),
                            IsActive = true,
                            Name = "CONFIGURATION GLOABLE 2",
                            StartDate = new DateTime(2021, 1, 1, 8, 0, 0, 0, DateTimeKind.Unspecified),
                            UpdatedAt = new DateTime(2021, 10, 19, 14, 36, 54, 267, DateTimeKind.Local).AddTicks(3950),
                            UpdatedBy = "1"
                        },
                        new
                        {
                            Id = 3,
                            Code = "GC3",
                            CreatedAt = new DateTime(2021, 10, 19, 14, 36, 54, 267, DateTimeKind.Local).AddTicks(3994),
                            CreatedBy = "1",
                            Description = "CONFIGURATION GLOABLE 3",
                            EndDate = new DateTime(2021, 1, 1, 18, 0, 0, 0, DateTimeKind.Unspecified),
                            IsActive = true,
                            Name = "CONFIGURATION GLOABLE 3",
                            StartDate = new DateTime(2021, 1, 1, 7, 30, 0, 0, DateTimeKind.Unspecified),
                            UpdatedAt = new DateTime(2021, 10, 19, 14, 36, 54, 267, DateTimeKind.Local).AddTicks(3996),
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

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Code = "PENDING",
                            CreatedAt = new DateTime(2021, 10, 19, 14, 36, 54, 268, DateTimeKind.Local).AddTicks(9843),
                            CreatedBy = "1",
                            Description = "PERMISSION ON PENDING FOR TRAITEMENT",
                            IsActive = true,
                            Name = "PENDING",
                            UpdatedAt = new DateTime(2021, 10, 19, 14, 36, 54, 268, DateTimeKind.Local).AddTicks(9861),
                            UpdatedBy = "1"
                        },
                        new
                        {
                            Id = 2,
                            Code = "ACCEPTED",
                            CreatedAt = new DateTime(2021, 10, 19, 14, 36, 54, 268, DateTimeKind.Local).AddTicks(9889),
                            CreatedBy = "1",
                            Description = "PERMISSION ACCEPTED",
                            IsActive = true,
                            Name = "ACCEPTED",
                            UpdatedAt = new DateTime(2021, 10, 19, 14, 36, 54, 268, DateTimeKind.Local).AddTicks(9891),
                            UpdatedBy = "1"
                        },
                        new
                        {
                            Id = 3,
                            Code = "REJECTED",
                            CreatedAt = new DateTime(2021, 10, 19, 14, 36, 54, 268, DateTimeKind.Local).AddTicks(9894),
                            CreatedBy = "1",
                            Description = "PERMISSION REJECTED",
                            IsActive = true,
                            Name = "REJECTED",
                            UpdatedAt = new DateTime(2021, 10, 19, 14, 36, 54, 268, DateTimeKind.Local).AddTicks(9895),
                            UpdatedBy = "1"
                        });
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

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Code = "PENDING",
                            CreatedAt = new DateTime(2021, 10, 19, 14, 36, 54, 269, DateTimeKind.Local).AddTicks(1054),
                            CreatedBy = "1",
                            Description = "REVENDICATION ON PENDING FOR TRAITEMENT",
                            IsActive = true,
                            Name = "PENDING",
                            UpdatedAt = new DateTime(2021, 10, 19, 14, 36, 54, 269, DateTimeKind.Local).AddTicks(1062),
                            UpdatedBy = "1"
                        },
                        new
                        {
                            Id = 2,
                            Code = "ACCEPTED",
                            CreatedAt = new DateTime(2021, 10, 19, 14, 36, 54, 269, DateTimeKind.Local).AddTicks(1099),
                            CreatedBy = "1",
                            Description = "REVENDICATION ACCEPTED",
                            IsActive = true,
                            Name = "ACCEPTED",
                            UpdatedAt = new DateTime(2021, 10, 19, 14, 36, 54, 269, DateTimeKind.Local).AddTicks(1100),
                            UpdatedBy = "1"
                        },
                        new
                        {
                            Id = 3,
                            Code = "REJECTED",
                            CreatedAt = new DateTime(2021, 10, 19, 14, 36, 54, 269, DateTimeKind.Local).AddTicks(1104),
                            CreatedBy = "1",
                            Description = "REVENDICATION REJECTED",
                            IsActive = true,
                            Name = "REJECTED",
                            UpdatedAt = new DateTime(2021, 10, 19, 14, 36, 54, 269, DateTimeKind.Local).AddTicks(1106),
                            UpdatedBy = "1"
                        });
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

            modelBuilder.Entity("PSETIME_BACK.DAL.Models.Entities.UserManager.Claims", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("ClaimsType")
                        .HasColumnType("character varying(100)")
                        .HasMaxLength(100);

                    b.Property<string>("ClaimsValue")
                        .HasColumnType("character varying(100)")
                        .HasMaxLength(100);

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

                    b.Property<int?>("ParentId")
                        .HasColumnType("integer");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("UpdatedBy")
                        .HasColumnType("character varying(100)")
                        .HasMaxLength(100);

                    b.HasKey("Id");

                    b.ToTable("Claimss");
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

            modelBuilder.Entity("PSETIME_BACK.DAL.Models.Entities.UserManager.UserSession", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("ClientId")
                        .IsRequired()
                        .HasColumnType("character varying(50)")
                        .HasMaxLength(50);

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

                    b.Property<DateTime>("ExpireDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<bool>("IsActive")
                        .HasColumnType("boolean");

                    b.Property<DateTime>("IssuedDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Name")
                        .HasColumnType("character varying(100)")
                        .HasMaxLength(100);

                    b.Property<string>("Token")
                        .IsRequired()
                        .HasColumnType("character varying(10000)")
                        .HasMaxLength(10000);

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("UpdatedBy")
                        .HasColumnType("character varying(100)")
                        .HasMaxLength(100);

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("character varying(50)")
                        .HasMaxLength(50);

                    b.Property<string>("UserName")
                        .HasColumnType("character varying(100)")
                        .HasMaxLength(100);

                    b.HasKey("Id");

                    b.ToTable("UserSessions");
                });

            modelBuilder.Entity("PSETIME_BACK.DAL.Models.Entities.UserManager.Users", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("integer");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("text");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("character varying(100)")
                        .HasMaxLength(100);

                    b.Property<string>("Email")
                        .HasColumnType("character varying(256)")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("boolean");

                    b.Property<bool>("IsActive")
                        .HasColumnType("boolean");

                    b.Property<string>("LastName")
                        .HasColumnType("character varying(100)")
                        .HasMaxLength(100);

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("boolean");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Name")
                        .HasColumnType("character varying(100)")
                        .HasMaxLength(100);

                    b.Property<string>("NormalizedEmail")
                        .HasColumnType("character varying(256)")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasColumnType("character varying(256)")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash")
                        .HasColumnType("text");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("text");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("boolean");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("text");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("boolean");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("UpdatedBy")
                        .HasColumnType("character varying(100)")
                        .HasMaxLength(100);

                    b.Property<string>("UserName")
                        .HasColumnType("character varying(256)")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("PSETIME_BACK.DAL.Models.Entities.UserManager.Users", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("PSETIME_BACK.DAL.Models.Entities.UserManager.Users", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PSETIME_BACK.DAL.Models.Entities.UserManager.Users", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("PSETIME_BACK.DAL.Models.Entities.UserManager.Users", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
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
