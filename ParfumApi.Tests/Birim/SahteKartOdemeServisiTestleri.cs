using ParfumApi.Services.Odeme;

namespace ParfumApi.Tests.Birim;

// Birim testi: tek bir sınıfı, veritabanı ve HTTP olmadan, tek başına test eder.
public class SahteKartOdemeServisiTestleri
{
    private readonly SahteKartOdemeServisi _servis = new();
    private readonly Siparis _siparis = new() { SiparisNo = "ESTEST0001", Toplam = 1000m };

    private static KartBilgisi Kart(string numara) => new("Test Müşteri", numara, "12/35", "123");

    [Fact]
    public async Task Basarili_test_karti_onaylanir_ve_islem_referansi_doner()
    {
        var sonuc = await _servis.Ode(_siparis, Kart("4242424242424242"));

        Assert.True(sonuc.Basarili);
        Assert.Null(sonuc.HataMesaji);
        Assert.StartsWith("SAHTE-", sonuc.Referans);
    }

    [Theory]
    [InlineData("4000000000000002", "reddedildi")]
    [InlineData("4000000000009995", "limiti yetersiz")]
    public async Task Hatali_test_kartlari_nedeniyle_birlikte_reddedilir(string kartNo, string beklenenMesaj)
    {
        var sonuc = await _servis.Ode(_siparis, Kart(kartNo));

        Assert.False(sonuc.Basarili);
        Assert.Null(sonuc.Referans);
        Assert.Contains(beklenenMesaj, sonuc.HataMesaji);
    }

    [Fact]
    public async Task Test_listesinde_olmayan_kart_kabul_edilmez()
    {
        var sonuc = await _servis.Ode(_siparis, Kart("4111111111111111"));

        Assert.False(sonuc.Basarili);
        Assert.Contains("simülasyon", sonuc.HataMesaji);
    }

    [Fact]
    public async Task Kart_numarasindaki_bosluklar_sonucu_degistirmez()
    {
        var sonuc = await _servis.Ode(_siparis, Kart("4242 4242 4242 4242"));

        Assert.True(sonuc.Basarili);
    }
}
