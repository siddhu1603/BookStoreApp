using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookStoreApp.Migrations
{
    /// <inheritdoc />
    public partial class RemoveApplicationUsers : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Authors_ApplicationUser_ApplicationUserId",
                table: "Authors");

            migrationBuilder.DropForeignKey(
                name: "FK_Books_ApplicationUser_ApplicationUserId",
                table: "Books");

            migrationBuilder.DropForeignKey(
                name: "FK_Genres_ApplicationUser_ApplicationUserId",
                table: "Genres");

            migrationBuilder.DropForeignKey(
                name: "FK_Publishers_ApplicationUser_ApplicationUserId",
                table: "Publishers");

            migrationBuilder.DropTable(
                name: "ApplicationUser");

            migrationBuilder.DropIndex(
                name: "IX_Publishers_ApplicationUserId",
                table: "Publishers");

            migrationBuilder.DropIndex(
                name: "IX_Genres_ApplicationUserId",
                table: "Genres");

            migrationBuilder.DropIndex(
                name: "IX_Books_ApplicationUserId",
                table: "Books");

            migrationBuilder.DropIndex(
                name: "IX_Authors_ApplicationUserId",
                table: "Authors");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                table: "Publishers");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                table: "Genres");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                table: "Books");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                table: "Authors");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ApplicationUserId",
                table: "Publishers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ApplicationUserId",
                table: "Genres",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ApplicationUserId",
                table: "Books",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ApplicationUserId",
                table: "Authors",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "ApplicationUser",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GoogleId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplicationUser", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Publishers_ApplicationUserId",
                table: "Publishers",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Genres_ApplicationUserId",
                table: "Genres",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Books_ApplicationUserId",
                table: "Books",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Authors_ApplicationUserId",
                table: "Authors",
                column: "ApplicationUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Authors_ApplicationUser_ApplicationUserId",
                table: "Authors",
                column: "ApplicationUserId",
                principalTable: "ApplicationUser",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Books_ApplicationUser_ApplicationUserId",
                table: "Books",
                column: "ApplicationUserId",
                principalTable: "ApplicationUser",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Genres_ApplicationUser_ApplicationUserId",
                table: "Genres",
                column: "ApplicationUserId",
                principalTable: "ApplicationUser",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Publishers_ApplicationUser_ApplicationUserId",
                table: "Publishers",
                column: "ApplicationUserId",
                principalTable: "ApplicationUser",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
