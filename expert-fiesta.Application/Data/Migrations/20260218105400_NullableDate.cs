using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace expert_fiesta.Application.Migrations
{
    /// <inheritdoc />
    public partial class NullableDate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "ReleaseDate",
                table: "Games",
                type: "character(8)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character(8)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "ReleaseDate",
                table: "Games",
                type: "character(8)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "character(8)",
                oldNullable: true);
        }
    }
}
