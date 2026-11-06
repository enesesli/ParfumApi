using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ParfumApi.Migrations
{
    /// <inheritdoc />
    public partial class GercekKatalog : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<string>(
                name: "GorselYolu",
                table: "Parfumler",
                type: "TEXT",
                nullable: true);

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
                table: "Markalar",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Ad", "Ulke" },
                values: new object[] { "Giorgio Armani", "İtalya" });

            migrationBuilder.UpdateData(
                table: "Markalar",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "Ad", "Ulke" },
                values: new object[] { "Lancôme", "Fransa" });

            migrationBuilder.UpdateData(
                table: "Markalar",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "Ad", "Ulke" },
                values: new object[] { "Maison Francis Kurkdjian", "Fransa" });

            migrationBuilder.UpdateData(
                table: "Markalar",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "Ad", "Ulke" },
                values: new object[] { "Creed", "Fransa" });

            migrationBuilder.UpdateData(
                table: "Markalar",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "Ad", "Ulke" },
                values: new object[] { "Rabanne", "İspanya" });

            migrationBuilder.UpdateData(
                table: "Markalar",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "Ad", "Ulke" },
                values: new object[] { "Versace", "İtalya" });

            migrationBuilder.UpdateData(
                table: "Parfumler",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Aciklama", "Ad", "AltNotalar", "Cinsiyet", "Fiyat", "GorselYolu", "KalpNotalar", "KokuAilesi", "Renk", "SiseTipi", "UstNotalar" },
                values: new object[] { "Narenciyenin ferahlığıyla açılan, odunsu ve aromatik bir erkek klasiği.", "Bleu de Chanel", "Tütsü, Sedir, Sandal ağacı, Vetiver", "Erkek", 7900.0, null, "Zencefil, Yasemin, Muskat", "Odunsu", "#2f3d5c", 0, "Greyfurt, Limon, Nane, Pembe biber" });

            migrationBuilder.UpdateData(
                table: "Parfumler",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Aciklama", "Ad", "AltNotalar", "EskiFiyat", "Fiyat", "GorselYolu", "HacimMl", "KalpNotalar", "Konsantrasyon", "Renk", "Stok", "UstNotalar" },
                values: new object[] { "Taze narenciye ve gül ile başlayan, paçulinin derinleştirdiği modern bir şipr.", "Coco Mademoiselle", "Paçuli, Vetiver, Vanilya, Beyaz misk", null, 8400.0, null, 100, "Gül, Yasemin, Liçi", "Eau de Parfum", "#e8b9a0", 10, "Portakal, Bergamot, Greyfurt" });

            migrationBuilder.UpdateData(
                table: "Parfumler",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Aciklama", "Ad", "AltNotalar", "Cinsiyet", "Fiyat", "GorselYolu", "KalpNotalar", "Renk", "SiseTipi", "Stok", "UstNotalar", "Yeni" },
                values: new object[] { "Aldehitlerin ışıltısıyla tanınan, çiçek buketi biçiminde efsanevi bir koku.", "N°5", "Sandal ağacı, Vanilya, Vetiver", "Kadın", 8900.0, null, "Gül, Yasemin, Süsen", "#f0d8a0", 0, 7, "Aldehitler, Neroli, Bergamot", false });

            migrationBuilder.UpdateData(
                table: "Parfumler",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Aciklama", "Ad", "AltNotalar", "EskiFiyat", "Fiyat", "GorselYolu", "HacimMl", "KalpNotalar", "KokuAilesi", "Konsantrasyon", "Renk", "SiseTipi", "Stok", "UstNotalar", "Yeni" },
                values: new object[] { "Meyveli ve çiçeksi; yumuşak, pastel tonlarda neşeli bir koku.", "Chance Eau Tendre", "Süsen, Sedir, Beyaz misk", 7600.0, 6900.0, null, 100, "Yasemin, Sümbül", "Çiçeksi", "Eau de Toilette", "#f3c6c9", 1, 12, "Ayva, Greyfurt", false });

            migrationBuilder.UpdateData(
                table: "Parfumler",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Aciklama", "Ad", "AltNotalar", "Fiyat", "GorselYolu", "KalpNotalar", "KokuAilesi", "Konsantrasyon", "Renk", "Stok", "UstNotalar" },
                values: new object[] { "Kalabriya bergamotu ve ambroksanla ferah, baharatlı ve güçlü bir iz.", "Sauvage", "Ambroksan, Sedir, Labdanum", 6800.0, null, "Sichuan biberi, Lavanta, Geranyum", "Aromatik", "Eau de Toilette", "#9fb8d6", 22, "Bergamot, Karabiber" });

            migrationBuilder.UpdateData(
                table: "Parfumler",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "Aciklama", "Ad", "AltNotalar", "Cinsiyet", "Fiyat", "GorselYolu", "HacimMl", "KalpNotalar", "KokuAilesi", "Konsantrasyon", "Renk", "SiseTipi", "Stok", "UstNotalar" },
                values: new object[] { "Altın tonlu, parlak ve zarif bir beyaz çiçek buketi.", "J'adore", "Misk, Vanilya, Sedir", "Kadın", 8200.0, null, 100, "Yasemin, Gül, Tuberoz", "Çiçeksi", "Eau de Parfum", "#f2d27a", 1, 11, "Armut, Kavun, Bergamot" });

            migrationBuilder.UpdateData(
                table: "Parfumler",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "Aciklama", "Ad", "AltNotalar", "Cinsiyet", "EskiFiyat", "Fiyat", "GorselYolu", "KalpNotalar", "KokuAilesi", "Konsantrasyon", "Renk", "SiseTipi", "Stok", "UstNotalar", "Yeni" },
                values: new object[] { "Romantik bir gül ve şakayık buketi; pudralı ve aşık bir koku.", "Miss Dior", "Misk, Vanilya", "Kadın", null, 7700.0, null, "Gül, Şakayık, Süsen", "Çiçeksi", "Eau de Parfum", "#f0b2c0", 1, 9, "Mandalina, Pembe biber", true });

            migrationBuilder.UpdateData(
                table: "Parfumler",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "Aciklama", "Ad", "AltNotalar", "Cinsiyet", "EskiFiyat", "Fiyat", "GorselYolu", "KalpNotalar", "KokuAilesi", "Konsantrasyon", "Renk", "Stok", "UstNotalar", "Yeni" },
                values: new object[] { "Menekşe yaprağı ve derinin cesur, benzersiz uyumu.", "Fahrenheit", "Deri, Vetiver, Misk", "Erkek", 7000.0, 6300.0, null, "Menekşe yaprağı, Hanımeli, Sedir", "Odunsu", "Eau de Toilette", "#b0412c", 8, "Muskat, Lavanta, Mandalina", false });

            migrationBuilder.UpdateData(
                table: "Parfumler",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "Aciklama", "Ad", "AltNotalar", "Fiyat", "GorselYolu", "KalpNotalar", "Konsantrasyon", "MarkaId", "Renk", "SiseTipi", "Stok", "UstNotalar" },
                values: new object[] { "Bademli ve vanilyalı, baştan çıkarıcı bir akşam kokusu.", "Hypnotic Poison", "Badem, Vanilya, Sandal ağacı, Misk", 6900.0, null, "Yasemin, Tuberoz, Gül", "Eau de Toilette", 2, "#7a1f2b", 3, 6, "Hindistan cevizi, Erik, Kayısı" });

            migrationBuilder.UpdateData(
                table: "Parfumler",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "Aciklama", "Ad", "AltNotalar", "EskiFiyat", "Fiyat", "GorselYolu", "HacimMl", "KalpNotalar", "KokuAilesi", "Renk", "Stok", "UstNotalar" },
                values: new object[] { "Ud'un dumanlı tarafını yumuşak odunlarla dengeleyen rafine bir koku.", "Oud Wood", "Tonka, Vanilya, Amber", null, 14500.0, null, 50, "Sandal ağacı, Vetiver, Çin biberi", "Odunsu", "#5a3a2a", 5, "Ud, Gül ağacı, Kakule" });

            migrationBuilder.UpdateData(
                table: "Parfumler",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "Aciklama", "Ad", "AltNotalar", "Fiyat", "GorselYolu", "HacimMl", "KalpNotalar", "KokuAilesi", "Konsantrasyon", "Renk", "SiseTipi", "Stok", "UstNotalar", "Yeni" },
                values: new object[] { "Koyu, gizemli ve lüks; siyah orkide ve trüfle yoğun bir koku.", "Black Orchid", "Paçuli, Kakao, Tütsü, Vanilya", 12900.0, null, 100, "Orkide, Baharatlar, Lotus", "Oryantal", "Eau de Parfum", "#2a1c2e", 3, 4, "Trüf, Bergamot, Siyah frenk üzümü", false });

            migrationBuilder.UpdateData(
                table: "Parfumler",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "Aciklama", "Ad", "AltNotalar", "Cinsiyet", "Fiyat", "GorselYolu", "KalpNotalar", "KokuAilesi", "Konsantrasyon", "Renk", "SiseTipi", "Stok", "UstNotalar" },
                values: new object[] { "Tütün yaprağı ve vanilyanın sıcak, kremsi ve zengin buluşması.", "Tobacco Vanille", "Kuru meyve, Odunsu notalar", "Unisex", 15500.0, null, "Vanilya, Kakao, Tonka", "Gurme", "Eau de Parfum", "#8a5a2b", 0, 6, "Tütün yaprağı, Baharatlar" });

            migrationBuilder.UpdateData(
                table: "Parfumler",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "Aciklama", "Ad", "AltNotalar", "Cinsiyet", "Fiyat", "GorselYolu", "HacimMl", "KalpNotalar", "KokuAilesi", "Konsantrasyon", "MarkaId", "Renk", "SiseTipi", "Stok", "UstNotalar" },
                values: new object[] { "Olgun vişne ve bademle tatlı ama derin bir koku.", "Lost Cherry", "Peru balsamı, Tonka, Sandal ağacı, Vetiver", "Unisex", 17500.0, null, 50, "Vişne likörü, Türk gülü, Yasemin", "Gurme", "Eau de Parfum", 3, "#9e1b2c", 0, 3, "Vişne, Acı badem" });

            migrationBuilder.UpdateData(
                table: "Parfumler",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "Aciklama", "Ad", "AltNotalar", "EskiFiyat", "Fiyat", "GorselYolu", "KalpNotalar", "KokuAilesi", "MarkaId", "Renk", "SiseTipi", "Stok", "UstNotalar", "Yeni" },
                values: new object[] { "Yumuşak deri ve kakuleyle çölü andıran sıcak bir koku.", "Ombré Leather", "Amber, Yosun, Paçuli", 15500.0, 13900.0, null, "Deri, Yasemin", "Odunsu", 3, "#3a2e28", 0, 5, "Kakule", false });

            migrationBuilder.UpdateData(
                table: "Parfumler",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "Aciklama", "Ad", "AltNotalar", "EskiFiyat", "Fiyat", "GorselYolu", "HacimMl", "KalpNotalar", "KokuAilesi", "Konsantrasyon", "Renk", "SiseTipi", "Stok", "UstNotalar", "Yeni" },
                values: new object[] { "Lavanta ile portakal çiçeğinin cesur ve özgür buluşması.", "Libre", "Vanilya, Misk, Sedir, Amber", null, 7600.0, null, 90, "Portakal çiçeği, Yasemin", "Çiçeksi", "Eau de Parfum", "#e9c46a", 3, 13, "Lavanta, Mandalina, Siyah frenk üzümü", true });

            migrationBuilder.UpdateData(
                table: "Parfumler",
                keyColumn: "Id",
                keyValue: 16,
                columns: new[] { "Aciklama", "Ad", "AltNotalar", "Cinsiyet", "EskiFiyat", "Fiyat", "GorselYolu", "HacimMl", "KalpNotalar", "KokuAilesi", "Renk", "Stok", "UstNotalar" },
                values: new object[] { "Kahve ve vanilyayla enerjik, bağımlılık yapan bir gece kokusu.", "Black Opium", "Vanilya, Paçuli, Sedir", "Kadın", 8200.0, 7400.0, null, 90, "Kahve, Yasemin", "Gurme", "#1d1a24", 15, "Armut, Pembe biber, Portakal çiçeği" });

            migrationBuilder.UpdateData(
                table: "Parfumler",
                keyColumn: "Id",
                keyValue: 17,
                columns: new[] { "Aciklama", "Ad", "AltNotalar", "Cinsiyet", "Fiyat", "GorselYolu", "KalpNotalar", "KokuAilesi", "Konsantrasyon", "MarkaId", "Renk", "Stok", "UstNotalar", "Yeni" },
                values: new object[] { "Ferah elma ve adaçayının odunsu bir tabana oturduğu modern erkek kokusu.", "Y", "Tonka, Sedir, Vetiver, Tütsü", "Erkek", 7200.0, null, "Adaçayı, Ardıç, Geranyum", "Aromatik", "Eau de Parfum", 4, "#2e4a7a", 16, "Elma, Zencefil, Bergamot", true });

            migrationBuilder.UpdateData(
                table: "Parfumler",
                keyColumn: "Id",
                keyValue: 18,
                columns: new[] { "Aciklama", "Ad", "AltNotalar", "Fiyat", "GorselYolu", "KalpNotalar", "KokuAilesi", "Konsantrasyon", "MarkaId", "Renk", "Stok", "UstNotalar" },
                values: new object[] { "Kakule ve lavantayla baştan çıkarıcı, zarif bir gece kokusu.", "La Nuit de L'Homme", "Vetiver, Kimyon", 6600.0, null, "Lavanta, Sedir", "Aromatik", "Eau de Toilette", 4, "#24263a", 0, "Kakule, Bergamot" });

            migrationBuilder.UpdateData(
                table: "Parfumler",
                keyColumn: "Id",
                keyValue: 19,
                columns: new[] { "Aciklama", "Ad", "AltNotalar", "Cinsiyet", "EskiFiyat", "Fiyat", "GorselYolu", "KalpNotalar", "KokuAilesi", "Konsantrasyon", "Renk", "SiseTipi", "Stok", "UstNotalar" },
                values: new object[] { "Akdeniz'in tuzlu ve güneşli ferahlığı; zamansız bir yaz kokusu.", "Acqua di Giò", "Beyaz misk, Sedir, Paçuli", "Erkek", 6900.0, 6200.0, null, "Deniz notaları, Yasemin, Biberiye", "Ferah", "Eau de Toilette", "#a8d0e0", 2, 25, "Limon, Bergamot, Neroli" });

            migrationBuilder.UpdateData(
                table: "Parfumler",
                keyColumn: "Id",
                keyValue: 20,
                columns: new[] { "Aciklama", "Ad", "AltNotalar", "Fiyat", "GorselYolu", "HacimMl", "KalpNotalar", "KokuAilesi", "Konsantrasyon", "Renk", "SiseTipi", "Stok", "UstNotalar", "Yeni" },
                values: new object[] { "Siyah frenk üzümü ve vanilyayla zarif ve güçlü bir kadın kokusu.", "Sì", "Vanilya, Paçuli, Amber odunu", 7300.0, null, 100, "Gül, Frezya", "Gurme", "Eau de Parfum", "#e7b9a8", 0, 12, "Siyah frenk üzümü", false });

            migrationBuilder.UpdateData(
                table: "Parfumler",
                keyColumn: "Id",
                keyValue: 21,
                columns: new[] { "Aciklama", "Ad", "AltNotalar", "Cinsiyet", "Fiyat", "GorselYolu", "HacimMl", "KalpNotalar", "KokuAilesi", "MarkaId", "Renk", "SiseTipi", "Stok", "UstNotalar" },
                values: new object[] { "Zeytin çiçeği ve tonkayla baştan çıkarıcı, şık bir akşam kokusu.", "Armani Code", "Tonka, Deri, Tütün", "Erkek", 6400.0, null, 75, "Zeytin çiçeği, Yıldız anason", "Oryantal", 5, "#2b2b2b", 4, 9, "Bergamot, Limon" });

            migrationBuilder.UpdateData(
                table: "Parfumler",
                keyColumn: "Id",
                keyValue: 22,
                columns: new[] { "Aciklama", "Ad", "AltNotalar", "Cinsiyet", "Fiyat", "GorselYolu", "HacimMl", "KalpNotalar", "KokuAilesi", "MarkaId", "Renk", "SiseTipi", "Stok", "UstNotalar", "Yeni" },
                values: new object[] { "Beyaz çiçeklerle aydınlık ve pozitif bir koku.", "My Way", "Vanilya, Beyaz misk, Sedir", "Kadın", 7100.0, null, 90, "Tuberoz, Yasemin", "Çiçeksi", 5, "#f1dfe6", 1, 14, "Bergamot, Portakal çiçeği", true });

            migrationBuilder.UpdateData(
                table: "Parfumler",
                keyColumn: "Id",
                keyValue: 23,
                columns: new[] { "Aciklama", "Ad", "AltNotalar", "EskiFiyat", "Fiyat", "GorselYolu", "HacimMl", "KalpNotalar", "KokuAilesi", "Konsantrasyon", "Renk", "SiseTipi", "Stok", "UstNotalar", "Yeni" },
                values: new object[] { "Süsen ve pralinle tatlı, mutlu ve tanınır bir imza.", "La Vie Est Belle", "Pralin, Vanilya, Paçuli, Tonka", 8600.0, 7800.0, null, 100, "Süsen, Yasemin, Portakal çiçeği", "Gurme", "Eau de Parfum", "#f2a6b6", 1, 18, "Siyah frenk üzümü, Armut", false });

            migrationBuilder.UpdateData(
                table: "Parfumler",
                keyColumn: "Id",
                keyValue: 24,
                columns: new[] { "Aciklama", "Ad", "AltNotalar", "Cinsiyet", "EskiFiyat", "Fiyat", "GorselYolu", "HacimMl", "KalpNotalar", "KokuAilesi", "Renk", "SiseTipi", "Stok", "UstNotalar", "Yeni" },
                values: new object[] { "Temiz gül ve yasemin; hafif ve modern bir çiçek kokusu.", "Idôle", "Beyaz misk, Vanilya, Sedir", "Kadın", null, 5600.0, null, 50, "Gül, Yasemin", "Çiçeksi", "#f0d3c8", 2, 11, "Armut, Bergamot, Pembe biber", true });

            migrationBuilder.UpdateData(
                table: "Parfumler",
                keyColumn: "Id",
                keyValue: 25,
                columns: new[] { "Aciklama", "Ad", "AltNotalar", "EskiFiyat", "Fiyat", "GorselYolu", "KalpNotalar", "MarkaId", "Renk", "SiseTipi", "Stok", "UstNotalar" },
                values: new object[] { "Şeftali ve gülle pudralı, romantik bir klasik.", "Trésor", "Amber, Vanilya, Misk, Sandal ağacı", 7200.0, 6500.0, null, "Gül, Süsen, Leylak", 6, "#f1c7b0", 3, 7, "Şeftali, Kayısı, Bergamot" });

            migrationBuilder.UpdateData(
                table: "Parfumler",
                keyColumn: "Id",
                keyValue: 26,
                columns: new[] { "Aciklama", "Ad", "AltNotalar", "Fiyat", "GorselYolu", "HacimMl", "KalpNotalar", "KokuAilesi", "Renk", "SiseTipi", "Stok", "UstNotalar", "Yeni" },
                values: new object[] { "Safran ve amber odunuyla havada asılı kalan, ışıltılı bir imza.", "Baccarat Rouge 540", "Köknar reçinesi, Sedir", 18900.0, null, 70, "Amber odunu, Ambergris", "Oryantal", "#c0542f", 3, 4, "Safran, Yasemin", false });

            migrationBuilder.UpdateData(
                table: "Parfumler",
                keyColumn: "Id",
                keyValue: 27,
                columns: new[] { "Aciklama", "Ad", "AltNotalar", "EskiFiyat", "Fiyat", "GorselYolu", "HacimMl", "KalpNotalar", "Renk", "SiseTipi", "Stok", "UstNotalar" },
                values: new object[] { "Tertemiz çamaşır ferahlığı; sade, ışıklı ve evrensel.", "Aqua Universalis", "Beyaz misk, Odunsu notalar", null, 11900.0, null, 70, "Müge çiçeği", "#e8f1f2", 0, 8, "Bergamot, Limon" });

            migrationBuilder.UpdateData(
                table: "Parfumler",
                keyColumn: "Id",
                keyValue: 28,
                columns: new[] { "Aciklama", "Ad", "AltNotalar", "Cinsiyet", "Fiyat", "GorselYolu", "HacimMl", "KalpNotalar", "Konsantrasyon", "Renk", "SiseTipi", "Stok", "UstNotalar", "Yeni" },
                values: new object[] { "Saten gibi pürüzsüz bir gül ve ud; kadifemsi ve zengin.", "Oud Satin Mood", "Vanilya, Benzoin", "Unisex", 19900.0, null, 70, "Gül, Ud", "Eau de Parfum", "#6b2a3a", 0, 3, "Menekşe", true });

            migrationBuilder.UpdateData(
                table: "Parfumler",
                keyColumn: "Id",
                keyValue: 29,
                columns: new[] { "Aciklama", "Ad", "AltNotalar", "Cinsiyet", "Fiyat", "GorselYolu", "HacimMl", "KalpNotalar", "KokuAilesi", "Konsantrasyon", "Renk", "SiseTipi", "Stok", "UstNotalar" },
                values: new object[] { "Ananas ve huş dumanıyla güçlü, meyveli ve tanınır bir erkek kokusu.", "Aventus", "Misk, Meşe yosunu, Ambergris, Vanilya", "Erkek", 22500.0, null, 100, "Huş katranı, Paçuli, Yasemin", "Odunsu", "Eau de Parfum", "#e9e4d6", 0, 6, "Ananas, Bergamot, Siyah frenk üzümü, Elma" });

            migrationBuilder.UpdateData(
                table: "Parfumler",
                keyColumn: "Id",
                keyValue: 30,
                columns: new[] { "Aciklama", "Ad", "AltNotalar", "Cinsiyet", "EskiFiyat", "Fiyat", "GorselYolu", "KalpNotalar", "KokuAilesi", "Renk", "SiseTipi", "Stok", "UstNotalar" },
                values: new object[] { "Dağ derelerinin serinliği; yeşil çay ve narenciyeyle berrak bir koku.", "Silver Mountain Water", "Misk, Sandal ağacı", "Unisex", 21500.0, 19500.0, null, "Yeşil çay, Siyah frenk üzümü", "Ferah", "#c9dde6", 2, 5, "Bergamot, Mandalina" });

            migrationBuilder.UpdateData(
                table: "Parfumler",
                keyColumn: "Id",
                keyValue: 31,
                columns: new[] { "Aciklama", "Ad", "AltNotalar", "Cinsiyet", "Fiyat", "GorselYolu", "KalpNotalar", "KokuAilesi", "Renk", "SiseTipi", "Stok", "UstNotalar", "Yeni" },
                values: new object[] { "Yeşil çayırlar ve menekşe yaprağıyla zarif bir centilmen kokusu.", "Green Irish Tweed", "Ambergris, Sandal ağacı", "Erkek", 19500.0, null, "Süsen, Menekşe yaprağı", "Aromatik", "#7c9a6a", 2, 4, "Limon otu, Nane", false });

            migrationBuilder.UpdateData(
                table: "Parfumler",
                keyColumn: "Id",
                keyValue: 32,
                columns: new[] { "Aciklama", "Ad", "AltNotalar", "Fiyat", "GorselYolu", "HacimMl", "KalpNotalar", "KokuAilesi", "Konsantrasyon", "MarkaId", "Renk", "SiseTipi", "Stok", "UstNotalar" },
                values: new object[] { "Tarçın ve deriyle baharatlı, tatlı ve göz alıcı bir koku.", "1 Million", "Deri, Amber, Paçuli", 5900.0, null, 100, "Tarçın, Gül, Baharatlar", "Oryantal", "Eau de Toilette", 9, "#d4a43a", 4, 20, "Greyfurt, Nane, Kan portakalı" });

            migrationBuilder.InsertData(
                table: "Parfumler",
                columns: new[] { "Id", "Aciklama", "Ad", "AltNotalar", "Cinsiyet", "EskiFiyat", "Fiyat", "GorselYolu", "HacimMl", "KalpNotalar", "KokuAilesi", "Konsantrasyon", "MarkaId", "Renk", "SiseTipi", "Stok", "UstNotalar", "Yeni" },
                values: new object[,]
                {
                    { 33, "Deniz notaları ve greyfurtla sportif, ferah bir zafer kokusu.", "Invictus", "Guaiac ağacı, Meşe yosunu, Paçuli, Ambergris", "Erkek", 6300.0, 5600.0, null, 100, "Defne yaprağı, Yasemin", "Ferah", "Eau de Toilette", 9, "#c9d4dc", 2, 19, "Greyfurt, Deniz notaları", false },
                    { 34, "Ahududu ve balla ışıltılı, iddialı bir çiçek kokusu.", "Lady Million", "Bal, Paçuli", "Kadın", null, 5800.0, null, 80, "Yasemin, Portakal çiçeği, Gardenya", "Çiçeksi", "Eau de Parfum", 9, "#f0c060", 3, 13, "Ahududu, Neroli, Limon", false },
                    { 35, "Nane ve vanilyayla ferah ama tatlı, enerjik bir koku.", "Eros", "Vanilya, Vetiver, Sedir, Meşe yosunu", "Erkek", null, 5700.0, null, 100, "Tonka, Geranyum, Ambroksan", "Aromatik", "Eau de Toilette", 10, "#4fb3b0", 4, 21, "Nane, Yeşil elma, Limon", false },
                    { 36, "Nar ve şakayıkla taze, ışıltılı ve hafif bir çiçek kokusu.", "Bright Crystal", "Misk, Maun, Amber", "Kadın", 5900.0, 5300.0, null, 90, "Şakayık, Manolya, Lotus", "Çiçeksi", "Eau de Toilette", 10, "#f4c3cf", 3, 17, "Nar, Yuzu", false },
                    { 37, "Akdeniz esintili ferah narenciye ve odunsu-amberli bir taban.", "Dylan Blue", "Misk, Tonka, Safran, Tütsü", "Erkek", null, 5400.0, null, 100, "Menekşe yaprağı, Ambroksan, Karabiber", "Ferah", "Eau de Toilette", 10, "#1f3f7a", 0, 15, "Bergamot, Greyfurt, İncir yaprağı", true }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Parfumler",
                keyColumn: "Id",
                keyValue: 33);

            migrationBuilder.DeleteData(
                table: "Parfumler",
                keyColumn: "Id",
                keyValue: 34);

            migrationBuilder.DeleteData(
                table: "Parfumler",
                keyColumn: "Id",
                keyValue: 35);

            migrationBuilder.DeleteData(
                table: "Parfumler",
                keyColumn: "Id",
                keyValue: 36);

            migrationBuilder.DeleteData(
                table: "Parfumler",
                keyColumn: "Id",
                keyValue: 37);

            migrationBuilder.DropColumn(
                name: "GorselYolu",
                table: "Parfumler");

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

            migrationBuilder.UpdateData(
                table: "Markalar",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Ad", "Ulke" },
                values: new object[] { "Casa Ámbar", "İspanya" });

            migrationBuilder.UpdateData(
                table: "Markalar",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "Ad", "Ulke" },
                values: new object[] { "Hikari", "Japonya" });

            migrationBuilder.UpdateData(
                table: "Markalar",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "Ad", "Ulke" },
                values: new object[] { "Anatolia Esans", "Türkiye" });

            migrationBuilder.UpdateData(
                table: "Markalar",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "Ad", "Ulke" },
                values: new object[] { "Oud Royale", "BAE" });

            migrationBuilder.UpdateData(
                table: "Markalar",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "Ad", "Ulke" },
                values: new object[] { "Kyma", "Yunanistan" });

            migrationBuilder.UpdateData(
                table: "Markalar",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "Ad", "Ulke" },
                values: new object[] { "Saffron & Sand", "Hindistan" });

            migrationBuilder.UpdateData(
                table: "Parfumler",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Aciklama", "Ad", "AltNotalar", "Cinsiyet", "Fiyat", "KalpNotalar", "KokuAilesi", "Renk", "SiseTipi", "UstNotalar" },
                values: new object[] { "Ay ışığında açan beyaz çiçeklerden ilham alan, yumuşak ve tenle bütünleşen bir koku.", "Lune Blanche", "Beyaz misk, Kaşmir ağacı", "Kadın", 4850.0, "Beyaz şakayık, Yasemin", "Çiçeksi", "#f0d5de", 1, "Armut, Bergamot" });

            migrationBuilder.UpdateData(
                table: "Parfumler",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Aciklama", "Ad", "AltNotalar", "EskiFiyat", "Fiyat", "HacimMl", "KalpNotalar", "Konsantrasyon", "Renk", "Stok", "UstNotalar" },
                values: new object[] { "İpek gibi pürüzsüz gül yaprakları; gündüz için hafif ve neşeli.", "Pétale de Soie", "Misk, Sedir", 3450.0, 2950.0, 50, "Gül, Manolya", "Eau de Toilette", "#f2b9bd", 22, "Liçi, Pembe biber" });

            migrationBuilder.UpdateData(
                table: "Parfumler",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Aciklama", "Ad", "AltNotalar", "Cinsiyet", "Fiyat", "KalpNotalar", "Renk", "SiseTipi", "Stok", "UstNotalar", "Yeni" },
                values: new object[] { "Kışın bir sera bahçesinde yürümek gibi: yeşil, serin ve zarif.", "Jardin d'Hiver", "Vetiver, Yosun", "Unisex", 5200.0, "Lale, Süsen", "#cfdcc0", 2, 9, "Galbanum, Yeşil yapraklar", true });

            migrationBuilder.UpdateData(
                table: "Parfumler",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Aciklama", "Ad", "AltNotalar", "EskiFiyat", "Fiyat", "HacimMl", "KalpNotalar", "KokuAilesi", "Konsantrasyon", "Renk", "SiseTipi", "Stok", "UstNotalar", "Yeni" },
                values: new object[] { "Altın tonlarında, ballı ve sıcak bir gece kokusu.", "Rêve Doré", "Vanilya, Tonka", null, 6400.0, 50, "Portakal çiçeği, Bal", "Gurme", "Extrait de Parfum", "#e3b766", 3, 5, "Mandalina", true });

            migrationBuilder.UpdateData(
                table: "Parfumler",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Aciklama", "Ad", "AltNotalar", "Fiyat", "KalpNotalar", "KokuAilesi", "Konsantrasyon", "Renk", "Stok", "UstNotalar" },
                values: new object[] { "Kül, tütsü ve kuru odunların karanlık ve sakin dengesi.", "Cendre", "Vetiver, Sedir", 5600.0, "Tütsü, Süsen", "Odunsu", "Eau de Parfum", "#454a52", 11, "Kakule, Karabiber" });

            migrationBuilder.UpdateData(
                table: "Parfumler",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "Aciklama", "Ad", "AltNotalar", "Cinsiyet", "Fiyat", "HacimMl", "KalpNotalar", "KokuAilesi", "Konsantrasyon", "Renk", "SiseTipi", "Stok", "UstNotalar" },
                values: new object[] { "Yumuşak deri ve dumanlı odunlar; akşamlar için cesur bir imza.", "Fumée Douce", "Guaiac ağacı, Labdanum", "Unisex", 7200.0, 50, "Deri, Gül", "Odunsu", "Extrait de Parfum", "#6a5549", 4, 6, "Huş katranı, Safran" });

            migrationBuilder.UpdateData(
                table: "Parfumler",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "Aciklama", "Ad", "AltNotalar", "Cinsiyet", "EskiFiyat", "Fiyat", "KalpNotalar", "KokuAilesi", "Konsantrasyon", "Renk", "SiseTipi", "Stok", "UstNotalar", "Yeni" },
                values: new object[] { "Gece yarısı ormanında aromatik otlar ve serin yeşillik.", "Minuit Vert", "Paçuli, Meşe yosunu", "Erkek", 4600.0, 3900.0, "Lavanta, Adaçayı", "Aromatik", "Eau de Toilette", "#2f5d50", 2, 18, "Nane, Greyfurt", false });

            migrationBuilder.UpdateData(
                table: "Parfumler",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "Aciklama", "Ad", "AltNotalar", "Cinsiyet", "EskiFiyat", "Fiyat", "KalpNotalar", "KokuAilesi", "Konsantrasyon", "Renk", "Stok", "UstNotalar", "Yeni" },
                values: new object[] { "Volkanik camdan ilham alan koyu, reçineli ve baharatlı bir koku.", "Obsidienne", "Amber, Paçuli", "Unisex", null, 6100.0, "Tütsü, Kakao", "Oryantal", "Eau de Parfum", "#26232c", 0, "Pembe biber", true });

            migrationBuilder.UpdateData(
                table: "Parfumler",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "Aciklama", "Ad", "AltNotalar", "Fiyat", "KalpNotalar", "Konsantrasyon", "MarkaId", "Renk", "SiseTipi", "Stok", "UstNotalar" },
                values: new object[] { "Pralin ve kirazla tatlı bir İtalyan gecesi.", "Dolce Notte", "Vanilya, Kaşmir", 4400.0, "Pralin, Yasemin", "Eau de Parfum", 3, "#b9785b", 1, 16, "Kiraz, Badem" });

            migrationBuilder.UpdateData(
                table: "Parfumler",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "Aciklama", "Ad", "AltNotalar", "EskiFiyat", "Fiyat", "HacimMl", "KalpNotalar", "KokuAilesi", "Renk", "Stok", "UstNotalar" },
                values: new object[] { "Kadifemsi espresso ve kakao; sıcak ve sarmalayıcı.", "Caffè Velluto", "Tonka, Benzoin", 5400.0, 4750.0, 100, "Kakao, Süsen", "Gurme", "#6b4a35", 12, "Kahve, Kakule" });

            migrationBuilder.UpdateData(
                table: "Parfumler",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "Aciklama", "Ad", "AltNotalar", "Fiyat", "HacimMl", "KalpNotalar", "KokuAilesi", "Konsantrasyon", "Renk", "SiseTipi", "Stok", "UstNotalar", "Yeni" },
                values: new object[] { "Bademli likör ve pudralı gül; oyunbaz ve şık.", "Amaretto Rosa", "Vanilya, Misk", 2800.0, 50, "Gül, Heliotrop", "Gurme", "Eau de Toilette", "#e39f9b", 4, 25, "Badem, Bergamot", true });

            migrationBuilder.UpdateData(
                table: "Parfumler",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "Aciklama", "Ad", "AltNotalar", "Cinsiyet", "Fiyat", "KalpNotalar", "KokuAilesi", "Konsantrasyon", "Renk", "SiseTipi", "Stok", "UstNotalar" },
                values: new object[] { "Amberle parlayan ipeksi bir dokunuş.", "Seta Ambrata", "Sandal ağacı, Vanilya", "Kadın", 6900.0, "Amber, Gül", "Oryantal", "Extrait de Parfum", "#c8894a", 3, 7, "Safran" });

            migrationBuilder.UpdateData(
                table: "Parfumler",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "Aciklama", "Ad", "AltNotalar", "Cinsiyet", "Fiyat", "HacimMl", "KalpNotalar", "KokuAilesi", "Konsantrasyon", "MarkaId", "Renk", "SiseTipi", "Stok", "UstNotalar" },
                values: new object[] { "Buzul sularının berraklığı; ferah ve enerjik.", "Fjord", "Beyaz yosun, Sedir", "Erkek", 3300.0, 100, "Ardıç, Biberiye", "Ferah", "Eau de Toilette", 4, "#8fc0d6", 2, 30, "Deniz notaları, Limon" });

            migrationBuilder.UpdateData(
                table: "Parfumler",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "Aciklama", "Ad", "AltNotalar", "EskiFiyat", "Fiyat", "KalpNotalar", "KokuAilesi", "MarkaId", "Renk", "SiseTipi", "Stok", "UstNotalar", "Yeni" },
                values: new object[] { "Gece yarısı güneşi: parlak narenciye ve sıcak bir son.", "Midnattsol", "Amber, Misk", null, 4200.0, "Portakal çiçeği, Beyaz çay", "Ferah", 4, "#efd98a", 1, 15, "Greyfurt, Yuzu", true });

            migrationBuilder.UpdateData(
                table: "Parfumler",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "Aciklama", "Ad", "AltNotalar", "EskiFiyat", "Fiyat", "HacimMl", "KalpNotalar", "KokuAilesi", "Konsantrasyon", "Renk", "SiseTipi", "Stok", "UstNotalar", "Yeni" },
                values: new object[] { "Taze yağmış kar kadar temiz ve sade.", "Snö", "Beyaz misk", 3100.0, 2600.0, 50, "Zambak, Pamuk çiçeği", "Ferah", "Eau de Toilette", "#dfe7ec", 0, 20, "Aldehitler, Armut", false });

            migrationBuilder.UpdateData(
                table: "Parfumler",
                keyColumn: "Id",
                keyValue: 16,
                columns: new[] { "Aciklama", "Ad", "AltNotalar", "Cinsiyet", "EskiFiyat", "Fiyat", "HacimMl", "KalpNotalar", "KokuAilesi", "Renk", "Stok", "UstNotalar" },
                values: new object[] { "Ladin ormanında bir sabah yürüyüşü.", "Granskog", "Vetiver, Sedir", "Erkek", null, 4500.0, 100, "Ladin, Ardıç", "Odunsu", "#4b6b4f", 10, "Çam iğnesi, Bergamot" });

            migrationBuilder.UpdateData(
                table: "Parfumler",
                keyColumn: "Id",
                keyValue: 17,
                columns: new[] { "Aciklama", "Ad", "AltNotalar", "Cinsiyet", "Fiyat", "KalpNotalar", "KokuAilesi", "Konsantrasyon", "MarkaId", "Renk", "Stok", "UstNotalar", "Yeni" },
                values: new object[] { "Valensiya portakal bahçelerinden güneşli bir esinti.", "Sol de Valencia", "Misk", "Unisex", 3100.0, "Portakal çiçeği, Fesleğen", "Ferah", "Eau de Toilette", 5, "#f0a03a", 28, "Portakal, Limon", false });

            migrationBuilder.UpdateData(
                table: "Parfumler",
                keyColumn: "Id",
                keyValue: 18,
                columns: new[] { "Aciklama", "Ad", "AltNotalar", "Fiyat", "KalpNotalar", "KokuAilesi", "Konsantrasyon", "MarkaId", "Renk", "Stok", "UstNotalar" },
                values: new object[] { "Tütün yaprakları ve sıcak amberle asil bir koku.", "Ámbar Real", "Vanilya, Deri", 5400.0, "Amber, Tütün", "Oryantal", "Eau de Parfum", 5, "#b8642b", 9, "Tarçın, Mandalina" });

            migrationBuilder.UpdateData(
                table: "Parfumler",
                keyColumn: "Id",
                keyValue: 19,
                columns: new[] { "Aciklama", "Ad", "AltNotalar", "Cinsiyet", "EskiFiyat", "Fiyat", "KalpNotalar", "KokuAilesi", "Konsantrasyon", "Renk", "SiseTipi", "Stok", "UstNotalar" },
                values: new object[] { "Portakal çiçeğinin beyaz ve ışıltılı yüzü.", "Flor de Azahar", "Misk", "Kadın", 4900.0, 4300.0, "Portakal çiçeği, Yasemin", "Çiçeksi", "Eau de Parfum", "#f2d3b3", 1, 13, "Neroli" });

            migrationBuilder.UpdateData(
                table: "Parfumler",
                keyColumn: "Id",
                keyValue: 20,
                columns: new[] { "Aciklama", "Ad", "AltNotalar", "Fiyat", "HacimMl", "KalpNotalar", "KokuAilesi", "Konsantrasyon", "Renk", "SiseTipi", "Stok", "UstNotalar", "Yeni" },
                values: new object[] { "Endülüs gecelerinin tutkulu, koyu kırmızı hikâyesi.", "Noche Andaluza", "Ud, Amber", 6300.0, 50, "Gül, Safran", "Oryantal", "Extrait de Parfum", "#7b2d3a", 3, 4, "Kırmızı meyveler", true });

            migrationBuilder.UpdateData(
                table: "Parfumler",
                keyColumn: "Id",
                keyValue: 21,
                columns: new[] { "Aciklama", "Ad", "AltNotalar", "Cinsiyet", "Fiyat", "HacimMl", "KalpNotalar", "KokuAilesi", "MarkaId", "Renk", "SiseTipi", "Stok", "UstNotalar" },
                values: new object[] { "Japon çay seremonisinin sakinliği; dengeli ve temiz.", "Ocha", "Misk", "Unisex", 3600.0, 100, "Yasemin çayı, Mate", "Aromatik", 6, "#a3bb83", 0, 19, "Yeşil çay, Bergamot" });

            migrationBuilder.UpdateData(
                table: "Parfumler",
                keyColumn: "Id",
                keyValue: 22,
                columns: new[] { "Aciklama", "Ad", "AltNotalar", "Cinsiyet", "Fiyat", "HacimMl", "KalpNotalar", "KokuAilesi", "MarkaId", "Renk", "SiseTipi", "Stok", "UstNotalar", "Yeni" },
                values: new object[] { "Hinoki ağacından banyolar; sıcak, kuru ve meditatif.", "Hinoki", "Sedir, Misk", "Unisex", 4900.0, 100, "Hinoki ağacı, Tütsü", "Odunsu", 6, "#d2b285", 2, 8, "Yuzu", false });

            migrationBuilder.UpdateData(
                table: "Parfumler",
                keyColumn: "Id",
                keyValue: 23,
                columns: new[] { "Aciklama", "Ad", "AltNotalar", "EskiFiyat", "Fiyat", "HacimMl", "KalpNotalar", "KokuAilesi", "Konsantrasyon", "Renk", "SiseTipi", "Stok", "UstNotalar", "Yeni" },
                values: new object[] { "Kiraz çiçeklerine yağan bir ilkbahar yağmuru.", "Sakura Ame", "Beyaz misk", null, 2700.0, 50, "Şakayık, Manolya", "Çiçeksi", "Eau de Toilette", "#f1c3cf", 4, 24, "Kiraz çiçeği, Yağmur notaları", true });

            migrationBuilder.UpdateData(
                table: "Parfumler",
                keyColumn: "Id",
                keyValue: 24,
                columns: new[] { "Aciklama", "Ad", "AltNotalar", "Cinsiyet", "EskiFiyat", "Fiyat", "HacimMl", "KalpNotalar", "KokuAilesi", "Renk", "SiseTipi", "Stok", "UstNotalar", "Yeni" },
                values: new object[] { "Mürekkep siyahı ve aromatik otların minimalist uyumu.", "Kuro", "Ambroksan, Vetiver", "Erkek", 5000.0, 4400.0, 100, "Lavanta, Siyah çay", "Aromatik", "#2e2f33", 3, 12, "Shiso, Kakule", false });

            migrationBuilder.UpdateData(
                table: "Parfumler",
                keyColumn: "Id",
                keyValue: 25,
                columns: new[] { "Aciklama", "Ad", "AltNotalar", "EskiFiyat", "Fiyat", "KalpNotalar", "MarkaId", "Renk", "SiseTipi", "Stok", "UstNotalar" },
                values: new object[] { "Isparta'nın gül tarlalarından, sabah çiğiyle toplanmış gül.", "Isparta Gülü", "Misk, Paçuli", null, 3900.0, "Gül, Şakayık", 7, "#d45f77", 1, 21, "Pembe biber, Liçi" });

            migrationBuilder.UpdateData(
                table: "Parfumler",
                keyColumn: "Id",
                keyValue: 26,
                columns: new[] { "Aciklama", "Ad", "AltNotalar", "Fiyat", "HacimMl", "KalpNotalar", "KokuAilesi", "Renk", "SiseTipi", "Stok", "UstNotalar", "Yeni" },
                values: new object[] { "Peri bacalarının üzerinde gün doğumu: sıcak taş ve kayısı.", "Kapadokya", "Sedir, Amber", 4600.0, 100, "Tütsü, Kuru incir", "Odunsu", "#c98f62", 0, 10, "Kayısı, Safran", true });

            migrationBuilder.UpdateData(
                table: "Parfumler",
                keyColumn: "Id",
                keyValue: 27,
                columns: new[] { "Aciklama", "Ad", "AltNotalar", "EskiFiyat", "Fiyat", "HacimMl", "KalpNotalar", "Renk", "SiseTipi", "Stok", "UstNotalar" },
                values: new object[] { "Ege'de bir incir ağacının gölgesi.", "İncir Bahçesi", "Sedir", 3700.0, 3200.0, 100, "İncir, Hindistan cevizi sütü", "#8fa36a", 2, 26, "İncir yaprağı, Bergamot" });

            migrationBuilder.UpdateData(
                table: "Parfumler",
                keyColumn: "Id",
                keyValue: 28,
                columns: new[] { "Aciklama", "Ad", "AltNotalar", "Cinsiyet", "Fiyat", "HacimMl", "KalpNotalar", "Konsantrasyon", "Renk", "SiseTipi", "Stok", "UstNotalar", "Yeni" },
                values: new object[] { "İpek Yolu kervanlarından baharat ve deri.", "Safran Yolu", "Ud, Amber", "Erkek", 5800.0, 50, "Deri, Tütsü", "Extrait de Parfum", "#a3442f", 4, 6, "Safran, Kakule", false });

            migrationBuilder.UpdateData(
                table: "Parfumler",
                keyColumn: "Id",
                keyValue: 29,
                columns: new[] { "Aciklama", "Ad", "AltNotalar", "Cinsiyet", "Fiyat", "HacimMl", "KalpNotalar", "KokuAilesi", "Konsantrasyon", "Renk", "SiseTipi", "Stok", "UstNotalar" },
                values: new object[] { "Geleneksel bir mecliste yanan ud ve tütsü.", "Majlis", "Amber, Misk", "Unisex", 9800.0, 50, "Ud, Tütsü", "Oryantal", "Extrait de Parfum", "#4a2c2a", 3, 5, "Safran, Gül" });

            migrationBuilder.UpdateData(
                table: "Parfumler",
                keyColumn: "Id",
                keyValue: 30,
                columns: new[] { "Aciklama", "Ad", "AltNotalar", "Cinsiyet", "EskiFiyat", "Fiyat", "KalpNotalar", "KokuAilesi", "Renk", "SiseTipi", "Stok", "UstNotalar" },
                values: new object[] { "Çöl gecesinin sıcaklığı; hurma, tütün ve ud.", "Sahra Gecesi", "Vanilya, Amber", "Erkek", 8200.0, 7400.0, "Ud, Tütün", "Oryantal", "#8c5a2b", 0, 8, "Tarçın, Hurma" });

            migrationBuilder.UpdateData(
                table: "Parfumler",
                keyColumn: "Id",
                keyValue: 31,
                columns: new[] { "Aciklama", "Ad", "AltNotalar", "Cinsiyet", "Fiyat", "KalpNotalar", "KokuAilesi", "Renk", "SiseTipi", "Stok", "UstNotalar", "Yeni" },
                values: new object[] { "Taif gülüyle yumuşatılmış ışıltılı bir ud.", "Lulu Rose", "Misk, Sandal ağacı", "Kadın", 6800.0, "Taif gülü, Ud", "Çiçeksi", "#c97a8f", 1, 9, "Bergamot", true });

            migrationBuilder.UpdateData(
                table: "Parfumler",
                keyColumn: "Id",
                keyValue: 32,
                columns: new[] { "Aciklama", "Ad", "AltNotalar", "Fiyat", "HacimMl", "KalpNotalar", "KokuAilesi", "Konsantrasyon", "MarkaId", "Renk", "SiseTipi", "Stok", "UstNotalar" },
                values: new object[] { "Ud ve ambergrinin yoğun, uzun ömürlü buluşması.", "Anbar", "Ambergris, Labdanum", 8900.0, 50, "Ud, Sedir", "Odunsu", "Extrait de Parfum", 8, "#2b2420", 2, 3, "Karabiber" });

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
    }
}
