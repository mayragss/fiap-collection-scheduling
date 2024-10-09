using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddCollectionTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CollectionWindowEnd",
                table: "CollectionSchedules",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CollectionWindowStart",
                table: "CollectionSchedules",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ConfirmationDate",
                table: "CollectionSchedules",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsRecurring",
                table: "CollectionSchedules",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Notes",
                table: "CollectionSchedules",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "RecurringInterval",
                table: "CollectionSchedules",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CollectionWindowEnd",
                table: "CollectionSchedules");

            migrationBuilder.DropColumn(
                name: "CollectionWindowStart",
                table: "CollectionSchedules");

            migrationBuilder.DropColumn(
                name: "ConfirmationDate",
                table: "CollectionSchedules");

            migrationBuilder.DropColumn(
                name: "IsRecurring",
                table: "CollectionSchedules");

            migrationBuilder.DropColumn(
                name: "Notes",
                table: "CollectionSchedules");

            migrationBuilder.DropColumn(
                name: "RecurringInterval",
                table: "CollectionSchedules");
        }
    }
}
