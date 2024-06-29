using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CodeGardenApi.Migrations
{
    /// <inheritdoc />
    public partial class AddQuestionAndChoiceModels : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_UserModules_ModuleId",
                schema: "dbo",
                table: "UserModules");

            migrationBuilder.DropIndex(
                name: "IX_UserModules_UserId",
                schema: "dbo",
                table: "UserModules");

            migrationBuilder.DropColumn(
                name: "Content",
                schema: "dbo",
                table: "Sections");

            migrationBuilder.DropColumn(
                name: "State",
                schema: "dbo",
                table: "Modules");

            migrationBuilder.CreateTable(
                name: "OpenEndedQuestions",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Content = table.Column<string>(type: "varchar(max)", nullable: false),
                    CorrectAnswer = table.Column<string>(type: "varchar(max)", nullable: false),
                    ChallengeId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OpenEndedQuestions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OpenEndedQuestions_Challenges_ChallengeId",
                        column: x => x.ChallengeId,
                        principalSchema: "dbo",
                        principalTable: "Challenges",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Choices",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Content = table.Column<string>(type: "varchar(max)", nullable: false),
                    IsCorrect = table.Column<string>(type: "varchar(100)", nullable: false),
                    OpenEndedQuestionId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Choices", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Choices_OpenEndedQuestions_OpenEndedQuestionId",
                        column: x => x.OpenEndedQuestionId,
                        principalSchema: "dbo",
                        principalTable: "OpenEndedQuestions",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Choices_OpenEndedQuestionId",
                schema: "dbo",
                table: "Choices",
                column: "OpenEndedQuestionId");

            migrationBuilder.CreateIndex(
                name: "IX_OpenEndedQuestions_ChallengeId",
                schema: "dbo",
                table: "OpenEndedQuestions",
                column: "ChallengeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Choices",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "OpenEndedQuestions",
                schema: "dbo");

            migrationBuilder.AddColumn<string>(
                name: "Content",
                schema: "dbo",
                table: "Sections",
                type: "varchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "State",
                schema: "dbo",
                table: "Modules",
                type: "varchar(100)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_UserModules_ModuleId",
                schema: "dbo",
                table: "UserModules",
                column: "ModuleId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserModules_UserId",
                schema: "dbo",
                table: "UserModules",
                column: "UserId",
                unique: true);
        }
    }
}
