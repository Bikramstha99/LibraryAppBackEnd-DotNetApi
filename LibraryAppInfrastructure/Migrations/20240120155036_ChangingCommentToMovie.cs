using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LibraryAppInfrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ChangingCommentToMovie : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1,
                column: "PasswordHash",
                value: "$2a$11$CUHp1sPmSSiUFpe2tDnTcunyMINHUfbzOhF8wGSHwRhnHtu3LDT4S");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1,
                column: "PasswordHash",
                value: "$2a$11$r8OuUayihjNi0HhlyN43MOvaoPH0gm0ZWYpqwbdPOlNvZtlFv1raO");
        }
    }
}
