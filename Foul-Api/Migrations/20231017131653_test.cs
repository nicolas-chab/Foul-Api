using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Foul_Api.Migrations
{
    /// <inheritdoc />
    public partial class test : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Teamuser");

            migrationBuilder.AddColumn<string>(
                name: "SubscribedTeams",
                table: "users",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "partidos",
                table: "Team",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "subscribedteams",
                table: "users");

            migrationBuilder.DropColumn(
                name: "partidos",
                table: "Team");

            migrationBuilder.CreateTable(
                name: "Teamuser",
                columns: table => new
                {
                    SubscribedTeamsid = table.Column<int>(type: "int", nullable: false),
                    SubscribedUsersid = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teamuser", x => new { x.SubscribedTeamsid, x.SubscribedUsersid });
                    table.ForeignKey(
                        name: "FK_Teamuser_Team_SubscribedTeamsid",
                        column: x => x.SubscribedTeamsid,
                        principalTable: "Team",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Teamuser_users_SubscribedUsersid",
                        column: x => x.SubscribedUsersid,
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Teamuser_SubscribedUsersid",
                table: "Teamuser",
                column: "SubscribedUsersid");
        }
    }
}
