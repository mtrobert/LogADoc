using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LogADoc.Migrations
{
    public partial class AddedMoreItemProperties : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CurrentHolder",
                table: "Items",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DestroyedOn",
                table: "Items",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "RequestReason",
                table: "Items",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RequestedBy",
                table: "Items",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ReturnedOn",
                table: "Items",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CurrentHolder",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "DestroyedOn",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "RequestReason",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "RequestedBy",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "ReturnedOn",
                table: "Items");
        }
    }
}
