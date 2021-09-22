using Microsoft.EntityFrameworkCore.Migrations;

namespace PSETIME_BACK.Migrations
{
    public partial class Migration02_RenameTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserGroups_GlobalConfigs_config_id",
                table: "UserGroups");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserGroups",
                table: "UserGroups");

            migrationBuilder.DropPrimaryKey(
                name: "PK_GlobalConfigs",
                table: "GlobalConfigs");

            migrationBuilder.RenameTable(
                name: "UserGroups",
                newName: "adm_t_group_user");

            migrationBuilder.RenameTable(
                name: "GlobalConfigs",
                newName: "config_t_global_config");

            migrationBuilder.RenameIndex(
                name: "IX_UserGroups_config_id",
                table: "adm_t_group_user",
                newName: "IX_adm_t_group_user_config_id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_adm_t_group_user",
                table: "adm_t_group_user",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_config_t_global_config",
                table: "config_t_global_config",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_adm_t_group_user_config_t_global_config_config_id",
                table: "adm_t_group_user",
                column: "config_id",
                principalTable: "config_t_global_config",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_adm_t_group_user_config_t_global_config_config_id",
                table: "adm_t_group_user");

            migrationBuilder.DropPrimaryKey(
                name: "PK_config_t_global_config",
                table: "config_t_global_config");

            migrationBuilder.DropPrimaryKey(
                name: "PK_adm_t_group_user",
                table: "adm_t_group_user");

            migrationBuilder.RenameTable(
                name: "config_t_global_config",
                newName: "GlobalConfigs");

            migrationBuilder.RenameTable(
                name: "adm_t_group_user",
                newName: "UserGroups");

            migrationBuilder.RenameIndex(
                name: "IX_adm_t_group_user_config_id",
                table: "UserGroups",
                newName: "IX_UserGroups_config_id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_GlobalConfigs",
                table: "GlobalConfigs",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserGroups",
                table: "UserGroups",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UserGroups_GlobalConfigs_config_id",
                table: "UserGroups",
                column: "config_id",
                principalTable: "GlobalConfigs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
