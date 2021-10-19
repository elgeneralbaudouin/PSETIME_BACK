using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace PSETIME_BACK.Migrations
{
    public partial class Migration04_insert_datain_statustable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "adm_t_permis_status",
                columns: new[] { "Id", "Code", "CreatedAt", "CreatedBy", "Description", "IsActive", "etat_permis", "UpdatedAt", "UpdatedBy" },
                values: new object[,]
                {
                    { 1, "PENDING", new DateTime(2021, 10, 6, 13, 44, 30, 534, DateTimeKind.Local).AddTicks(4358), "1", "PERMISSION ON PENDING FOR TRAITEMENT", true, "PENDING", new DateTime(2021, 10, 6, 13, 44, 30, 534, DateTimeKind.Local).AddTicks(4366), "1" },
                    { 2, "ACCEPTED", new DateTime(2021, 10, 6, 13, 44, 30, 534, DateTimeKind.Local).AddTicks(4386), "1", "PERMISSION ACCEPTED", true, "ACCEPTED", new DateTime(2021, 10, 6, 13, 44, 30, 534, DateTimeKind.Local).AddTicks(4387), "1" },
                    { 3, "REJECTED", new DateTime(2021, 10, 6, 13, 44, 30, 534, DateTimeKind.Local).AddTicks(4390), "1", "PERMISSION REJECTED", true, "REJECTED", new DateTime(2021, 10, 6, 13, 44, 30, 534, DateTimeKind.Local).AddTicks(4391), "1" }
                });

            migrationBuilder.InsertData(
                table: "adm_t_reven_atatut",
                columns: new[] { "Id", "Code", "CreatedAt", "CreatedBy", "Description", "IsActive", "etat_reven", "UpdatedAt", "UpdatedBy" },
                values: new object[,]
                {
                    { 1, "PENDING", new DateTime(2021, 10, 6, 13, 44, 30, 534, DateTimeKind.Local).AddTicks(5145), "1", "REVENDICATION ON PENDING FOR TRAITEMENT", true, "PENDING", new DateTime(2021, 10, 6, 13, 44, 30, 534, DateTimeKind.Local).AddTicks(5150), "1" },
                    { 2, "ACCEPTED", new DateTime(2021, 10, 6, 13, 44, 30, 534, DateTimeKind.Local).AddTicks(5176), "1", "REVENDICATION ACCEPTED", true, "ACCEPTED", new DateTime(2021, 10, 6, 13, 44, 30, 534, DateTimeKind.Local).AddTicks(5177), "1" },
                    { 3, "REJECTED", new DateTime(2021, 10, 6, 13, 44, 30, 534, DateTimeKind.Local).AddTicks(5179), "1", "REVENDICATION REJECTED", true, "REJECTED", new DateTime(2021, 10, 6, 13, 44, 30, 534, DateTimeKind.Local).AddTicks(5180), "1" }
                });

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "adm_t_permis_status",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "adm_t_permis_status",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "adm_t_permis_status",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "adm_t_reven_atatut",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "adm_t_reven_atatut",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "adm_t_reven_atatut",
                keyColumn: "Id",
                keyValue: 3);

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
        }
    }
}
