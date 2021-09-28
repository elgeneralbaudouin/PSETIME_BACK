using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PSETIME_BACK.Migrations
{
    public partial class Migration_seedconfigdata : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "config_t_global_config",
                columns: new[] { "Id", "Code", "CreatedAt", "CreatedBy", "Description", "date_fin", "IsActive", "Name", "date_debut", "UpdatedAt", "UpdatedBy" },
                values: new object[,]
                {
                    { 1, "GC1", new DateTime(2021, 9, 24, 16, 40, 46, 696, DateTimeKind.Local).AddTicks(2498), "1", "CONFIGURATION GLOABLE 1", new DateTime(2021, 1, 1, 18, 0, 0, 0, DateTimeKind.Unspecified), true, "CONFIGURATION GLOABLE 1", new DateTime(2021, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 9, 24, 16, 40, 46, 697, DateTimeKind.Local).AddTicks(1360), "1" },
                    { 2, "GC2", new DateTime(2021, 9, 24, 16, 40, 46, 697, DateTimeKind.Local).AddTicks(2409), "1", "CONFIGURATION GLOABLE 2", new DateTime(2021, 1, 1, 18, 0, 0, 0, DateTimeKind.Unspecified), true, "CONFIGURATION GLOABLE 2", new DateTime(2021, 1, 1, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 9, 24, 16, 40, 46, 697, DateTimeKind.Local).AddTicks(2418), "1" },
                    { 3, "GC3", new DateTime(2021, 9, 24, 16, 40, 46, 697, DateTimeKind.Local).AddTicks(2451), "1", "CONFIGURATION GLOABLE 3", new DateTime(2021, 1, 1, 18, 0, 0, 0, DateTimeKind.Unspecified), true, "CONFIGURATION GLOABLE 3", new DateTime(2021, 1, 1, 7, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 9, 24, 16, 40, 46, 697, DateTimeKind.Local).AddTicks(2453), "1" }
                });

            migrationBuilder.InsertData(
              table: "Import_t_user_Import",
              columns: new[] { "Id", "Code", "CreatedAt", "CreatedBy", "Description", "heure_de_depart", "IsActive", "Name", "heure_d_arrive", "UpdatedAt", "jour", "UpdatedBy" },
              values: new object[,]
              {
                    { 1, "GC1", new DateTime(2021, 9, 24, 16, 40, 46, 696, DateTimeKind.Local).AddTicks(2498), "1", "CONFIGURATION GLOABLE 1", new DateTime(2021, 1, 1, 18, 0, 0, 0, DateTimeKind.Unspecified), true, "CONFIGURATION GLOABLE 1", new DateTime(2021, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 9, 24, 16, 40, 46, 697, DateTimeKind.Local).AddTicks(1360), "1" },
                    { 2, "GC2", new DateTime(2021, 9, 24, 16, 40, 46, 697, DateTimeKind.Local).AddTicks(2409), "1", "CONFIGURATION GLOABLE 2", new DateTime(2021, 1, 1, 18, 0, 0, 0, DateTimeKind.Unspecified), true, "CONFIGURATION GLOABLE 2", new DateTime(2021, 1, 1, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 9, 24, 16, 40, 46, 697, DateTimeKind.Local).AddTicks(2418), "1" },
                    { 3, "GC3", new DateTime(2021, 9, 24, 16, 40, 46, 697, DateTimeKind.Local).AddTicks(2451), "1", "CONFIGURATION GLOABLE 3", new DateTime(2021, 1, 1, 18, 0, 0, 0, DateTimeKind.Unspecified), true, "CONFIGURATION GLOABLE 3", new DateTime(2021, 1, 1, 7, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 9, 24, 16, 40, 46, 697, DateTimeKind.Local).AddTicks(2453), new DateTime(2021, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), "1" }
              });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "config_t_global_config",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "config_t_global_config",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "config_t_global_config",
                keyColumn: "Id",
                keyValue: 3);


            migrationBuilder.DeleteData(
               table: "Import_t_user_Import",
               keyColumn: "Id",
               keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Import_t_user_Import",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Import_t_user_Import",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
