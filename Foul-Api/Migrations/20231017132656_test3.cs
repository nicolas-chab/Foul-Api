using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Foul_Api.Migrations
{
    /// <inheritdoc />
    public partial class test3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Team");

            migrationBuilder.RenameColumn(
                name: "SubscribedTeams",
                table: "users",
                newName: "subscribedteams");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "subscribedteams",
                table: "users",
                newName: "SubscribedTeams");

            migrationBuilder.CreateTable(
                name: "Team",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    partidos = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    player = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    trainer = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    zona = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Team", x => x.id);
                });
        }
    }
}
