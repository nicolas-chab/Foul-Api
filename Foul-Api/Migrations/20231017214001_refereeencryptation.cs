using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Foul_Api.Migrations
{
    /// <inheritdoc />
    public partial class refereeencryptation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte[]>(
                name: "passwordhash",
                table: "referees",
                type: "varbinary(max)",
                nullable: false,
                defaultValue: new byte[0]);

            migrationBuilder.AddColumn<string>(
                name: "passwordresettoken",
                table: "referees",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "passwordsalt",
                table: "referees",
                type: "varbinary(max)",
                nullable: false,
                defaultValue: new byte[0]);

            migrationBuilder.AddColumn<DateTime>(
                name: "resettokenexpires",
                table: "referees",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "verificationtoken",
                table: "referees",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "verifiedat",
                table: "referees",
                type: "datetime2",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "passwordhash",
                table: "referees");

            migrationBuilder.DropColumn(
                name: "passwordresettoken",
                table: "referees");

            migrationBuilder.DropColumn(
                name: "passwordsalt",
                table: "referees");

            migrationBuilder.DropColumn(
                name: "resettokenexpires",
                table: "referees");

            migrationBuilder.DropColumn(
                name: "verificationtoken",
                table: "referees");

            migrationBuilder.DropColumn(
                name: "verifiedat",
                table: "referees");
        }
    }
}
