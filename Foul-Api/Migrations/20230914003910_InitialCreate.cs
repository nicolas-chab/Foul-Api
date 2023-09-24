using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Foul_Api.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Team",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    trainer = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    zona = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    player = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Team", x => x.id);
                });

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Teamuser");

            migrationBuilder.DropTable(
                name: "Team");
        }
    }
}
