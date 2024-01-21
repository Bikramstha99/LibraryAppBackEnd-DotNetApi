using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LibraryAppInfrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddedAdminRole : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Role",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "User",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "Email", "FirstName", "LastName", "PasswordHash", "Role", "UserName" },
                values: new object[] { 1, "stha.bikram999@gmail.com", "Bikram", "Shrestha", "$2a$11$r8OuUayihjNi0HhlyN43MOvaoPH0gm0ZWYpqwbdPOlNvZtlFv1raO", "Admin", "BikramShrestha" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1);

            migrationBuilder.AlterColumn<string>(
                name: "Role",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldDefaultValue: "User");
        }
    }
}
