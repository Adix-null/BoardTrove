using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BoardTroveAPI.Migrations
{
    /// <inheritdoc />
    public partial class reorg : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "bio",
                table: "Users",
                newName: "Bio");

            migrationBuilder.AddColumn<DateTime>(
                name: "Created",
                table: "Users",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc));
            migrationBuilder.RenameTable("Posts", "Posts_FEN");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Created",
                table: "Users");

            migrationBuilder.RenameColumn(
                name: "Bio",
                table: "Users",
                newName: "bio");
        }
    }
}
