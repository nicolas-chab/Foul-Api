using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Foul_Api.Migrations
{
    /// <inheritdoc />
    public partial class usertest3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "firstandlastname",
                table: "users",
                newName: "Fullname");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Fullname",
                table: "users",
                newName: "firstandlastname");
        }
    }
}
