using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BoardTroveAPI.Migrations
{
    /// <inheritdoc />
    public partial class post_poly : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FEN",
                table: "Posts");

            migrationBuilder.AddColumn<string>(
                name: "PfpLink",
                table: "Users",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PfpLink",
                table: "Users");

            migrationBuilder.AddColumn<string>(
                name: "FEN",
                table: "Posts",
                type: "text",
                nullable: false,
                defaultValue: "");
        }
    }
}
