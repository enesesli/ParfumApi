using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ParfumApi.Migrations
{
    /// <inheritdoc />
    public partial class IlkKurulum : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Markalar",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Ad = table.Column<string>(type: "TEXT", nullable: false),
                    Ulke = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Markalar", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Parfumler",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Ad = table.Column<string>(type: "TEXT", nullable: false),
                    Aciklama = table.Column<string>(type: "TEXT", nullable: false),
                    Fiyat = table.Column<double>(type: "REAL", nullable: false),
                    HacimMl = table.Column<int>(type: "INTEGER", nullable: false),
                    Cinsiyet = table.Column<string>(type: "TEXT", nullable: false),
                    Stok = table.Column<int>(type: "INTEGER", nullable: false),
                    MarkaId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Parfumler", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Parfumler_Markalar_MarkaId",
                        column: x => x.MarkaId,
                        principalTable: "Markalar",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Markalar",
                columns: new[] { "Id", "Ad", "Ulke" },
                values: new object[,]
                {
                    { 1, "Chanel", "Fransa" },
                    { 2, "Dior", "Fransa" },
                    { 3, "Tom Ford", "ABD" },
                    { 4, "Yves Saint Laurent", "Fransa" }
                });

            migrationBuilder.InsertData(
                table: "Parfumler",
                columns: new[] { "Id", "Aciklama", "Ad", "Cinsiyet", "Fiyat", "HacimMl", "MarkaId", "Stok" },
                values: new object[,]
                {
                    { 1, "Odunsu ve aromatik, günlük kullanıma uygun.", "Bleu de Chanel", "Erkek", 5200.0, 100, 1, 12 },
                    { 2, "Taze çiçeksi ve oryantal notalar.", "Coco Mademoiselle", "Kadın", 5600.0, 100, 1, 8 },
                    { 3, "Bergamot ve ambroksan ile ferah bir koku.", "Sauvage", "Erkek", 4800.0, 100, 2, 20 },
                    { 4, "Yasemin ve gül ağırlıklı çiçeksi koku.", "J'adore", "Kadın", 5400.0, 100, 2, 6 },
                    { 5, "Ud, sandal ağacı ve baharat notaları.", "Oud Wood", "Unisex", 9800.0, 50, 3, 4 },
                    { 6, "Koyu, yoğun ve gizemli bir akşam kokusu.", "Black Orchid", "Unisex", 7200.0, 100, 3, 5 },
                    { 7, "Lavanta ve portakal çiçeği ile modern bir koku.", "Libre", "Kadın", 5000.0, 90, 4, 10 },
                    { 8, "Elma, adaçayı ve odunsu notalar.", "Y Eau de Parfum", "Erkek", 4600.0, 100, 4, 15 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Parfumler_MarkaId",
                table: "Parfumler",
                column: "MarkaId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Parfumler");

            migrationBuilder.DropTable(
                name: "Markalar");
        }
    }
}
