using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CodeGardenApi.Migrations
{
    /// <inheritdoc />
    public partial class RefactorQuestionModelName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Choices_OpenEndedQuestions_OpenEndedQuestionId",
                schema: "dbo",
                table: "Choices");

            migrationBuilder.DropTable(
                name: "OpenEndedQuestions",
                schema: "dbo");

            migrationBuilder.RenameColumn(
                name: "OpenEndedQuestionId",
                schema: "dbo",
                table: "Choices",
                newName: "QuestionId");

            migrationBuilder.RenameIndex(
                name: "IX_Choices_OpenEndedQuestionId",
                schema: "dbo",
                table: "Choices",
                newName: "IX_Choices_QuestionId");

            migrationBuilder.CreateTable(
                name: "Questions",
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
                    table.PrimaryKey("PK_Questions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Questions_Challenges_ChallengeId",
                        column: x => x.ChallengeId,
                        principalSchema: "dbo",
                        principalTable: "Challenges",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Questions_ChallengeId",
                schema: "dbo",
                table: "Questions",
                column: "ChallengeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Choices_Questions_QuestionId",
                schema: "dbo",
                table: "Choices",
                column: "QuestionId",
                principalSchema: "dbo",
                principalTable: "Questions",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Choices_Questions_QuestionId",
                schema: "dbo",
                table: "Choices");

            migrationBuilder.DropTable(
                name: "Questions",
                schema: "dbo");

            migrationBuilder.RenameColumn(
                name: "QuestionId",
                schema: "dbo",
                table: "Choices",
                newName: "OpenEndedQuestionId");

            migrationBuilder.RenameIndex(
                name: "IX_Choices_QuestionId",
                schema: "dbo",
                table: "Choices",
                newName: "IX_Choices_OpenEndedQuestionId");

            migrationBuilder.CreateTable(
                name: "OpenEndedQuestions",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ChallengeId = table.Column<int>(type: "int", nullable: true),
                    Content = table.Column<string>(type: "varchar(max)", nullable: false),
                    CorrectAnswer = table.Column<string>(type: "varchar(max)", nullable: false)
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

            migrationBuilder.CreateIndex(
                name: "IX_OpenEndedQuestions_ChallengeId",
                schema: "dbo",
                table: "OpenEndedQuestions",
                column: "ChallengeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Choices_OpenEndedQuestions_OpenEndedQuestionId",
                schema: "dbo",
                table: "Choices",
                column: "OpenEndedQuestionId",
                principalSchema: "dbo",
                principalTable: "OpenEndedQuestions",
                principalColumn: "Id");
        }
    }
}
