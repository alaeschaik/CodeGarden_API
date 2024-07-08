using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CodeGardenApi.Migrations
{
    /// <inheritdoc />
    public partial class AddXpPointsToQuestionChallenge : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "XpPoints",
                schema: "dbo",
                table: "Questions",
                type: "decimal(20,0)",
                precision: 20,
                scale: 0,
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "XpPoints",
                schema: "dbo",
                table: "Challenges",
                type: "decimal(20,0)",
                precision: 20,
                scale: 0,
                nullable: false,
                defaultValue: 0m);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "XpPoints",
                schema: "dbo",
                table: "Questions");

            migrationBuilder.DropColumn(
                name: "XpPoints",
                schema: "dbo",
                table: "Challenges");
        }
    }
}
