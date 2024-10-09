using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddRelations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "CollectionSchedules",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_CollectionSchedules_UserId",
                table: "CollectionSchedules",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_CollectionSchedules_Users_UserId",
                table: "CollectionSchedules",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CollectionSchedules_Users_UserId",
                table: "CollectionSchedules");

            migrationBuilder.DropIndex(
                name: "IX_CollectionSchedules_UserId",
                table: "CollectionSchedules");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "CollectionSchedules");
        }
    }
}
