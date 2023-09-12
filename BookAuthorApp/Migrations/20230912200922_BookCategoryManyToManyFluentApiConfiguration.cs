using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookAuthorApp.Migrations
{
    /// <inheritdoc />
    public partial class BookCategoryManyToManyFluentApiConfiguration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BookCategory");

            migrationBuilder.CreateTable(
                name: "BookCategoryMaps",
                columns: table => new
                {
                    Book_Id = table.Column<int>(type: "integer", nullable: false),
                    Category_Id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookCategoryMaps", x => new { x.Book_Id, x.Category_Id });
                    table.ForeignKey(
                        name: "FK_BookCategoryMaps_Books_Book_Id",
                        column: x => x.Book_Id,
                        principalTable: "Books",
                        principalColumn: "Book_Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BookCategoryMaps_Categories_Category_Id",
                        column: x => x.Category_Id,
                        principalTable: "Categories",
                        principalColumn: "CategoryId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BookCategoryMaps_Category_Id",
                table: "BookCategoryMaps",
                column: "Category_Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BookCategoryMaps");

            migrationBuilder.CreateTable(
                name: "BookCategory",
                columns: table => new
                {
                    BooksBook_Id = table.Column<int>(type: "integer", nullable: false),
                    CategoriesCategoryId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookCategory", x => new { x.BooksBook_Id, x.CategoriesCategoryId });
                    table.ForeignKey(
                        name: "FK_BookCategory_Books_BooksBook_Id",
                        column: x => x.BooksBook_Id,
                        principalTable: "Books",
                        principalColumn: "Book_Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BookCategory_Categories_CategoriesCategoryId",
                        column: x => x.CategoriesCategoryId,
                        principalTable: "Categories",
                        principalColumn: "CategoryId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BookCategory_CategoriesCategoryId",
                table: "BookCategory",
                column: "CategoriesCategoryId");
        }
    }
}
