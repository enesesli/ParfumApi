using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ParfumApi.Migrations
{
    /// <inheritdoc />
    public partial class Katalog : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AltNotalar",
                table: "Parfumler",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<double>(
                name: "EskiFiyat",
                table: "Parfumler",
                type: "REAL",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "KalpNotalar",
                table: "Parfumler",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "KokuAilesi",
                table: "Parfumler",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Konsantrasyon",
                table: "Parfumler",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Renk",
                table: "Parfumler",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "SiseTipi",
                table: "Parfumler",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "UstNotalar",
                table: "Parfumler",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "Yeni",
                table: "Parfumler",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "Markalar",
                keyColumn: "Id",
                keyValue: 1,
                column: "Ad",
                value: "Maison Lune");

            migrationBuilder.UpdateData(
                table: "Markalar",
                keyColumn: "Id",
                keyValue: 2,
                column: "Ad",
                value: "Atelier Noir");

            migrationBuilder.UpdateData(
                table: "Markalar",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Ad", "Ulke" },
                values: new object[] { "Velours & Co.", "İtalya" });

            migrationBuilder.UpdateData(
                table: "Markalar",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Ad", "Ulke" },
                values: new object[] { "Nordlys", "İsveç" });

            migrationBuilder.InsertData(
                table: "Markalar",
                columns: new[] { "Id", "Ad", "Ulke" },
                values: new object[,]
                {
                    { 5, "Casa Ámbar", "İspanya" },
                    { 6, "Hikari", "Japonya" },
                    { 7, "Anatolia Esans", "Türkiye" },
                    { 8, "Oud Royale", "BAE" }
                });

            migrationBuilder.UpdateData(
                table: "Parfumler",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Aciklama", "Ad", "AltNotalar", "Cinsiyet", "EskiFiyat", "Fiyat", "KalpNotalar", "KokuAilesi", "Konsantrasyon", "Renk", "SiseTipi", "Stok", "UstNotalar", "Yeni" },
                values: new object[] { "Ay ışığında açan beyaz çiçeklerden ilham alan, yumuşak ve tenle bütünleşen bir koku.", "Lune Blanche", "Beyaz misk, Kaşmir ağacı", "Kadın", null, 4850.0, "Beyaz şakayık, Yasemin", "Çiçeksi", "Eau de Parfum", "#f0d5de", 1, 14, "Armut, Bergamot", false });

            migrationBuilder.UpdateData(
                table: "Parfumler",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Aciklama", "Ad", "AltNotalar", "EskiFiyat", "Fiyat", "HacimMl", "KalpNotalar", "KokuAilesi", "Konsantrasyon", "Renk", "SiseTipi", "Stok", "UstNotalar", "Yeni" },
                values: new object[] { "İpek gibi pürüzsüz gül yaprakları; gündüz için hafif ve neşeli.", "Pétale de Soie", "Misk, Sedir", 3450.0, 2950.0, 50, "Gül, Manolya", "Çiçeksi", "Eau de Toilette", "#f2b9bd", 0, 22, "Liçi, Pembe biber", false });

            migrationBuilder.UpdateData(
                table: "Parfumler",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Aciklama", "Ad", "AltNotalar", "Cinsiyet", "EskiFiyat", "Fiyat", "KalpNotalar", "KokuAilesi", "Konsantrasyon", "MarkaId", "Renk", "SiseTipi", "Stok", "UstNotalar", "Yeni" },
                values: new object[] { "Kışın bir sera bahçesinde yürümek gibi: yeşil, serin ve zarif.", "Jardin d'Hiver", "Vetiver, Yosun", "Unisex", null, 5200.0, "Lale, Süsen", "Çiçeksi", "Eau de Parfum", 1, "#cfdcc0", 2, 9, "Galbanum, Yeşil yapraklar", true });

            migrationBuilder.UpdateData(
                table: "Parfumler",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Aciklama", "Ad", "AltNotalar", "EskiFiyat", "Fiyat", "HacimMl", "KalpNotalar", "KokuAilesi", "Konsantrasyon", "MarkaId", "Renk", "SiseTipi", "Stok", "UstNotalar", "Yeni" },
                values: new object[] { "Altın tonlarında, ballı ve sıcak bir gece kokusu.", "Rêve Doré", "Vanilya, Tonka", null, 6400.0, 50, "Portakal çiçeği, Bal", "Gurme", "Extrait de Parfum", 1, "#e3b766", 3, 5, "Mandalina", true });

            migrationBuilder.UpdateData(
                table: "Parfumler",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Aciklama", "Ad", "AltNotalar", "Cinsiyet", "EskiFiyat", "Fiyat", "HacimMl", "KalpNotalar", "KokuAilesi", "Konsantrasyon", "MarkaId", "Renk", "SiseTipi", "Stok", "UstNotalar", "Yeni" },
                values: new object[] { "Kül, tütsü ve kuru odunların karanlık ve sakin dengesi.", "Cendre", "Vetiver, Sedir", "Erkek", null, 5600.0, 100, "Tütsü, Süsen", "Odunsu", "Eau de Parfum", 2, "#454a52", 0, 11, "Kakule, Karabiber", false });

            migrationBuilder.UpdateData(
                table: "Parfumler",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "Aciklama", "Ad", "AltNotalar", "EskiFiyat", "HacimMl", "KalpNotalar", "KokuAilesi", "Konsantrasyon", "MarkaId", "Renk", "SiseTipi", "Stok", "UstNotalar", "Yeni" },
                values: new object[] { "Yumuşak deri ve dumanlı odunlar; akşamlar için cesur bir imza.", "Fumée Douce", "Guaiac ağacı, Labdanum", null, 50, "Deri, Gül", "Odunsu", "Extrait de Parfum", 2, "#6a5549", 4, 6, "Huş katranı, Safran", false });

            migrationBuilder.UpdateData(
                table: "Parfumler",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "Aciklama", "Ad", "AltNotalar", "Cinsiyet", "EskiFiyat", "Fiyat", "HacimMl", "KalpNotalar", "KokuAilesi", "Konsantrasyon", "MarkaId", "Renk", "SiseTipi", "Stok", "UstNotalar", "Yeni" },
                values: new object[] { "Gece yarısı ormanında aromatik otlar ve serin yeşillik.", "Minuit Vert", "Paçuli, Meşe yosunu", "Erkek", 4600.0, 3900.0, 100, "Lavanta, Adaçayı", "Aromatik", "Eau de Toilette", 2, "#2f5d50", 2, 18, "Nane, Greyfurt", false });

            migrationBuilder.UpdateData(
                table: "Parfumler",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "Aciklama", "Ad", "AltNotalar", "Cinsiyet", "EskiFiyat", "Fiyat", "KalpNotalar", "KokuAilesi", "Konsantrasyon", "MarkaId", "Renk", "SiseTipi", "Stok", "UstNotalar", "Yeni" },
                values: new object[] { "Volkanik camdan ilham alan koyu, reçineli ve baharatlı bir koku.", "Obsidienne", "Amber, Paçuli", "Unisex", null, 6100.0, "Tütsü, Kakao", "Oryantal", "Eau de Parfum", 2, "#26232c", 3, 0, "Pembe biber", true });

            migrationBuilder.InsertData(
                table: "Parfumler",
                columns: new[] { "Id", "Aciklama", "Ad", "AltNotalar", "Cinsiyet", "EskiFiyat", "Fiyat", "HacimMl", "KalpNotalar", "KokuAilesi", "Konsantrasyon", "MarkaId", "Renk", "SiseTipi", "Stok", "UstNotalar", "Yeni" },
                values: new object[,]
                {
                    { 9, "Pralin ve kirazla tatlı bir İtalyan gecesi.", "Dolce Notte", "Vanilya, Kaşmir", "Kadın", null, 4400.0, 100, "Pralin, Yasemin", "Gurme", "Eau de Parfum", 3, "#b9785b", 1, 16, "Kiraz, Badem", false },
                    { 10, "Kadifemsi espresso ve kakao; sıcak ve sarmalayıcı.", "Caffè Velluto", "Tonka, Benzoin", "Unisex", 5400.0, 4750.0, 100, "Kakao, Süsen", "Gurme", "Eau de Parfum", 3, "#6b4a35", 0, 12, "Kahve, Kakule", false },
                    { 11, "Bademli likör ve pudralı gül; oyunbaz ve şık.", "Amaretto Rosa", "Vanilya, Misk", "Kadın", null, 2800.0, 50, "Gül, Heliotrop", "Gurme", "Eau de Toilette", 3, "#e39f9b", 4, 25, "Badem, Bergamot", true },
                    { 12, "Amberle parlayan ipeksi bir dokunuş.", "Seta Ambrata", "Sandal ağacı, Vanilya", "Kadın", null, 6900.0, 50, "Amber, Gül", "Oryantal", "Extrait de Parfum", 3, "#c8894a", 3, 7, "Safran", false },
                    { 13, "Buzul sularının berraklığı; ferah ve enerjik.", "Fjord", "Beyaz yosun, Sedir", "Erkek", null, 3300.0, 100, "Ardıç, Biberiye", "Ferah", "Eau de Toilette", 4, "#8fc0d6", 2, 30, "Deniz notaları, Limon", false },
                    { 14, "Gece yarısı güneşi: parlak narenciye ve sıcak bir son.", "Midnattsol", "Amber, Misk", "Unisex", null, 4200.0, 100, "Portakal çiçeği, Beyaz çay", "Ferah", "Eau de Parfum", 4, "#efd98a", 1, 15, "Greyfurt, Yuzu", true },
                    { 15, "Taze yağmış kar kadar temiz ve sade.", "Snö", "Beyaz misk", "Kadın", 3100.0, 2600.0, 50, "Zambak, Pamuk çiçeği", "Ferah", "Eau de Toilette", 4, "#dfe7ec", 0, 20, "Aldehitler, Armut", false },
                    { 16, "Ladin ormanında bir sabah yürüyüşü.", "Granskog", "Vetiver, Sedir", "Erkek", null, 4500.0, 100, "Ladin, Ardıç", "Odunsu", "Eau de Parfum", 4, "#4b6b4f", 4, 10, "Çam iğnesi, Bergamot", false },
                    { 17, "Valensiya portakal bahçelerinden güneşli bir esinti.", "Sol de Valencia", "Misk", "Unisex", null, 3100.0, 100, "Portakal çiçeği, Fesleğen", "Ferah", "Eau de Toilette", 5, "#f0a03a", 2, 28, "Portakal, Limon", false },
                    { 18, "Tütün yaprakları ve sıcak amberle asil bir koku.", "Ámbar Real", "Vanilya, Deri", "Erkek", null, 5400.0, 100, "Amber, Tütün", "Oryantal", "Eau de Parfum", 5, "#b8642b", 0, 9, "Tarçın, Mandalina", false },
                    { 19, "Portakal çiçeğinin beyaz ve ışıltılı yüzü.", "Flor de Azahar", "Misk", "Kadın", 4900.0, 4300.0, 100, "Portakal çiçeği, Yasemin", "Çiçeksi", "Eau de Parfum", 5, "#f2d3b3", 1, 13, "Neroli", false },
                    { 20, "Endülüs gecelerinin tutkulu, koyu kırmızı hikâyesi.", "Noche Andaluza", "Ud, Amber", "Kadın", null, 6300.0, 50, "Gül, Safran", "Oryantal", "Extrait de Parfum", 5, "#7b2d3a", 3, 4, "Kırmızı meyveler", true },
                    { 21, "Japon çay seremonisinin sakinliği; dengeli ve temiz.", "Ocha", "Misk", "Unisex", null, 3600.0, 100, "Yasemin çayı, Mate", "Aromatik", "Eau de Toilette", 6, "#a3bb83", 0, 19, "Yeşil çay, Bergamot", false },
                    { 22, "Hinoki ağacından banyolar; sıcak, kuru ve meditatif.", "Hinoki", "Sedir, Misk", "Unisex", null, 4900.0, 100, "Hinoki ağacı, Tütsü", "Odunsu", "Eau de Parfum", 6, "#d2b285", 2, 8, "Yuzu", false },
                    { 23, "Kiraz çiçeklerine yağan bir ilkbahar yağmuru.", "Sakura Ame", "Beyaz misk", "Kadın", null, 2700.0, 50, "Şakayık, Manolya", "Çiçeksi", "Eau de Toilette", 6, "#f1c3cf", 4, 24, "Kiraz çiçeği, Yağmur notaları", true },
                    { 24, "Mürekkep siyahı ve aromatik otların minimalist uyumu.", "Kuro", "Ambroksan, Vetiver", "Erkek", 5000.0, 4400.0, 100, "Lavanta, Siyah çay", "Aromatik", "Eau de Parfum", 6, "#2e2f33", 3, 12, "Shiso, Kakule", false },
                    { 25, "Isparta'nın gül tarlalarından, sabah çiğiyle toplanmış gül.", "Isparta Gülü", "Misk, Paçuli", "Kadın", null, 3900.0, 100, "Gül, Şakayık", "Çiçeksi", "Eau de Parfum", 7, "#d45f77", 1, 21, "Pembe biber, Liçi", false },
                    { 26, "Peri bacalarının üzerinde gün doğumu: sıcak taş ve kayısı.", "Kapadokya", "Sedir, Amber", "Unisex", null, 4600.0, 100, "Tütsü, Kuru incir", "Odunsu", "Eau de Parfum", 7, "#c98f62", 0, 10, "Kayısı, Safran", true },
                    { 27, "Ege'de bir incir ağacının gölgesi.", "İncir Bahçesi", "Sedir", "Unisex", 3700.0, 3200.0, 100, "İncir, Hindistan cevizi sütü", "Ferah", "Eau de Toilette", 7, "#8fa36a", 2, 26, "İncir yaprağı, Bergamot", false },
                    { 28, "İpek Yolu kervanlarından baharat ve deri.", "Safran Yolu", "Ud, Amber", "Erkek", null, 5800.0, 50, "Deri, Tütsü", "Oryantal", "Extrait de Parfum", 7, "#a3442f", 4, 6, "Safran, Kakule", false },
                    { 29, "Geleneksel bir mecliste yanan ud ve tütsü.", "Majlis", "Amber, Misk", "Unisex", null, 9800.0, 50, "Ud, Tütsü", "Oryantal", "Extrait de Parfum", 8, "#4a2c2a", 3, 5, "Safran, Gül", false },
                    { 30, "Çöl gecesinin sıcaklığı; hurma, tütün ve ud.", "Sahra Gecesi", "Vanilya, Amber", "Erkek", 8200.0, 7400.0, 100, "Ud, Tütün", "Oryantal", "Eau de Parfum", 8, "#8c5a2b", 0, 8, "Tarçın, Hurma", false },
                    { 31, "Taif gülüyle yumuşatılmış ışıltılı bir ud.", "Lulu Rose", "Misk, Sandal ağacı", "Kadın", null, 6800.0, 100, "Taif gülü, Ud", "Çiçeksi", "Eau de Parfum", 8, "#c97a8f", 1, 9, "Bergamot", true },
                    { 32, "Ud ve ambergrinin yoğun, uzun ömürlü buluşması.", "Anbar", "Ambergris, Labdanum", "Erkek", null, 8900.0, 50, "Ud, Sedir", "Odunsu", "Extrait de Parfum", 8, "#2b2420", 2, 3, "Karabiber", false }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Parfumler",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Parfumler",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Parfumler",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Parfumler",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Parfumler",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Parfumler",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Parfumler",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Parfumler",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Parfumler",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Parfumler",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Parfumler",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Parfumler",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Parfumler",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Parfumler",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "Parfumler",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "Parfumler",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "Parfumler",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "Parfumler",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "Parfumler",
                keyColumn: "Id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "Parfumler",
                keyColumn: "Id",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "Parfumler",
                keyColumn: "Id",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "Parfumler",
                keyColumn: "Id",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "Parfumler",
                keyColumn: "Id",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "Parfumler",
                keyColumn: "Id",
                keyValue: 32);

            migrationBuilder.DeleteData(
                table: "Markalar",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Markalar",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Markalar",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Markalar",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DropColumn(
                name: "AltNotalar",
                table: "Parfumler");

            migrationBuilder.DropColumn(
                name: "EskiFiyat",
                table: "Parfumler");

            migrationBuilder.DropColumn(
                name: "KalpNotalar",
                table: "Parfumler");

            migrationBuilder.DropColumn(
                name: "KokuAilesi",
                table: "Parfumler");

            migrationBuilder.DropColumn(
                name: "Konsantrasyon",
                table: "Parfumler");

            migrationBuilder.DropColumn(
                name: "Renk",
                table: "Parfumler");

            migrationBuilder.DropColumn(
                name: "SiseTipi",
                table: "Parfumler");

            migrationBuilder.DropColumn(
                name: "UstNotalar",
                table: "Parfumler");

            migrationBuilder.DropColumn(
                name: "Yeni",
                table: "Parfumler");

            migrationBuilder.UpdateData(
                table: "Markalar",
                keyColumn: "Id",
                keyValue: 1,
                column: "Ad",
                value: "Chanel");

            migrationBuilder.UpdateData(
                table: "Markalar",
                keyColumn: "Id",
                keyValue: 2,
                column: "Ad",
                value: "Dior");

            migrationBuilder.UpdateData(
                table: "Markalar",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Ad", "Ulke" },
                values: new object[] { "Tom Ford", "ABD" });

            migrationBuilder.UpdateData(
                table: "Markalar",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Ad", "Ulke" },
                values: new object[] { "Yves Saint Laurent", "Fransa" });

            migrationBuilder.UpdateData(
                table: "Parfumler",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Aciklama", "Ad", "Cinsiyet", "Fiyat", "Stok" },
                values: new object[] { "Odunsu ve aromatik, günlük kullanıma uygun.", "Bleu de Chanel", "Erkek", 5200.0, 12 });

            migrationBuilder.UpdateData(
                table: "Parfumler",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Aciklama", "Ad", "Fiyat", "HacimMl", "Stok" },
                values: new object[] { "Taze çiçeksi ve oryantal notalar.", "Coco Mademoiselle", 5600.0, 100, 8 });

            migrationBuilder.UpdateData(
                table: "Parfumler",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Aciklama", "Ad", "Cinsiyet", "Fiyat", "MarkaId", "Stok" },
                values: new object[] { "Bergamot ve ambroksan ile ferah bir koku.", "Sauvage", "Erkek", 4800.0, 2, 20 });

            migrationBuilder.UpdateData(
                table: "Parfumler",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Aciklama", "Ad", "Fiyat", "HacimMl", "MarkaId", "Stok" },
                values: new object[] { "Yasemin ve gül ağırlıklı çiçeksi koku.", "J'adore", 5400.0, 100, 2, 6 });

            migrationBuilder.UpdateData(
                table: "Parfumler",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Aciklama", "Ad", "Cinsiyet", "Fiyat", "HacimMl", "MarkaId", "Stok" },
                values: new object[] { "Ud, sandal ağacı ve baharat notaları.", "Oud Wood", "Unisex", 9800.0, 50, 3, 4 });

            migrationBuilder.UpdateData(
                table: "Parfumler",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "Aciklama", "Ad", "HacimMl", "MarkaId", "Stok" },
                values: new object[] { "Koyu, yoğun ve gizemli bir akşam kokusu.", "Black Orchid", 100, 3, 5 });

            migrationBuilder.UpdateData(
                table: "Parfumler",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "Aciklama", "Ad", "Cinsiyet", "Fiyat", "HacimMl", "MarkaId", "Stok" },
                values: new object[] { "Lavanta ve portakal çiçeği ile modern bir koku.", "Libre", "Kadın", 5000.0, 90, 4, 10 });

            migrationBuilder.UpdateData(
                table: "Parfumler",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "Aciklama", "Ad", "Cinsiyet", "Fiyat", "MarkaId", "Stok" },
                values: new object[] { "Elma, adaçayı ve odunsu notalar.", "Y Eau de Parfum", "Erkek", 4600.0, 4, 15 });
        }
    }
}
