using Microsoft.EntityFrameworkCore;
using ParfumApi.Models;

namespace ParfumApi.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<Marka> Markalar => Set<Marka>();
    public DbSet<Parfum> Parfumler => Set<Parfum>();
    public DbSet<Kullanici> Kullanicilar => Set<Kullanici>();
    public DbSet<Esans> Esanslar => Set<Esans>();
    public DbSet<EsansUyumu> EsansUyumlari => Set<EsansUyumu>();
    public DbSet<Siparis> Siparisler => Set<Siparis>();
    public DbSet<SiparisKalemi> SiparisKalemleri => Set<SiparisKalemi>();

    // Tüm modeller için geçerli kurallar: SQLite decimal'i metin olarak saklar ve
    // toplama/sıralama yapamaz; bu yüzden bütün decimal alanları sayı (double) olarak saklıyoruz
    protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
    {
        configurationBuilder.Properties<decimal>().HaveConversion<double>();
        configurationBuilder.Properties<decimal?>().HaveConversion<double?>();
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // SQLite decimal ile sıralama yapamıyor, fiyatı sayı olarak saklıyoruz
        modelBuilder.Entity<Parfum>()
            .Property(p => p.Fiyat)
            .HasConversion<double>();

        modelBuilder.Entity<Parfum>()
            .Property(p => p.EskiFiyat)
            .HasConversion<double?>();

        modelBuilder.Entity<Marka>().HasData(
            new Marka { Id = 1, Ad = "Chanel", Ulke = "Fransa" },
            new Marka { Id = 2, Ad = "Dior", Ulke = "Fransa" },
            new Marka { Id = 3, Ad = "Tom Ford", Ulke = "ABD" },
            new Marka { Id = 4, Ad = "Yves Saint Laurent", Ulke = "Fransa" },
            new Marka { Id = 5, Ad = "Giorgio Armani", Ulke = "İtalya" },
            new Marka { Id = 6, Ad = "Lancôme", Ulke = "Fransa" },
            new Marka { Id = 7, Ad = "Maison Francis Kurkdjian", Ulke = "Fransa" },
            new Marka { Id = 8, Ad = "Creed", Ulke = "Fransa" },
            new Marka { Id = 9, Ad = "Rabanne", Ulke = "İspanya" },
            new Marka { Id = 10, Ad = "Versace", Ulke = "İtalya" }
        );

        modelBuilder.Entity<Parfum>().HasData(
            new Parfum
            {
                Id = 1, MarkaId = 1, Ad = "Bleu de Chanel",
                KokuAilesi = "Odunsu", Konsantrasyon = "Eau de Parfum", Cinsiyet = "Erkek",
                HacimMl = 100, Fiyat = 7900m, EskiFiyat = null, Stok = 14,
                Renk = "#2f3d5c", SiseTipi = 0, Yeni = false,
                UstNotalar = "Greyfurt, Limon, Nane, Pembe biber",
                KalpNotalar = "Zencefil, Yasemin, Muskat",
                AltNotalar = "Tütsü, Sedir, Sandal ağacı, Vetiver",
                Aciklama = "Narenciyenin ferahlığıyla açılan, odunsu ve aromatik bir erkek klasiği."
            },
            new Parfum
            {
                Id = 2, MarkaId = 1, Ad = "Coco Mademoiselle",
                KokuAilesi = "Çiçeksi", Konsantrasyon = "Eau de Parfum", Cinsiyet = "Kadın",
                HacimMl = 100, Fiyat = 8400m, EskiFiyat = null, Stok = 10,
                Renk = "#e8b9a0", SiseTipi = 0, Yeni = false,
                UstNotalar = "Portakal, Bergamot, Greyfurt",
                KalpNotalar = "Gül, Yasemin, Liçi",
                AltNotalar = "Paçuli, Vetiver, Vanilya, Beyaz misk",
                Aciklama = "Taze narenciye ve gül ile başlayan, paçulinin derinleştirdiği modern bir şipr."
            },
            new Parfum
            {
                Id = 3, MarkaId = 1, Ad = "N°5",
                KokuAilesi = "Çiçeksi", Konsantrasyon = "Eau de Parfum", Cinsiyet = "Kadın",
                HacimMl = 100, Fiyat = 8900m, EskiFiyat = null, Stok = 7,
                Renk = "#f0d8a0", SiseTipi = 0, Yeni = false,
                UstNotalar = "Aldehitler, Neroli, Bergamot",
                KalpNotalar = "Gül, Yasemin, Süsen",
                AltNotalar = "Sandal ağacı, Vanilya, Vetiver",
                Aciklama = "Aldehitlerin ışıltısıyla tanınan, çiçek buketi biçiminde efsanevi bir koku."
            },
            new Parfum
            {
                Id = 4, MarkaId = 1, Ad = "Chance Eau Tendre",
                KokuAilesi = "Çiçeksi", Konsantrasyon = "Eau de Toilette", Cinsiyet = "Kadın",
                HacimMl = 100, Fiyat = 6900m, EskiFiyat = 7600m, Stok = 12,
                Renk = "#f3c6c9", SiseTipi = 1, Yeni = false,
                UstNotalar = "Ayva, Greyfurt",
                KalpNotalar = "Yasemin, Sümbül",
                AltNotalar = "Süsen, Sedir, Beyaz misk",
                Aciklama = "Meyveli ve çiçeksi; yumuşak, pastel tonlarda neşeli bir koku."
            },
            new Parfum
            {
                Id = 5, MarkaId = 2, Ad = "Sauvage",
                KokuAilesi = "Aromatik", Konsantrasyon = "Eau de Toilette", Cinsiyet = "Erkek",
                HacimMl = 100, Fiyat = 6800m, EskiFiyat = null, Stok = 22,
                Renk = "#9fb8d6", SiseTipi = 0, Yeni = false,
                UstNotalar = "Bergamot, Karabiber",
                KalpNotalar = "Sichuan biberi, Lavanta, Geranyum",
                AltNotalar = "Ambroksan, Sedir, Labdanum",
                Aciklama = "Kalabriya bergamotu ve ambroksanla ferah, baharatlı ve güçlü bir iz."
            },
            new Parfum
            {
                Id = 6, MarkaId = 2, Ad = "J'adore",
                KokuAilesi = "Çiçeksi", Konsantrasyon = "Eau de Parfum", Cinsiyet = "Kadın",
                HacimMl = 100, Fiyat = 8200m, EskiFiyat = null, Stok = 11,
                Renk = "#f2d27a", SiseTipi = 1, Yeni = false,
                UstNotalar = "Armut, Kavun, Bergamot",
                KalpNotalar = "Yasemin, Gül, Tuberoz",
                AltNotalar = "Misk, Vanilya, Sedir",
                Aciklama = "Altın tonlu, parlak ve zarif bir beyaz çiçek buketi."
            },
            new Parfum
            {
                Id = 7, MarkaId = 2, Ad = "Miss Dior",
                KokuAilesi = "Çiçeksi", Konsantrasyon = "Eau de Parfum", Cinsiyet = "Kadın",
                HacimMl = 100, Fiyat = 7700m, EskiFiyat = null, Stok = 9,
                Renk = "#f0b2c0", SiseTipi = 1, Yeni = true,
                UstNotalar = "Mandalina, Pembe biber",
                KalpNotalar = "Gül, Şakayık, Süsen",
                AltNotalar = "Misk, Vanilya",
                Aciklama = "Romantik bir gül ve şakayık buketi; pudralı ve aşık bir koku."
            },
            new Parfum
            {
                Id = 8, MarkaId = 2, Ad = "Fahrenheit",
                KokuAilesi = "Odunsu", Konsantrasyon = "Eau de Toilette", Cinsiyet = "Erkek",
                HacimMl = 100, Fiyat = 6300m, EskiFiyat = 7000m, Stok = 8,
                Renk = "#b0412c", SiseTipi = 3, Yeni = false,
                UstNotalar = "Muskat, Lavanta, Mandalina",
                KalpNotalar = "Menekşe yaprağı, Hanımeli, Sedir",
                AltNotalar = "Deri, Vetiver, Misk",
                Aciklama = "Menekşe yaprağı ve derinin cesur, benzersiz uyumu."
            },
            new Parfum
            {
                Id = 9, MarkaId = 2, Ad = "Hypnotic Poison",
                KokuAilesi = "Gurme", Konsantrasyon = "Eau de Toilette", Cinsiyet = "Kadın",
                HacimMl = 100, Fiyat = 6900m, EskiFiyat = null, Stok = 6,
                Renk = "#7a1f2b", SiseTipi = 3, Yeni = false,
                UstNotalar = "Hindistan cevizi, Erik, Kayısı",
                KalpNotalar = "Yasemin, Tuberoz, Gül",
                AltNotalar = "Badem, Vanilya, Sandal ağacı, Misk",
                Aciklama = "Bademli ve vanilyalı, baştan çıkarıcı bir akşam kokusu."
            },
            new Parfum
            {
                Id = 10, MarkaId = 3, Ad = "Oud Wood",
                KokuAilesi = "Odunsu", Konsantrasyon = "Eau de Parfum", Cinsiyet = "Unisex",
                HacimMl = 50, Fiyat = 14500m, EskiFiyat = null, Stok = 5,
                Renk = "#5a3a2a", SiseTipi = 0, Yeni = false,
                UstNotalar = "Ud, Gül ağacı, Kakule",
                KalpNotalar = "Sandal ağacı, Vetiver, Çin biberi",
                AltNotalar = "Tonka, Vanilya, Amber",
                Aciklama = "Ud'un dumanlı tarafını yumuşak odunlarla dengeleyen rafine bir koku."
            },
            new Parfum
            {
                Id = 11, MarkaId = 3, Ad = "Black Orchid",
                KokuAilesi = "Oryantal", Konsantrasyon = "Eau de Parfum", Cinsiyet = "Kadın",
                HacimMl = 100, Fiyat = 12900m, EskiFiyat = null, Stok = 4,
                Renk = "#2a1c2e", SiseTipi = 3, Yeni = false,
                UstNotalar = "Trüf, Bergamot, Siyah frenk üzümü",
                KalpNotalar = "Orkide, Baharatlar, Lotus",
                AltNotalar = "Paçuli, Kakao, Tütsü, Vanilya",
                Aciklama = "Koyu, gizemli ve lüks; siyah orkide ve trüfle yoğun bir koku."
            },
            new Parfum
            {
                Id = 12, MarkaId = 3, Ad = "Tobacco Vanille",
                KokuAilesi = "Gurme", Konsantrasyon = "Eau de Parfum", Cinsiyet = "Unisex",
                HacimMl = 50, Fiyat = 15500m, EskiFiyat = null, Stok = 6,
                Renk = "#8a5a2b", SiseTipi = 0, Yeni = false,
                UstNotalar = "Tütün yaprağı, Baharatlar",
                KalpNotalar = "Vanilya, Kakao, Tonka",
                AltNotalar = "Kuru meyve, Odunsu notalar",
                Aciklama = "Tütün yaprağı ve vanilyanın sıcak, kremsi ve zengin buluşması."
            },
            new Parfum
            {
                Id = 13, MarkaId = 3, Ad = "Lost Cherry",
                KokuAilesi = "Gurme", Konsantrasyon = "Eau de Parfum", Cinsiyet = "Unisex",
                HacimMl = 50, Fiyat = 17500m, EskiFiyat = null, Stok = 3,
                Renk = "#9e1b2c", SiseTipi = 0, Yeni = false,
                UstNotalar = "Vişne, Acı badem",
                KalpNotalar = "Vişne likörü, Türk gülü, Yasemin",
                AltNotalar = "Peru balsamı, Tonka, Sandal ağacı, Vetiver",
                Aciklama = "Olgun vişne ve bademle tatlı ama derin bir koku."
            },
            new Parfum
            {
                Id = 14, MarkaId = 3, Ad = "Ombré Leather",
                KokuAilesi = "Odunsu", Konsantrasyon = "Eau de Parfum", Cinsiyet = "Unisex",
                HacimMl = 100, Fiyat = 13900m, EskiFiyat = 15500m, Stok = 5,
                Renk = "#3a2e28", SiseTipi = 0, Yeni = false,
                UstNotalar = "Kakule",
                KalpNotalar = "Deri, Yasemin",
                AltNotalar = "Amber, Yosun, Paçuli",
                Aciklama = "Yumuşak deri ve kakuleyle çölü andıran sıcak bir koku."
            },
            new Parfum
            {
                Id = 15, MarkaId = 4, Ad = "Libre",
                KokuAilesi = "Çiçeksi", Konsantrasyon = "Eau de Parfum", Cinsiyet = "Kadın",
                HacimMl = 90, Fiyat = 7600m, EskiFiyat = null, Stok = 13,
                Renk = "#e9c46a", SiseTipi = 3, Yeni = true,
                UstNotalar = "Lavanta, Mandalina, Siyah frenk üzümü",
                KalpNotalar = "Portakal çiçeği, Yasemin",
                AltNotalar = "Vanilya, Misk, Sedir, Amber",
                Aciklama = "Lavanta ile portakal çiçeğinin cesur ve özgür buluşması."
            },
            new Parfum
            {
                Id = 16, MarkaId = 4, Ad = "Black Opium",
                KokuAilesi = "Gurme", Konsantrasyon = "Eau de Parfum", Cinsiyet = "Kadın",
                HacimMl = 90, Fiyat = 7400m, EskiFiyat = 8200m, Stok = 15,
                Renk = "#1d1a24", SiseTipi = 4, Yeni = false,
                UstNotalar = "Armut, Pembe biber, Portakal çiçeği",
                KalpNotalar = "Kahve, Yasemin",
                AltNotalar = "Vanilya, Paçuli, Sedir",
                Aciklama = "Kahve ve vanilyayla enerjik, bağımlılık yapan bir gece kokusu."
            },
            new Parfum
            {
                Id = 17, MarkaId = 4, Ad = "Y",
                KokuAilesi = "Aromatik", Konsantrasyon = "Eau de Parfum", Cinsiyet = "Erkek",
                HacimMl = 100, Fiyat = 7200m, EskiFiyat = null, Stok = 16,
                Renk = "#2e4a7a", SiseTipi = 2, Yeni = true,
                UstNotalar = "Elma, Zencefil, Bergamot",
                KalpNotalar = "Adaçayı, Ardıç, Geranyum",
                AltNotalar = "Tonka, Sedir, Vetiver, Tütsü",
                Aciklama = "Ferah elma ve adaçayının odunsu bir tabana oturduğu modern erkek kokusu."
            },
            new Parfum
            {
                Id = 18, MarkaId = 4, Ad = "La Nuit de L'Homme",
                KokuAilesi = "Aromatik", Konsantrasyon = "Eau de Toilette", Cinsiyet = "Erkek",
                HacimMl = 100, Fiyat = 6600m, EskiFiyat = null, Stok = 0,
                Renk = "#24263a", SiseTipi = 0, Yeni = false,
                UstNotalar = "Kakule, Bergamot",
                KalpNotalar = "Lavanta, Sedir",
                AltNotalar = "Vetiver, Kimyon",
                Aciklama = "Kakule ve lavantayla baştan çıkarıcı, zarif bir gece kokusu."
            },
            new Parfum
            {
                Id = 19, MarkaId = 5, Ad = "Acqua di Giò",
                KokuAilesi = "Ferah", Konsantrasyon = "Eau de Toilette", Cinsiyet = "Erkek",
                HacimMl = 100, Fiyat = 6200m, EskiFiyat = 6900m, Stok = 25,
                Renk = "#a8d0e0", SiseTipi = 2, Yeni = false,
                UstNotalar = "Limon, Bergamot, Neroli",
                KalpNotalar = "Deniz notaları, Yasemin, Biberiye",
                AltNotalar = "Beyaz misk, Sedir, Paçuli",
                Aciklama = "Akdeniz'in tuzlu ve güneşli ferahlığı; zamansız bir yaz kokusu."
            },
            new Parfum
            {
                Id = 20, MarkaId = 5, Ad = "Sì",
                KokuAilesi = "Gurme", Konsantrasyon = "Eau de Parfum", Cinsiyet = "Kadın",
                HacimMl = 100, Fiyat = 7300m, EskiFiyat = null, Stok = 12,
                Renk = "#e7b9a8", SiseTipi = 0, Yeni = false,
                UstNotalar = "Siyah frenk üzümü",
                KalpNotalar = "Gül, Frezya",
                AltNotalar = "Vanilya, Paçuli, Amber odunu",
                Aciklama = "Siyah frenk üzümü ve vanilyayla zarif ve güçlü bir kadın kokusu."
            },
            new Parfum
            {
                Id = 21, MarkaId = 5, Ad = "Armani Code",
                KokuAilesi = "Oryantal", Konsantrasyon = "Eau de Toilette", Cinsiyet = "Erkek",
                HacimMl = 75, Fiyat = 6400m, EskiFiyat = null, Stok = 9,
                Renk = "#2b2b2b", SiseTipi = 4, Yeni = false,
                UstNotalar = "Bergamot, Limon",
                KalpNotalar = "Zeytin çiçeği, Yıldız anason",
                AltNotalar = "Tonka, Deri, Tütün",
                Aciklama = "Zeytin çiçeği ve tonkayla baştan çıkarıcı, şık bir akşam kokusu."
            },
            new Parfum
            {
                Id = 22, MarkaId = 5, Ad = "My Way",
                KokuAilesi = "Çiçeksi", Konsantrasyon = "Eau de Parfum", Cinsiyet = "Kadın",
                HacimMl = 90, Fiyat = 7100m, EskiFiyat = null, Stok = 14,
                Renk = "#f1dfe6", SiseTipi = 1, Yeni = true,
                UstNotalar = "Bergamot, Portakal çiçeği",
                KalpNotalar = "Tuberoz, Yasemin",
                AltNotalar = "Vanilya, Beyaz misk, Sedir",
                Aciklama = "Beyaz çiçeklerle aydınlık ve pozitif bir koku."
            },
            new Parfum
            {
                Id = 23, MarkaId = 6, Ad = "La Vie Est Belle",
                KokuAilesi = "Gurme", Konsantrasyon = "Eau de Parfum", Cinsiyet = "Kadın",
                HacimMl = 100, Fiyat = 7800m, EskiFiyat = 8600m, Stok = 18,
                Renk = "#f2a6b6", SiseTipi = 1, Yeni = false,
                UstNotalar = "Siyah frenk üzümü, Armut",
                KalpNotalar = "Süsen, Yasemin, Portakal çiçeği",
                AltNotalar = "Pralin, Vanilya, Paçuli, Tonka",
                Aciklama = "Süsen ve pralinle tatlı, mutlu ve tanınır bir imza."
            },
            new Parfum
            {
                Id = 24, MarkaId = 6, Ad = "Idôle",
                KokuAilesi = "Çiçeksi", Konsantrasyon = "Eau de Parfum", Cinsiyet = "Kadın",
                HacimMl = 50, Fiyat = 5600m, EskiFiyat = null, Stok = 11,
                Renk = "#f0d3c8", SiseTipi = 2, Yeni = true,
                UstNotalar = "Armut, Bergamot, Pembe biber",
                KalpNotalar = "Gül, Yasemin",
                AltNotalar = "Beyaz misk, Vanilya, Sedir",
                Aciklama = "Temiz gül ve yasemin; hafif ve modern bir çiçek kokusu."
            },
            new Parfum
            {
                Id = 25, MarkaId = 6, Ad = "Trésor",
                KokuAilesi = "Çiçeksi", Konsantrasyon = "Eau de Parfum", Cinsiyet = "Kadın",
                HacimMl = 100, Fiyat = 6500m, EskiFiyat = 7200m, Stok = 7,
                Renk = "#f1c7b0", SiseTipi = 3, Yeni = false,
                UstNotalar = "Şeftali, Kayısı, Bergamot",
                KalpNotalar = "Gül, Süsen, Leylak",
                AltNotalar = "Amber, Vanilya, Misk, Sandal ağacı",
                Aciklama = "Şeftali ve gülle pudralı, romantik bir klasik."
            },
            new Parfum
            {
                Id = 26, MarkaId = 7, Ad = "Baccarat Rouge 540",
                KokuAilesi = "Oryantal", Konsantrasyon = "Eau de Parfum", Cinsiyet = "Unisex",
                HacimMl = 70, Fiyat = 18900m, EskiFiyat = null, Stok = 4,
                Renk = "#c0542f", SiseTipi = 3, Yeni = false,
                UstNotalar = "Safran, Yasemin",
                KalpNotalar = "Amber odunu, Ambergris",
                AltNotalar = "Köknar reçinesi, Sedir",
                Aciklama = "Safran ve amber odunuyla havada asılı kalan, ışıltılı bir imza."
            },
            new Parfum
            {
                Id = 27, MarkaId = 7, Ad = "Aqua Universalis",
                KokuAilesi = "Ferah", Konsantrasyon = "Eau de Toilette", Cinsiyet = "Unisex",
                HacimMl = 70, Fiyat = 11900m, EskiFiyat = null, Stok = 8,
                Renk = "#e8f1f2", SiseTipi = 0, Yeni = false,
                UstNotalar = "Bergamot, Limon",
                KalpNotalar = "Müge çiçeği",
                AltNotalar = "Beyaz misk, Odunsu notalar",
                Aciklama = "Tertemiz çamaşır ferahlığı; sade, ışıklı ve evrensel."
            },
            new Parfum
            {
                Id = 28, MarkaId = 7, Ad = "Oud Satin Mood",
                KokuAilesi = "Oryantal", Konsantrasyon = "Eau de Parfum", Cinsiyet = "Unisex",
                HacimMl = 70, Fiyat = 19900m, EskiFiyat = null, Stok = 3,
                Renk = "#6b2a3a", SiseTipi = 0, Yeni = true,
                UstNotalar = "Menekşe",
                KalpNotalar = "Gül, Ud",
                AltNotalar = "Vanilya, Benzoin",
                Aciklama = "Saten gibi pürüzsüz bir gül ve ud; kadifemsi ve zengin."
            },
            new Parfum
            {
                Id = 29, MarkaId = 8, Ad = "Aventus",
                KokuAilesi = "Odunsu", Konsantrasyon = "Eau de Parfum", Cinsiyet = "Erkek",
                HacimMl = 100, Fiyat = 22500m, EskiFiyat = null, Stok = 6,
                Renk = "#e9e4d6", SiseTipi = 0, Yeni = false,
                UstNotalar = "Ananas, Bergamot, Siyah frenk üzümü, Elma",
                KalpNotalar = "Huş katranı, Paçuli, Yasemin",
                AltNotalar = "Misk, Meşe yosunu, Ambergris, Vanilya",
                Aciklama = "Ananas ve huş dumanıyla güçlü, meyveli ve tanınır bir erkek kokusu."
            },
            new Parfum
            {
                Id = 30, MarkaId = 8, Ad = "Silver Mountain Water",
                KokuAilesi = "Ferah", Konsantrasyon = "Eau de Parfum", Cinsiyet = "Unisex",
                HacimMl = 100, Fiyat = 19500m, EskiFiyat = 21500m, Stok = 5,
                Renk = "#c9dde6", SiseTipi = 2, Yeni = false,
                UstNotalar = "Bergamot, Mandalina",
                KalpNotalar = "Yeşil çay, Siyah frenk üzümü",
                AltNotalar = "Misk, Sandal ağacı",
                Aciklama = "Dağ derelerinin serinliği; yeşil çay ve narenciyeyle berrak bir koku."
            },
            new Parfum
            {
                Id = 31, MarkaId = 8, Ad = "Green Irish Tweed",
                KokuAilesi = "Aromatik", Konsantrasyon = "Eau de Parfum", Cinsiyet = "Erkek",
                HacimMl = 100, Fiyat = 19500m, EskiFiyat = null, Stok = 4,
                Renk = "#7c9a6a", SiseTipi = 2, Yeni = false,
                UstNotalar = "Limon otu, Nane",
                KalpNotalar = "Süsen, Menekşe yaprağı",
                AltNotalar = "Ambergris, Sandal ağacı",
                Aciklama = "Yeşil çayırlar ve menekşe yaprağıyla zarif bir centilmen kokusu."
            },
            new Parfum
            {
                Id = 32, MarkaId = 9, Ad = "1 Million",
                KokuAilesi = "Oryantal", Konsantrasyon = "Eau de Toilette", Cinsiyet = "Erkek",
                HacimMl = 100, Fiyat = 5900m, EskiFiyat = null, Stok = 20,
                Renk = "#d4a43a", SiseTipi = 4, Yeni = false,
                UstNotalar = "Greyfurt, Nane, Kan portakalı",
                KalpNotalar = "Tarçın, Gül, Baharatlar",
                AltNotalar = "Deri, Amber, Paçuli",
                Aciklama = "Tarçın ve deriyle baharatlı, tatlı ve göz alıcı bir koku."
            },
            new Parfum
            {
                Id = 33, MarkaId = 9, Ad = "Invictus",
                KokuAilesi = "Ferah", Konsantrasyon = "Eau de Toilette", Cinsiyet = "Erkek",
                HacimMl = 100, Fiyat = 5600m, EskiFiyat = 6300m, Stok = 19,
                Renk = "#c9d4dc", SiseTipi = 2, Yeni = false,
                UstNotalar = "Greyfurt, Deniz notaları",
                KalpNotalar = "Defne yaprağı, Yasemin",
                AltNotalar = "Guaiac ağacı, Meşe yosunu, Paçuli, Ambergris",
                Aciklama = "Deniz notaları ve greyfurtla sportif, ferah bir zafer kokusu."
            },
            new Parfum
            {
                Id = 34, MarkaId = 9, Ad = "Lady Million",
                KokuAilesi = "Çiçeksi", Konsantrasyon = "Eau de Parfum", Cinsiyet = "Kadın",
                HacimMl = 80, Fiyat = 5800m, EskiFiyat = null, Stok = 13,
                Renk = "#f0c060", SiseTipi = 3, Yeni = false,
                UstNotalar = "Ahududu, Neroli, Limon",
                KalpNotalar = "Yasemin, Portakal çiçeği, Gardenya",
                AltNotalar = "Bal, Paçuli",
                Aciklama = "Ahududu ve balla ışıltılı, iddialı bir çiçek kokusu."
            },
            new Parfum
            {
                Id = 35, MarkaId = 10, Ad = "Eros",
                KokuAilesi = "Aromatik", Konsantrasyon = "Eau de Toilette", Cinsiyet = "Erkek",
                HacimMl = 100, Fiyat = 5700m, EskiFiyat = null, Stok = 21,
                Renk = "#4fb3b0", SiseTipi = 4, Yeni = false,
                UstNotalar = "Nane, Yeşil elma, Limon",
                KalpNotalar = "Tonka, Geranyum, Ambroksan",
                AltNotalar = "Vanilya, Vetiver, Sedir, Meşe yosunu",
                Aciklama = "Nane ve vanilyayla ferah ama tatlı, enerjik bir koku."
            },
            new Parfum
            {
                Id = 36, MarkaId = 10, Ad = "Bright Crystal",
                KokuAilesi = "Çiçeksi", Konsantrasyon = "Eau de Toilette", Cinsiyet = "Kadın",
                HacimMl = 90, Fiyat = 5300m, EskiFiyat = 5900m, Stok = 17,
                Renk = "#f4c3cf", SiseTipi = 3, Yeni = false,
                UstNotalar = "Nar, Yuzu",
                KalpNotalar = "Şakayık, Manolya, Lotus",
                AltNotalar = "Misk, Maun, Amber",
                Aciklama = "Nar ve şakayıkla taze, ışıltılı ve hafif bir çiçek kokusu."
            },
            new Parfum
            {
                Id = 37, MarkaId = 10, Ad = "Dylan Blue",
                KokuAilesi = "Ferah", Konsantrasyon = "Eau de Toilette", Cinsiyet = "Erkek",
                HacimMl = 100, Fiyat = 5400m, EskiFiyat = null, Stok = 15,
                Renk = "#1f3f7a", SiseTipi = 0, Yeni = true,
                UstNotalar = "Bergamot, Greyfurt, İncir yaprağı",
                KalpNotalar = "Menekşe yaprağı, Ambroksan, Karabiber",
                AltNotalar = "Misk, Tonka, Safran, Tütsü",
                Aciklama = "Akdeniz esintili ferah narenciye ve odunsu-amberli bir taban."
            }
        );

        // ----- Koku atölyesi -----

        modelBuilder.Entity<Esans>()
            .Property(e => e.EkFiyat)
            .HasConversion<double>();

        // İki sütunlu (birleşik) birincil anahtar: aynı çift iki kez eklenemez
        modelBuilder.Entity<EsansUyumu>()
            .HasKey(u => new { u.EsansAId, u.EsansBId });

        // Her iki sütun da Esans tablosuna bağlı (aynı tabloya iki yabancı anahtar)
        modelBuilder.Entity<EsansUyumu>()
            .HasOne<Esans>()
            .WithMany()
            .HasForeignKey(u => u.EsansAId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<EsansUyumu>()
            .HasOne<Esans>()
            .WithMany()
            .HasForeignKey(u => u.EsansBId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<Esans>().HasData(
            new Esans { Id = 1, Ad = "Bergamot", Katman = "Üst", Aile = "Narenciye", EkFiyat = 150m, Renk = "#e9d36b", Aciklama = "Parlak ve hafif acımsı narenciye; neredeyse her şeyle uyumlu." },
            new Esans { Id = 2, Ad = "Limon", Katman = "Üst", Aile = "Narenciye", EkFiyat = 100m, Renk = "#f2e24a", Aciklama = "Keskin, temiz ve enerjik." },
            new Esans { Id = 3, Ad = "Greyfurt", Katman = "Üst", Aile = "Narenciye", EkFiyat = 120m, Renk = "#f29a8a", Aciklama = "Sulu ve hafif acı; modern ve ferah." },
            new Esans { Id = 4, Ad = "Mandalina", Katman = "Üst", Aile = "Narenciye", EkFiyat = 120m, Renk = "#f4a340", Aciklama = "Tatlı ve yumuşak bir narenciye." },
            new Esans { Id = 5, Ad = "Armut", Katman = "Üst", Aile = "Meyveli", EkFiyat = 140m, Renk = "#d8d97a", Aciklama = "Sulu, şeffaf ve neşeli." },
            new Esans { Id = 6, Ad = "Ahududu", Katman = "Üst", Aile = "Meyveli", EkFiyat = 160m, Renk = "#c8455d", Aciklama = "Ekşimsi tatlı kırmızı meyve." },
            new Esans { Id = 7, Ad = "Nane", Katman = "Üst", Aile = "Yeşil", EkFiyat = 90m, Renk = "#7fc39a", Aciklama = "Serin ve canlandırıcı." },
            new Esans { Id = 8, Ad = "Deniz notası", Katman = "Üst", Aile = "Yeşil", EkFiyat = 130m, Renk = "#7fb7cf", Aciklama = "Tuzlu, havadar bir deniz esintisi." },
            new Esans { Id = 9, Ad = "Pembe biber", Katman = "Üst", Aile = "Baharatlı", EkFiyat = 200m, Renk = "#e07f8a", Aciklama = "Hafif, ışıltılı bir baharat." },
            new Esans { Id = 10, Ad = "Kakule", Katman = "Üst", Aile = "Baharatlı", EkFiyat = 220m, Renk = "#b7b56a", Aciklama = "Serin ve aromatik bir baharat." },
            new Esans { Id = 11, Ad = "Gül", Katman = "Kalp", Aile = "Çiçeksi", EkFiyat = 400m, Renk = "#d9667e", Aciklama = "Çiçeklerin kraliçesi; romantik ve zengin." },
            new Esans { Id = 12, Ad = "Yasemin", Katman = "Kalp", Aile = "Çiçeksi", EkFiyat = 380m, Renk = "#f3ead0", Aciklama = "Beyaz, baş döndürücü ve kremsi." },
            new Esans { Id = 13, Ad = "Süsen", Katman = "Kalp", Aile = "Çiçeksi", EkFiyat = 450m, Renk = "#b9a7d6", Aciklama = "Pudralı, zarif ve hafif topraksı." },
            new Esans { Id = 14, Ad = "Portakal çiçeği", Katman = "Kalp", Aile = "Çiçeksi", EkFiyat = 300m, Renk = "#f5e3c0", Aciklama = "Ballı, temiz ve ışıltılı." },
            new Esans { Id = 15, Ad = "Şakayık", Katman = "Kalp", Aile = "Çiçeksi", EkFiyat = 250m, Renk = "#efb3c3", Aciklama = "Taze ve pembe bir çiçek." },
            new Esans { Id = 16, Ad = "Lavanta", Katman = "Kalp", Aile = "Aromatik", EkFiyat = 150m, Renk = "#9b8ac4", Aciklama = "Sakinleştirici; temiz ve otsu." },
            new Esans { Id = 17, Ad = "Adaçayı", Katman = "Kalp", Aile = "Aromatik", EkFiyat = 140m, Renk = "#8fa58a", Aciklama = "Otsu, hafif kafurlu ve ferah." },
            new Esans { Id = 18, Ad = "Yeşil çay", Katman = "Kalp", Aile = "Yeşil", EkFiyat = 200m, Renk = "#a3bb83", Aciklama = "Sakin, hafif ve dengeli." },
            new Esans { Id = 19, Ad = "Tarçın", Katman = "Kalp", Aile = "Baharatlı", EkFiyat = 180m, Renk = "#a5622f", Aciklama = "Sıcak, tatlımsı bir baharat." },
            new Esans { Id = 20, Ad = "Safran", Katman = "Kalp", Aile = "Baharatlı", EkFiyat = 600m, Renk = "#d08a2e", Aciklama = "Deri tonlu, değerli ve sıcak." },
            new Esans { Id = 21, Ad = "Vanilya", Katman = "Alt", Aile = "Gurme", EkFiyat = 300m, Renk = "#e8cf9e", Aciklama = "Kremsi, tatlı ve sarmalayıcı." },
            new Esans { Id = 22, Ad = "Tonka", Katman = "Alt", Aile = "Gurme", EkFiyat = 260m, Renk = "#b98a5a", Aciklama = "Badem ve karamel arası sıcak bir tatlılık." },
            new Esans { Id = 23, Ad = "Kakao", Katman = "Alt", Aile = "Gurme", EkFiyat = 220m, Renk = "#5c3a28", Aciklama = "Koyu ve hafif acı bir tatlılık." },
            new Esans { Id = 24, Ad = "Sedir", Katman = "Alt", Aile = "Odunsu", EkFiyat = 200m, Renk = "#a07a54", Aciklama = "Kuru, temiz ve düz bir odun." },
            new Esans { Id = 25, Ad = "Sandal ağacı", Katman = "Alt", Aile = "Odunsu", EkFiyat = 450m, Renk = "#d8b07a", Aciklama = "Kremsi, yumuşak ve sütlü bir odun." },
            new Esans { Id = 26, Ad = "Vetiver", Katman = "Alt", Aile = "Odunsu", EkFiyat = 250m, Renk = "#7d8a64", Aciklama = "Topraksı, dumanlı ve yeşil." },
            new Esans { Id = 27, Ad = "Ud", Katman = "Alt", Aile = "Reçineli", EkFiyat = 900m, Renk = "#4a2c2a", Aciklama = "Yoğun, hayvansı ve çok kalıcı; dikkatli kullanılmalı." },
            new Esans { Id = 28, Ad = "Amber", Katman = "Alt", Aile = "Reçineli", EkFiyat = 350m, Renk = "#c8894a", Aciklama = "Sıcak, reçineli ve tatlımsı." },
            new Esans { Id = 29, Ad = "Tütsü", Katman = "Alt", Aile = "Reçineli", EkFiyat = 300m, Renk = "#8a8170", Aciklama = "Dumanlı, mistik ve kuru." },
            new Esans { Id = 30, Ad = "Beyaz misk", Katman = "Alt", Aile = "Misk", EkFiyat = 200m, Renk = "#f1ece6", Aciklama = "Temiz, ten gibi; diğer notaları birbirine bağlar." }
        );

        modelBuilder.Entity<EsansUyumu>().HasData(
            new EsansUyumu { EsansAId = 11, EsansBId = 27, Puan = 2, Aciklama = "Ortadoğu parfümcülüğünün klasik ikilisi." },
            new EsansUyumu { EsansAId = 21, EsansBId = 22, Puan = 2, Aciklama = "İkisi de kremsi ve sıcak; birbirini derinleştirir." },
            new EsansUyumu { EsansAId = 16, EsansBId = 22, Puan = 2, Aciklama = "Klasik 'fougère' yapısının temeli." },
            new EsansUyumu { EsansAId = 12, EsansBId = 25, Puan = 2, Aciklama = "Kremsi bir çiçek ile kremsi bir odun; yumuşak bir bütün." },
            new EsansUyumu { EsansAId = 7, EsansBId = 21, Puan = -2, Aciklama = "Diş macunu etkisi yaratabilir." },
            new EsansUyumu { EsansAId = 2, EsansBId = 27, Puan = -2, Aciklama = "Keskin limon, udun ağırlığıyla çatışır." },
            new EsansUyumu { EsansAId = 11, EsansBId = 20, Puan = 2, Aciklama = "Safranın deri tonu gülü zenginleştirir." },
            new EsansUyumu { EsansAId = 3, EsansBId = 26, Puan = 2, Aciklama = "Ferah ve topraksı; modern bir uyum." },
            new EsansUyumu { EsansAId = 8, EsansBId = 23, Puan = -2, Aciklama = "Deniz ferahlığı ile kakao birbirini bastırır." },
            new EsansUyumu { EsansAId = 6, EsansBId = 11, Puan = 2, Aciklama = "Meyveli bir gül; canlı ve genç." },
            new EsansUyumu { EsansAId = 4, EsansBId = 21, Puan = 1, Aciklama = "Portakallı dondurma gibi; oyunbaz bir gurme." },
            new EsansUyumu { EsansAId = 9, EsansBId = 11, Puan = 2, Aciklama = "Gülü canlandıran klasik baharat dokunuşu." },
            new EsansUyumu { EsansAId = 7, EsansBId = 27, Puan = -2, Aciklama = "Serin nane ile yoğun ud birbirini boğar." },
            new EsansUyumu { EsansAId = 10, EsansBId = 29, Puan = 2, Aciklama = "Serin baharat ve duman; meditatif bir uyum." }
        );

        // ----- Siparişler -----

        modelBuilder.Entity<Siparis>()
            .HasIndex(s => s.SiparisNo)
            .IsUnique();

        // Sipariş silinirse kalemleri de silinir (bire-çok, cascade)
        modelBuilder.Entity<Siparis>()
            .HasMany(s => s.Kalemler)
            .WithOne()
            .HasForeignKey(k => k.SiparisId)
            .OnDelete(DeleteBehavior.Cascade);

        // Aynı kullanıcı adıyla iki kayıt olamaz
        modelBuilder.Entity<Kullanici>()
            .HasIndex(k => k.KullaniciAdi)
            .IsUnique();
    }
}
