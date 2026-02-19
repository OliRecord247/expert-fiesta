using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace expert_fiesta.Application.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "games",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    name = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: false),
                    description = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    release_date = table.Column<string>(type: "character(8)", nullable: true),
                    play_hours = table.Column<int>(type: "integer", nullable: false, defaultValue: 2)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_games", x => x.id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "games");
        }
    }
}
