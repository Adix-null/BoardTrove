using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BoardTroveAPI.Migrations
{
    /// <inheritdoc />
    public partial class seed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Posts",
                columns: new[] { "ID", "Description", "FEN", "Title" },
                values: new object[,]
                {
                    { "1", "...", "rnbqkbnr/pppppppp/8/8/8/8/PPPPPPPP/RNBQKBNR w KQkq - 0 1", "Test Post" },
                    { "2", "AlphaZero's zugzwang game", "5rkq/3prp1p/5RpP/p1p5/5QP1/1B6/P4PK1/8 w - - 0 1", "Zugzwang" },
                    { "3", "Nimzo Immortal", "k7/4p3/3pP1b1/2pP1p2/2P1pP2/1B1pP3/3P4/7K w - - 0 1", "Zugzwang" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Posts",
                keyColumn: "ID",
                keyValue: "1");

            migrationBuilder.DeleteData(
                table: "Posts",
                keyColumn: "ID",
                keyValue: "2");

            migrationBuilder.DeleteData(
                table: "Posts",
                keyColumn: "ID",
                keyValue: "3");
        }
    }
}
