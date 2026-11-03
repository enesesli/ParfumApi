using Microsoft.EntityFrameworkCore;
using ParfumApi.Models;

namespace ParfumApi.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<Marka> Markalar => Set<Marka>();
    public DbSet<Parfum> Parfumler => Set<Parfum>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // SQLite decimal ile sıralama yapamıyor, fiyatı sayı olarak saklıyoruz
        modelBuilder.Entity<Parfum>()
            .Property(p => p.Fiyat)
            .HasConversion<double>();

        modelBuilder.Entity<Marka>().HasData(
            new Marka { Id = 1, Ad = "Chanel", Ulke = "Fransa" },
            new Marka { Id = 2, Ad = "Dior", Ulke = "Fransa" },
            new Marka { Id = 3, Ad = "Tom Ford", Ulke = "ABD" },
            new Marka { Id = 4, Ad = "Yves Saint Laurent", Ulke = "Fransa" }
        );

        modelBuilder.Entity<Parfum>().HasData(
            new Parfum { Id = 1, MarkaId = 1, Ad = "Bleu de Chanel", Aciklama = "Odunsu ve aromatik, günlük kullanıma uygun.", Fiyat = 5200, HacimMl = 100, Cinsiyet = "Erkek", Stok = 12 },
            new Parfum { Id = 2, MarkaId = 1, Ad = "Coco Mademoiselle", Aciklama = "Taze çiçeksi ve oryantal notalar.", Fiyat = 5600, HacimMl = 100, Cinsiyet = "Kadın", Stok = 8 },
            new Parfum { Id = 3, MarkaId = 2, Ad = "Sauvage", Aciklama = "Bergamot ve ambroksan ile ferah bir koku.", Fiyat = 4800, HacimMl = 100, Cinsiyet = "Erkek", Stok = 20 },
            new Parfum { Id = 4, MarkaId = 2, Ad = "J'adore", Aciklama = "Yasemin ve gül ağırlıklı çiçeksi koku.", Fiyat = 5400, HacimMl = 100, Cinsiyet = "Kadın", Stok = 6 },
            new Parfum { Id = 5, MarkaId = 3, Ad = "Oud Wood", Aciklama = "Ud, sandal ağacı ve baharat notaları.", Fiyat = 9800, HacimMl = 50, Cinsiyet = "Unisex", Stok = 4 },
            new Parfum { Id = 6, MarkaId = 3, Ad = "Black Orchid", Aciklama = "Koyu, yoğun ve gizemli bir akşam kokusu.", Fiyat = 7200, HacimMl = 100, Cinsiyet = "Unisex", Stok = 5 },
            new Parfum { Id = 7, MarkaId = 4, Ad = "Libre", Aciklama = "Lavanta ve portakal çiçeği ile modern bir koku.", Fiyat = 5000, HacimMl = 90, Cinsiyet = "Kadın", Stok = 10 },
            new Parfum { Id = 8, MarkaId = 4, Ad = "Y Eau de Parfum", Aciklama = "Elma, adaçayı ve odunsu notalar.", Fiyat = 4600, HacimMl = 100, Cinsiyet = "Erkek", Stok = 15 }
        );
    }
}