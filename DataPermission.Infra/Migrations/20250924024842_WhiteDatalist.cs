using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataPermission.Infra.Migrations
{
    /// <inheritdoc />
    public partial class WhiteDatalist : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "T_Role_DataPermissions_BlackList");

            migrationBuilder.DropTable(
                name: "T_RowPermissions_BlackList");

            migrationBuilder.CreateTable(
                name: "T_Role_DataPermissions",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    RoleId = table.Column<long>(type: "bigint", nullable: false),
                    DataPermissionId = table.Column<long>(type: "bigint", nullable: false),
                    DataPermissionType = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T_Role_DataPermissions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "T_Row_DataPermissions",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    DataScopeType = table.Column<int>(type: "int", nullable: false),
                    ScopeField = table.Column<string>(type: "varchar(256)", unicode: false, maxLength: 256, nullable: true),
                    ScopeValue = table.Column<string>(type: "varchar(256)", unicode: false, maxLength: 256, nullable: true),
                    RowDataAllowOperateType = table.Column<int>(type: "int", nullable: false),
                    FullTableName = table.Column<string>(type: "varchar(512)", unicode: false, maxLength: 512, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(512)", maxLength: 512, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T_Row_DataPermissions", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "T_Role_DataPermissions");

            migrationBuilder.DropTable(
                name: "T_Row_DataPermissions");

            migrationBuilder.CreateTable(
                name: "T_Role_DataPermissions_BlackList",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    DataPermissionId = table.Column<long>(type: "bigint", nullable: false),
                    DataPermissionType = table.Column<int>(type: "int", nullable: false),
                    RoleId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T_Role_DataPermissions_BlackList", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "T_RowPermissions_BlackList",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    DataScopeType = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(512)", maxLength: 512, nullable: true),
                    FullTableName = table.Column<string>(type: "varchar(512)", unicode: false, maxLength: 512, nullable: false),
                    RowDataDenyOperateType = table.Column<int>(type: "int", nullable: false),
                    ScopeField = table.Column<string>(type: "varchar(256)", unicode: false, maxLength: 256, nullable: true),
                    ScopeValue = table.Column<string>(type: "varchar(256)", unicode: false, maxLength: 256, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T_RowPermissions_BlackList", x => x.Id);
                });
        }
    }
}
