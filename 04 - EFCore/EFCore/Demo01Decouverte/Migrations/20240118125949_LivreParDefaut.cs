using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Demo01Decouverte.Migrations
{
    public partial class LivreParDefaut : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Livres",
                columns: new[] { "Id", "Auteur", "DatePublication", "Description", "Titre" },
                values: new object[] { 1, "Arthur DENNETIERE", new DateTime(2024, 1, 18, 13, 59, 49, 23, DateTimeKind.Local).AddTicks(4143), "La meilleure recette de crêpe connue à ce jour", "La recette des crêpes" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Livres",
                keyColumn: "Id",
                keyValue: -1);
        }
    }
}
