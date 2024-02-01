using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RestAlpaka.Migrations
{
    /// <inheritdoc />
    public partial class img2MigrationName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageData",
                table: "Alpakas");

            migrationBuilder.AddColumn<string>(
                name: "Img",
                table: "Alpakas",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Img",
                table: "Alpakas");

            migrationBuilder.AddColumn<byte[]>(
                name: "ImageData",
                table: "Alpakas",
                type: "longblob",
                nullable: true);
        }
    }
}
