using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ParfumApi.Migrations
{
    /// <inheritdoc />
    public partial class Siparisler : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Siparisler",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    SiparisNo = table.Column<string>(type: "TEXT", nullable: false),
                    OlusturmaTarihi = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Durum = table.Column<string>(type: "TEXT", nullable: false),
                    AdSoyad = table.Column<string>(type: "TEXT", nullable: false),
                    Eposta = table.Column<string>(type: "TEXT", nullable: false),
                    Telefon = table.Column<string>(type: "TEXT", nullable: false),
                    Adres = table.Column<string>(type: "TEXT", nullable: false),
                    Sehir = table.Column<string>(type: "TEXT", nullable: false),
                    AraToplam = table.Column<double>(type: "REAL", nullable: false),
                    KargoUcreti = table.Column<double>(type: "REAL", nullable: false),
                    Toplam = table.Column<double>(type: "REAL", nullable: false),
                    OdemeYontemi = table.Column<string>(type: "TEXT", nullable: true),
                    OdemeReferansi = table.Column<string>(type: "TEXT", nullable: true),
                    OdemeTarihi = table.Column<DateTime>(type: "TEXT", nullable: true),
                    KartSonDortHane = table.Column<string>(type: "TEXT", nullable: true),
                    KriptoPara = table.Column<string>(type: "TEXT", nullable: true),
                    KriptoTutar = table.Column<double>(type: "REAL", nullable: true),
                    KriptoAdres = table.Column<string>(type: "TEXT", nullable: true),
                    KriptoSonTarih = table.Column<DateTime>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Siparisler", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SiparisKalemleri",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    SiparisId = table.Column<int>(type: "INTEGER", nullable: false),
                    ParfumId = table.Column<int>(type: "INTEGER", nullable: true),
                    Ad = table.Column<string>(type: "TEXT", nullable: false),
                    Marka = table.Column<string>(type: "TEXT", nullable: false),
                    Aciklama = table.Column<string>(type: "TEXT", nullable: false),
                    BirimFiyat = table.Column<double>(type: "REAL", nullable: false),
                    Adet = table.Column<int>(type: "INTEGER", nullable: false),
                    Tutar = table.Column<double>(type: "REAL", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SiparisKalemleri", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SiparisKalemleri_Siparisler_SiparisId",
                        column: x => x.SiparisId,
                        principalTable: "Siparisler",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SiparisKalemleri_SiparisId",
                table: "SiparisKalemleri",
                column: "SiparisId");

            migrationBuilder.CreateIndex(
                name: "IX_Siparisler_SiparisNo",
                table: "Siparisler",
                column: "SiparisNo",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SiparisKalemleri");

            migrationBuilder.DropTable(
                name: "Siparisler");
        }
    }
}
