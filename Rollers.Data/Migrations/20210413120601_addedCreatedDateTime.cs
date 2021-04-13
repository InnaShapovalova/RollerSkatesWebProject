using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Rollers.Data.Migrations
{
    public partial class addedCreatedDateTime : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "RollerSkateMapLocations",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "LocationCreatedDateTime",
                table: "RollerSkateMapLocations",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "CommentCreatedDateTime",
                table: "Comments",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "RollerSkateMapLocations");

            migrationBuilder.DropColumn(
                name: "LocationCreatedDateTime",
                table: "RollerSkateMapLocations");

            migrationBuilder.DropColumn(
                name: "CommentCreatedDateTime",
                table: "Comments");
        }
    }
}
