using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Website.Infrastructure.Migrations
{
    public partial class PostCategoriesTable_Renamed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CategoryPosts_PostCategories_CategoriesId",
                table: "CategoryPosts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PostCategories",
                table: "PostCategories");

            migrationBuilder.RenameTable(
                name: "PostCategories",
                newName: "Catecories");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Catecories",
                table: "Catecories",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CategoryPosts_Catecories_CategoriesId",
                table: "CategoryPosts",
                column: "CategoriesId",
                principalTable: "Catecories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CategoryPosts_Catecories_CategoriesId",
                table: "CategoryPosts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Catecories",
                table: "Catecories");

            migrationBuilder.RenameTable(
                name: "Catecories",
                newName: "PostCategories");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PostCategories",
                table: "PostCategories",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CategoryPosts_PostCategories_CategoriesId",
                table: "CategoryPosts",
                column: "CategoriesId",
                principalTable: "PostCategories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
