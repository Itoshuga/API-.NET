using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiWeb.Migrations
{
    /// <inheritdoc />
    public partial class PowerMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "HeroId",
                table: "Powers",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Powers_HeroId",
                table: "Powers",
                column: "HeroId");

            migrationBuilder.AddForeignKey(
                name: "FK_Powers_Heroes_HeroId",
                table: "Powers",
                column: "HeroId",
                principalTable: "Heroes",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Powers_Heroes_HeroId",
                table: "Powers");

            migrationBuilder.DropIndex(
                name: "IX_Powers_HeroId",
                table: "Powers");

            migrationBuilder.DropColumn(
                name: "HeroId",
                table: "Powers");
        }
    }
}
