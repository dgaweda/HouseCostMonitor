using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HouseCostMonitor.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddDurationInsteadEstimatedTime : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EstimatedTime",
                table: "Jobs");

            migrationBuilder.AddColumn<long>(
                name: "Duration",
                table: "Jobs",
                type: "bigint",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Duration",
                table: "Jobs");

            migrationBuilder.AddColumn<TimeSpan>(
                name: "EstimatedTime",
                table: "Jobs",
                type: "time",
                nullable: false,
                defaultValue: new TimeSpan(0, 0, 0, 0, 0));
        }
    }
}
