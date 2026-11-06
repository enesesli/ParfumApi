using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ParfumApi.Migrations
{
    /// <inheritdoc />
    public partial class KokuAtolyesi : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Esanslar",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Ad = table.Column<string>(type: "TEXT", nullable: false),
                    Katman = table.Column<string>(type: "TEXT", nullable: false),
                    Aile = table.Column<string>(type: "TEXT", nullable: false),
                    Aciklama = table.Column<string>(type: "TEXT", nullable: false),
                    Renk = table.Column<string>(type: "TEXT", nullable: false),
                    EkFiyat = table.Column<double>(type: "REAL", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Esanslar", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EsansUyumlari",
                columns: table => new
                {
                    EsansAId = table.Column<int>(type: "INTEGER", nullable: false),
                    EsansBId = table.Column<int>(type: "INTEGER", nullable: false),
                    Puan = table.Column<int>(type: "INTEGER", nullable: false),
                    Aciklama = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EsansUyumlari", x => new { x.EsansAId, x.EsansBId });
                    table.ForeignKey(
                        name: "FK_EsansUyumlari_Esanslar_EsansAId",
                        column: x => x.EsansAId,
                        principalTable: "Esanslar",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EsansUyumlari_Esanslar_EsansBId",
                        column: x => x.EsansBId,
                        principalTable: "Esanslar",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Esanslar",
                columns: new[] { "Id", "Aciklama", "Ad", "Aile", "EkFiyat", "Katman", "Renk" },
                values: new object[,]
                {
                    { 1, "Parlak ve hafif acımsı narenciye; neredeyse her şeyle uyumlu.", "Bergamot", "Narenciye", 150.0, "Üst", "#e9d36b" },
                    { 2, "Keskin, temiz ve enerjik.", "Limon", "Narenciye", 100.0, "Üst", "#f2e24a" },
                    { 3, "Sulu ve hafif acı; modern ve ferah.", "Greyfurt", "Narenciye", 120.0, "Üst", "#f29a8a" },
                    { 4, "Tatlı ve yumuşak bir narenciye.", "Mandalina", "Narenciye", 120.0, "Üst", "#f4a340" },
                    { 5, "Sulu, şeffaf ve neşeli.", "Armut", "Meyveli", 140.0, "Üst", "#d8d97a" },
                    { 6, "Ekşimsi tatlı kırmızı meyve.", "Ahududu", "Meyveli", 160.0, "Üst", "#c8455d" },
                    { 7, "Serin ve canlandırıcı.", "Nane", "Yeşil", 90.0, "Üst", "#7fc39a" },
                    { 8, "Tuzlu, havadar bir deniz esintisi.", "Deniz notası", "Yeşil", 130.0, "Üst", "#7fb7cf" },
                    { 9, "Hafif, ışıltılı bir baharat.", "Pembe biber", "Baharatlı", 200.0, "Üst", "#e07f8a" },
                    { 10, "Serin ve aromatik bir baharat.", "Kakule", "Baharatlı", 220.0, "Üst", "#b7b56a" },
                    { 11, "Çiçeklerin kraliçesi; romantik ve zengin.", "Gül", "Çiçeksi", 400.0, "Kalp", "#d9667e" },
                    { 12, "Beyaz, baş döndürücü ve kremsi.", "Yasemin", "Çiçeksi", 380.0, "Kalp", "#f3ead0" },
                    { 13, "Pudralı, zarif ve hafif topraksı.", "Süsen", "Çiçeksi", 450.0, "Kalp", "#b9a7d6" },
                    { 14, "Ballı, temiz ve ışıltılı.", "Portakal çiçeği", "Çiçeksi", 300.0, "Kalp", "#f5e3c0" },
                    { 15, "Taze ve pembe bir çiçek.", "Şakayık", "Çiçeksi", 250.0, "Kalp", "#efb3c3" },
                    { 16, "Sakinleştirici; temiz ve otsu.", "Lavanta", "Aromatik", 150.0, "Kalp", "#9b8ac4" },
                    { 17, "Otsu, hafif kafurlu ve ferah.", "Adaçayı", "Aromatik", 140.0, "Kalp", "#8fa58a" },
                    { 18, "Sakin, hafif ve dengeli.", "Yeşil çay", "Yeşil", 200.0, "Kalp", "#a3bb83" },
                    { 19, "Sıcak, tatlımsı bir baharat.", "Tarçın", "Baharatlı", 180.0, "Kalp", "#a5622f" },
                    { 20, "Deri tonlu, değerli ve sıcak.", "Safran", "Baharatlı", 600.0, "Kalp", "#d08a2e" },
                    { 21, "Kremsi, tatlı ve sarmalayıcı.", "Vanilya", "Gurme", 300.0, "Alt", "#e8cf9e" },
                    { 22, "Badem ve karamel arası sıcak bir tatlılık.", "Tonka", "Gurme", 260.0, "Alt", "#b98a5a" },
                    { 23, "Koyu ve hafif acı bir tatlılık.", "Kakao", "Gurme", 220.0, "Alt", "#5c3a28" },
                    { 24, "Kuru, temiz ve düz bir odun.", "Sedir", "Odunsu", 200.0, "Alt", "#a07a54" },
                    { 25, "Kremsi, yumuşak ve sütlü bir odun.", "Sandal ağacı", "Odunsu", 450.0, "Alt", "#d8b07a" },
                    { 26, "Topraksı, dumanlı ve yeşil.", "Vetiver", "Odunsu", 250.0, "Alt", "#7d8a64" },
                    { 27, "Yoğun, hayvansı ve çok kalıcı; dikkatli kullanılmalı.", "Ud", "Reçineli", 900.0, "Alt", "#4a2c2a" },
                    { 28, "Sıcak, reçineli ve tatlımsı.", "Amber", "Reçineli", 350.0, "Alt", "#c8894a" },
                    { 29, "Dumanlı, mistik ve kuru.", "Tütsü", "Reçineli", 300.0, "Alt", "#8a8170" },
                    { 30, "Temiz, ten gibi; diğer notaları birbirine bağlar.", "Beyaz misk", "Misk", 200.0, "Alt", "#f1ece6" }
                });

            migrationBuilder.InsertData(
                table: "EsansUyumlari",
                columns: new[] { "EsansAId", "EsansBId", "Aciklama", "Puan" },
                values: new object[,]
                {
                    { 2, 27, "Keskin limon, udun ağırlığıyla çatışır.", -2 },
                    { 3, 26, "Ferah ve topraksı; modern bir uyum.", 2 },
                    { 4, 21, "Portakallı dondurma gibi; oyunbaz bir gurme.", 1 },
                    { 6, 11, "Meyveli bir gül; canlı ve genç.", 2 },
                    { 7, 21, "Diş macunu etkisi yaratabilir.", -2 },
                    { 7, 27, "Serin nane ile yoğun ud birbirini boğar.", -2 },
                    { 8, 23, "Deniz ferahlığı ile kakao birbirini bastırır.", -2 },
                    { 9, 11, "Gülü canlandıran klasik baharat dokunuşu.", 2 },
                    { 10, 29, "Serin baharat ve duman; meditatif bir uyum.", 2 },
                    { 11, 20, "Safranın deri tonu gülü zenginleştirir.", 2 },
                    { 11, 27, "Ortadoğu parfümcülüğünün klasik ikilisi.", 2 },
                    { 12, 25, "Kremsi bir çiçek ile kremsi bir odun; yumuşak bir bütün.", 2 },
                    { 16, 22, "Klasik 'fougère' yapısının temeli.", 2 },
                    { 21, 22, "İkisi de kremsi ve sıcak; birbirini derinleştirir.", 2 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_EsansUyumlari_EsansBId",
                table: "EsansUyumlari",
                column: "EsansBId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EsansUyumlari");

            migrationBuilder.DropTable(
                name: "Esanslar");
        }
    }
}
