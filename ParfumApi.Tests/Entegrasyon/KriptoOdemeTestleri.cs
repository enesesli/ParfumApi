namespace ParfumApi.Tests.Entegrasyon;

public class KriptoOdemeTestleri(ApiFabrikasi fabrika) : ApiTestTabani(fabrika)
{
    private Task<HttpResponseMessage> FaturaIste(SiparisDto siparis, string para) =>
        Istemci.PostAsJsonAsync($"/api/siparisler/{siparis.SiparisNo}/odeme/kripto",
            new KriptoOdemeIstegi { Eposta = siparis.Eposta, Para = para });

    private Task<HttpResponseMessage> OdemeyiSimuleEt(SiparisDto siparis) =>
        Istemci.PostAsJsonAsync($"/api/siparisler/{siparis.SiparisNo}/odeme/kripto/simule-et",
            new EpostaIstegi { Eposta = siparis.Eposta });

    [Fact]
    public async Task Fatura_olusturulur_ama_odeme_gelene_kadar_stok_dusmez()
    {
        var urun = await UrunEkle(stok: 5);
        var siparis = await SiparisVer((urun, 1));

        var yanit = await FaturaIste(siparis, "ETH");

        Assert.Equal(HttpStatusCode.OK, yanit.StatusCode);
        var faturali = await yanit.Content.ReadFromJsonAsync<SiparisDto>();
        var fatura = faturali!.Kripto!;
        Assert.Equal("ETH", fatura.Para);
        Assert.Equal(150_000m, fatura.Kur);
        Assert.Equal(Math.Round(siparis.Toplam / 150_000m, 6, MidpointRounding.AwayFromZero), fatura.Tutar);
        Assert.StartsWith("DEMO-ETH-", fatura.Adres);
        Assert.True(fatura.Simulasyon);
        Assert.Equal(SiparisDurumlari.OdemeBekliyor, faturali.Durum);
        Assert.Equal(5, await Stok(urun));
    }

    [Fact]
    public async Task Fatura_olmadan_odeme_simule_edilemez()
    {
        var urun = await UrunEkle(stok: 5);
        var siparis = await SiparisVer((urun, 1));

        var yanit = await OdemeyiSimuleEt(siparis);

        Assert.Equal(HttpStatusCode.BadRequest, yanit.StatusCode);
        Assert.Equal(5, await Stok(urun));
    }

    [Fact]
    public async Task Simule_edilen_odeme_siparisi_tamamlar_ve_stogu_dusurur()
    {
        var urun = await UrunEkle(stok: 5);
        var siparis = await SiparisVer((urun, 2));
        await FaturaIste(siparis, "USDT");

        var yanit = await OdemeyiSimuleEt(siparis);

        Assert.Equal(HttpStatusCode.OK, yanit.StatusCode);
        var odenmis = await yanit.Content.ReadFromJsonAsync<SiparisDto>();
        Assert.Equal(SiparisDurumlari.Odendi, odenmis!.Durum);
        Assert.Equal("Kripto", odenmis.OdemeYontemi);
        Assert.Equal(3, await Stok(urun));
    }

    [Fact]
    public async Task Kayitli_kur_sonradan_okununca_ayni_kalir()
    {
        var urun = await UrunEkle(stok: 5);
        var siparis = await SiparisVer((urun, 1));
        await FaturaIste(siparis, "BTC");

        var tekrarOkunan = await SiparisiGetir(siparis);

        Assert.Equal(4_200_000m, tekrarOkunan!.Kripto!.Kur);
    }

    [Fact]
    public async Task Desteklenmeyen_kripto_para_reddedilir()
    {
        var urun = await UrunEkle(stok: 5);
        var siparis = await SiparisVer((urun, 1));

        var yanit = await FaturaIste(siparis, "DOGE");

        Assert.Equal(HttpStatusCode.BadRequest, yanit.StatusCode);
    }
}
