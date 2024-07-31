using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Exercice04.Migrations
{
    public partial class DataSeed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Animals",
                columns: new[] { "Id", "Age", "FirstName", "Species" },
                values: new object[] { 1, 3, "Coco", "Perroquet" });

            migrationBuilder.InsertData(
                table: "Animals",
                columns: new[] { "Id", "Age", "FirstName", "Species" },
                values: new object[] { 2, 5, "Pepette", "Chien, Bouledogue" });

            migrationBuilder.InsertData(
                table: "Animals",
                columns: new[] { "Id", "Age", "FirstName", "Species" },
                values: new object[] { 3, 15, "Perry", "Platypus" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Animals",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Animals",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Animals",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
