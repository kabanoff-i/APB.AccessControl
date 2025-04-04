using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace APB.AccessControl.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class init2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AccessPoints_AccessPointType_AccessPointTypeId",
                table: "AccessPoints");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AccessPointType",
                table: "AccessPointType");

            migrationBuilder.RenameTable(
                name: "AccessPointType",
                newName: "AccessPointTypes");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AccessPointTypes",
                table: "AccessPointTypes",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AccessPoints_AccessPointTypes_AccessPointTypeId",
                table: "AccessPoints",
                column: "AccessPointTypeId",
                principalTable: "AccessPointTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AccessPoints_AccessPointTypes_AccessPointTypeId",
                table: "AccessPoints");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AccessPointTypes",
                table: "AccessPointTypes");

            migrationBuilder.RenameTable(
                name: "AccessPointTypes",
                newName: "AccessPointType");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AccessPointType",
                table: "AccessPointType",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AccessPoints_AccessPointType_AccessPointTypeId",
                table: "AccessPoints",
                column: "AccessPointTypeId",
                principalTable: "AccessPointType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
