using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using System;

namespace PSETIME_BACK.Migrations
{
    public partial class Migration01_InitDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "GlobalConfigs",
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
                    date_debut = table.Column<DateTime>(nullable: false),
                    date_fin = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GlobalConfigs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserGroups",
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
                    config_id = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserGroups", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserGroups_GlobalConfigs_config_id",
                        column: x => x.config_id,
                        principalTable: "GlobalConfigs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserGroups_config_id",
                table: "UserGroups",
                column: "config_id",
                unique: true);

            ///les lignes du haut devra etre ajouter apres la creation des utilisateurs

            ///Migration pour la table horaire 

            migrationBuilder.CreateTable(
             name: "ImportTimeUser",
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
                 jour = table.Column<DateTime>(nullable: false),
                 heure_d_arrive = table.Column<DateTime>(nullable: false),
                 heure_de_depart = table.Column<DateTime>(nullable: false)
             },
             constraints: table =>
             {
                 table.PrimaryKey("PK_ImportTimeUser", x => x.Id);
             });




        }



        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserGroups");

            migrationBuilder.DropTable(
                name: "GlobalConfigs");

            migrationBuilder.DropTable(
                name: "ImportTimeUser");
        }
    }
}
