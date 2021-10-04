using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace PSETIME_BACK.Migrations
{
    public partial class Migration03_createrevendpermsmodule : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "adm_t_permis_status",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Description = table.Column<string>(maxLength: 100, nullable: true),
                    Code = table.Column<string>(maxLength: 100, nullable: true),
                    CreatedBy = table.Column<string>(maxLength: 100, nullable: true),
                    UpdatedBy = table.Column<string>(maxLength: 100, nullable: true),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    UpdatedAt = table.Column<DateTime>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false),
                    etat_permis = table.Column<string>(maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_adm_t_permis_status", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "adm_t_reven_atatut",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Description = table.Column<string>(maxLength: 100, nullable: true),
                    Code = table.Column<string>(maxLength: 100, nullable: true),
                    CreatedBy = table.Column<string>(maxLength: 100, nullable: true),
                    UpdatedBy = table.Column<string>(maxLength: 100, nullable: true),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    UpdatedAt = table.Column<DateTime>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false),
                    etat_reven = table.Column<string>(maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_adm_t_reven_atatut", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "adm_t_perm_user",
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
                    perm_status_id = table.Column<int>(nullable: false),
                    date_demande = table.Column<DateTime>(nullable: false),
                    date_reponse = table.Column<DateTime>(nullable: false),
                    reponse = table.Column<string>(maxLength: 300, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_adm_t_perm_user", x => x.Id);
                    table.ForeignKey(
                        name: "FK_adm_t_perm_user_adm_t_permis_status_perm_status_id",
                        column: x => x.perm_status_id,
                        principalTable: "adm_t_permis_status",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "adm_t_reven_user",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Code = table.Column<string>(maxLength: 100, nullable: true),
                    Name = table.Column<string>(maxLength: 100, nullable: true),
                    CreatedBy = table.Column<string>(maxLength: 100, nullable: true),
                    UpdatedBy = table.Column<string>(maxLength: 100, nullable: true),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    UpdatedAt = table.Column<DateTime>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false),
                    revenUser_id = table.Column<int>(nullable: false),
                    objet = table.Column<string>(maxLength: 100, nullable: true),
                    piece_jointe = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_adm_t_reven_user", x => x.Id);
                    table.ForeignKey(
                        name: "FK_adm_t_reven_user_adm_t_reven_atatut_revenUser_id",
                        column: x => x.revenUser_id,
                        principalTable: "adm_t_reven_atatut",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "config_t_global_config",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2021, 10, 4, 12, 36, 25, 718, DateTimeKind.Local).AddTicks(4768), new DateTime(2021, 10, 4, 12, 36, 25, 719, DateTimeKind.Local).AddTicks(4457) });

            migrationBuilder.UpdateData(
                table: "config_t_global_config",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2021, 10, 4, 12, 36, 25, 719, DateTimeKind.Local).AddTicks(5371), new DateTime(2021, 10, 4, 12, 36, 25, 719, DateTimeKind.Local).AddTicks(5381) });

            migrationBuilder.UpdateData(
                table: "config_t_global_config",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2021, 10, 4, 12, 36, 25, 719, DateTimeKind.Local).AddTicks(5412), new DateTime(2021, 10, 4, 12, 36, 25, 719, DateTimeKind.Local).AddTicks(5413) });

            migrationBuilder.CreateIndex(
                name: "IX_adm_t_perm_user_perm_status_id",
                table: "adm_t_perm_user",
                column: "perm_status_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_adm_t_reven_user_revenUser_id",
                table: "adm_t_reven_user",
                column: "revenUser_id",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "adm_t_perm_user");

            migrationBuilder.DropTable(
                name: "adm_t_reven_user");

            migrationBuilder.DropTable(
                name: "adm_t_permis_status");

            migrationBuilder.DropTable(
                name: "adm_t_reven_atatut");

            migrationBuilder.UpdateData(
                table: "config_t_global_config",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2021, 9, 24, 16, 40, 46, 696, DateTimeKind.Local).AddTicks(2498), new DateTime(2021, 9, 24, 16, 40, 46, 697, DateTimeKind.Local).AddTicks(1360) });

            migrationBuilder.UpdateData(
                table: "config_t_global_config",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2021, 9, 24, 16, 40, 46, 697, DateTimeKind.Local).AddTicks(2409), new DateTime(2021, 9, 24, 16, 40, 46, 697, DateTimeKind.Local).AddTicks(2418) });

            migrationBuilder.UpdateData(
                table: "config_t_global_config",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2021, 9, 24, 16, 40, 46, 697, DateTimeKind.Local).AddTicks(2451), new DateTime(2021, 9, 24, 16, 40, 46, 697, DateTimeKind.Local).AddTicks(2453) });
        }
    }
}
