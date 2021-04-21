using Microsoft.EntityFrameworkCore.Migrations;

namespace Rollers.Data.Migrations
{
    public partial class UserIdLocationNull : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RollerSkateMapLocations_Users_UserId",
                table: "RollerSkateMapLocations");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "RollerSkateMapLocations",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_RollerSkateMapLocations_Users_UserId",
                table: "RollerSkateMapLocations",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RollerSkateMapLocations_Users_UserId",
                table: "RollerSkateMapLocations");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "RollerSkateMapLocations",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_RollerSkateMapLocations_Users_UserId",
                table: "RollerSkateMapLocations",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
