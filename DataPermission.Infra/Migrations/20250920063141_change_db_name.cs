using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataPermission.Infra.Migrations
{
    /// <inheritdoc />
    public partial class change_db_name : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_T_Row_Permissions",
                table: "T_Row_Permissions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_T_Column_Permissions",
                table: "T_Column_Permissions");

            migrationBuilder.RenameTable(
                name: "T_Row_Permissions",
                newName: "T_Row_Data_Permissions");

            migrationBuilder.RenameTable(
                name: "T_Column_Permissions",
                newName: "T_Column_Data_Permissions");

            migrationBuilder.AddPrimaryKey(
                name: "PK_T_Row_Data_Permissions",
                table: "T_Row_Data_Permissions",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_T_Column_Data_Permissions",
                table: "T_Column_Data_Permissions",
                column: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_T_Row_Data_Permissions",
                table: "T_Row_Data_Permissions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_T_Column_Data_Permissions",
                table: "T_Column_Data_Permissions");

            migrationBuilder.RenameTable(
                name: "T_Row_Data_Permissions",
                newName: "T_Row_Permissions");

            migrationBuilder.RenameTable(
                name: "T_Column_Data_Permissions",
                newName: "T_Column_Permissions");

            migrationBuilder.AddPrimaryKey(
                name: "PK_T_Row_Permissions",
                table: "T_Row_Permissions",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_T_Column_Permissions",
                table: "T_Column_Permissions",
                column: "Id");
        }
    }
}
