using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using ParfumApi.Data;

#nullable disable

namespace ParfumApi.Migrations
{
    // Kripto faturasında kurun siparişe kaydedilmesi için tek sütunluk migration.
    // (Elle yazıldı; doğruluğunu ParfumApi.Tests içindeki
    // "Model_ve_migrationlar_uyumlu" testi kontrol ediyor.)
    [DbContext(typeof(AppDbContext))]
    [Migration("20261106100000_KriptoKur")]
    public partial class KriptoKur : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "KriptoKur",
                table: "Siparisler",
                type: "REAL",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "KriptoKur",
                table: "Siparisler");
        }
    }
}
