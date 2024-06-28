using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CodeGardenApi.Migrations
{
    /// <inheritdoc />
    public partial class RemoveUserModuleProperties : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserModules_Modules_ModuleId",
                schema: "dbo",
                table: "UserModules");

            migrationBuilder.DropForeignKey(
                name: "FK_UserModules_Users_UserId",
                schema: "dbo",
                table: "UserModules");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
    }
}
