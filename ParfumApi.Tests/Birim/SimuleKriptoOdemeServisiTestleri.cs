using ParfumApi.Services.Odeme;

namespace ParfumApi.Tests.Birim;

public class SimuleKriptoOdemeServisiTestleri
{
    private readonly SimuleKriptoOdemeServisi _servis = new();

    [Theory]
    [InlineData("USDT", 4200, 100, 42)]
    [InlineData("BTC", 4200, 0.001, 4200000)]
    [InlineData("ETH", 4200, 0.028, 150000)]
    public void Tutar_sabit_kura_gore_hesaplanir(string para, decimal toplam, decimal beklenenTutar, decimal beklenenKur)
    {
        var fatura = _servis.FaturaOlustur(new Siparis { Toplam = toplam }, para);

        Assert.Equal(para, fatura.Para);
        Assert.Equal(beklenenTutar, fatura.Tutar);
        Assert.Equal(beklenenKur, fatura.Kur);
    }

    [Fact]
    public void Tutar_para_biriminin_ondalik_hanesine_yuvarlanir()
    {
        // 1000 / 42 = 23,8095... -> USDT 2 hane
        var fatura = _servis.FaturaOlustur(new Siparis { Toplam = 1000m }, "USDT");

        Assert.Equal(23.81m, fatura.Tutar);
    }

    [Fact]
    public void Adres_acikca_demo_oldugunu_belirtir_ve_her_faturada_farklidir()
    {
        var siparis = new Siparis { Toplam = 1000m };
        var ilk = _servis.FaturaOlustur(siparis, "BTC");
        var ikinci = _servis.FaturaOlustur(siparis, "BTC");

        Assert.StartsWith("DEMO-BTC-", ilk.Adres);
        Assert.NotEqual(ilk.Adres, ikinci.Adres);
    }

    [Fact]
    public void Fatura_15_dakika_gecerlidir()
    {
        var once = DateTime.UtcNow;
        var fatura = _servis.FaturaOlustur(new Siparis { Toplam = 1000m }, "ETH");

        var sure = fatura.SonTarih - once;
        Assert.InRange(sure, TimeSpan.FromMinutes(14.9), TimeSpan.FromMinutes(15.1));
    }

    [Fact]
    public void Servis_kendini_simulasyon_olarak_tanitir()
    {
        Assert.True(_servis.SimulasyonMu);
    }
}
