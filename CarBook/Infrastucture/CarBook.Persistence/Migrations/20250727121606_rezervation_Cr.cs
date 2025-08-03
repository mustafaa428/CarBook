using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarBook.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class rezervation_Cr : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Rezervations_CarId",
                table: "Rezervations",
                column: "CarId");

            migrationBuilder.AddForeignKey(
                name: "FK_Rezervations_cars_CarId",
                table: "Rezervations",
                column: "CarId",
                principalTable: "cars",
                principalColumn: "CarId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Rezervations_cars_CarId",
                table: "Rezervations");

            migrationBuilder.DropIndex(
                name: "IX_Rezervations_CarId",
                table: "Rezervations");
        }
    }
}
