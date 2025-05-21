using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace APB.AccessControl.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class Heartbeat : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Triggers",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "LastHeartbeatAt",
                table: "AccessPoints",
                type: "timestamp with time zone",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "Triggers");

            migrationBuilder.DropColumn(
                name: "LastHeartbeatAt",
                table: "AccessPoints");
        }
    }
}
