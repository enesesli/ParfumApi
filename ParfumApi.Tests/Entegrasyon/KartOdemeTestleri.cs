namespace ParfumApi.Tests.Entegrasyon;

public class KartOdemeTestleri(ApiFabrikasi fabrika) : ApiTestTabani(fabrika)
{
    [Fact]
    public async Task Basarili_odemede_siparis_odendi_olur_ve_stok_duser()
    {
        var urun = await UrunEkle(stok: 5);
        var siparis = await SiparisVer((urun, 2));

        var yanit = await KartlaOde(siparis);

        Assert.Equal(HttpStatusCode.OK, yanit.StatusCode);
        var odenmis = await yanit.Content.ReadFromJsonAsync<SiparisDto>();
        Assert.Equal(SiparisDurumlari.Odendi, odenmis!.Durum);
        Assert.Equal("Kart", odenmis.OdemeYontemi);
        Assert.Equal("4242", odenmis.KartSonDortHane);
        Assert.NotNull(odenmis.OdemeTarihi);
        Assert.Equal(3, await Stok(urun));
    }

    [Theory]
    [InlineData(ReddedilenKart)]
    [InlineData(LimitiYetersizKart)]
    public async Task Reddedilen_kartta_stok_dusmez_ve_siparis_odeme_bekler(string kartNo)
    {
        var urun = await UrunEkle(stok: 5);
        var siparis = await SiparisVer((urun, 1));

        var yanit = await KartlaOde(siparis, kartNo);

        Assert.Equal(HttpStatusCode.PaymentRequired, yanit.StatusCode);
        Assert.Equal(5, await Stok(urun));
        Assert.Equal(SiparisDurumlari.OdemeBekliyor, (await SiparisiGetir(siparis))!.Durum);
    }

    [Fact]
    public async Task Test_listesinde_olmayan_kart_numarasi_reddedilir()
    {
        var urun = await UrunEkle(stok: 5);
        var siparis = await SiparisVer((urun, 1));

        var yanit = await KartlaOde(siparis, "5555555555554444");

        Assert.Equal(HttpStatusCode.PaymentRequired, yanit.StatusCode);
        Assert.Equal(5, await Stok(urun));
    }

    [Fact]
    public async Task Son_kullanma_tarihi_gecmis_kart_reddedilir()
    {
        var urun = await UrunEkle(stok: 5);
        var siparis = await SiparisVer((urun, 1));

        var yanit = await KartlaOde(siparis, sonKullanma: "01/20");

        Assert.Equal(HttpStatusCode.BadRequest, yanit.StatusCode);
        Assert.Contains("son kullanma", await yanit.Content.ReadAsStringAsync());
    }

    [Fact]
    public async Task Ayni_siparis_iki_kez_odenemez_stok_bir_kez_duser()
    {
        var urun = await UrunEkle(stok: 5);
        var siparis = await SiparisVer((urun, 1));

        var ilk = await KartlaOde(siparis);
        var ikinci = await KartlaOde(siparis);

        Assert.Equal(HttpStatusCode.OK, ilk.StatusCode);
        Assert.Equal(HttpStatusCode.Conflict, ikinci.StatusCode);
        Assert.Equal(4, await Stok(urun));
    }

    [Fact]
    public async Task Kart_numarasinin_tamami_hicbir_yanitta_gorunmez()
    {
        var urun = await UrunEkle(stok: 5);
        var siparis = await SiparisVer((urun, 1));

        var odemeYaniti = await (await KartlaOde(siparis)).Content.ReadAsStringAsync();
        var sorguYaniti = await Istemci.GetStringAsync(
            $"/api/siparisler/{siparis.SiparisNo}?eposta={Uri.EscapeDataString(siparis.Eposta)}");

        Assert.DoesNotContain(BasariliKart, odemeYaniti);
        Assert.DoesNotContain(BasariliKart, sorguYaniti);
    }

    [Fact]
    public async Task Reddedilen_karttan_sonra_baska_kartla_odeme_yapilabilir()
    {
        var urun = await UrunEkle(stok: 5);
        var siparis = await SiparisVer((urun, 1));

        var reddedilen = await KartlaOde(siparis, ReddedilenKart);
        var basarili = await KartlaOde(siparis);

        Assert.Equal(HttpStatusCode.PaymentRequired, reddedilen.StatusCode);
        Assert.Equal(HttpStatusCode.OK, basarili.StatusCode);
        Assert.Equal(4, await Stok(urun));
    }

    [Fact]
    public async Task Yanlis_eposta_ile_odeme_yapilamaz()
    {
        var urun = await UrunEkle(stok: 5);
        var siparis = await SiparisVer((urun, 1));

        var yanit = await KartlaOde(siparis with { Eposta = "baskasi@ornek.com" });

        Assert.Equal(HttpStatusCode.NotFound, yanit.StatusCode);
        Assert.Equal(5, await Stok(urun));
    }
}
