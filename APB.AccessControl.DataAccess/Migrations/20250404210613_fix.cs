using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace APB.AccessControl.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class fix : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_AccessLogs_CardHash",
                table: "AccessLogs");

            migrationBuilder.CreateIndex(
                name: "IX_AccessLogs_CardHash",
                table: "AccessLogs",
                column: "CardHash");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_AccessLogs_CardHash",
                table: "AccessLogs");

            migrationBuilder.CreateIndex(
                name: "IX_AccessLogs_CardHash",
                table: "AccessLogs",
                column: "CardHash",
                unique: true);
        }
    }
}
