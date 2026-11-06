using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Data.Sqlite;

namespace ParfumApi.Tests.TestAltyapisi;

// API'yi test için bellekte çalıştırır. Her test sınıfı kendi geçici SQLite veritabanını alır:
// gerçek migration'lar uygulanır, gerçek SQL çalışır, ama senin parfum.db dosyana dokunulmaz.
public class ApiFabrikasi : WebApplicationFactory<Program>
{
    public const string AdminKullaniciAdi = "test-admin";
    public const string AdminSifre = "Test-Sifresi-123";

    private readonly string _veritabaniYolu =
        Path.Combine(Path.GetTempPath(), $"parfum-test-{Guid.NewGuid():N}.db");

    public ApiFabrikasi()
    {
        // Program.cs bu ayarları uygulama kurulurken okuduğu için ortam değişkeni olarak veriyoruz.
        // Ortam değişkenleri appsettings.json ve User Secrets'tan önce gelir.
        Environment.SetEnvironmentVariable("ConnectionStrings__Default", $"Data Source={_veritabaniYolu}");
        Environment.SetEnvironmentVariable("Jwt__Key", "testlere-ozel-anahtar-en-az-32-bayt-olmali-0123456789");
        Environment.SetEnvironmentVariable("Admin__KullaniciAdi", AdminKullaniciAdi);
        Environment.SetEnvironmentVariable("Admin__Sifre", AdminSifre);
    }

    protected override void ConfigureWebHost(IWebHostBuilder builder)
    {
        // "Development" değil: böylece senin User Secrets ayarların testlere karışmaz
        builder.UseEnvironment("Testing");
    }

    protected override void Dispose(bool disposing)
    {
        base.Dispose(disposing);

        // Açık bağlantıları kapatıp geçici veritabanını sil
        SqliteConnection.ClearAllPools();
        foreach (var ek in new[] { "", "-shm", "-wal" })
        {
            try { File.Delete(_veritabaniYolu + ek); } catch (IOException) { }
        }
    }
}
