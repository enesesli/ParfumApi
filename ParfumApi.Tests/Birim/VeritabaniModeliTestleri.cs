using Microsoft.EntityFrameworkCore;
using ParfumApi.Data;

namespace ParfumApi.Tests.Birim;

public class VeritabaniModeliTestleri
{
    // Modelde bir değişiklik yapılıp migration'ı oluşturulmayı unutulursa bu test kırılır
    [Fact]
    public void Model_ve_migrationlar_uyumlu()
    {
        var ayarlar = new DbContextOptionsBuilder<AppDbContext>()
            .UseSqlite("Data Source=:memory:")
            .Options;
        using var db = new AppDbContext(ayarlar);

        Assert.False(db.Database.HasPendingModelChanges(),
            "Modelde migration'ı oluşturulmamış bir değişiklik var. 'dotnet ef migrations add ...' çalıştır.");
    }
}
