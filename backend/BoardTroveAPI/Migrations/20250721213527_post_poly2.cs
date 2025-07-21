using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BoardTroveAPI.Migrations
{
    /// <inheritdoc />
    public partial class post_poly2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FEN",
                table: "Posts",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PGN",
                table: "Posts",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "post_type",
                table: "Posts",
                type: "character varying(13)",
                maxLength: 13,
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FEN",
                table: "Posts");

            migrationBuilder.DropColumn(
                name: "PGN",
                table: "Posts");

            migrationBuilder.DropColumn(
                name: "post_type",
                table: "Posts");
        }
    }
}
