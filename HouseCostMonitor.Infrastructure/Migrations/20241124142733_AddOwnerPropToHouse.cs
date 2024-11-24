using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HouseCostMonitor.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddOwnerPropToHouse : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Houses_AspNetUsers_OwnerId",
                table: "Houses");

            migrationBuilder.RenameColumn(
                name: "OwnerId",
                table: "Houses",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Houses_OwnerId",
                table: "Houses",
                newName: "IX_Houses_UserId");

            migrationBuilder.AddColumn<string>(
                name: "Owner",
                table: "Houses",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Houses_AspNetUsers_UserId",
                table: "Houses",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Houses_AspNetUsers_UserId",
                table: "Houses");

            migrationBuilder.DropColumn(
                name: "Owner",
                table: "Houses");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Houses",
                newName: "OwnerId");

            migrationBuilder.RenameIndex(
                name: "IX_Houses_UserId",
                table: "Houses",
                newName: "IX_Houses_OwnerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Houses_AspNetUsers_OwnerId",
                table: "Houses",
                column: "OwnerId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
