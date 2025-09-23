using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataPermission.Infra.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "T_Column_Permissions",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    ColumnName = table.Column<string>(type: "varchar(256)", unicode: false, maxLength: 256, nullable: false),
                    FullTableName = table.Column<string>(type: "varchar(512)", unicode: false, maxLength: 512, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T_Column_Permissions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "T_Role_Data_Permissions",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    RoleId = table.Column<long>(type: "bigint", nullable: false),
                    DataPermissionId = table.Column<long>(type: "bigint", nullable: false),
                    DataPermissionType = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T_Role_Data_Permissions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "T_Row_Permissions",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    DataScopeType = table.Column<int>(type: "int", nullable: false),
                    ScopeField = table.Column<string>(type: "varchar(256)", unicode: false, maxLength: 256, nullable: true),
                    ScopeValue = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FullTableName = table.Column<string>(type: "varchar(512)", unicode: false, maxLength: 512, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T_Row_Permissions", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "T_Column_Permissions");

            migrationBuilder.DropTable(
                name: "T_Role_Data_Permissions");

            migrationBuilder.DropTable(
                name: "T_Row_Permissions");
        }
    }
}
