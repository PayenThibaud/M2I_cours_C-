using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Demo01.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Crepes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsSalty = table.Column<bool>(type: "bit", nullable: false),
                    Diameter = table.Column<double>(type: "float", nullable: false),
                    Topping1 = table.Column<int>(type: "int", nullable: false),
                    Topping2 = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Crepes", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Crepes",
                columns: new[] { "Id", "Diameter", "IsSalty", "Name", "Topping1", "Topping2" },
                values: new object[,]
                {
                    { 1, 14.0, true, "Surprise du chef", 4, 8 },
                    { 2, 14.0, true, "Fruits de la mer", 3, 0 },
                    { 3, 14.0, false, "Double nut", 0, 0 },
                    { 4, 14.0, false, "Myrtille", 5, 5 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Crepes");
        }
    }
}
