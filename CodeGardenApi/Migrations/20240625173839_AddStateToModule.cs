using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CodeGardenApi.Migrations
{
    /// <inheritdoc />
    public partial class AddStateToModule : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "State",
                schema: "dbo",
                table: "Modules",
                type: "varchar(100)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "State",
                schema: "dbo",
                table: "Modules");
        }
    }
}
