using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JokesApi_DAL.Migrations
{
    /// <inheritdoc />
    public partial class removeColumns : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IpAddress",
                table: "JokeLikes");

            migrationBuilder.DropColumn(
                name: "UserAgent",
                table: "JokeLikes");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "IpAddress",
                table: "JokeLikes",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "UserAgent",
                table: "JokeLikes",
                type: "text",
                nullable: false,
                defaultValue: "");
        }
    }
}
