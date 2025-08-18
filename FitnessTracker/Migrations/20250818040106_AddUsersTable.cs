using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FitnessTracker.Migrations
{
    /// <inheritdoc />
    public partial class AddUsersTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_NutritionLogs",
                table: "NutritionLogs");

            migrationBuilder.RenameTable(
                name: "NutritionLogs",
                newName: "Users");

            migrationBuilder.RenameColumn(
                name: "PasswordHash",
                table: "Users",
                newName: "Password");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Users",
                table: "Users",
                column: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Users",
                table: "Users");

            migrationBuilder.RenameTable(
                name: "Users",
                newName: "NutritionLogs");

            migrationBuilder.RenameColumn(
                name: "Password",
                table: "NutritionLogs",
                newName: "PasswordHash");

            migrationBuilder.AddPrimaryKey(
                name: "PK_NutritionLogs",
                table: "NutritionLogs",
                column: "Id");
        }
    }
}
