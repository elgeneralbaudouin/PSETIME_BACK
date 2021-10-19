using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace PSETIME_BACK.Migrations
{
    public partial class Migration05 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    UserName = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(maxLength: 256, nullable: true),
                    Email = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    PasswordHash = table.Column<string>(nullable: true),
                    SecurityStamp = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false),
                    CreatedBy = table.Column<string>(maxLength: 100, nullable: true),
                    Name = table.Column<string>(maxLength: 100, nullable: true),
                    LastName = table.Column<string>(maxLength: 100, nullable: true),
                    UpdatedBy = table.Column<string>(maxLength: 100, nullable: true),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    UpdatedAt = table.Column<DateTime>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Claimss",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Description = table.Column<string>(maxLength: 100, nullable: true),
                    Code = table.Column<string>(maxLength: 100, nullable: true),
                    Name = table.Column<string>(maxLength: 100, nullable: true),
                    CreatedBy = table.Column<string>(maxLength: 100, nullable: true),
                    UpdatedBy = table.Column<string>(maxLength: 100, nullable: true),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    UpdatedAt = table.Column<DateTime>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false),
                    ClaimsValue = table.Column<string>(maxLength: 100, nullable: true),
                    ClaimsType = table.Column<string>(maxLength: 100, nullable: true),
                    ParentId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Claimss", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserSessions",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Description = table.Column<string>(maxLength: 100, nullable: true),
                    Code = table.Column<string>(maxLength: 100, nullable: true),
                    Name = table.Column<string>(maxLength: 100, nullable: true),
                    CreatedBy = table.Column<string>(maxLength: 100, nullable: true),
                    UpdatedBy = table.Column<string>(maxLength: 100, nullable: true),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    UpdatedAt = table.Column<DateTime>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false),
                    UserId = table.Column<string>(maxLength: 50, nullable: false),
                    UserName = table.Column<string>(maxLength: 100, nullable: true),
                    ClientId = table.Column<string>(maxLength: 50, nullable: false),
                    IssuedDate = table.Column<DateTime>(nullable: false),
                    ExpireDate = table.Column<DateTime>(nullable: false),
                    Token = table.Column<string>(maxLength: 10000, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserSessions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    RoleId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(nullable: false),
                    ProviderKey = table.Column<string>(nullable: false),
                    ProviderDisplayName = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    RoleId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    LoginProvider = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "adm_t_permis_status",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2021, 10, 19, 14, 36, 54, 268, DateTimeKind.Local).AddTicks(9843), new DateTime(2021, 10, 19, 14, 36, 54, 268, DateTimeKind.Local).AddTicks(9861) });

            migrationBuilder.UpdateData(
                table: "adm_t_permis_status",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2021, 10, 19, 14, 36, 54, 268, DateTimeKind.Local).AddTicks(9889), new DateTime(2021, 10, 19, 14, 36, 54, 268, DateTimeKind.Local).AddTicks(9891) });

            migrationBuilder.UpdateData(
                table: "adm_t_permis_status",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2021, 10, 19, 14, 36, 54, 268, DateTimeKind.Local).AddTicks(9894), new DateTime(2021, 10, 19, 14, 36, 54, 268, DateTimeKind.Local).AddTicks(9895) });

            migrationBuilder.UpdateData(
                table: "adm_t_reven_atatut",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2021, 10, 19, 14, 36, 54, 269, DateTimeKind.Local).AddTicks(1054), new DateTime(2021, 10, 19, 14, 36, 54, 269, DateTimeKind.Local).AddTicks(1062) });

            migrationBuilder.UpdateData(
                table: "adm_t_reven_atatut",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2021, 10, 19, 14, 36, 54, 269, DateTimeKind.Local).AddTicks(1099), new DateTime(2021, 10, 19, 14, 36, 54, 269, DateTimeKind.Local).AddTicks(1100) });

            migrationBuilder.UpdateData(
                table: "adm_t_reven_atatut",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2021, 10, 19, 14, 36, 54, 269, DateTimeKind.Local).AddTicks(1104), new DateTime(2021, 10, 19, 14, 36, 54, 269, DateTimeKind.Local).AddTicks(1106) });

            migrationBuilder.UpdateData(
                table: "config_t_global_config",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2021, 10, 19, 14, 36, 54, 266, DateTimeKind.Local).AddTicks(1448), new DateTime(2021, 10, 19, 14, 36, 54, 267, DateTimeKind.Local).AddTicks(2477) });

            migrationBuilder.UpdateData(
                table: "config_t_global_config",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2021, 10, 19, 14, 36, 54, 267, DateTimeKind.Local).AddTicks(3935), new DateTime(2021, 10, 19, 14, 36, 54, 267, DateTimeKind.Local).AddTicks(3950) });

            migrationBuilder.UpdateData(
                table: "config_t_global_config",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2021, 10, 19, 14, 36, 54, 267, DateTimeKind.Local).AddTicks(3994), new DateTime(2021, 10, 19, 14, 36, 54, 267, DateTimeKind.Local).AddTicks(3996) });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Claimss");

            migrationBuilder.DropTable(
                name: "UserSessions");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.UpdateData(
                table: "adm_t_permis_status",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2021, 10, 6, 13, 44, 30, 534, DateTimeKind.Local).AddTicks(4358), new DateTime(2021, 10, 6, 13, 44, 30, 534, DateTimeKind.Local).AddTicks(4366) });

            migrationBuilder.UpdateData(
                table: "adm_t_permis_status",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2021, 10, 6, 13, 44, 30, 534, DateTimeKind.Local).AddTicks(4386), new DateTime(2021, 10, 6, 13, 44, 30, 534, DateTimeKind.Local).AddTicks(4387) });

            migrationBuilder.UpdateData(
                table: "adm_t_permis_status",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2021, 10, 6, 13, 44, 30, 534, DateTimeKind.Local).AddTicks(4390), new DateTime(2021, 10, 6, 13, 44, 30, 534, DateTimeKind.Local).AddTicks(4391) });

            migrationBuilder.UpdateData(
                table: "adm_t_reven_atatut",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2021, 10, 6, 13, 44, 30, 534, DateTimeKind.Local).AddTicks(5145), new DateTime(2021, 10, 6, 13, 44, 30, 534, DateTimeKind.Local).AddTicks(5150) });

            migrationBuilder.UpdateData(
                table: "adm_t_reven_atatut",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2021, 10, 6, 13, 44, 30, 534, DateTimeKind.Local).AddTicks(5176), new DateTime(2021, 10, 6, 13, 44, 30, 534, DateTimeKind.Local).AddTicks(5177) });

            migrationBuilder.UpdateData(
                table: "adm_t_reven_atatut",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2021, 10, 6, 13, 44, 30, 534, DateTimeKind.Local).AddTicks(5179), new DateTime(2021, 10, 6, 13, 44, 30, 534, DateTimeKind.Local).AddTicks(5180) });

            migrationBuilder.UpdateData(
                table: "config_t_global_config",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2021, 10, 6, 13, 44, 30, 532, DateTimeKind.Local).AddTicks(5270), new DateTime(2021, 10, 6, 13, 44, 30, 533, DateTimeKind.Local).AddTicks(3093) });

            migrationBuilder.UpdateData(
                table: "config_t_global_config",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2021, 10, 6, 13, 44, 30, 533, DateTimeKind.Local).AddTicks(4013), new DateTime(2021, 10, 6, 13, 44, 30, 533, DateTimeKind.Local).AddTicks(4023) });

            migrationBuilder.UpdateData(
                table: "config_t_global_config",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2021, 10, 6, 13, 44, 30, 533, DateTimeKind.Local).AddTicks(4055), new DateTime(2021, 10, 6, 13, 44, 30, 533, DateTimeKind.Local).AddTicks(4057) });
        }
    }
}
