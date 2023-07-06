using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MagicVilla.API.Migrations
{
    /// <inheritdoc />
    public partial class Seed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Vilas",
                columns: new[] { "Id", "Comodidade", "DataAtualizacao", "DataCriacao", "Detalhes", "MetrosQuadrados", "Nome", "Ocupacao", "Tarifa", "UrlDaImagem" },
                values: new object[,]
                {
                    { 1, "Ar condicionado, TV, Frigobar, Cama King Size, Banheira de Hidromassagem", new DateTime(2023, 7, 6, 18, 52, 19, 167, DateTimeKind.Local).AddTicks(9702), new DateTime(2023, 7, 6, 18, 52, 19, 167, DateTimeKind.Local).AddTicks(9692), "Vila com vista para a piscina", 100, "Vista da Piscina", 2, 1000.0, "https://dotnetmastery.com/bluevillaimages/villa1.jpg" },
                    { 2, "Ar condicionado, TV, Frigobar, Cama King Size, Banheira de Hidromassagem", new DateTime(2023, 7, 6, 18, 52, 19, 167, DateTimeKind.Local).AddTicks(9705), new DateTime(2023, 7, 6, 18, 52, 19, 167, DateTimeKind.Local).AddTicks(9705), "Vila com vista para o lago", 200, "Vista do Lago", 4, 2000.0, "https://dotnetmastery.com/bluevillaimages/villa2.jpg" },
                    { 3, "Ar condicionado, TV, Frigobar, Cama King Size, Banheira de Hidromassagem", new DateTime(2023, 7, 6, 18, 52, 19, 167, DateTimeKind.Local).AddTicks(9707), new DateTime(2023, 7, 6, 18, 52, 19, 167, DateTimeKind.Local).AddTicks(9707), "Vila com vista para o mar", 300, "Vista do Mar", 6, 3000.0, "https://dotnetmastery.com/bluevillaimages/villa3.jpg" },
                    { 4, "Ar condicionado, TV, Frigobar, Cama King Size, Banheira de Hidromassagem", new DateTime(2023, 7, 6, 18, 52, 19, 167, DateTimeKind.Local).AddTicks(9709), new DateTime(2023, 7, 6, 18, 52, 19, 167, DateTimeKind.Local).AddTicks(9709), "Vila com vista para o jardim", 400, "Vista do Jardim", 8, 4000.0, "https://dotnetmastery.com/bluevillaimages/villa4.jpg" },
                    { 5, "Ar condicionado, TV, Frigobar, Cama King Size, Banheira de Hidromassagem", new DateTime(2023, 7, 6, 18, 52, 19, 167, DateTimeKind.Local).AddTicks(9711), new DateTime(2023, 7, 6, 18, 52, 19, 167, DateTimeKind.Local).AddTicks(9711), "Vila com vista para a montanha", 500, "Vista da Montanha", 10, 5000.0, "https://dotnetmastery.com/bluevillaimages/villa5.jpg" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Vilas",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Vilas",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Vilas",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Vilas",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Vilas",
                keyColumn: "Id",
                keyValue: 5);
        }
    }
}
