using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace APB.AccessControl.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class ForeignKeyFix : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AccessTriggerLogs_AccessLogs_AccessLogId1",
                table: "AccessTriggerLogs");

            migrationBuilder.DropIndex(
                name: "IX_AccessTriggerLogs_AccessLogId1",
                table: "AccessTriggerLogs");

            migrationBuilder.DropColumn(
                name: "AccessLogId1",
                table: "AccessTriggerLogs");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "AccessLogId1",
                table: "AccessTriggerLogs",
                type: "uuid",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AccessTriggerLogs_AccessLogId1",
                table: "AccessTriggerLogs",
                column: "AccessLogId1");

            migrationBuilder.AddForeignKey(
                name: "FK_AccessTriggerLogs_AccessLogs_AccessLogId1",
                table: "AccessTriggerLogs",
                column: "AccessLogId1",
                principalTable: "AccessLogs",
                principalColumn: "Id");
        }
    }
}
