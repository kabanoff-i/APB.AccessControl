using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace APB.AccessControl.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class AddedMaskPan : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "MaskPan",
                table: "Cards",
                type: "text",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MaskPan",
                table: "Cards");
        }
    }
}
