using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Foul_Api.Migrations
{
    /// <inheritdoc />
    public partial class userchange : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "firstname",
                table: "users");

            migrationBuilder.RenameColumn(
                name: "lastname",
                table: "users",
                newName: "firstandlastname");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "firstandlastname",
                table: "users",
                newName: "lastname");

            migrationBuilder.AddColumn<string>(
                name: "firstname",
                table: "users",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
