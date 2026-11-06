using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ParfumApi.Migrations
{
    /// <inheritdoc />
    public partial class KatalogGenisleme : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Markalar",
                columns: new[] { "Id", "Ad", "Ulke" },
                values: new object[,]
                {
                    { 9, "Kyma", "Yunanistan" },
                    { 10, "Saffron & Sand", "Hindistan" }
                });

            migrationBuilder.InsertData(
                table: "Parfumler",
                columns: new[] { "Id", "Aciklama", "Ad", "AltNotalar", "Cinsiyet", "EskiFiyat", "Fiyat", "HacimMl", "KalpNotalar", "KokuAilesi", "Konsantrasyon", "MarkaId", "Renk", "SiseTipi", "Stok", "UstNotalar", "Yeni" },
                values: new object[,]
                {
                    { 101, "Pudralı süsen ve menekşe; zamansız bir zarafet.", "Poudre d'Iris", "Misk, Kaşmir ağacı", "Kadın", null, 5100.0, 75, "Süsen, Menekşe", "Çiçeksi", "Eau de Parfum", 1, "#d9cfe6", 0, 12, "Bergamot, Havuç tohumu", false },
                    { 102, "Sabah güneşinde açan portakal çiçeği.", "Néroli Matin", "Beyaz misk", "Unisex", 3900.0, 3400.0, 100, "Portakal çiçeği, Petitgrain", "Ferah", "Eau de Toilette", 1, "#f3e6b8", 2, 19, "Neroli, Limon", false },
                    { 103, "Gece açan koyu bir gül; tutkulu ve derin.", "Rose Nocturne", "Paçuli, Amber", "Kadın", null, 6900.0, 50, "Gül, Ud", "Çiçeksi", "Extrait de Parfum", 1, "#8e2f4a", 3, 6, "Pembe biber", true },
                    { 104, "Yanık tütün yaprakları ve koyu bal.", "Tabac Brûlé", "Vanilya, Deri", "Erkek", null, 5900.0, 100, "Tütün yaprağı, Bal", "Oryantal", "Eau de Parfum", 2, "#6e4a2c", 0, 9, "Kakule, Tarçın", false },
                    { 105, "Taş bir şapelde yükselen tütsü dumanı.", "Encens", "Sedir, Labdanum", "Unisex", 6200.0, 5300.0, 100, "Tütsü, Mür", "Odunsu", "Eau de Parfum", 2, "#8a8170", 4, 10, "Elemi, Limon", false },
                    { 106, "Gri bir sabahın serin, topraksı vetiveri.", "Vétiver Gris", "Misk, Ambroksan", "Erkek", null, 3800.0, 100, "Vetiver, Süsen", "Odunsu", "Eau de Toilette", 2, "#7d8a78", 2, 17, "Greyfurt, Karabiber", true },
                    { 107, "Fıstıklı dondurmanın kremsi ve neşeli tatlılığı.", "Pistacchio Dolce", "Vanilya, Tonka", "Unisex", null, 4300.0, 75, "Antep fıstığı, Süt notası", "Gurme", "Eau de Parfum", 3, "#b8c98a", 1, 14, "Bergamot", true },
                    { 108, "Amalfi kıyısının limonlu, güneşli havası.", "Limone di Amalfi", "Misk", "Unisex", null, 3300.0, 100, "Fesleğen, Portakal çiçeği", "Ferah", "Eau de Toilette", 3, "#f2e27a", 2, 24, "Limon, Mandalina", false },
                    { 109, "Kahve ve kakaoyla katman katman tatlı bir gece.", "Tiramisù Notturno", "Vanilya, Benzoin", "Kadın", 6900.0, 6200.0, 50, "Kakao, Krema notası", "Gurme", "Extrait de Parfum", 3, "#7a5440", 3, 7, "Kahve", false },
                    { 110, "Kuzey denizinden esen tuzlu, temiz bir rüzgâr.", "Havsbris", "Deniz odunu, Misk", "Erkek", null, 2900.0, 100, "Adaçayı, Biberiye", "Ferah", "Eau de Toilette", 4, "#a8d0d8", 0, 26, "Deniz tuzu, Limon", false },
                    { 111, "Kırmızı orman meyveleri ve yumuşak çiçekler.", "Lingon", "Misk, Sedir", "Kadın", null, 3600.0, 50, "Gül, Şakayık", "Ferah", "Eau de Parfum", 4, "#c64a5a", 4, 15, "Yaban mersini, Bergamot", true },
                    { 112, "Uzun bir kış gecesi; şömine başında lavanta ve reçine.", "Vinternatt", "Amber, Süet", "Unisex", null, 4600.0, 100, "Lavanta, Çam reçinesi", "Aromatik", "Eau de Parfum", 4, "#3b4a6b", 3, 0, "Ardıç, Kakule", false },
                    { 113, "Olgun siyah incir ve romun koyu tatlılığı.", "Higo Negro", "Tonka, Odunlar", "Unisex", null, 4700.0, 100, "Kakao, Rom", "Gurme", "Eau de Parfum", 5, "#4b3a4f", 1, 11, "Siyah incir, Kakule", false },
                    { 114, "Sevilla avlularında gece açan yasemin.", "Jazmín de Sevilla", "Misk, Sandal ağacı", "Kadın", null, 4400.0, 100, "Yasemin, Tuberoz", "Çiçeksi", "Eau de Parfum", 5, "#f4ecd6", 0, 13, "Mandalina", true },
                    { 115, "Yumuşak deri ve safranla asil bir Endülüs kokusu.", "Cuero Andaluz", "Sedir, Amber", "Erkek", 7400.0, 6600.0, 50, "Deri, Süsen", "Odunsu", "Extrait de Parfum", 5, "#5a3826", 3, 5, "Safran, Ahududu", false },
                    { 116, "Yuzu ve zencefille esen ferah bir rüzgâr.", "Yuzu Kaze", "Beyaz misk", "Unisex", null, 3200.0, 100, "Yeşil çay, Shiso", "Ferah", "Eau de Toilette", 6, "#f2d65c", 2, 23, "Yuzu, Zencefil", true },
                    { 117, "Kırık çömleği altınla onarma sanatından ilham: sıcak ve parlak.", "Kintsugi", "Sandal ağacı, Benzoin", "Unisex", null, 7600.0, 50, "Ud, Gül", "Oryantal", "Extrait de Parfum", 6, "#c9a24a", 3, 5, "Safran", false },
                    { 118, "Kremsi matcha; huzurlu bir öğleden sonra.", "Matcha Latte", "Vanilya, Misk", "Kadın", 4400.0, 3900.0, 50, "Süt notası, Yasemin", "Gurme", "Eau de Parfum", 6, "#9cb46c", 4, 16, "Matcha, Bergamot", false },
                    { 119, "Temmuzda mor tarlalardan toplanmış taze lavanta.", "Lavanta Köyü", "Misk, Tonka", "Unisex", null, 2900.0, 100, "Adaçayı, Kekik", "Aromatik", "Eau de Toilette", 7, "#9b8ac4", 0, 27, "Lavanta, Bergamot", false },
                    { 120, "Gül lokumu ve badem; tatlı bir bayram sabahı.", "Lokum", "Vanilya, Misk", "Kadın", null, 3700.0, 100, "Şeker, Gül", "Gurme", "Eau de Parfum", 7, "#f0b8c4", 1, 18, "Gül suyu, Badem", true },
                    { 121, "Bodrum'da bir tekne gezintisi: tuz, defne ve güneş.", "Ege Rüzgârı", "Sedir, Ambroksan", "Erkek", 3500.0, 3000.0, 100, "Defne, Biberiye", "Ferah", "Eau de Toilette", 7, "#6fb3c9", 2, 21, "Deniz notaları, Limon", false },
                    { 122, "Geleneksel bakhoor tütsüsünün sıcak, dumanlı kucaklaması.", "Bakhoor", "Amber, Sandal ağacı", "Unisex", null, 7900.0, 100, "Ud, Gül", "Oryantal", "Eau de Parfum", 8, "#5e2f22", 0, 7, "Tütsü, Tarçın", false },
                    { 123, "Gece kadar yumuşak, ipeksi bir misk.", "Musk Al Layl", "Beyaz misk, Amber", "Kadın", null, 7100.0, 50, "Beyaz çiçekler, Gül", "Çiçeksi", "Extrait de Parfum", 8, "#ece2e6", 1, 9, "Bergamot", true },
                    { 124, "Safran ve udun altın renkli, yoğun buluşması.", "Zafaran", "Amber, Paçuli", "Erkek", 9900.0, 9200.0, 50, "Ud, Deri", "Oryantal", "Extrait de Parfum", 8, "#c27a2c", 3, 4, "Safran, Kakule", false },
                    { 125, "Ege'nin berrak mavisi; tuzlu ve aydınlık.", "Thalassa", "Misk, Ambroksan", "Unisex", null, 3300.0, 100, "Deniz yosunu, Neroli", "Ferah", "Eau de Toilette", 9, "#5fa8c4", 2, 20, "Deniz tuzu, Bergamot", true },
                    { 126, "Asırlık zeytin ağaçlarının gümüşi yeşili.", "Olea", "Sedir, Vetiver", "Unisex", null, 4100.0, 100, "Kekik, İncir yaprağı", "Aromatik", "Eau de Parfum", 9, "#a7a86a", 0, 14, "Zeytin yaprağı, Limon", false },
                    { 127, "Beyaz evler ve begonviller arasında bir gün batımı.", "Santorini", "Beyaz misk", "Kadın", 4300.0, 3800.0, 50, "Yasemin, Gardenya", "Çiçeksi", "Eau de Parfum", 9, "#f3f0ea", 1, 12, "Limon çiçeği", false },
                    { 128, "Dağ sedirinin reçineli, kuru ve asil sıcaklığı.", "Kedros", "Amber, Deri", "Erkek", null, 5600.0, 50, "Sedir, Reçine", "Odunsu", "Extrait de Parfum", 9, "#7a5a3a", 4, 8, "Karabiber, Bergamot", false },
                    { 129, "Baharatlı bir fincan chai; sıcak ve davetkâr.", "Chai Masala", "Vanilya, Tonka", "Unisex", null, 4200.0, 100, "Siyah çay, Tarçın", "Gurme", "Eau de Parfum", 10, "#b07848", 0, 15, "Kakule, Zencefil", true },
                    { 130, "Pembe şehrin gülleri ve baharat pazarları.", "Jaipur Rose", "Sandal ağacı, Misk", "Kadın", null, 4800.0, 100, "Gül, Safran", "Çiçeksi", "Eau de Parfum", 10, "#e07a92", 1, 11, "Pembe biber, Kakule", false },
                    { 131, "Kremsi sandal ağacının sakin ve sıcak dokusu.", "Mysore Sandal", "Misk, Benzoin", "Unisex", 7500.0, 6800.0, 50, "Sandal ağacı, Yasemin", "Odunsu", "Extrait de Parfum", 10, "#d8b07a", 3, 6, "Kakule", false },
                    { 132, "Muson yağmurundan sonra ıslak toprak ve yeşillik.", "Monsoon", "Paçuli, Misk", "Erkek", null, 3400.0, 100, "Vetiver, Yeşil çay", "Aromatik", "Eau de Toilette", 10, "#4f7a6a", 2, 0, "Islak toprak, Zencefil", true }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Parfumler",
                keyColumn: "Id",
                keyValue: 101);

            migrationBuilder.DeleteData(
                table: "Parfumler",
                keyColumn: "Id",
                keyValue: 102);

            migrationBuilder.DeleteData(
                table: "Parfumler",
                keyColumn: "Id",
                keyValue: 103);

            migrationBuilder.DeleteData(
                table: "Parfumler",
                keyColumn: "Id",
                keyValue: 104);

            migrationBuilder.DeleteData(
                table: "Parfumler",
                keyColumn: "Id",
                keyValue: 105);

            migrationBuilder.DeleteData(
                table: "Parfumler",
                keyColumn: "Id",
                keyValue: 106);

            migrationBuilder.DeleteData(
                table: "Parfumler",
                keyColumn: "Id",
                keyValue: 107);

            migrationBuilder.DeleteData(
                table: "Parfumler",
                keyColumn: "Id",
                keyValue: 108);

            migrationBuilder.DeleteData(
                table: "Parfumler",
                keyColumn: "Id",
                keyValue: 109);

            migrationBuilder.DeleteData(
                table: "Parfumler",
                keyColumn: "Id",
                keyValue: 110);

            migrationBuilder.DeleteData(
                table: "Parfumler",
                keyColumn: "Id",
                keyValue: 111);

            migrationBuilder.DeleteData(
                table: "Parfumler",
                keyColumn: "Id",
                keyValue: 112);

            migrationBuilder.DeleteData(
                table: "Parfumler",
                keyColumn: "Id",
                keyValue: 113);

            migrationBuilder.DeleteData(
                table: "Parfumler",
                keyColumn: "Id",
                keyValue: 114);

            migrationBuilder.DeleteData(
                table: "Parfumler",
                keyColumn: "Id",
                keyValue: 115);

            migrationBuilder.DeleteData(
                table: "Parfumler",
                keyColumn: "Id",
                keyValue: 116);

            migrationBuilder.DeleteData(
                table: "Parfumler",
                keyColumn: "Id",
                keyValue: 117);

            migrationBuilder.DeleteData(
                table: "Parfumler",
                keyColumn: "Id",
                keyValue: 118);

            migrationBuilder.DeleteData(
                table: "Parfumler",
                keyColumn: "Id",
                keyValue: 119);

            migrationBuilder.DeleteData(
                table: "Parfumler",
                keyColumn: "Id",
                keyValue: 120);

            migrationBuilder.DeleteData(
                table: "Parfumler",
                keyColumn: "Id",
                keyValue: 121);

            migrationBuilder.DeleteData(
                table: "Parfumler",
                keyColumn: "Id",
                keyValue: 122);

            migrationBuilder.DeleteData(
                table: "Parfumler",
                keyColumn: "Id",
                keyValue: 123);

            migrationBuilder.DeleteData(
                table: "Parfumler",
                keyColumn: "Id",
                keyValue: 124);

            migrationBuilder.DeleteData(
                table: "Parfumler",
                keyColumn: "Id",
                keyValue: 125);

            migrationBuilder.DeleteData(
                table: "Parfumler",
                keyColumn: "Id",
                keyValue: 126);

            migrationBuilder.DeleteData(
                table: "Parfumler",
                keyColumn: "Id",
                keyValue: 127);

            migrationBuilder.DeleteData(
                table: "Parfumler",
                keyColumn: "Id",
                keyValue: 128);

            migrationBuilder.DeleteData(
                table: "Parfumler",
                keyColumn: "Id",
                keyValue: 129);

            migrationBuilder.DeleteData(
                table: "Parfumler",
                keyColumn: "Id",
                keyValue: 130);

            migrationBuilder.DeleteData(
                table: "Parfumler",
                keyColumn: "Id",
                keyValue: 131);

            migrationBuilder.DeleteData(
                table: "Parfumler",
                keyColumn: "Id",
                keyValue: 132);

            migrationBuilder.DeleteData(
                table: "Markalar",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Markalar",
                keyColumn: "Id",
                keyValue: 10);
        }
    }
}
