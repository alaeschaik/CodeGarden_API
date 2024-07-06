using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CodeGardenApi.Migrations
{
    /// <inheritdoc />
    public partial class AddMissingForeinKeys : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Choices_Questions_QuestionId",
                schema: "dbo",
                table: "Choices");

            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Posts_PostId",
                schema: "dbo",
                table: "Comments");

            migrationBuilder.AlterColumn<int>(
                name: "ChallengeId",
                schema: "dbo",
                table: "Questions",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "QuestionId",
                schema: "dbo",
                table: "Choices",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserModules_ModuleId",
                schema: "dbo",
                table: "UserModules",
                column: "ModuleId");

            migrationBuilder.CreateIndex(
                name: "IX_UserModules_UserId",
                schema: "dbo",
                table: "UserModules",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Choices_Questions_QuestionId",
                schema: "dbo",
                table: "Choices",
                column: "QuestionId",
                principalSchema: "dbo",
                principalTable: "Questions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Posts_PostId",
                schema: "dbo",
                table: "Comments",
                column: "PostId",
                principalSchema: "dbo",
                principalTable: "Posts",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UserModules_Modules_ModuleId",
                schema: "dbo",
                table: "UserModules",
                column: "ModuleId",
                principalSchema: "dbo",
                principalTable: "Modules",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserModules_Users_UserId",
                schema: "dbo",
                table: "UserModules",
                column: "UserId",
                principalSchema: "dbo",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Choices_Questions_QuestionId",
                schema: "dbo",
                table: "Choices");

            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Posts_PostId",
                schema: "dbo",
                table: "Comments");

            migrationBuilder.DropForeignKey(
                name: "FK_UserModules_Modules_ModuleId",
                schema: "dbo",
                table: "UserModules");

            migrationBuilder.DropForeignKey(
                name: "FK_UserModules_Users_UserId",
                schema: "dbo",
                table: "UserModules");

            migrationBuilder.DropIndex(
                name: "IX_UserModules_ModuleId",
                schema: "dbo",
                table: "UserModules");

            migrationBuilder.DropIndex(
                name: "IX_UserModules_UserId",
                schema: "dbo",
                table: "UserModules");

            migrationBuilder.AlterColumn<int>(
                name: "ChallengeId",
                schema: "dbo",
                table: "Questions",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "QuestionId",
                schema: "dbo",
                table: "Choices",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Choices_Questions_QuestionId",
                schema: "dbo",
                table: "Choices",
                column: "QuestionId",
                principalSchema: "dbo",
                principalTable: "Questions",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Posts_PostId",
                schema: "dbo",
                table: "Comments",
                column: "PostId",
                principalSchema: "dbo",
                principalTable: "Posts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
