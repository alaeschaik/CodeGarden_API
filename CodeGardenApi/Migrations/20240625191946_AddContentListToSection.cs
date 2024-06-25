using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CodeGardenApi.Migrations
{
    /// <inheritdoc />
    public partial class AddContentListToSection : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Content",
                schema: "dbo",
                table: "Sections",
                type: "varchar(max)",
                nullable: false,
                defaultValue: "[]");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Content",
                schema: "dbo",
                table: "Sections");
        }
    }
}
